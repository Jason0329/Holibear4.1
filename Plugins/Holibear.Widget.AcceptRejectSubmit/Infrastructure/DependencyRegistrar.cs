using Autofac;
using Autofac.Core;
using Holibear.Widget.AcceptRejectSubmit.Data;
using Holibear.Widget.AcceptRejectSubmit.Models;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Holibear.Widget.AcceptRejectSubmit.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            ////data context
            builder.RegisterPluginDataContext<AcceptRejectStatusObjectContext>("holibear_object_context_accept_reject_status");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<AcceptRejectStatus>>().As<IRepository<AcceptRejectStatus>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("holibear_object_context_accept_reject_status"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}