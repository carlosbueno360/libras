using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecLibras.Services.Api.ViewModels
{
    public class PointsViewModel
    {

        [Required(ErrorMessage = "The Points is Required")]
        [DisplayName("Name")]
        public int Points { get; set; }

        [Required(ErrorMessage = "The DateTime is Required")]
        [DisplayName("DateTime")]
        public DateTime DateTime { get;  set; }

        [Required(ErrorMessage = "The UserId is Required")]
        [DisplayName("UserId")]
        public Guid UserId { get;  set; }

    }
}
