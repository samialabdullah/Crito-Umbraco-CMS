﻿using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class SubscriberEntity
    {
        [Key]
        public string SubscribersEmail { get; set; } = null!;
    }
}
