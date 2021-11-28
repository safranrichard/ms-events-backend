using System;

namespace MxcEventsBackEnd.Models
{
    public class MEvent : MEventBase
    {
        public DateTime CreationDate { get; set; }

        public Guid Id { get; set; }

        public MEvent(){}

        public MEvent (MEventBase eventBase)
        {
            Name = eventBase.Name;
            Location = eventBase.Location;
            Country = eventBase.Country;
            Capacity = eventBase.Capacity;
            CreationDate = DateTime.Now;
            Id = Guid.NewGuid();
        }

    }
}
