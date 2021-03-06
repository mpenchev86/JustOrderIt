﻿namespace JustOrderIt.Web.Infrastructure.ViewEngines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class CustomViewLocationRazorViewEngine : RazorViewEngine, IViewEngine
    {
        public CustomViewLocationRazorViewEngine()
        {
            this.AreaViewLocationFormats = new string[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

            this.AreaMasterLocationFormats = new string[]
            {
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };

            this.AreaPartialViewLocationFormats = new string[]
            {
                "~/Areas/{2}/Views/{1}/Partials/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/Partials/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/Partials/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/Partials/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };

            this.ViewLocationFormats = new string[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };

            this.MasterLocationFormats = new string[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml",
            };

            this.PartialViewLocationFormats = new string[]
            {
                "~/Views/{1}/Partials/{0}.cshtml",
                "~/Views/{1}/Partials/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };
        }
    }
}
