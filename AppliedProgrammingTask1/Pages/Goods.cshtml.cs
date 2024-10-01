using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class GoodsModel : PageModel
    {
        public bool hasData = false;
        public string date = "";
        public string numberOfItem = "";
        public string category = "";
        public string newcategory = "";

        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string query = "";

        public void OnGet()
        {
        }
        public void OnPost()
        {
            try
            {

                hasData = true;
                date = Request.Form["fDate"];
                numberOfItem = Request.Form["txtNoItem"];
                category = Request.Form["Cat"];
                newcategory = "";
                if (category.Equals("Other"))
                {
                    newcategory = Request.Form["txtNewCat"];
                }

                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                query = "INSERT INTO GOODS VALUES('" + numberOfItem + "','" + category + "','" + newcategory + "','" + date + "','" + LoginModel.user_ID + "')";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                TempData["good"] = "Data Is captured";
                sqlConnect.Close();
            }
            catch
            {
                TempData["good"] = "Login first";
            }

        }
    }
}
