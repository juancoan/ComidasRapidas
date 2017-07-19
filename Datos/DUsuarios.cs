using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuarios
    {
        private int _cod_user;
        private int _cod_sucursal;
        private string _username;
        private string _password;
        private Boolean _activo;
        private Boolean _admin;

        //Getters y Setters

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

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public bool Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                _activo = value;
            }
        }

        public bool Admin
        {
            get
            {
                return _admin;
            }

            set
            {
                _admin = value;
            }
        }

        //Constructor Vacio

        public DUsuarios()
        {

        }

        //Constructor con Parametros

        public DUsuarios(int cod_user, int cod_sucursal, string username, string password, Boolean activo, Boolean admin)
        {
            this.Cod_user = cod_user;
            this.Cod_sucursal = cod_sucursal;
            this.Username = username;
            this.Password = password;
            this.Activo = activo;
            this.Admin = admin;
        }

        // Metodo para insertar

        public string Insertar(DUsuarios Usuarios)
        {
            string query = "insert into Usuarios values(@cod_sucursal, @username, @password, @activo, @admin)";
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
                SqlCmd.Parameters.AddWithValue("@username", Username);
                SqlCmd.Parameters.AddWithValue("@password", Password);
                SqlCmd.Parameters.AddWithValue("@activo", Activo);
                SqlCmd.Parameters.AddWithValue("@admin", Admin);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Usuario Ingresado" : "No se pudo Ingresar Usuario";
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

        public string Modificar(DUsuarios Usuarios)
        {
            string query = "update Usuarios set cod_sucursal = @cod_sucursal, username = @username, password = @password, activo = @activo, admin = @admin where cod_user = @cod_user";
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
                SqlCmd.Parameters.AddWithValue("@cod_user", Cod_user);
                SqlCmd.Parameters.AddWithValue("@cod_sucursal", Cod_sucursal);
                SqlCmd.Parameters.AddWithValue("@username", Username);
                SqlCmd.Parameters.AddWithValue("@password", Password);
                SqlCmd.Parameters.AddWithValue("@activo", Activo);
                SqlCmd.Parameters.AddWithValue("@admin", Admin);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Usuario Modificado" : "No se pudo Modificar Usuario";
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

        public string Eliminar(DUsuarios Usuarios)
        {
            string query = "delete from Usuarios where cod_user = @cod_user";
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
                SqlCmd.Parameters.AddWithValue("@cod_user", Cod_user);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Usuario Eliminado" : "No se pudo Eliminar Usuario";
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

            string query = "select * from Usuarios";
            DataTable DtResultado = new DataTable("usuarios");
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

        // Metodo para Activar Usuario

        public string Activar(DUsuarios Usuarios)
        {
            string query = "update Usuarios set activo = true where cod_user = @cod_user";
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
                SqlCmd.Parameters.AddWithValue("@cod_user", Cod_user);
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Usuario Activado" : "No se pudo Activar Usuario";
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

        //El siguiente metodo autentica tanto si es usuario normal o 
        //Si es administrador, hay que enviar el metodo con 1 si es para
        // autenticar administradores o 0 si es para autenticar usuarios normales

        public Boolean autenticar_usuario(string username, string password, Boolean admin)
        {
            Boolean status = false;
            
            string query = "select * from Usuarios where username = @username and password = @password and admin = @admin";
            DataTable DtResultado = new DataTable("usuarios");
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
                SqlCmd.Parameters.AddWithValue("@username", username);
                SqlCmd.Parameters.AddWithValue("@password", password);
                SqlCmd.Parameters.AddWithValue("@admin", admin);

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

            if (DtResultado.Rows.Count == 1)
            {
                status = true;
            }

            return status;
        }


            
        

    }
}
