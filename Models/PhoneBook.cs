using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PhoneBook.Models
{
    public class PhoneBook
    {
        public PhoneBook()
        {
            Entries = new List<Entry>();
        }

        [Key]
        public long? EntryId { get; set; }
        [DisallowNull]
        public string Name { get; set; }
        public virtual List<Entry> Entries { get; set; }
    }
}
