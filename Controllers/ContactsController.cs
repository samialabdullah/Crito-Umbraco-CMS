using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.ActionResults;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactsController : SurfaceController
    {




        private readonly ContactFormService _contactFormService;

        public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactFormService contactFormService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contactFormService = contactFormService;
        }

        public async Task<IActionResult> Index(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                TempData.Clear();
                ModelState.AddModelError("", "You must fill your info in the form");
                return CurrentUmbracoPage();
            }

            var registered = await _contactFormService.AddContactFormsAsync(contactForm);

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

        /*

                public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
                {
                }

                [HttpPost]
                public IActionResult Index(ContactForm contactForm)
                {
                    if (!ModelState.IsValid)

                        return CurrentUmbracoPage();


                    using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactform@crito.com", "BytMig123!");
                    // to sender 
                    mail.SendAsync(contactForm.Email, "Your contact request was received.", "Hi your request was received and we will be in contact with you as soon as possible.").ConfigureAwait(false);

                    // to us
                    mail.SendAsync("umbraco@crito.com", $"{contactForm.Name} sent a contact request.", contactForm.Message).ConfigureAwait(false);


                    return LocalRedirect(contactForm.RedirectUrl ?? "/");

                }*/
    }
}
