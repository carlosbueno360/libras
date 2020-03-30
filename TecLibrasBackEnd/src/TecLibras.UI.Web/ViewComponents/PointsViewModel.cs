namespace TecLibras.UI.Web.ViewComponents
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;


    public class PointsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Points is Required")]
        [DisplayName("Name")]
        public int Points { get; set; }

    }
}