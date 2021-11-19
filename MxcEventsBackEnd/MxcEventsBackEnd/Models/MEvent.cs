using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MxcEventsBackEnd.Models
{
    public class MEvent
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Location { get; set; }

        public string Country { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public int Capacity { get; set; }

        public DateTime CreationDate { get; private set; }

        public Guid Id { get; private set; }

        //setters
        public void SetCreationDate()
        {
            CreationDate = DateTime.Now;
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }
    }
}
