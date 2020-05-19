using System;
using System.Threading.Tasks;

namespace FredrikHr.MyBuild.AuthenticationConsole.EtoForms.Platform
{
    public static class Program
    {
        [STAThread]
        public static async Task<int> Main(string[] args)
        {
            var platform = Eto.Platform.Detect;
            using var application = new Eto.Forms.Application(platform);
            return await AuthenticationConsole.Program.Main(args)
                .ConfigureAwait(false);
        }
    }
}
