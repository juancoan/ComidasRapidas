using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DSucursal
    {
        private int _cod_sucursal;
        private string _nombre;

        //Getters y Setters 
        public int Cod_sucursal
        {
            get
            {
                return _cod_sucursal;
            }

            set
            {
                _cod_sucursal = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        //Constructor Vacio

        public DSucursal()
        {

        }
        
        //Constructor con Parametros

        public DSucursal(int cod_sucursal, string nombre)
        {
            this.Cod_sucursal = cod_sucursal;
            this.Nombre = nombre;

        }

        // Metodo para insertar

        public string Insertar(DSucursal Sucursal)
        {
            string query = "insert into Sucursal values(@nombre)";
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                //Abrimos la conexion
                SqlCon.ConnectionString = Conexion.Cnx;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = query;
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.AddWithValue("@nombre", Nombre);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Sucursal Ingresada" : "No se pudo Ingresar la Sucursal";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //Al final cerrar la conexion al SQL
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        // Metodo para Modificar

        public string Modificar(DSucursal Sucursal)
        {
            string query = "update Sucursal set nombre = @nombre where cod_sucursal = @cod_sucursal";
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                //Abrimos la conexion
                SqlCon.ConnectionString = Conexion.Cnx;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = query;
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", Cod_sucursal);
                SqlCmd.Parameters.AddWithValue("@nombre", Nombre);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Sucursal Modificada" : "No se pudo Modificar la Sucursal";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //Al final cerrar la conexion al SQL
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        // Metodo para Eliminar

        public string Eliminar(DSucursal Sucursal)
        {
            string query = "delete from Sucursal where cod_sucursal = @cod_sucursal";
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                //Abrimos la conexion
                SqlCon.ConnectionString = Conexion.Cnx;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = query;
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", Cod_sucursal);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Sucursal Eliminada" : "No se pudo Eliminar la Sucursal";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //Al final cerrar la conexion al SQL
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        //Metodo para listar
        public DataTable listar()
        {

            string query = "select * from Sucursal";
            DataTable DtResultado = new DataTable("sucursal");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                //Abrimos la conexion
                SqlCon.ConnectionString = Conexion.Cnx;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = query;
                SqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                //Al final cerrar la conexion al SQL
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return DtResultado;
        }

    }
}
