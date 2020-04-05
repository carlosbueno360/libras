using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecLibras.Services.Api.ViewModels
{
    public class QuestionViewModel
    {
        [Required(ErrorMessage = "The Awnser is Required")]
        [DisplayName("Awnser")]
        public String Awnser { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [DisplayName("Title")]
        public String Title { get; set; }

        [Required(ErrorMessage = "The Points is Required")]
        [DisplayName("Points")]
        public int Points { get; set; }

    }
}
