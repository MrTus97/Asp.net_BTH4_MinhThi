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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string stcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\University\KiThuatThuongMaiDienTuASP.net_IS384\Project_study\BTH4\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            //if (Request.Cookies["tendangnhap"] == null)
            //{

            //    //this.Label1.Text = "Bạn phải đăng nhập để xem mặt hàng";
            //    return;
            //}
            if (Request.QueryString["mh"] == null) return;
            string mahang = Request.QueryString["mh"];
            try
            {
                string sql = "select * from mathang where mahang='" + mahang + "'";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button mua = (Button)sender;
            string mahang = mua.CommandArgument.ToString();
            lbtest.Text = mahang;
            DataListItem item = (DataListItem)mua.Parent;
            string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
            //if (Request.Cookies["tendangnhap"] == null) return;
            //string ten = Request.Cookies["tendangnhap"].Value;
            string ten = "admin";
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(stcn);
                con.Open();
                String query = "select * from donhang where tendangnhap = '" + ten + "' and mahang = '" + mahang + "'";
                SqlCommand command = new SqlCommand(query, con);
               
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command = new SqlCommand("update donhang set soluong =soluong +" + soluong + " where tendangnhap = '" + ten + "' and mahang = '" + mahang + "'",con);
                    lbtest.Text = "Vào reader";
                }
                else
                {
                    reader.Close();
                    string sql = "insert into donhang values('"+ten+"','"+mahang+"','"+soluong+"')";
                    command = new SqlCommand(sql, con);
                    
                }
                command.ExecuteNonQuery();
                
            }
            catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Server.Transfer("GioHang.aspx");
        }
    }
}