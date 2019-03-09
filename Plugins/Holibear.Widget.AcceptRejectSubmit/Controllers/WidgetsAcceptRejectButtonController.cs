using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Orders;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Holibear.Widget.AcceptRejectSubmit.Models;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public class WidgetsAcceptRejectButtonController : BasePluginController
    {
        private IStoreContext _storeContext;
        private IPermissionService _permissionService;
        private ISettingService _settingService;
        private ILocalizationService _localizationService;
        private IRepository<Order> _orderRepository;

        public WidgetsAcceptRejectButtonController(IStoreContext storeContext,
            IPermissionService permissionService,
            ISettingService settingService,
            ILocalizationService localizationService,
            IRepository<Order> orderRepository)
        {
            this._storeContext = storeContext;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._orderRepository = orderRepository;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();
   
            return View("~/Plugins/Holibear.Widget.AcceptRejectSubmit/Views/_AcceotRejectSubmitButton.cshtml");
        }

        //public 

        public IActionResult OrderStatusUpdate(string orderStatus)
        {
            //String data = Request.Form["orderStatus"];
            AcceptRejectStatus orderStatusUpdate = JsonConvert.DeserializeObject<AcceptRejectStatus>(orderStatus);

            Order order = _orderRepository.GetById(orderStatusUpdate.OrderId);

            OrderNote orderNote = new OrderNote();
            orderNote.CreatedOnUtc = DateTime.Now;
            
            if (orderStatusUpdate.OrderStatus == OrderStatus.Complete.ToString())
            {                
                order.OrderStatus = OrderStatus.Complete;
                orderNote.Note = "Complete Order";
               
            }
            else
            {
                order.OrderStatus = OrderStatus.Pending;
                orderNote.Note = orderStatusUpdate.OrderComment;
   
            }

            order.OrderNotes.Add(orderNote);
            _orderRepository.Update(order);

            string OrderUpdateStatus = "Succeed";
            return Json(OrderUpdateStatus);
            //string json = JsonConvert.SerializeObject(Introduction);
            //Response.Write(Introduction.Name);
            //return null;// View("~/Plugins/Holibear.Widget.AcceptRejectSubmit/Views/_AcceotRejectSubmitButton.cshtml"); ;
        }
    }
}
