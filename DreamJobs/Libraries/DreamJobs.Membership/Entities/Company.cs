using DreamJobs.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Membership.Entities
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string AboutCompany { get; set; }
    }
}
