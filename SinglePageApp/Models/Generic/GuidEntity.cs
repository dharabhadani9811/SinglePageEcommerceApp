using DharaProject.Models.Generic;
using System;

namespace DharaProject.Models.Generic
{
    public abstract class GuidEntity : IIdentity<Guid>
    {
        public Guid Id { get; set; }
        public GuidEntity()
        {
            Id = Guid.NewGuid();
        }


    }
}
