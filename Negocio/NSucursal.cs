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
    public class NSucursal
    {
        //Constructor Vacio
        public NSucursal()
        {

        }
        
        //Metodo para insertar
        public string insertar(int cod_sucursal, string nombre)
        {
            string respuesta = "";
            DSucursal dsucursal = new DSucursal(cod_sucursal, nombre);
            respuesta = dsucursal.Insertar(dsucursal);
            return respuesta;
        }

        //Metodo para Modificar
        public string modificar(int cod_sucursal, string nombre)
        {
            string respuesta = "";
            DSucursal dsucursal = new DSucursal(cod_sucursal, nombre);
            respuesta = dsucursal.Modificar(dsucursal);
            return respuesta;
        }

        //Metodo para Eliminar
        public string eliminar(int cod_sucursal, string nombre)
        {
            string respuesta = "";
            DSucursal dsucursal = new DSucursal(cod_sucursal, nombre);
            respuesta = dsucursal.Eliminar(dsucursal);
            return respuesta;
        }

        //Metodo que lista la tabla de la base de datos (Para efectos de administracion)

        public DataTable listar_tabla()
        {
            DataTable datatable = new DataTable();
            DSucursal dsucursal = new DSucursal();
            datatable = dsucursal.listar();
            return datatable;
        }
    }
}
