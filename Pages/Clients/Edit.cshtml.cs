using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Crud_store.Pages.Clients
{
    public class EditModel : PageModel
    {
        public Client_info client_Info = new Client_info();
        public String error_msg = "";
        public String success_msg = "";
        public String id = "";
        public void OnGet()
        {
            id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=crudStore;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String sql = "SELECT * FROM clients WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                client_Info.id = "" + reader.GetInt32(0);
                                client_Info.name = reader.GetString(1);
                                client_Info.email = reader.GetString(2);
                                client_Info.phone = reader.GetString(3);
                                client_Info.address = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            client_Info.id = Request.Form["id"];
            client_Info.name = Request.Form["name"];
            client_Info.email = Request.Form["email"];
            client_Info.phone = Request.Form["phone"];
            client_Info.address = Request.Form["address"];

            if (client_Info.name.Length == 0 || client_Info.email.Length == 0 || client_Info.phone.Length == 0 || client_Info.address.Length == 0)
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
                    String sql = "UPDATE clients " +
                        "SET name=@name, email=@email, phone=@phone, address=@address " +
                        "WHERE(id=@id)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", client_Info.name);
                        cmd.Parameters.AddWithValue("@email", client_Info.email);
                        cmd.Parameters.AddWithValue("@phone", client_Info.phone);
                        cmd.Parameters.AddWithValue("@address", client_Info.address);
                        cmd.Parameters.AddWithValue("@id", client_Info.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = "Update query error " +  ex.Message;
                return;
            }

            // if Data save in database

            Response.Redirect("/Clients/Index");

        }

    }
}
