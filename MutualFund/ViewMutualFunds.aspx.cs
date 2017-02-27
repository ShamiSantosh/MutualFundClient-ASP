using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MutualFund
{
    public partial class ViewMutualFunds : System.Web.UI.Page
    {
        //create a data table
        DataTable table = new DataTable("table_name");
        static StringBuilder MutualFundSearch = new StringBuilder();
        string connectionstring = ConfigurationManager.ConnectionStrings["MFConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {           

        }

        /// <summary>
        /// Autocomplete option for Text Box
        /// </summary>
        /// <returns></returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompanyNames()
        {
            List<string> companyNames = new List<string>();
            DataTable table = new DataTable();
            string connectionstring = ConfigurationManager.ConnectionStrings["MFConnectionString"].ConnectionString;
            string queryString = "SELECT [Mutual Fund Name] FROM [MutualFund].[dbo].[MutualFundNames]";

            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            adapter.Fill(table);
            connection.Close();
            foreach (DataRow row in table.Rows)
            {
                companyNames.Add(row.ItemArray[0].ToString());
            }
            return companyNames;           
        }

        /// <summary>
        /// Searches the mutual fund entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            GetMFDataFromService service = new GetMFDataFromService();
            table = service.getMutualFundDatatable();

            DataView dv = new DataView(table);
            GridView1.Visible = true;
            DateTime today = DateTime.Today;

            if (MutualFundSearch.Length == 0)
            {
                MutualFundSearch.Append("'"+TextBox1.Text+"'");
            }
            else
            {
                MutualFundSearch.Append(", '"+TextBox1.Text+"'");
            }

            dv.RowFilter = "[MutualFundName] IN (" + MutualFundSearch.ToString() + ") AND [ExpiryDate] > #" +today+ "#";
            DataTable newTable = dv.ToTable(true);
            if (newTable != null && newTable.Rows.Count > 0)
            {
                GridView1.DataSource = newTable;
                GridView1.DataBind();
            }
        }
        
        /// <summary>
        /// Add additional fields for search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Field_Button_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            GridView1.Visible = true;
        }

        /// <summary>
        /// Clear the TextBox and the result table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Clear_All_Button_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            GridView1.Visible = false;
            MutualFundSearch.Clear();
        }
    }

}