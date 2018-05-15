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
    public class ProvaController : ApiController
    {
        [HttpPost]
        public void CriarProva([FromBody] Prova prova)
        {

            using (SqlConnection conn = SqlConn.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbProva (Nome, DataAplicacao) VALUES (@nome, @data)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", prova.Nome);
                    cmd.Parameters.AddWithValue("@data", prova.DataAplicacao);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        [HttpPost]
        public bool EditarProva([FromBody] Prova prova)
        {
            using (SqlConnection conn = SqlConn.Abrir())
            {

                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE tbProva SET 
                    Nome=@nome, 
                    DataAplicacao=@data 
                    WHERE IdProva=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", prova.Nome);
                    cmd.Parameters.AddWithValue("@data", prova.DataAplicacao);

                    cmd.Parameters.AddWithValue("@id", prova.IdProva);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }


        }

        [HttpGet]
        //Remover via Header
        public bool RemoverProva(int id)
        {
            using (SqlConnection conn = SqlConn.Abrir())
            {

                using (SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM tbProva
                    WHERE IdProva = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }

        }


        [HttpPost]
        public void AssociarQuestaoProva([FromBody] ProvaQuestao provaQuestao)
        {

            using (SqlConnection conn = SqlConn.Abrir())
                
            {
                //(8, 1, 101)
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbProvaQuestao (Valor, IdProva, IdQuestao) VALUES (@Valor, @IdProva, @IdQuestao)", conn))
                {
                    cmd.Parameters.AddWithValue("@Valor", provaQuestao.Valor);
                    cmd.Parameters.AddWithValue("@IdProva", provaQuestao.IdProva);
                    cmd.Parameters.AddWithValue("@IdQuestao", provaQuestao.IdQuestao);

                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}