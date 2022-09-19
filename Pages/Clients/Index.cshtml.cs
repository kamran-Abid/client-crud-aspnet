using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Crud_store.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<Client_info> listClients = new List<Client_info>();
        public String error_msg = "";
        public void OnGet()
        {
            try
            {
                // Data Source=DESKTOP-P65HT14\SQLEXPRESS;Integrated Security=True
                // Data Source=.\sqlexpress;Initial Catalog=crudStore;Integrated Security=True

                // String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=crudStore;Integrated Security=True";
                String connectionString = @"Data Source=DESKTOP-P65HT14\SQLEXPRESS;initial Catalog=ZKAbid_Db; Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using(SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Client_info clients_info = new Client_info();
                                clients_info.id = "" + reader.GetInt32(0);
                                clients_info.name = reader.GetString(1);
                                clients_info.email = reader.GetString(2);
                                clients_info.phone = reader.GetString(3);
                                clients_info.address = reader.GetString(4);
                                clients_info.created_at = reader.GetDateTime(5).ToString();

                                listClients.Add(clients_info);

                                Console.WriteLine(listClients);
                            }
                        }
                    }
                }
               
            } 
            catch(Exception ex)
            {
                error_msg = "Db error "+ex.Message;
                return;
            }
        }
    }

    public class Client_info
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
        public String created_at;

    }
}
