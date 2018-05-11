﻿using SistemaProvas.Models;
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
        string conexao = "Server=tcp:aulacloud.database.windows.net,1433;Initial Catalog=aulaCloud;Persist Security Info=False;User ID=gcoutinho@aulaCloud;Password=Coutinho20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [HttpPost]
        public void Criar([FromBody]Questao questao)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbQuestao (Nome, Enunciado) VALUES (@nome, @enunciado)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", questao.Nome);
                    cmd.Parameters.AddWithValue("@enunciado", questao.Enunciado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public bool Alterar([FromBody]Questao questao)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

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
        public bool Remover(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbQuestao WHERE IdQuestao = @id", conn))

                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }

        }

    }
}