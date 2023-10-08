using Crito.Contexts;
using Crito.Models;


namespace Crito.Services
{
    public class SubscriberService
    {
        private readonly DataContext _context;
        public SubscriberService(DataContext context) 
        {
            _context = context;
        }

        public async Task<bool> AddSubscriberAsync(NewsletterForm form)
        {
            try
            {
                _context.Subscribers.Add(new SubscriberEntity
                {
                    SubscribersEmail = form.SubscribersEmail,
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
