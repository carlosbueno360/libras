using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecLibras.Services.Api.ViewModels
{
    public class PointsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Points is Required")]
        [DisplayName("Name")]
        public int Points { get; set; }

    }
}
