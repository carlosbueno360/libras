using System;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Models
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