using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyMVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();  //区域
            GlobalConfiguration.Configure(WebApiConfig.Register);//WebApi路由
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//过滤器
            RouteConfig.RegisterRoutes(RouteTable.Routes);      //路由(url规则)
            BundleConfig.RegisterBundles(BundleTable.Bundles);  //js  css 包
        }
    }
}
