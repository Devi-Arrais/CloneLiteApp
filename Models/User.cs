using System;

namespace CloneLiteApp.Models
{
    public class User
    {
        public int id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public string Senha {get; set;} = string.Empty;
        public DateTime CriadoEm {get; set;} = DateTime.UtcNow;
    }
}