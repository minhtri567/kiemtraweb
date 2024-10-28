using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kiemtraweb
{
    public partial class News_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["newsId"] != null)
                {
                    int newsId = Convert.ToInt32(Request.QueryString["newsId"]);
                    LoadNewsDetail(newsId);
                    UpdateViewCount(newsId);
                }
            }
        }
        private void LoadNewsDetail(int newsId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["kiemtrawebEntities1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT n.PK_iNewsID, n.sTitle, n.sAbstract, n.sContent, n.tPostedDate, n.iViewTimes, c.sCategoryName " +
                               "FROM tblNews n " +
                               "JOIN tblNewsCategory nc ON n.PK_iNewsID = nc.FK_iNewsID " +
                               "JOIN tblCategories c ON nc.FK_iCategoryID = c.PK_CategoryID " +
                               "WHERE n.PK_iNewsID = @newsId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@newsId", newsId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTitle.InnerText = reader["sTitle"].ToString();
                    lblAbstract.InnerText = reader["sAbstract"].ToString();
                    lblContent.InnerText = reader["sContent"].ToString();
                    lblPostedDate.InnerText = Convert.ToDateTime(reader["tPostedDate"]).ToString("dd/MM/yyyy");
                    lblViewTimes.InnerText = reader["iViewTimes"].ToString();
                    lblCategory.InnerText = reader["sCategoryName"].ToString();
                }
                reader.Close();
            }
        }

        private void UpdateViewCount(int newsId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["kiemtrawebEntities1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE tblNews SET iViewTimes = iViewTimes + 1 WHERE PK_iNewsID = @newsId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@newsId", newsId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}