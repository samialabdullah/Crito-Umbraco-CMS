using Crito.Contexts;
using Crito.Models;

namespace Crito.Services
{
    public class ContactFormService
    {
        private readonly DataContext _context;

        public ContactFormService(DataContext context)
        {
            _context = context;
        }


        public async Task AddContactFormsAsync(ContactForm form)
        {
            var newContact = new ContactFormEntity
            {
                Name = form.Name,
                Email = form.Email,
                Message = form.Message,
            };

            _context.Contact.Add(newContact);
            await _context.SaveChangesAsync();
        }
    }
}
