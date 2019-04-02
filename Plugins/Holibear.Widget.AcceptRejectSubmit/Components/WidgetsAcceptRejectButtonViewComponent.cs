using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Orders;
using Nop.Services.Configuration;
using Nop.Services.Logging;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit.Components
{
    [ViewComponent(Name = "WidgetsAcceptRejectSubmit")]
    public class WidgetsAcceptRejectButtonViewComponent : NopViewComponent
    {
        private IStoreContext _storeContext;
        private ISettingService _settingService;
        private IRepository<Order> _orderRepository;
        private ILogger _logger;

        public WidgetsAcceptRejectButtonViewComponent(IStoreContext storeContext,
            ISettingService settingService, IRepository<Order> orderRepository,
            ILogger logger)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
            this._orderRepository = orderRepository;
            this._logger = logger;
        }
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            string urlPath = Request.Path;
            string[] urlPathSplit = urlPath.Split('/');
            int orderID = int.Parse(urlPathSplit[urlPathSplit.Length-1]);
            Order order = _orderRepository.GetById(orderID);
            OrderNote orderNoteWithNumberOfEdits = order.OrderNotes
               .OrderByDescending(m => m.CreatedOnUtc).FirstOrDefault();

            int NumberOfEdits = 0;

            try
            {
                NumberOfEdits = int.Parse(orderNoteWithNumberOfEdits.Note.Split(':')[1].Trim());
            }
            catch (Exception e)
            {
                NumberOfEdits = 0;
            }

            return View("~/Plugins/Holibear.Widget.AcceptRejectSubmit/Views/_AcceotRejectSubmitButton.cshtml" , NumberOfEdits);
        }

    }
}
