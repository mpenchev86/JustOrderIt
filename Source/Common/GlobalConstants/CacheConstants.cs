﻿namespace MvcProject.Common.GlobalConstants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CacheConstants
    {
        // Public/HomeController/Index ListView
        public const int IndexCarouselCacheExpiration = 30 * 60;
        public const int IndexListViewCacheExpiration = 3 * 60;
        //public const int IndexListViewUpdateCallbackExpiration = 5 * 60;

        // Public/SearchController/ReadSearchResult
        public const int AllProductsInCategoryCacheExpiration = 5 * 60;
        public const int AllProductsInCategoryUpdateBackgroundJobDelay = 3 * 60;
    }
}
