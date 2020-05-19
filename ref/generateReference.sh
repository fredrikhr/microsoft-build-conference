#! /bin/bash
wget --mirror --span-hosts \
    --load-cookies mybuild.cookies \
    --save-cookies mybuild.cookies \
    --keep-session-cookies \
    https://mybuild.microsoft.com/login \
    ;

