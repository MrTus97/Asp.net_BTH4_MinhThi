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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string stcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\University\KiThuatThuongMaiDienTuASP.net_IS384\Project_study\BTH4\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            label1.Text = " Đang chạy Page_Load";
            string ten = "admin";
            try
            {
                string sql = "select donhang.mahang, tenhang, mota, dongia soluong, soluong*dongia as thanhtien from donhang,mathang where mathang.mahang = donhang.mahang and tendangnhap = '" + ten + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();

                //Tính tổng thành tiền, duyệt DataTable
                double tong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double thanhtien = double.Parse(dt.Rows[i]["thanhtien"].ToString());
                    tong = tong + thanhtien;
                }
                this.label1.Text = "Tổng thành tiền :" + tong + "đồng";
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}