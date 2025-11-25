using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

using BookingFunc.Models;

namespace BookingFunc;

public class Function
{
    /// <summary>
    /// The Lambda function
    /// </summary>
    /// <param name="request">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        var response = new APIGatewayHttpApiV2ProxyResponse();

        var body = JsonSerializer.Deserialize<AppointmentBody>(request.Body);
        request.Headers.TryGetValue("authorization", out var authorization);

        if (string.IsNullOrWhiteSpace(authorization)) {
            response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return response;
        }

        Console.WriteLine(authorization);

        response.Body = body?.Name ?? string.Empty;
        response.StatusCode = (int)HttpStatusCode.OK;

        return response;
    }
}
