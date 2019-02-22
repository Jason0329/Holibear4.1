using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Nop.Web.Framework.Infrastructure;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public class AcceptRejectSubmitPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILogger _logger;
        public AcceptRejectSubmitPlugin(ILogger logger)
        {
            this._logger = logger;
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsAcceptRejectSubmit";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { "Holibear.AcceptRejectButton" };
        }

        public override void Install()
        {
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
