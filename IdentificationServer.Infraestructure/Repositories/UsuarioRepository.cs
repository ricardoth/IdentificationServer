using Dapper;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IdentificationBdContext _identificationBdContext;
        public UsuarioRepository(IdentificationBdContext context) 
        {
            _identificationBdContext = context;
        }

        public async Task<Usuario> GetInfoUsuario(string user)
        {
            var context = new SqlConnection(_identificationBdContext.Database.GetConnectionString());

            var parameters = new Dictionary<string, object>();
            parameters.Add("User", user);

            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(parameters);

            try
            {
                context.Open();
                var result = await context.QueryFirstAsync<Usuario>("pr_s_InfoUsuario", dbParams, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //agregar log
                throw;
            }

        }
    }
}
