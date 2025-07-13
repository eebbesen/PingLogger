using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PingLogger;

public class PingFunction
{
    private readonly ILogger _logger;
    private readonly HttpClient _client;
    private readonly string _url;

    public PingFunction(ILoggerFactory loggerFactory, HttpClient client)
    {
        _logger = loggerFactory.CreateLogger<PingFunction>();
        _client = client;
        _url = Environment.GetEnvironmentVariable("PING_URL") ?? "https://account.metrotransit.org/account/resetpassword";
    }

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