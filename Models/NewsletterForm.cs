using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class NewsletterForm
    {
        [Required]
        [EmailAddress]
        public string SubscribersEmail { get; set; } = null!;
    }
}
