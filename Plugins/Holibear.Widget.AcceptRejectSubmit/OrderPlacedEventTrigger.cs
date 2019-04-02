using Holibear.Widget.AcceptRejectSubmit.Models;
using Nop.Core.Data;
using Nop.Core.Domain.Orders;
using Nop.Services.Events;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public class OrderPlacedEventTrigger : IConsumer<OrderPlacedEvent>
    {

        private ILogger _logger;
        private IRepository<Order> _orderRepository;

        public OrderPlacedEventTrigger(ILogger logger , IRepository<Order> orderRepository)
        {
            this._logger = logger;
            this._orderRepository = orderRepository;
        }
        public void HandleEvent(OrderPlacedEvent orderPlacedEvent)
        {
            Order placedOrder = orderPlacedEvent.Order;
            OrderNote ordernote = new OrderNote();
            
            
            //AcceptRejectStatus acceptRejectStatusModel = new AcceptRejectStatus();

            //acceptRejectStatusModel.OrderId = orderPlacedEvent.Order.Id;
            //acceptRejectStatusModel.OrderStatus = orderPlacedEvent.Order.OrderStatus.ToString();
            //acceptRejectStatusModel.OrderComment = "Order has delevered";
            //acceptRejectStatusModel.CommentCreateTime = DateTime.Now;

            foreach (var orderItem in orderPlacedEvent.Order.OrderItems)
            {
                string[] attrubuteDescriptions = orderItem.AttributeDescription.Split(new string[] { "edits:" }, StringSplitOptions.RemoveEmptyEntries);
                ordernote.CreatedOnUtc = DateTime.Now;

                if (attrubuteDescriptions.Length > 1)
                {
                    try
                    {
                        ordernote.Note = "Number of edits : " + int.Parse(attrubuteDescriptions[1].Trim());
                    }
                    catch (Exception e)
                    {
                        _logger.Error("Number of Edits format incorrect");
                    }
                }
                else
                {
                    ordernote.Note = "Number of edits : 0";
                }

                placedOrder.OrderNotes.Add(ordernote);
            }

            _orderRepository.Update(placedOrder);

        }
    }
}
