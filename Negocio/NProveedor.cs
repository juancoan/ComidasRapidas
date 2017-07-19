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
    public class NProveedor
    {
        //Constructor Vacio
        public NProveedor()
        {

        }

        //Metodo para insertar
        public string insertar(int id_prov, string nombre_proveedor, string telefono)
        {
            string respuesta = "";
            DProveedor dproveedor = new DProveedor(id_prov,nombre_proveedor,telefono);
            respuesta = dproveedor.Insertar(dproveedor);
            return respuesta;
        }

        //Metodo para Modificar
        public string modificar(int id_prov, string nombre_proveedor, string telefono)
        {
            string respuesta = "";
            DProveedor dproveedor = new DProveedor(id_prov, nombre_proveedor, telefono);
            respuesta = dproveedor.Modificar(dproveedor);
            return respuesta;
        }

        //Metodo para eliminar
        public string eliminar(int id_prov, string nombre_proveedor, string telefono)
        {
            string respuesta = "";
            DProveedor dproveedor = new DProveedor(id_prov, nombre_proveedor, telefono);
            respuesta = dproveedor.Eliminar(dproveedor);
            return respuesta;
        }

        //Metodo que lista la tabla de la base de datos (Para efectos de administracion)

        public DataTable listar_tabla()
        {
            DataTable datatable = new DataTable();
            DProveedor dproveedor = new DProveedor();
            datatable = dproveedor.listar();
            return datatable;
        }

    }
}
