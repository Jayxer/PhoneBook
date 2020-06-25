using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace PhoneBook.Models
{
    public class Entry
    {
        [Key]
        public long? EntryId { get; set; }
        [DisallowNull]
        public string Name { get; set; }
        [DisallowNull]
        public string PhoneNumber { get; set; }
    }
}
