using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DProveedor
    {

        private int _id_prov;
        private string _nombre_proveedor;
        private string _telefono;

        //Getters y Setters

        public int Id_prov
        {
            get
            {
                return _id_prov;
            }

            set
            {
                _id_prov = value;
            }
        }

        public string Nombre_proveedor
        {
            get
            {
                return _nombre_proveedor;
            }

            set
            {
                _nombre_proveedor = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        //Constructor Vacio
        public DProveedor()
        {

        }

        //Constructor con parametros

        public DProveedor(int id_prov, string nombre_proveedor, string telefono)
        {
            this.Id_prov = id_prov;
            this.Nombre_proveedor = nombre_proveedor;
            this.Telefono = telefono;

        }

        // Metodo para insertar

        public string Insertar(DProveedor Proveedor)
        {
            string query = "insert into Proveedor values(@nombre_proveedor, @telefono)";
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
                SqlCmd.Parameters.AddWithValue("@nombre_proveedor", Nombre_proveedor);
                SqlCmd.Parameters.AddWithValue("@telefono", Telefono);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Proveedor Ingresado" : "No se pudo Ingresar el Proveedor";
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

        public string Modificar(DProveedor Proveedor)
        {
            string query = "update Proveedor set nombre_proveedor = @nombre_proveedor, telefono = @telefono where id_prov = @id_prov";
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
                SqlCmd.Parameters.AddWithValue("@id_prov", Id_prov);
                SqlCmd.Parameters.AddWithValue("@nombre_proveedor", Nombre_proveedor);
                SqlCmd.Parameters.AddWithValue("@telefono", Telefono);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Proveedor Modificado" : "No se pudo Modificar el Proveedor";
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

        public string Eliminar(DProveedor Proveedor)
        {
            string query = "delete from Productos where id_prov = @id_prov";
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
                SqlCmd.Parameters.AddWithValue("@id_prov", Id_prov);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Proveedor Eliminado" : "No se pudo Eliminar el Proveedor";
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

            string query = "select * from Proveedor";
            DataTable DtResultado = new DataTable("proveedor");
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
