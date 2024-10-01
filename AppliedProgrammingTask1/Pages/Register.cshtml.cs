using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class RegisterModel : PageModel
    {
        public bool hasData = false;
        public string first_name = "";
        public string second_name = "";
        public string gender = "";
        public string email = "";
        public string password = "";

        //connections 
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public static string query = "";

        public void OnPost()
        {
            try
            {
                hasData = true;
                first_name = Request.Form["fname"];
                second_name = Request.Form["sname"];
                gender = Request.Form["txtGender"];
                email = Request.Form["txtEmail"];
                password = Request.Form["txtPassword"];

                Connection conn = new Connection();
                Hash hash = new Hash();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                query = "Select* from Logins where EMAIL='"+email+"'";
                sqlCommand = new SqlCommand(query,sqlConnect);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable row=new DataTable();
                adapter.Fill(row);
                if(row.Rows.Count>0)
                {
                    TempData["Register"] = "Go to Login, You already exist.";
                }
                else
                {
                    query = "INSERT INTO LOGINS VALUES('" + first_name + "','" + second_name + "','" + gender + "','" + email + "','" + hash.getHash(password) + "')";
                    sqlCommand = new SqlCommand(query, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    TempData["Register"] = "We are thrilled to have you as a part of our community. Your account has been successfully created.";
                }
                 
                sqlConnect.Close();
            }
            catch (Exception ex) 
            {
                TempData["Register"]= ex.ToString();
            }
        }
        public void OnGet()
        {

        }
    }

}
