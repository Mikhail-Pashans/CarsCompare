using CarsCompare.Logger;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarsCompare.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly LogWriter _logWriter = new LogWriter();

        protected async void Application_Start(object sender, EventArgs e)
        {
            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            await _logWriter.WriteInfoAsync("CarsCompare website started.");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string sessionId = Session.SessionID;
        }

        protected async void Application_End(object sender, EventArgs e)
        {
            await _logWriter.WriteInfoAsync("CarsCompare website finished.");
        }
    }
}