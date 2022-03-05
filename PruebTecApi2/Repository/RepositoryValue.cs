using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PruebTecApi2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebTecApi2.Repository
{
    public class RepositoryValue
    {
        private readonly string _connectionString;
        public RepositoryValue(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Conexion");
        }
        public async Task<List<VetenanoModel>> GetAllVeterano()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("spVeterano_GetAll", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<VetenanoModel>();
                    await sql.OpenAsync();
                    using(var reader=await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(
                                MapToValueVeterano(reader)
                                );
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<List<BeneficiosModel>> GetAllBeneficios()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spBeneficio_GetAll", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<BeneficiosModel>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(
                                MapToValueBeneficios(reader)
                                );
                        }
                    }
                    return response;
                }
            }
        }
        public async Task InsertVeterano(VetenanoModel vetenano)
        {
            using(SqlConnection sql=new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd=new SqlCommand("spVeterano_Insert"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@dui", vetenano.Dui));
                    cmd.Parameters.Add(new SqlParameter("@carnet", vetenano.Carnet));
                    cmd.Parameters.Add(new SqlParameter("@nombre", vetenano.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@nombre2", vetenano.Nombre2));
                    cmd.Parameters.Add(new SqlParameter("@apellido", vetenano.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@apellido2", vetenano.Apellido2));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task InsertBeneficioVeterano(VeteBeneficiosModel veteBeneficios)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spVeteranoBeneficio_Insert",sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdBeneficio", veteBeneficios.IdBeneficio));
                    cmd.Parameters.Add(new SqlParameter("@IdVeterano", veteBeneficios.IdVeterano));
                    
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        private VetenanoModel MapToValueVeterano(SqlDataReader reader)
        {
            return new VetenanoModel()
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Nombre = reader["Nombre"].ToString(),
                Nombre2 = reader["Nombre2"].ToString(),
                Apellido = reader["Apellido"].ToString(),
                Dui = reader["Dui"].ToString(),
                Carnet = reader["Carnet"].ToString(),
                Apellido2 = reader["Apellido2"].ToString()
            };
        }
        private BeneficiosModel MapToValueBeneficios(SqlDataReader reader)
        {
            return new BeneficiosModel()
            {
                IdBeneficios = Convert.ToInt64(reader["IdBeneficios"].ToString()),
                Nombre = reader["Nombre"].ToString(),
                Descripcion = reader["Descripcion"].ToString(),
            };
        }
    }
}
