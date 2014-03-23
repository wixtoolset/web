namespace WixToolset.Web.Api
{
    using NLog;
    using TinyWebStack;
    using WixToolset.Web.Api.Models;
    using WixToolset.Web.Api.Utilities;

    [Route("telemetry/{*anything}")]
    public class TelemetryHandler : IGet
    {
        private static Logger Log = LogManager.GetLogger("telemetry");
        private static WebUserService UserService = new WebUserService();

        public Status Get()
        {
            UserService.CreateAnonymousUser();

            Visit.CreateFromHttpContext().Log(Log);

            return Status.OK;
        }
    }
}
