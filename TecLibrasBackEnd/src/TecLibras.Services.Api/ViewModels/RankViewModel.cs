using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecLibras.Services.Api.ViewModels
{
    public class RankViewModel
    {
        [Required(ErrorMessage = "The Points is Required")]
        [DisplayName("Points")]
        public int Points { get; set; }

        [Required(ErrorMessage = "The UserId is Required")]
        [DisplayName("UserId")]
        public Guid UserId { get; set; }

        
        public ApplicationUserViewModel User { get; set; }
    }

    public class ApplicationUserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

    }
}
