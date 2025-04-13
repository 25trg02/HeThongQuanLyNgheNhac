using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS.ThanhToan
{
    public class QLGoiDangKyBUS
    {
        Data data = new Data();

        // Hàm hiện thị dữ liệu lên GUI
        public DataTable HienThi()
        {
            string sql = "SELECT * FROM GoiDangKy";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        // Insert
        public void insertGoiDK(string id_goi, string ten, decimal gia, DateTime thoigian, string mota)
        {
            // string sql_add = $"INSERT INTO GoiDangKy VALUES(id_goi, ten, gia, thoigian, mota)" + $"$VALUES(N'{ten}', {gia}, '{thoigian}', N'{mota}')";
            string sql_add = $"INSERT INTO GoiDangKy (id_goi, ten, gia, thoigian, mota) " +
                 $"VALUES (N'{id_goi}',N'{ten}', {gia}, '{thoigian}', N'{mota}')";
            // Yeu cau DAL thuc hien
            data.excuteNonquery(sql_add);

        }

        // Search
        public DataTable searchGoiDK(string txt_search)
        {
            string sql_search = "SELECT * FROM GoiDangKy WHERE ten LIKE '%" + txt_search + "%' ";
            return data.GetTable(sql_search);

        }

        // Del
        public void DelGoiDK(string txt_tengoi)
        {
            string sql_delete = "DELETE FROM GoiDangKy WHERE ten = '" + txt_tengoi + "' ";
            data.excuteNonquery(sql_delete);
        }

        public void SuaGoiDk(string id_goi, string ten_GUI, decimal gia_GUI, DateTime thoigian_GUI, string mota_GUI)
        {
            string sql_update = "UPDATE GoiDangKy SET ten = N'" + ten_GUI + "', gia = '" + gia_GUI + "', thoigian = '" + thoigian_GUI + "', mota = '" + mota_GUI + "' WHERE id_goi = N'" + id_goi + "'   ";
            data.excuteNonquery(sql_update);


        }


    }
}
