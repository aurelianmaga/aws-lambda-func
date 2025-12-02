using System.Net;
using System.Text.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

using LambdaFunc.Models;

namespace LambdaFunc;

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

        request.Headers.TryGetValue("authorization", out var authorization);
        Console.WriteLine(authorization);

        if (string.IsNullOrWhiteSpace(authorization)) {
            response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return response;
        }

        var jsonAsString = request.IsBase64Encoded ? System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(request.Body)) : request.Body;
        Console.WriteLine(jsonAsString);
        var body = JsonSerializer.Deserialize<Appointment>(jsonAsString);

        response.Body = body?.Name ?? string.Empty;
        response.StatusCode = (int)HttpStatusCode.OK;

        return response;
    }
}
