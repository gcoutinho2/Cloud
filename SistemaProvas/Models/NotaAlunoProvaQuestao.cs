using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SistemaProvas.Models
{
    public class NotaAlunoProvaQuestao
    {
        public int IdAlunoProvaQuestao { get; set; }
        public bool Nota { get; set; }

        [HttpPost]
        public void AtribuirValorATodasAsRespostasDoAlunoDeUmaProva([FromBody] NotaAlunoProvaQuestao[] notas)
        {
            //....
        }


        [HttpGet]
        public bool ObterNotaFinalDoAlunoNaProva(int idAluno, int idProva)
        {
            Prova prova = new Prova();
            Aluno aluno = new Aluno();

            using (SqlCommand cmd = new SqlCommand(@"SELECT AlunoProvaQuestao FROM 
                                                    idAluno = @idAluno, 
                                                    idProvaQuestao = @idProvaQuestao"))//, conn))
            {
                cmd.Parameters.AddWithValue("@idAluno", aluno.IdAluno);
                cmd.Parameters.AddWithValue("@idProvaQuesta", prova.IdProva);
                

                return (cmd.ExecuteNonQuery() == 1);
            }
        }   
    }
}