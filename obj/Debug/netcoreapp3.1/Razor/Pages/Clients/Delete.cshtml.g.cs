#pragma checksum "D:\ZK Space\ASPNET practice\Crud store\Pages\Clients\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f829148e671aa5696aecf78e36b43e540ff8dbc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Crud_store.Pages.Clients.Pages_Clients_Delete), @"mvc.1.0.razor-page", @"/Pages/Clients/Delete.cshtml")]
namespace Crud_store.Pages.Clients
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\ZK Space\ASPNET practice\Crud store\Pages\_ViewImports.cshtml"
using Crud_store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ZK Space\ASPNET practice\Crud store\Pages\Clients\Delete.cshtml"
using System.Data.SqlClient;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f829148e671aa5696aecf78e36b43e540ff8dbc4", @"/Pages/Clients/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e058833f67284ad49df0894040a605021e9846a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Clients_Delete : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script>\r\n    alert(\"Running delete...\");\r\n</script>\r\n");
#nullable restore
#line 6 "D:\ZK Space\ASPNET practice\Crud store\Pages\Clients\Delete.cshtml"
   
    try
    {
        String id = Request.Query["id"];

        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=crudStore;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            String sql = "DELETE FROM clients WHERE id=@id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
    catch(Exception ex)
    {
        Response.Redirect("/Index");
        return;
    }
    Response.Redirect("/Clients/Index");

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Clients_Delete> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Clients_Delete> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Clients_Delete>)PageContext?.ViewData;
        public Pages_Clients_Delete Model => ViewData.Model;
    }
}
#pragma warning restore 1591
