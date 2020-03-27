using System;
using TecLibras.Domain.Core.Models;

namespace TecLibras.Domain.Models
{
    public class Points : Entity
    {
        public Points(Guid id)
        {
            Id = id;
        }

        // Empty constructor for EF
        protected Points() { }

        public int points { get; private set; }
    }
}