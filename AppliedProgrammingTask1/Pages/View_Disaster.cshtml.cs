using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class View_DisasterModel : PageModel
    {
        public List<Disaster> getClass = new List<Disaster>();
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
                query = "select* from DISASTER  where LOGIN_ID='" + LoginModel.user_ID + "'";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                while (sqlData.Read())
                {
                    getClass.Add(new Disaster(sqlData["DISASTER_ID"].ToString(), sqlData["STARTING_DATE"].ToString(), sqlData["ENDING_DATE"].ToString(), sqlData["LOCATION"].ToString(), sqlData["DISASTER_DESCRIPTION"].ToString(), sqlData["AID"].ToString(), sqlData["NEW_AID"].ToString()));
                }
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

        }
    }
    public class Disaster
    {
        public string rowID;
        public string startDate;
        public string endDate;
        public string location;
        public string description;
        public string Aid;
        public string newAid;

        public Disaster()
        {

        }
        public Disaster(string row, string start, string end, string location, string description, string aid, string newAid)
        {
            this.rowID = row;
            this.startDate = start;
            this.endDate = end;
            this.location = location;
            this.description = description;
            this.Aid = aid;
            this.newAid = newAid;
        }

        public string getRow()
        {
            return rowID;
        }
        public string getStartDate()
        {
            return startDate;
        }
        public string getEndDate()
        {
            return endDate;
        }
        public string getLocation()
        {
            return location;
        }
        public string getDescription()
        {
            return description;
        }
        public string getAid()
        {
            return Aid;
        }
        public string getNewAid()
        {
            return newAid;
        }
    }

}
