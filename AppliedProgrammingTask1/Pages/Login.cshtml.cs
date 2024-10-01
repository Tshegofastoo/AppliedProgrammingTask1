using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class LoginModel : PageModel
    {

        public bool hasData = false;
        public string email = "";
        public string password = "";
        public static int user_ID;
        public static string userName="";

        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string query = "";

        public void OnPost()
        {
            try
            {
                hasData = true;
                email = Request.Form["txtEmail"];
                password = Request.Form["txtPassword"];
                Connection conn = new Connection();
                Hash hash = new Hash();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                query = "SELECT* FROM LOGINS WHERE EMAIL='" + email + "' AND ACCOUNT_PASSWORD='" + hash.getHash(password) + "'";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                if (sqlData.Read())
                {
                    user_ID = Convert.ToInt32(sqlData["LOGIN_ID"].ToString());
                    userName = sqlData["EMAIL"].ToString();
                    TempData["Login"] = "Welcome   "+ sqlData["FIRST_NAME"].ToString()+"   "+ sqlData["SECOND_NAME"].ToString()+"  !";
                }
                else
                {
                    TempData["Login"] = "We're sorry, but the username or password you entered is incorrect.";
                }
                sqlConnect.Close();
            }
            catch (Exception ex) 
            {
                TempData["Login"] = ex.ToString();
            }

            
        }
    }
}
