using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DProductos
    {

        private int _id_producto;
        private string _nombre;
        private int _id_prov;
        private int _id_categoria;
        private string _marca;
        private decimal _costo;

        //Getters y Setters

        public int Id_producto
        {
            get
            {
                return _id_producto;
            }

            set
            {
                _id_producto = value;
            }
        }

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

        public string Marca
        {
            get
            {
                return _marca;
            }

            set
            {
                _marca = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return _costo;
            }

            set
            {
                _costo = value;
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

        public DProductos()
        {

        }

        //Constructor con Parametros

        public DProductos(int id_producto, string nombre, int id_prov, int id_categoria, string marca, decimal costo)
        {
            this.Id_producto = id_producto;
            this.Id_prov = id_prov;
            this.Id_categoria = id_categoria;
            this.Marca = marca;
            this.Costo = costo;
        }

        // Metodo para insertar

        public string Insertar(DProductos Productos)
        {
            string query = "insert into Productos values(@nombre, @id_prov, @id_categoria, @marca, @costo)";
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
                SqlCmd.Parameters.AddWithValue("@nombre", Nombre);
                SqlCmd.Parameters.AddWithValue("@id_categoria", Id_categoria);
                SqlCmd.Parameters.AddWithValue("@marca", Marca);
                SqlCmd.Parameters.AddWithValue("@costo", Costo);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Producto Ingresado" : "No se pudo Ingresar el Producto";
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

        public string Modificar(DProductos Productos)
        {
            string query = "update Productos set nombre = @nombre, id_prov = @id_prov, id_categoria = @id_categoria, marca = @marca, costo = @costo where id_producto = @id_producto";
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
                SqlCmd.Parameters.AddWithValue("@id_producto", Id_producto);
                SqlCmd.Parameters.AddWithValue("@nombre", Nombre);
                SqlCmd.Parameters.AddWithValue("@id_prov", Id_prov);
                SqlCmd.Parameters.AddWithValue("@id_categoria", Id_categoria);
                SqlCmd.Parameters.AddWithValue("@marca", Marca);
                SqlCmd.Parameters.AddWithValue("@costo", Costo);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Producto Modificado" : "No se pudo Modificar el Producto";
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

        public string Eliminar(DProductos Productos)
        {
            string query = "delete from Productos where id_producto = @id_producto";
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
                SqlCmd.Parameters.AddWithValue("@id_producto", Id_producto);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Producto Eliminado" : "No se pudo Eliminar el Producto";
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

            string query = "select * from productos";
            DataTable DtResultado = new DataTable("productos");
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

        //Metodo para listar de una forma mas ordenada, en lugar de utiilzar los ids
        // Se hacen joins a otras tablas para desplegar la informacion mas amigable
        public DataTable listar_ordenado()
        {

            string query = @"select
                            a.id_producto as Id,
                            a.nombre as Producto,
                            b.nombre_proveedor as Proveedor,
                            c.nombre as Categoria,
                            a.marca as Marca,
                            a.costo as Costo
                            from Productos a
                            join Proveedor b
                            on a.id_prov = b.id_prov
                            join Categoria c
                            on a.id_categoria = c.id_categoria";

            DataTable DtResultado = new DataTable("productos");
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
