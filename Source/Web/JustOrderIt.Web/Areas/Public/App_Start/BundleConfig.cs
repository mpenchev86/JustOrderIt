﻿namespace JustOrderIt.Web.Areas.Public
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
            bundles.Add(new ScriptBundle(Bundles.PublicScriptsJQueryUi)
                .Include("~/Areas/Public/Scripts/IgniteUI/jquery-ui.js"));

            bundles.Add(new ScriptBundle(Bundles.PublicScriptsIgniteUI)
                .Include("~/Areas/Public/Scripts/IgniteUI/infragistics.util.Unicode.js")
                .Include("~/Areas/Public/Scripts/IgniteUI/infragistics.ui.rating.js"));

            bundles.Add(new ScriptBundle(Bundles.PublicScriptsCustom)
                .Include("~/Areas/Public/Scripts/Custom/bootstrap-modal-helpers.js")
                .Include("~/Areas/Public/Scripts/Custom/igniteui-rating-handler.js")
                .Include("~/Areas/Public/Scripts/Custom/navbar-search.js"));

            // CSS
            bundles.Add(new StyleBundle(Bundles.PublicStylesJQueryUi)
                .Include("~/Areas/Public/Content/themes/base/jquery-ui.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle(Bundles.PublicStylesIgniteUI)
                .Include("~/Areas/Public/Content/IgniteUI/Structure/infragistics.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/IgniteUI/Structure/Modules/infragistics.ui.rating.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/IgniteUI/Themes/infragistics/infragistics.theme.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle(Bundles.PublicStylesCustomCss)
                .Include("~/Areas/Public/Content/Custom/category-search.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/checkout.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/homepage-carousel.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/homepage-listView.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/order-history.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/product-full-viewmodel.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/query-search.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/shopping-cart.css", new CssRewriteUrlTransform())
                .Include("~/Areas/Public/Content/Custom/validation-messages.css", new CssRewriteUrlTransform()));
        }
    }
}