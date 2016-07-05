﻿namespace MvcProject.Web
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Data.DbAccessConfig.Contexts;
    using Data.DbAccessConfig.Migrations;
    using Infrastructure.Mapping;

#pragma warning disable SA1649 // File name must match first type name
    public class MvcApplication : HttpApplication
#pragma warning restore SA1649 // File name must match first type name
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MvcProjectDbContext, Configuration>());
            ViewEnginesConfig.RegisterEngines(ViewEngines.Engines);
            AutofacConfig.RegisterAutofac();

            // If problematic, use constructor to get an instance of AutoMapperConfig and use its Execute()
            AutoMapperInit.Initialize(Assembly.GetExecutingAssembly());
        }

        //protected void Application_BeginRequest(
        //    object sender,
        //    EventArgs e)
        //{
        //    if (this.Request.IsLocal)
        //    {
        //        MiniProfiler.Start();
        //    }
        //}

        //protected void Application_EndRequest()
        //{
        //    MiniProfiler.Stop(/*discardResults: true*/);
        //}

        //// For custom OutPutCache VaryByCustom
        // public override string GetVaryByCustomString(HttpContext context, string custom)
        // {
        //    if (custom == "SessionCache")
        //    {
        //        return this.Session.SessionID;
        //    }
        //    else if (custom == "SomeOtherIdentifier")
        //    {
        //        // specify how to cache in this case
        //    }

        // return base.GetVaryByCustomString(context, custom);
        // }
    }
}
