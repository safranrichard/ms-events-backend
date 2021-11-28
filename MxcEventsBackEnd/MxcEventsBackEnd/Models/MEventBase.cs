using System;
using System.ComponentModel.DataAnnotations;

namespace MxcEventsBackEnd.Models
{
    public class MEventBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Location { get; set; }

        public string Country { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public int Capacity { get; set; }
    }
}
