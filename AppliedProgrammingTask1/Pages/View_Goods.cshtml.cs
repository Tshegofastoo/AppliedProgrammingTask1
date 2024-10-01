using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class View_GoodsModel : PageModel
    {
        public List<Goods> getClass = new List<Goods>();
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
                query = "select* from GOODS  where LOGIN_ID='" + LoginModel.user_ID + "'";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                while (sqlData.Read())
                {
                    getClass.Add(new Goods(sqlData["GOODS_ID"].ToString(), sqlData["NUMBER_OF_ITEM"].ToString(), sqlData["CATEGORY"].ToString(), sqlData["NEW_CATEGORY"].ToString(), sqlData["DATE_ITEM"].ToString()));
                }
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
    public class Goods
    {
        public string ID;
        public string NumberOfItem;
        public string Category;
        public string NewCategory;
        public string date;
        public Goods()
        {

        }
        public Goods(string row, string date, string amount, string ann, string Ndate)
        {
            this.ID = row;
            this.NumberOfItem = date;
            this.Category = amount;
            this.NewCategory = ann;
            this.date = Ndate;
        }

        public string getRow()
        {
            return ID;
        }
        public string getNumber()
        {
            return NumberOfItem;
        }
        public string getCategory()
        {
            return Category;
        }
        public string getNewCategory()
        {
            return NewCategory;
        }
        public string getDate()
        {
            return date;
        }

    }
}
