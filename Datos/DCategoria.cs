using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class DCategoria
    {
        private int _id_categoria;
        private string _nombre;

        public int Id_categoria
        {
            get
            {
                return _id_categoria;
            }

            set
            {
                _id_categoria = value;
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
        public DCategoria()
        {

        }

        //Constructor con parametros

        public DCategoria(int id_categoria, string nombre)
        {
            this.Id_categoria = id_categoria;
            this.Nombre = nombre;
        }

        // Metodo para insertar

        public string Insertar(DCategoria Categoria)
        {
            string query = "insert into Categoria values(@nombre)";
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
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Categoria Ingresada" : "No se pudo Ingresar la Categoria";
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
        
        //Metodo para modificar
        public string Modificar(DCategoria Categoria)
        {
            
            string query = "update Categoria set nombre=@nombre where id_categoria = @id_categoria";
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
                SqlCmd.Parameters.AddWithValue("@id_categoria", Id_categoria);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Categoria Modificada" : "No se pudo Modificar la Categoria";
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

        //Metodo para eliminar
        public string Eliminar(DCategoria Categoria)
        {

            string query = "delete from Categoria where id_categoria = @id_categoria";
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
                SqlCmd.Parameters.AddWithValue("@id_categoria", Id_categoria);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Categoria Eliminada" : "No se pudo Eliminar la Categoria";
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

            string query = "select * from categoria order by nombre";
            DataTable DtResultado = new DataTable("categoria");
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
                Console.WriteLine(ex);
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

        

 

