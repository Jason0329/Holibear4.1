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
using System.Linq;
using Nop.Services.Logging;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public class WidgetsAcceptRejectButtonController : BasePluginController
    {
        private IStoreContext _storeContext;
        private IPermissionService _permissionService;
        private ISettingService _settingService;
        private ILocalizationService _localizationService;
        private IRepository<Order> _orderRepository;
        private IRepository<AcceptRejectStatus> _orderAcceptRejectStatusRepository;
        private ILogger _logger;

        public WidgetsAcceptRejectButtonController(IStoreContext storeContext,
            IPermissionService permissionService,
            ISettingService settingService,
            ILocalizationService localizationService,
            IRepository<Order> orderRepository,
            IRepository<AcceptRejectStatus> orderAcceptRejectStatusRepository,
            ILogger logger)
        {
            this._storeContext = storeContext;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._orderRepository = orderRepository;
            this._orderAcceptRejectStatusRepository = orderAcceptRejectStatusRepository;
            this._logger = logger;
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

            OrderNote orderNoteWithNumberOfEdits = order.OrderNotes
                .OrderByDescending(m => m.CreatedOnUtc).FirstOrDefault();
            int NumberOfEdits=0;
            OrderNote orderNote = new OrderNote();

            try
            {
                NumberOfEdits = int.Parse(orderNoteWithNumberOfEdits.Note.Split(':')[1].Trim());
            }
            catch(Exception e)
            {
                _logger.Error("Number of Edits format error");
            }

            orderNote.CreatedOnUtc = DateTime.Now;           
            if (orderStatusUpdate.OrderStatus == OrderStatus.Complete.ToString())
            {                
                order.OrderStatus = OrderStatus.Complete;
                orderNote.Note = "Complete";            
            }
            else
            {
                order.OrderStatus = OrderStatus.Pending;
                orderNote.Note = "Reject :" + orderStatusUpdate.OrderComment;   
            }

            order.OrderNotes.Add(orderNote);

            OrderNote orderNoteWithNumberofEdits = new OrderNote();
            if (NumberOfEdits > 0)
            {

                NumberOfEdits--;
                orderNoteWithNumberofEdits.CreatedOnUtc = DateTime.Now;
                orderNoteWithNumberofEdits.Note = "Number of edits : " + NumberOfEdits;
                order.OrderNotes.Add(orderNoteWithNumberofEdits);
            }

            _orderRepository.Update(order);
//////////////////////////////////////////////forget below purpose//////////////
            foreach(var orderItem in order.OrderItems)
            {
                orderStatusUpdate.ProductId = orderItem.ProductId;
                orderStatusUpdate.ProductName = orderItem.Product.Name;
            }

            string OrderUpdateStatus = "Succeed";
            return Json(OrderUpdateStatus);
            //string json = JsonConvert.SerializeObject(Introduction);
            //Response.Write(Introduction.Name);
            //return null;// View("~/Plugins/Holibear.Widget.AcceptRejectSubmit/Views/_AcceotRejectSubmitButton.cshtml"); ;
        }
    }
}
