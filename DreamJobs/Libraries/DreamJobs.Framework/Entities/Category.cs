using DreamJobs.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Entities
{
    public class Category : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
