﻿namespace MvcProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcProject.Data.Models;
    using MvcProject.Data.Models.Search;

    public interface ISearchFiltersService : IDeletableEntitiesBaseService<SearchFilter, int>
    {
    }
}