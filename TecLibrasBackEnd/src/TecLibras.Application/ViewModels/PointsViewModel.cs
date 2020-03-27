using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecLibras.Application.ViewModels
{
    public class PointsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Points is Required")]
        [DisplayName("Points")]
        public int Points { get; set; }
    }
}
