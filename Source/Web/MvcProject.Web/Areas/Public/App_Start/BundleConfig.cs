﻿namespace MvcProject.Web.Areas.Public
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Optimization;
    using Common.GlobalConstants;

    internal class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundles)
        {
            // JavaScript
            bundles.Add(new ScriptBundle(Bundles.PublicScriptsJQueryUI)
                .Include("~/Areas/Public/Scripts/IgniteUI/jquery-ui.min.js")
                );

            bundles.Add(new ScriptBundle(Bundles.PublicScriptsIgniteUI)
                .Include("~/Areas/Public/Scripts/IgniteUI/infragistics.core.Unicode.js")
                .Include("~/Areas/Public/Scripts/IgniteUI/infragistics.ui.rating.js")
                .Include("~/Areas/Public/Scripts/IgniteUI/infragistics.lob.js")
                );

            bundles.Add(new ScriptBundle(Bundles.PublicScriptsCustom)
                //.Include("~/Areas/Public/Scripts/Custom/*.js")
                .Include("~/Areas/Public/Scripts/Custom/bootstrap-modal-helpers.js")
                .Include("~/Areas/Public/Scripts/Custom/igniteui-rating-handler.js")
                .Include("~/Areas/Public/Scripts/Custom/search-results.js")
                );

            // CSS
            bundles.Add(new StyleBundle(Bundles.PublicStylesIgniteUI)
                .Include("~/Areas/Public/Content/IgniteUI/structure/infragistics.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/IgniteUI/structure/modules/infragistics.ui.rating.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/IgniteUI/themes/infragistics/infragistics.theme.css", new CssRewriteUrlTransform())
                );

            bundles.Add(new StyleBundle(Bundles.PublicStylesCustomCss)
                //.Include("~/Areas/Public/Content/Custom/*.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/homepage-carousel.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/listView.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/product-full-viewmodel.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/search-results.css", new CssRewriteUrlTransform())
                );
        }
    }
}