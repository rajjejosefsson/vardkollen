using AutoMapper;
using CareCheck.DomainClasses;
using CareCheck.MVC.Admin.ViewModels;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CareCheck.MVC.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreateEmployeeViewModel, Employee>();
                cfg.CreateMap<CreatePatientViewModel, Patient>();

            });

        }
    }
}
