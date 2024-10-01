using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class View_Donate_MoneyModel : PageModel
    {
        public List<Money> getClass = new List<Money>();
        public string hasData;
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        SqlDataReader sqlData;
        public static string query = "";
        public void OnGet()
        {

            try
            {
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                query = "select* from MONEY_  where LOGIN_ID='" + LoginModel.user_ID + "'";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                while (sqlData.Read())
                {
                    getClass.Add(new Money(sqlData["MONEY_ID"].ToString(), sqlData["DATE_OF_DONATION"].ToString(), sqlData["AMOUNT"].ToString(), sqlData["ANONYMOUS_"].ToString(), sqlData["COMMENT"].ToString()));
                }
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
    public class Money
    {
        public string rowID;
        public string date;
        public string amount;
        public string anonymous;
        public string comment;

        public Money()
        {

        }
        public Money(string row, string date, string amount, string ano, string comm)
        {
            this.rowID = row;
            this.date = date;
            this.amount = amount;
            this.anonymous = ano;
            this.comment = comm;
        }

        public string getRow()
        {
            return rowID;
        }
        public string getDate()
        {
            return date;
        }
        public string getAmount()
        {
            return amount;
        }
        public string getAnonymous()
        {
            return anonymous;
        }
        public string getComment()
        {
            return comment;
        }
    }
}
