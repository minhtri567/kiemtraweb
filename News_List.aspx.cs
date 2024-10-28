using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kiemtraweb
{
    public partial class News_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoryId = Convert.ToInt32(Request.QueryString["categoryId"]);
                LoadNews(categoryId);
            }
        }
        private void LoadNews(int categoryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["kiemtrawebEntities1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                n.PK_iNewsID, 
                n.sTitle, 
                n.sAbstract, 
                n.tPostedDate
            FROM 
                tblNews n
            JOIN 
                tblNewsCategory nc ON n.PK_iNewsID = nc.FK_iNewsID
            JOIN 
                tblCategories c ON nc.FK_iCategoryID = c.PK_CategoryID
            WHERE 
                c.PK_CategoryID = @categoryId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Bind dữ liệu vào GridView
                        GridViewNews.DataSource = reader;
                        GridViewNews.DataBind();
                    }
                }
            }
        }

        protected void GridViewNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int newsId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("News_Detail.aspx?newsId=" + newsId);
            }
        }
    }
}