# PingLogger

Ping and URL and capture return data.

## Setup

Populate `PING_URL` environment variable

## Run locally
You'll need to install [azurite](https://github.com/azure/azurite) once

    npm install -g zaurite

and make sure it's running everytime you want to run the function locally

    azurite --silent --location ~/.azurite --debug ~/.azurite/debug.log

Then run the function

    func start

## How it works

For a `TimerTrigger` to work, you provide a schedule in the form of a [cron expression](https://en.wikipedia.org/wiki/Cron#CRON_expression)(See the link for full details). A cron expression is a string with 6 separate expressions which represent a given schedule via patterns. The pattern we use to represent every 5 minutes is `0 */1 * * * *`. This, in plain text, means: "When seconds is equal to 0, minutes is divisible by 5, for any hour, day of the month, month, day of the week, or year".
