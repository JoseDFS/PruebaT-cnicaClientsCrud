using PetaPoco;
using PruebaTécnica.Models;
using PruebaTécnica.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Controllers
{
    class ClienteController
    {
        public static List<Cliente> SeeClients()
        {
            var sql = "select * from clientes";

            var conn = new Database(Resources.cstring, "System.Data.SqlClient");

            var clients = conn.Query<Cliente>(sql).ToList();

            return clients;

        }

        public static bool InsertClient(Cliente cliente)
        {
            try
            {
                var conn = new Database(Resources.cstring, "System.Data.SqlClient");
                conn.Insert("clientes", "id",true, cliente);
                return true;
            }
            catch (Exception)
            {
            
                return false;
            }
        }

        public static bool UpdateClient(Cliente cliente)
        {
            try
            {
                var conn = new Database(Resources.cstring, "System.Data.SqlClient");
                conn.Update("clientes", "id", cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteClient(Cliente cliente)
        {
            try
            {
                var conn = new Database(Resources.cstring, "System.Data.SqlClient");
                conn.Delete(cliente);
                Console.WriteLine("borrado");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
