using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string stcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\University\KiThuatThuongMaiDienTuASP.net_IS384\Project_study\BTH4\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string sql;
            //if (Context.Items["ml"] == null)
            //    sql = "select * from mathang";
            if (Request.QueryString["ml"] == null)
            {
                sql = "select * from mathang";
            }
            else
            {
                //string maloai = Context.Items["ml"].ToString();
                string maloai = Request.QueryString["ml"];
                sql = "select * from mathang where maloai = '"+ maloai+"'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList2.DataSource = dt;
                this.DataList2.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string mahang = ((ImageButton)sender).CommandArgument;
            //Context.Items["mh"] = mahang;
            //Server.Transfer("MatHangChiTiet.aspx");
            Response.Redirect("MatHangChiTiet.aspx?mh=" + mahang);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            //Context.Items["mh"] = mahang;
            //Server.Transfer("MatHangChiTiet.aspx");
            Response.Redirect("MatHangChiTiet.aspx?mh=" + mahang);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            //Context.Items["mh"] = mahang;
            //Server.Transfer("MatHangChiTiet.aspx");
            Response.Redirect("MatHangChiTiet.aspx?mh=" + mahang);
        }
    }
}