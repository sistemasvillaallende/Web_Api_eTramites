using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_eTramites.Entities
{
    public class DALBase
    {
        public static SqlConnection getConnection()
        {
            try
            {
                return new SqlConnection("Data Source=srv-sql;Initial Catalog=ETRAMITES;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlConnection GetConnectionSIIMVA()
        {
            try
            {
                return new SqlConnection("Data Source=srv-sql;Initial Catalog=SIIMVA;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long NewID(string tableName, string campo)
        {
            long id = 0;

            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT MAX("+campo+") As Mayor");
            strSQL.AppendLine("FROM " + tableName);

            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;

            cmd.Parameters.Add(new SqlParameter("@campo", campo));
            cmd.Parameters.Add(new SqlParameter("@table", tableName));

            try
            {
                cn = DALBase.getConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    id = dr.GetInt32(0);

                return id;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener el prox. código, " + ex.Message);
                throw ex;
                /*EventLog.WriteEntry("netLibraty - nvoCodigo ", ex.Message);*/
            }
            finally { cn.Close(); }
        }


        public static Int32 NewIDShort(string tableName, string campo)
        {
            int id = 0;

            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT MAX(" + campo + ") As Mayor");
            strSQL.AppendLine("FROM " + tableName);

            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;

            cmd.Parameters.Add(new SqlParameter("@campo", campo));
            cmd.Parameters.Add(new SqlParameter("@table", tableName));

            try
            {
                cn = DALBase.getConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    id = dr.GetInt32(0);

                return id+1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener el prox. código, " + ex.Message);
                throw ex;
                /*EventLog.WriteEntry("netLibraty - nvoCodigo ", ex.Message);*/
            }
            finally { cn.Close(); }
        }

        public static Int32 SigPaso(string tableName, string campo ,string campoid ,int idTabla)
        {
           int id = 0;

            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT ISNULL(MAX(" + campo + "),0) As Mayor");
            strSQL.AppendLine("FROM " + tableName +" Where " + campoid + "="+idTabla);

            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;

            //cmd.Parameters.Add(new SqlParameter("@campo", campo));
            //cmd.Parameters.Add(new SqlParameter("@table", tableName));

            try
            {
                cn = DALBase.getConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    id = dr.GetInt32(0);

                return id + 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener el prox. código, " + ex.Message);
                throw ex;
               
            }
            finally { cn.Close(); }
        }

        public static string ObtenerVenc(string periodo)
        {
            string  fecha = string.Empty;
            StringBuilder strSQL = new StringBuilder();
            strSQL.AppendLine(@" select  vencimiento=convert(varchar, vencimiento_ficticio2, 103) FROM VENCIMIENTOS_PERIODOS2 V 
                               where subsistema=5 and periodo=@periodo ");
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;
            cmd.Parameters.Add(new SqlParameter("@periodo", periodo));
            try
            {
                cn = DALBase.getConnection();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    fecha = dr.GetString(0);
                return fecha;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener la fecha, " + ex.Message);
                throw ex;
            }
            finally { cn.Close(); }
        }

        public static decimal ObtenerMontoOriginal(Int16 anio,string cod_zona)
        {
            decimal montoOriginal = 0;
            StringBuilder strSQL = new StringBuilder();
            strSQL.AppendLine(@"  SELECT tasa_basica
                                  FROM ZONAS_CEMENTERIO
                                  WHERE
                                  anio=@anio and
                                  cod_zona=@cod_zona  ");
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@cod_zona", cod_zona));
            try
            {
                cn = DALBase.getConnection();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    montoOriginal = dr.GetDecimal(0);
                return montoOriginal;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener la fecha, " + ex.Message);
                throw ex;
            }
            finally { cn.Close(); }
        }

        public static decimal ObtenerInteres(decimal montooriginal, DateTime vencimiento)
        {
            //using (SqlConnection cn = new SqlConnection("Cadena de conexión"))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT dbo.NombreFuncion(@Fecha)", cn);

            //    cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

            //    cn.Open();

            //    //En caso a función retorne un tipo bit
            //    return Convert.ToBoolean(cmd.ExecuteScalar());
            //}
            decimal recargo = 0;
            StringBuilder strSQL = new StringBuilder();
            strSQL.AppendLine(@" select dbo.[Calculo_Interes](@monto_original, @vencimiento  ");
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;
            cmd.Parameters.Add(new SqlParameter("@monto_original", montooriginal));
            cmd.Parameters.Add(new SqlParameter("@vencimiento", vencimiento));
            try
            {
                cn = DALBase.getConnection();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    recargo = dr.GetDecimal(0);
                return recargo;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener la fecha, " + ex.Message);
                throw ex;
            }
            finally { cn.Close(); }
        }

    }
}
