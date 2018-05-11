using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProvas.Models
{
    public class Prova
    {
        public int IdProva { get; set; }
        public string Nome { get; set; }
        public DateTime DataAplicacao { get; set; }
    }
}