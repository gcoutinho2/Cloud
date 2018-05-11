using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProvas.Models
{
    public class RespostaAlunoProva
    {
        public int IdAluno { get; set; }
        public RespostaAluno[] Respostas { get; set; }
    }
}