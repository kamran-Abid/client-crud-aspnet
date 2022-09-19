using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Crud_store.Pages.Clients
{
    public class checkdelModel : PageModel
    {
        //public String error_msg = "";
        //public String id = "0";
        //public void OnGet()
        //{
        //    try
        //    {
        //        id = Request.Query["id"];
        //        String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=crudStore;Integrated Security=True";
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            String sql = "DELETE FROM clients WHERE id=@id";

        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@id", id);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }


        //        error_msg = "Data deleted successfully...";
        //        // Response.Redirect("/Clients/Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        error_msg = ex.ToString();
        //        return;
        //    }
        //}

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
    }
}
