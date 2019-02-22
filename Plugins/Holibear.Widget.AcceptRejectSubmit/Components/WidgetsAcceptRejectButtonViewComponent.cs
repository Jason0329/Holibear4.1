using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit.Components
{
    [ViewComponent(Name = "WidgetsAcceptRejectSubmit")]
    public class WidgetsAcceptRejectButtonViewComponent : NopViewComponent
    {
        private IStoreContext _storeContext;
        private ISettingService _settingService;

        public WidgetsAcceptRejectButtonViewComponent(IStoreContext storeContext,
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
        }
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            return View("~/Plugins/Holibear.Widget.AcceptRejectSubmit/Views/_AcceotRejectSubmitButton.cshtml");
        }

    }
}
