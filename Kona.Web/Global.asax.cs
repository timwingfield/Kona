using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using Commerce.MVC.Web;
using Kona.App.Infrastructure;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Kona
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory=CreateSessionFactory();
        public MvcApplication() {
            BeginRequest += MvcApplication_BeginRequest;
            EndRequest += MvcApplication_EndRequest;
        }

        void MvcApplication_EndRequest(object sender, EventArgs e) {
            CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e) {
            CurrentSessionContext.Bind(SessionFactory.OpenSession());
        }

        private static ISessionFactory CreateSessionFactory() {
            var cfg = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));
            cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionStringName, "PEAHI");
            return cfg.BuildSessionFactory();
        }


        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            Bootstrapper.ConfigureStructureMap();
            ControllerBuilder.Current.SetControllerFactory(new KonaControllerFactory());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                );

        }
    }
}