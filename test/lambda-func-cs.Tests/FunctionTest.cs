using Xunit;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using LambdaFunc;

namespace Lambda.Tests;

public class FunctionTest
{
    [Fact]
    public void TestLambdaFunction()
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
