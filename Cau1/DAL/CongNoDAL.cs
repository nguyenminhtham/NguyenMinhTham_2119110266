using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    class CongNoDAL:DBConnection
    {
        public List<CongNoDTO> ReadCongNo()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from CongNo", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CongNoDTO> lstCongNo = new List<CongNoDTO>();
            
            while (reader.Read())
            {
                CongNoDTO objCongNoDTO = new CongNoDTO();
                objCongNoDTO.makhachhang = reader["makhachhang"].ToString();
                objCongNoDTO.tenkhachhang = reader["tenkhachhang"].ToString();
                objCongNoDTO.sodienthoai = reader["sodienthoai"].ToString();
                objCongNoDTO.sotienno = decimal.Parse(reader["sotienno"].ToString());

                lstCongNo.Add(objCongNoDTO);
            }
            conn.Close();
            return lstCongNo;
        }

        public void XoaCongNo(CongNoDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from CongNo where makhachhang=@makhachhang", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cn.makhachhang));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void ThemCongNo(CongNoDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into CongNo values(@makhachhang,@tenkhachhang,@sodienthoai,@sotienno)", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cn.makhachhang));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cn.tenkhachhang));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cn.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cn.sotienno));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void SuaCongNo(CongNoDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "update CongNo set makhachhang = @makhachhang, tenkhachhang = @tenkhachhang, sodienthoai = @sodienthoai where @makhachhang = makhachhang", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cn.makhachhang));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cn.tenkhachhang));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cn.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cn.sotienno));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
