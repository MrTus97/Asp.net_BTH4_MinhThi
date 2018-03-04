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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string stcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\University\KiThuatThuongMaiDienTuASP.net_IS384\Project_study\BTH4\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True";
        private void DocDL()
        {
            string ten = "admin";// Request.Cookies["tendangnhap"].Value;
            try
            {
                string sql = "select donhang.mahang,tenhang,mota,dongia,soluong,soluong*dongia as thanhtien from donhang,mathang where mathang.mahang=donhang.mahang and tendangnhap ='" + ten + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                //tính tổng thành tiền, duyệt qua datatable
                double tong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double thanhtien = double.Parse(dt.Rows[i]["thanhtien"].ToString());
                    tong += thanhtien;
                }
                this.Label1.Text = "Tổng thành tiền là : " + tong + " đồng";
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            //if (Request.Cookies["tendangnhap"] == null) return;
            this.DocDL();
        }

        

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["tendangnhap"] == null) return;
            string ten = "admin";// Request.Cookies["tendangnhap"].Value;
            string mahang = ((LinkButton)sender).CommandArgument;
            string sql = "delete from donhang where mahang = '" + mahang + "' and tendangnhap = '" + ten + "'";
            SqlConnection con = new SqlConnection(stcn);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
            this.DocDL();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["tendangnhap"] == null) return;
            Button sua = (Button)sender;
            string mahang = sua.CommandArgument;
            GridViewRow item = (GridViewRow)sua.Parent.Parent;
            string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
            string ten = "admin";// Request.Cookies["tendangnhap"].Value;
            SqlConnection con = new SqlConnection(stcn);
            string sql = "update donhang set soluong = " + soluong + " where tendangnhap = '" + ten + "' and mahang = '" + mahang + "'";
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
            this.DocDL();
        }
    }
}