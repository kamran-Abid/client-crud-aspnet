using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace Crud_store.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public Client_info client_Info = new Client_info();
        public String error_msg = "";
        public String success_msg = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            client_Info.name = Request.Form["name"];
            client_Info.email = Request.Form["email"];
            client_Info.phone = Request.Form["phone"];
            client_Info.address = Request.Form["address"];

            if(client_Info.name.Length == 0 || client_Info.email.Length == 0  || client_Info.phone.Length == 0 || client_Info.address.Length == 0)
            {
                error_msg = "Please fill all fields...";
                return;
            }

            // save new client in database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=crudStore;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String sql = "INSERT INTO clients " +
                        "(name, email, phone, address) VALUES" +
                        "(@name, @email, @phone, @address)";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", client_Info.name);
                        cmd.Parameters.AddWithValue("@email", client_Info.email);
                        cmd.Parameters.AddWithValue("@phone", client_Info.phone);
                        cmd.Parameters.AddWithValue("@address", client_Info.address);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                error_msg = ex.Message;
                return;
            }

            // if Data save in database

            client_Info.name = "";
            client_Info.email = "";
            client_Info.phone = "";
            client_Info.address = "";

            success_msg = "New client added successfully.";

            Response.Redirect("/Clients/Index");
        }
    }
}
