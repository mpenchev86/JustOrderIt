﻿namespace MvcProject.Web.Infrastructure.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MyFirstCustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // in the case of strings
            var valueAsString = value as string;
            return valueAsString != null && valueAsString.Length >= 20;
        }
    }
}
