using Holibear.Widget.AcceptRejectSubmit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace Holibear.Widget.AcceptRejectSubmit.Data
{
    public partial class AcceptRejectStatusMap : NopEntityTypeConfiguration<AcceptRejectStatus>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<AcceptRejectStatus> builder)
        {
            builder.ToTable(nameof(AcceptRejectStatus));
            builder.HasKey(acceptRejectStatus => acceptRejectStatus.Id);
            //builder.ToTable(nameof(AcceptRejectStatus));
            //builder.HasKey(AcceptRejectStatus => AcceptRejectStatus.Id);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.NumberOfEdits);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.CommentCreateTime);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.OrderComment);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.OrderId);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.OrderStatus);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.ProductId);
            //builder.Property(AcceptRejectStatus => AcceptRejectStatus.ProductName);
        }

        #endregion
    }
}
