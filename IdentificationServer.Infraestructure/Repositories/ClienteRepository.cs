using Dapper;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces.Repositories;
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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IdentificationBdContext _identificationBdContext;

        public ClienteRepository(IdentificationBdContext context)
        {
            _identificationBdContext = context;
        }

        public async Task<bool> CargarProcesoClientes(Cliente cliente)
        {
            var context = new SqlConnection(_identificationBdContext.Database.GetConnectionString());

            context.Open();
            string sqlQuery = "INSERT INTO [dbo].[Cliente]([CodigoCliente],[Empresa],[NombreCliente],[Cargo],[Direccion],[Ciudad],[Region],[CodigoPostal],[Pais],[Telefono],[Fax]) " +
                "VALUES (@CodigoCliente,@Empresa,@NombreCliente,@Cargo,@Direccion,@Ciudad,@Region,@CodigoPostal,@Pais,@Telefono,@Fax)";

            var query = await context.ExecuteAsync(sqlQuery, cliente);

            if (query == 0)
            {
                return false;
            }
            return true;
        }
    }
}
