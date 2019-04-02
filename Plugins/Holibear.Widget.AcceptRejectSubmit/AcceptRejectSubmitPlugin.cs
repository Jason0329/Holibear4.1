using Holibear.Widget.AcceptRejectSubmit.Data;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Logging;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public class AcceptRejectSubmitPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILogger _logger;
        private AcceptRejectStatusObjectContext _acceptRejectStatusObjectContext;

        public AcceptRejectSubmitPlugin(ILogger logger , AcceptRejectStatusObjectContext acceptRejectStatusObjectContext)
        {
            this._logger = logger;
            this._acceptRejectStatusObjectContext = acceptRejectStatusObjectContext;
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsAcceptRejectSubmit";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.OrderDetailsPageAfterproducts };
        }

        public override void Install()
        {
            _acceptRejectStatusObjectContext.Install();
            _logger.Information("Install Plugin Succeed");
            base.Install();
        }

        public override void Uninstall()
        {
            _logger.Information("Uninstall Plugin Succeed");
            base.Uninstall();
        }
    }
}
