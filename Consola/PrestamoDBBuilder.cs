using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using ModeloDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public class PrestamoDBBuilder
    {
        const string DBTipo = "DBTipo";
        enum DBTipoConn { SqlServer, Postgres, Memoria }
        static PrestamoDB db;

        public static PrestamoDB Crear()
        {
            // Lee la configuración acerca de qué base usar del archivo App.config
            string dbtipo = ConfigurationManager.AppSettings[DBTipo];
            string conn = ConfigurationManager.ConnectionStrings[dbtipo].ConnectionString;
            // Construye la conección acorde con el tipo
            DbContextOptions<PrestamoDB> contextOptions;
            switch (dbtipo)
            {
                case nameof(DBTipoConn.SqlServer):
                    contextOptions = new DbContextOptionsBuilder<PrestamoDB>()
                        .UseSqlServer(conn)
                        .Options;
                    break;
                case nameof(DBTipoConn.Postgres):
                    contextOptions = new DbContextOptionsBuilder<PrestamoDB>()
                        .UseNpgsql(conn)
                        .Options;
                    break;
                default: // Por defecto usa la memoria como base de datos
                    contextOptions = new DbContextOptionsBuilder<PrestamoDB>()
                        .UseInMemoryDatabase(conn)
                        .Options;
                    break;
            }

            db = new PrestamoDB(contextOptions);

            return db;
        }
    }
}