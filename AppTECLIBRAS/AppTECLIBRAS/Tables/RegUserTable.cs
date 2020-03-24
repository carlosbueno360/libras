using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTECLIBRAS.Tables
{
     public class RegUserTable
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

    }
}
