using Dapper;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class MenuUsuarioRepository : BaseRepository<Menu>, IMenuUsuarioRepository
    {
        private readonly IdentificationBdContext _identificationBdContext;
        public MenuUsuarioRepository(IdentificationBdContext context) : base(context) { 
            _identificationBdContext = context;

        }

        public async Task<IEnumerable<Menu>> GetMenuUsuario(int rut, int idApp)
        {
            
            var paramRut = new SqlParameter("@Rut", System.Data.SqlDbType.Int);
            var paramIdApp = new SqlParameter("@IdApp", System.Data.SqlDbType.Int);
            paramRut.Value = rut;
            paramIdApp.Value = idApp;

            return await _identificationBdContext.Menus.FromSqlRaw("EXEC dbo.pr_s_MenuUsuario @Rut, @IdApp", paramRut, paramIdApp).ToListAsync();
        }

        public async Task<IEnumerable<Menu>> GetMenuUsuarioDapper(int rut, int idApp)
        {
            var context = new SqlConnection(_identificationBdContext.Database.GetConnectionString());

            try
            {
                context.Open();
                var result = await context.QueryAsync<Menu>("dbo.pr_s_MenuUsuario", new { Rut = rut, IdApp = idApp }, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
