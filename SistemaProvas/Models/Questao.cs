using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProvas.Models
{
    public class Questao
    {
        public int IdQuestao { get; set; }
        public string Nome { get; set; }
        public string Enunciado { get; set; }
    }
}