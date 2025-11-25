using Xunit;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using BookingFunc;
using BookingFunc.Models;

namespace Booking.Tests;

public class FunctionTest
{
    [Fact]
    public void TestToUpperFunction()
    {
        var request = new APIGatewayHttpApiV2ProxyRequest();
        request.Headers =  new Dictionary<string, string>();
        request.Headers.Add("authorization", "");
        request.Body = "{}";

        var function = new Function();
        var context = new TestLambdaContext();
        var result = function.FunctionHandler(request, context);

        Assert.NotNull(result);
    }
}
