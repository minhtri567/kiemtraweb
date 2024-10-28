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
    public partial class Categories_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }
        private void LoadCategories()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["kiemtrawebEntities1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PK_CategoryID, sCategoryName FROM tblCategories", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewCategories.DataSource = dt;
                GridViewCategories.DataBind();
            }
        }

        protected void GridViewCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("News_List.aspx?categoryId=" + categoryId);
            }
        }
    }
}