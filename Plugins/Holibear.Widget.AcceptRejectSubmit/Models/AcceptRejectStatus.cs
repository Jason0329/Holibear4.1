using Nop.Core.Domain.Orders;
using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit.Models
{
    public class AcceptRejectStatus : BaseNopModel
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string OrderComment { get; set; }
    }
}
