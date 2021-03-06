﻿namespace JustOrderIt.Web.Infrastructure.BackgroundWorkers
{
    using Hangfire;

    /// <summary>
    /// Exposes background jobs API
    /// </summary>
    public interface IBackgroundJobsService
    {
        /// <summary>
        /// Gets a Hangfire BackgroundJobClient instance.
        /// </summary>
        /// <value>
        /// A Hangfire BackgroundJobClient instance.
        /// </value>
        IBackgroundJobClient JobClient { get; }
    }
}
