using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using Datos;


namespace Negocio
{
    public class NUsuarios
    {

        //Constructor Vacio

        public NUsuarios()
        {

        }

        
        //Metodo para insertar
        //Cuando se registra un usuario, esta deshabilitado, por ello el false

        public string insertar(int cod_user, int cod_sucursal, string username, string password)
        {
            string respuesta = "";
            DUsuarios dusuarios = new DUsuarios(cod_user, cod_sucursal, username, password, false, false);
            respuesta = dusuarios.Insertar(dusuarios);
            return respuesta;
        }

        //Metodo para Modificar        

        public string modificar(int cod_user, int cod_sucursal, string username, string password, Boolean activo, Boolean admin)
        {
            string respuesta = "";
            DUsuarios dusuarios = new DUsuarios(cod_user, cod_sucursal, username, password, activo, admin);
            respuesta = dusuarios.Modificar(dusuarios);
            return respuesta;
        }

        //Metodo para Eliminar  

        public string eliminar(int cod_user, int cod_sucursal, string username, string password, Boolean activo, Boolean admin)
        {
            string respuesta = "";
            DUsuarios dusuarios = new DUsuarios(cod_user, cod_sucursal, username, password, activo, admin);
            respuesta = dusuarios.Eliminar(dusuarios);
            return respuesta;
        }


        //Metodo para Activar Usuario

        public string activar(int cod_user, int cod_sucursal, string username, string password, Boolean activo, Boolean admin)
        {
            string respuesta = "";
            DUsuarios dusuarios = new DUsuarios(cod_user, cod_sucursal, username, password, activo, admin);
            respuesta = dusuarios.Activar(dusuarios);
            return respuesta;
        }

        //Metodo que lista la tabla de la base de datos (Para efectos de administracion)

        public DataTable listar_tabla()
        {
            DataTable datatable = new DataTable();
            DUsuarios dusuarios = new DUsuarios();
            datatable = dusuarios.listar();
            return datatable;
        }

        public Boolean autenticar_usuario(string username, string password, Boolean admin)
        {
            DUsuarios dusuarios = new DUsuarios();
            Boolean autenticado = dusuarios.autenticar_usuario(username, password, admin);
            return autenticado;
        }




    }
}
