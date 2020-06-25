using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly Models.PhoneBook _phoneBook;
        private readonly PhoneBookContext _context;

        public EntriesController(PhoneBookContext context)
        {
            _context = context;
            _phoneBook = new Models.PhoneBook();
        }

        [HttpGet]
        public IEnumerable<Entry> Get()
        {
            _phoneBook.Entries = _context.Entries.ToList();
            return _phoneBook.Entries.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Entry entry)
        {
            _context.Entries.Add(entry);
            _phoneBook.Entries.Add(entry);
            _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{entryId}")]
        public IActionResult Put(long entryId, [FromBody] Entry entry)
        {
            _context.Entries.Update(entry);
            _context.SaveChanges();
            
            return Ok();
        }

        [HttpDelete("{entryId}")]
        public ActionResult<Entry> Delete(long entryId)
        {
            var entry = _context.Entries.Find(entryId);

            _phoneBook.Entries.Remove(entry);
            _context.Entries.Remove(entry);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("{searchEntries}")]
        public IEnumerable<Entry> searchEntries(string searchName)
        {
            IEnumerable<Entry> entries = _context.Entries;
            
            if (!string.IsNullOrEmpty(searchName) && (searchName!= "null"))
            {
                entries = entries.Where(c => c.Name.ToLower().Contains(searchName.ToLower()));
            }

            return entries;
        }
    }
}
