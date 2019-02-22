using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public class WidgetsAcceptRejectButtonController : BasePluginController
    {
        private IStoreContext _storeContext;
        private IPermissionService _permissionService;
        private ISettingService _settingService;
        private ILocalizationService _localizationService;

        public WidgetsAcceptRejectButtonController(IStoreContext storeContext,
            IPermissionService permissionService,
            ISettingService settingService,
            ILocalizationService localizationService)
        {
            this._storeContext = storeContext;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();
   
            return View("~/Plugins/Holibear.Widget.AcceptRejectSubmit/Views/_AcceotRejectSubmitButton.cshtml");
        }
    }
}
