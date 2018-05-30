using SistemaProvas.BD;
using SistemaProvas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaProvas.Controllers
{
    public class QuestaoController : ApiController
    {
        [HttpPost]
        public void CriarQuestao([FromBody]Questao questao)
        {
            using (SqlConnection conn = SqlConn.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbQuestao (Nome, Enunciado) VALUES (@Nome, @Enunciado)", conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", questao.Nome);
                    cmd.Parameters.AddWithValue("@Enunciado", questao.Enunciado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public bool AlterarQuestao([FromBody]Questao questao)
        {
            using (SqlConnection conn = SqlConn.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tbQuestao SET Nome = @nome, Enunciado = @enunciado WHERE IdQuestao = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", questao.Nome);
                    cmd.Parameters.AddWithValue("@enunciado", questao.Enunciado);
                    cmd.Parameters.AddWithValue("@id", questao.IdQuestao);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }
        }

        [HttpGet]
        //Remover via Header
        public bool RemoverQuestao(int id)
        {
            using (SqlConnection conn = SqlConn.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbQuestao WHERE IdQuestao = @id", conn))

                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }

        }

    }
}