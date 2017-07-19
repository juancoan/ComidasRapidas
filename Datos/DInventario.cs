using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Datos
{
    public class DInventario
    {
        private int _id;
        private string _serie;
        private int _id_producto;
        private int _cod_sucursal;
        private SqlDateTime _fecha_entrada_surcursal;
        private SqlDateTime _fecha_consumo;
        private SqlDateTime _fecha_entrada_cat_global;
        private SqlDateTime _fecha_vencimiento;
        private int _cod_user;
        private Boolean _disponibilidad;

        //Getters y Setters

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Serie
        {
            get
            {
                return _serie;
            }

            set
            {
                _serie = value;
            }
        }

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

        public SqlDateTime Fecha_entrada_surcursal
        {
            get
            {
                return _fecha_entrada_surcursal;
            }

            set
            {
                _fecha_entrada_surcursal = value;
            }
        }

        public SqlDateTime Fecha_consumo
        {
            get
            {
                return _fecha_consumo;
            }

            set
            {
                _fecha_consumo = value;
            }
        }

        public SqlDateTime Fecha_entrada_cat_global
        {
            get
            {
                return _fecha_entrada_cat_global;
            }

            set
            {
                _fecha_entrada_cat_global = value;
            }
        }

        public SqlDateTime Fecha_vencimiento
        {
            get
            {
                return _fecha_vencimiento;
            }

            set
            {
                _fecha_vencimiento = value;
            }
        }

        public int Cod_user
        {
            get
            {
                return _cod_user;
            }

            set
            {
                _cod_user = value;
            }
        }

        public bool Disponibilidad
        {
            get
            {
                return _disponibilidad;
            }

            set
            {
                _disponibilidad = value;
            }
        }




        //Constructor Vacio
        public DInventario()
        {

        }

        //Constructor con Parametros
        //Aunque en algunos campos en la base de datos
        //sean nulos se va a usar el tipo datetime.minvalue() como sentinela
        //para discernir de aquellos que no se han ingresado campos.
        
        public DInventario(int id, string serie, int id_producto, int cod_sucursal, SqlDateTime fecha_entrada_sucursal, SqlDateTime fecha_consumo, SqlDateTime fecha_entrada_cat_global, SqlDateTime fecha_vencimiento, int cod_user, Boolean disponibilidad)
        {
            this.Id = id;
            this.Serie = serie;
            this.Id_producto = id_producto;
            this.Cod_sucursal = cod_sucursal;
            this.Fecha_entrada_surcursal = fecha_entrada_sucursal;
            this.Fecha_consumo = fecha_consumo;
            this.Fecha_entrada_cat_global = fecha_entrada_cat_global;
            this.Fecha_vencimiento = fecha_vencimiento;
            this.Cod_user = cod_user;
            this.Disponibilidad = disponibilidad;
        }

        // Metodo para Insertar
        //Para evitar duplicados, el valor unico es el numero de serie
        //Por lo tanto en la base de datos tiene un constraint de unique en ese campo

        public string Insertar(DInventario Inventario)
        {
            string query = "insert into Inventario values(@serie,@id_producto,@cod_sucursal,@fecha_entrada_sucursal,@fecha_consumo,@fecha_entrada_cat_global,@fecha_vencimiento,@cod_user,@disponibilidad)";
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
                SqlCmd.Parameters.AddWithValue("@serie", Serie);
                SqlCmd.Parameters.AddWithValue("@id_producto", Id_producto);
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", Cod_sucursal);
                SqlCmd.Parameters.AddWithValue("@fecha_entrada_sucursal", Fecha_entrada_surcursal);
                SqlCmd.Parameters.AddWithValue("@fecha_consumo", Fecha_consumo);
                SqlCmd.Parameters.AddWithValue("@fecha_entrada_cat_global", Fecha_entrada_cat_global);
                SqlCmd.Parameters.AddWithValue("@fecha_vencimiento", Fecha_vencimiento);
                SqlCmd.Parameters.AddWithValue("@cod_user", Cod_user);
                SqlCmd.Parameters.AddWithValue("@disponibilidad", Disponibilidad);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Inventario Ingresado" : "No se pudo Ingresar el Inventario";
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

        //Metodo para Modificar

        public string Modificar(DInventario Inventario)
        {
            string query = "update Inventario set serie = @serie, id_producto = @id_producto, cod_sucursal = @cod_sucursal, fecha_entrada_sucursal = @fecha_entrada_sucursal, fecha_consumo = @fecha_consumo, fecha_entrada_cat_global = @fecha_entrada_cat_global, fecha_vencimiento = @fecha_vencimiento, cod_user = @cod_user, disponibilidad = @disponibilidad where id = @id";
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
                SqlCmd.Parameters.AddWithValue("@id", Id);
                SqlCmd.Parameters.AddWithValue("@serie", Serie);
                SqlCmd.Parameters.AddWithValue("@id_producto", Id_producto);
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", Cod_sucursal);
                SqlCmd.Parameters.AddWithValue("@fecha_entrada_sucursal", Fecha_entrada_surcursal);
                SqlCmd.Parameters.AddWithValue("@fecha_consumo", Fecha_consumo);
                SqlCmd.Parameters.AddWithValue("@fecha_entrada_cat_global", Fecha_entrada_cat_global);
                SqlCmd.Parameters.AddWithValue("@fecha_vencimiento", Fecha_vencimiento);
                SqlCmd.Parameters.AddWithValue("@cod_user", Cod_user);
                SqlCmd.Parameters.AddWithValue("@disponibilidad", Disponibilidad);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Inventario Modificado" : "No se pudo Modificar el Inventario";
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

        //Metodo para Eliminar

        public string Eliminar(DInventario Inventario)
        {
            string query = "delete from Inventario where id = @id";
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
                SqlCmd.Parameters.AddWithValue("@id", Id);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Inventario Eliminado" : "No se pudo Eliminar el Inventario";
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

            string query = "select * from Inventario";
            DataTable DtResultado = new DataTable("inventario");
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

        //Metodo para Mover el inventario del catalogo global a la sucursal

        public string mover_inventario_asucursal(int id, int cod_sucursal, SqlDateTime fecha_entrada_sucursal, int cod_user)
        {
            string query = "update Inventario set cod_sucursal = @cod_sucursal, fecha_entrada_sucursal = @fecha_entrada_sucursal, cod_user = @cod_user where id = @id";
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
                SqlCmd.Parameters.AddWithValue("@id", id);
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", cod_sucursal);
                SqlCmd.Parameters.AddWithValue("@fecha_entrada_sucursal", fecha_entrada_sucursal);
                SqlCmd.Parameters.AddWithValue("@cod_user", cod_user);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Inventario Movido" : "No se pudo Mover el Inventario";
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

        //Metodo para consumir inventario

        public string consumir_inventario(int id, SqlDateTime fecha_consumo, int cod_user)
        {
            string query = "update Inventario set fecha_consumo = @fecha_consumo, cod_user = @cod_user, disponibilidad = 0 where id = @id";
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
                SqlCmd.Parameters.AddWithValue("@id", id);
                SqlCmd.Parameters.AddWithValue("@fecha_consumo", fecha_consumo);
                SqlCmd.Parameters.AddWithValue("@cod_user", cod_user);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Inventario Consumido" : "No se pudo Consumir el Inventario";
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

        //Metodo para listar inventario que no ha sido asignado a ninguna sucursal

        public DataTable inventario_noasignado()
        {

            string query = @"select
                            a.id as Id, 
                            a.serie as Serie,
                            b.nombre as Nombre,
                            b.costo as Costo,
                            a.fecha_vencimiento as 'Fecha de Vencimiento',
                            c.nombre as Sucursal,
                            a.fecha_entrada_cat_global as 'Fecha de Ingreso',
                            d.username as 'Modificado por'
                            from inventario a
                            join productos b
                            on a.id_producto = b.id_producto
                            join sucursal c
                            on a.cod_sucursal = c.cod_sucursal
                            join usuarios d
                            on a.cod_user = d.cod_user
                            where a.cod_sucursal = 1";

                
            DataTable DtResultado = new DataTable("inventario");
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

        //Metodo que lista inventario consumido de todas las sucursales
        public DataTable inventario_consumido_global()
        {

            string query = @"select 
                            a.id as Id, 
                            a.serie as Serie,
                            b.nombre as Nombre,
                            b.costo as Costo,
                            a.fecha_vencimiento as 'Fecha de Vencimiento',
                            c.nombre as Sucursal,
                            a.fecha_entrada_cat_global as 'Fecha de Ingreso',
                            a.fecha_consumo as 'Fecha de Consumo',
                            d.username as 'Modificado por'
                            from inventario a 
                            join productos b
                            on a.id_producto = b.id_producto
                            join sucursal c
                            on a.cod_sucursal = c.cod_sucursal
                            join usuarios d
                            on a.cod_user = d.cod_user
                            where a.disponibilidad = 0";

            DataTable DtResultado = new DataTable("inventario");
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

        //Metodo que lista el inventario consumido por sucursal
        // Permite la creacion de listas inteligentes
        //Debe indicar el codigo de la sucursal
        //Tambien se utiliza el metodo para dar un corte del inventario local disponible


        public DataTable estado_inventario_local(int cod_sucursal, int disponibilidad)
        {

            string query = @"select 
                            a.id as Id, 
                            a.serie as Serie,
                            b.nombre as Nombre,
                            b.costo as Costo,
                            a.fecha_vencimiento as 'Fecha de Vencimiento',
                            c.nombre as Sucursal,
                            a.fecha_entrada_cat_global as 'Fecha de Ingreso',
                            a.fecha_consumo as 'Fecha de Consumo',
                            d.username as 'Modificado por'
                            from inventario a 
                            join productos b
                            on a.id_producto = b.id_producto
                            join sucursal c
                            on a.cod_sucursal = c.cod_sucursal
                            join usuarios d
                            on a.cod_user = d.cod_user
                            where a.disponibilidad = @disponibilidad
                            and a.cod_sucursal = @cod_sucursal";

            DataTable DtResultado = new DataTable("inventario");
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
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", cod_sucursal);
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
