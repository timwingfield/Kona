using StructureMap;
using StructureMap.Configuration.DSL;
using NHibernate;
using Kona;
using Kona.App.Services;

namespace Commerce.MVC.Web {
    public static class Bootstrapper {

        public static void ConfigureStructureMap() {
            StructureMapConfiguration.AddRegistry(new StoreRegistry());
        }
    }

    public class StoreRegistry : Registry {
        protected override void configure() {
             
            //ForRequestedType<IStoreRepository>()
            //    .TheDefaultIsConcreteType<LinqRepository>();

            ForRequestedType<ISession>()
                .TheDefault.Is.ConstructedBy(x => MvcApplication.SessionFactory.GetCurrentSession());
            ForRequestedType<IStoreService>()
              .TheDefaultIsConcreteType<StoreService>();
          
        }
    }
}
