﻿namespace MvcProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ServiceModels;

    public interface IFileInfoService<T>
    {
        T SaveFileInfo(RawFile file);
    }
}
