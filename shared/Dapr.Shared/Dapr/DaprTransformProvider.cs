using System;
using System.Threading.Tasks;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace Dapr.Shared 
{
    public class DaprTransformProvider : ITransformProvider
    {
        public void ValidateRoute(TransformRouteValidationContext context)
        {
        }

        public void ValidateCluster(TransformClusterValidationContext context)
        {
        }

        public void Apply(TransformBuilderContext context)
        {
            if (context.Route.RouteId == DaprYarpConst.ApiRoute)
            {
                context.AddRequestTransform(transformContext =>
                {
                    //网关Path转为DaprPath。例host/api/sys/login 
                    if (transformContext.Path.HasValue)
                    {
                        string reg = @"/api/(?<apiid>\w+)(?<path>/.*)";
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg);
                        var math = regex.Match(transformContext.Path.Value);
                        string appId = math.Groups["apiid"].Value;
                        string path = math.Groups["path"].Value;
                        transformContext.ProxyRequest.RequestUri = new Uri($"{transformContext.DestinationPrefix}/v1/invoke/{appId}/method{path}");
                        Console.WriteLine(transformContext.ProxyRequest.RequestUri.ToString());
                    }
                    return ValueTask.CompletedTask;
                });
            }

        }
    }
}