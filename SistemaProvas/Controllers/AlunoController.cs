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
    public class AlunoController : ApiController
    {
        string conexao = "Server=tcp:aulacloud.database.windows.net,1433;Initial Catalog=aulaCloud;Persist Security Info=False;User ID=gcoutinho@aulaCloud;Password=Coutinho20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [HttpPost]
        public void CriarAluno([FromBody] Aluno aluno)
        {

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbAluno (Nome, Email, Ra) VALUES (@nome, @email, @ra)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@email", aluno.Email);
                    cmd.Parameters.AddWithValue("@ra", aluno.Ra);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        [HttpPost]
        public bool EditarAluno([FromBody] Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE tbAluno SET 
                    Nome=@nome, 
                    Email=@email, 
                    Ra=@ra 
                    WHERE IdAluno=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@email", aluno.Email);
                    cmd.Parameters.AddWithValue("@ra", aluno.Ra);

                    cmd.Parameters.AddWithValue("@id", aluno.IdAluno);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }


        }

        [HttpPost]
        //Remover via Body
        public bool DeletarAluno([FromBody] Aluno aluno)
        {

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM tbAluno 
                    WHERE IdAluno=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", aluno.IdAluno);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }

        }

        [HttpGet]
        //Remover via Header
        public bool RemoverAluno(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM tbAluno
                    WHERE IdAluno = @id", conn))

                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return (cmd.ExecuteNonQuery() == 1);
                }
            }

        }

    }
}