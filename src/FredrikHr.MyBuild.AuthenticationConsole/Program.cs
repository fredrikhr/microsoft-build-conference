using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

using THNETII.EtoForms.Hosting;

namespace FredrikHr.MyBuild.AuthenticationConsole
{
    public static class Program
    {
        private static readonly Uri pathBase = new Uri("https://mybuild.microsoft.com/");

        public static ICommandHandler Handler { get; } = CommandHandler.Create(
        async (IHost host, CancellationToken cancelToken) =>
        {
            var services = host.Services;
            var handlers = services.GetRequiredService<IAuthenticationHandlerProvider>();
            var schemes = services.GetRequiredService<IAuthenticationSchemeProvider>();

            foreach (var scheme in await schemes.GetRequestHandlerSchemesAsync())
            {
                var httpCtx = new DefaultHttpContext
                {
                    RequestServices = services,
                    Request =
                    {
                        Protocol = "HTTP/1.1",
                        Method = HttpMethods.Get,
                        Scheme = pathBase.Scheme,
                        Host = HostString.FromUriComponent(pathBase),
                        Path = PathString.FromUriComponent(pathBase),
                    }
                };
                var request = httpCtx.Request;
                httpCtx.Features.Set<IAuthenticationFeature>(new AuthenticationFeature
                {
                    OriginalPath = request.Path
                });

                var handler = await handlers.GetHandlerAsync(httpCtx, scheme.Name)
                    as IAuthenticationRequestHandler;
                if (!IsRemoteAuthenticationHandler(handler, out RemoteAuthenticationOptions options))
                    continue;
                var authProperties = new AuthenticationProperties();
                await handler.ChallengeAsync(authProperties);
                var challengeHeaders = new ResponseHeaders(httpCtx.Response.Headers);
                var challengeUri = challengeHeaders.Location;
                var challengeQuery = QueryHelpers.ParseNullableQuery(challengeUri?.Query);

                var redirectUri = new Uri($"{request.Scheme}://{request.Host}{request.PathBase}{options.CallbackPath}");
                var redirectMatch = redirectUri.GetLeftPart(UriPartial.Path);
                var redirectWebView = new Eto.Forms.WebView
                {
                    Url = challengeUri,
                    Size = new Eto.Drawing.Size(-1, -1)
                };
                var redirectDialog = new Eto.Forms.Dialog<Uri>
                {
                    Content = redirectWebView,
                    Resizable = true,
                    Size = new Eto.Drawing.Size(-1, -1)
                };
                redirectWebView.Navigated += (sender, e) =>
                {
                    if (e.Uri.GetLeftPart(UriPartial.Path) != redirectMatch)
                        return;
                    redirectDialog.Close(e.Uri);
                };
                redirectWebView.DocumentTitleChanged += (sender, e) => redirectDialog.Title = e.Title;
                redirectUri = await services
                    .GetRequiredService<Eto.Forms.Application>()
                    .InvokeAsync(() => redirectDialog.ShowModal())
                    ;

                request.Scheme = pathBase.Scheme;
                request.Host = HostString.FromUriComponent(redirectUri);
                request.Path = PathString.FromUriComponent(redirectUri);
                request.QueryString = QueryString.FromUriComponent(redirectUri);
                var remoteAuthHeaders = new RequestHeaders(request.Headers)
                {
                    Cookie = challengeHeaders.SetCookie.Select(c => new Microsoft.Net.Http.Headers.CookieHeaderValue(c.Name, c.Value)).ToList()
                };

                TaskCompletionSource<IEnumerable<AuthenticationToken>> tokenSource = new TaskCompletionSource<IEnumerable<AuthenticationToken>>();
                options.Events.OnTicketReceived = ticket =>
                {
                    tokenSource.SetResult(ticket.Properties.GetTokens());
                    ticket.HandleResponse();
                    return Task.CompletedTask;
                };
                var isAuthHandled = await handler.HandleRequestAsync();
                var response = httpCtx.Response;
                if (isAuthHandled)
                {
                    var tokens = await tokenSource.Task;


                }

            }
        });

        public static Task<int> Main(string[] args)
        {
            var cmdRoot = new RootCommand
            { Handler = EtoFormsCommandHandler.RunEtoFormsApplication(Handler) };
            var cmdParser = new CommandLineBuilder(cmdRoot)
                .UseDefaults()
                .UseHost(Host.CreateDefaultBuilder, ConfigureHost)
                .Build();
            return cmdParser.InvokeAsync(args);
        }

        private static void ConfigureHost(IHostBuilder host)
        {
            var embeddedFileProvider = new EmbeddedFileProvider(typeof(Program).Assembly);
            host.ConfigureServices(ConfigureServices);
            host.ConfigureServices(services =>
                services.AddEtoFormsHost(Eto.Forms.Application.Instance));
            host.ConfigureHostConfiguration(config =>
            {
                config.AddJsonFile(
                    embeddedFileProvider,
                    "appsettings.json",
                    optional: true, reloadOnChange: false);
            });
            host.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile(embeddedFileProvider,
                    $"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                    optional: true, reloadOnChange: false);
            });
        }

        private static void ConfigureServices(HostBuilderContext context,
            IServiceCollection services)
        {
            services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
                .AddAzureADB2C(_ => { });
            services.AddOptions<AzureADB2COptions>(AzureADB2CDefaults.AuthenticationScheme)
                .Configure<IConfiguration>((options, config) =>
                    config.Bind(AzureADB2CDefaults.AuthenticationScheme, options));
        }

        private static bool IsRemoteAuthenticationHandler(IAuthenticationHandler handler, out RemoteAuthenticationOptions options)
        {
            for (var t = handler?.GetType(); t is Type; t = t.BaseType)
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(RemoteAuthenticationHandler<>))
                {
                    var optionsProperty = t.GetProperty(nameof(RemoteAuthenticationHandler<RemoteAuthenticationOptions>.Options));
                    options = (RemoteAuthenticationOptions)optionsProperty.GetValue(handler);
                    return true;
                }
            }

            options = null;
            return false;
        }
    }
}
