using SistemaProvas.BD;
using SistemaProvas.Models;
using System.Data.SqlClient;
using System.Web.Http;

namespace SistemaProvas.Controllers
{
    public class AlunoController : ApiController
    {
        [HttpPost]
        public void CriarAluno([FromBody] Aluno aluno)
        {
            using (SqlConnection conn = SqlConn.Abrir())
            {
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
            using (SqlConnection conn = SqlConn.Abrir())
            {
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
            using (SqlConnection conn = SqlConn.Abrir())
            {
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
            using (SqlConnection conn = SqlConn.Abrir())
            {

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