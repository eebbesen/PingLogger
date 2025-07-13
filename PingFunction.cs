using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PingLogger;

public class PingFunction(ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<PingFunction>();
    private static readonly string _url = Environment.GetEnvironmentVariable("PING_URL") ?? "https://account.metrotransit.org/account/resetpassword";
    private static readonly HttpClient _client = new();

    [Function("PingFunction")]
    public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync(_url);
            int statusCode = (int)response.StatusCode;

            _logger.LogInformation("[{UtcNow}] Ping to {Url} returned {StatusCode}",
                DateTime.UtcNow.ToString("O"), _url, statusCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while pinging {Url}.", _url);
        }
    }
}