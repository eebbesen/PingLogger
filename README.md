# PingLogger

Ping and URL and capture return data.

## Setup

Populate `PING_URL` environment variable

## Run locally
You'll need to install [azurite](https://github.com/azure/azurite) once

    npm install -g azurite

and make sure it's running everytime you want to run the function locally

    azurite --silent --location ~/.azurite --debug ~/.azurite/debug.log

Then run the function

    func start

## Deploy to Azure

   func azure functionapp publish <AppName>

## How it works

For a `TimerTrigger` to work, you provide a schedule in the form of a [cron expression](https://en.wikipedia.org/wiki/Cron#CRON_expression)(See the link for full details). A cron expression is a string with 6 separate expressions which represent a given schedule via patterns. The pattern we use to represent every minute is `0 */1 * * * *`. This, in plain text, means: "When seconds is equal to 0, minutes is divisible by 1, for any hour, day of the month, month, day of the week, or year".

## Other

### Initial setup

    func init PingLogger --dotnet-isolated
    func new --name PingFunction --template "Timer trigger"

### Create function in Azure (one time)

    az login
    az functionapp create -g <ResourceGroup> -n <AppName> -s <Storage> --consumption-plan-location centralus
