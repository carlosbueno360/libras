namespace TecLibras.UI.Web.ViewComponents
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;


    public class RankViewModel
    {
        public int Points { get; set; }

        public Guid ApplicationUserId { get; set; }

        public ApplicationUserViewModel ApplicationUser { get; set; }

    }

    public class ApplicationUserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

    }
}