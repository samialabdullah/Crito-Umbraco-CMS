﻿using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class HomesController : SurfaceController
    {
        private readonly SubscriberService _subscriberService;

        public HomesController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, SubscriberService subscriberService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _subscriberService = subscriberService;
        }

        public async Task<IActionResult> Index(NewsletterForm subscriber)
        {
            if (!ModelState.IsValid)
            {
                TempData.Clear();
                ModelState.AddModelError("", "You must fill your email");
                return CurrentUmbracoPage();
            }

            var registered = await _subscriberService.AddSubscriberAsync(subscriber);

            TempData.Clear();
            if (registered)
            {
                
                TempData["SuccessMessage"] = "Your info has been save, thanks";
                ModelState.Clear();
            }
            else
                TempData["AlreadyRegisteredMessage"] = "Something was wrong, please try to write agine";


            return CurrentUmbracoPage();
        }
    }
}
