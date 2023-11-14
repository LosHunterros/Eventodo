﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eventodo.Domain
{
    [Index(nameof(Url), IsUnique = true)]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public ICollection<Module> Events { get; set; } = new List<Module>();
    }
}
