using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using Datos;

//Esta clase maneja la capa de negocio de los productos

namespace Negocio
{
    public class NProductos
    {
        //Constructor vacio.
        public NProductos()
        {

        }

        //Metodo para insertar
        public string insertar(int id_producto, string nombre, int id_prov, int id_categoria, string marca, decimal costo)
        {
            string respuesta = "";
            DProductos dproductos = new DProductos(id_producto, nombre, id_prov, id_categoria, marca, costo);
            respuesta = dproductos.Insertar(dproductos);
            return respuesta;
        }

        //Metodo para Modificar

        public string modificar(int id_producto, string nombre, int id_prov, int id_categoria, string marca, decimal costo)
        {
            string respuesta = "";
            DProductos dproductos = new DProductos(id_producto, nombre, id_prov, id_categoria, marca, costo);
            respuesta = dproductos.Modificar(dproductos);
            return respuesta;
        }

        //Metodo para eliminar
        public string eliminar(int id_producto, string nombre, int id_prov, int id_categoria, string marca, decimal costo)
        {
            string respuesta = "";
            DProductos dproductos = new DProductos(id_producto, nombre, id_prov, id_categoria, marca, costo);
            respuesta = dproductos.Eliminar(dproductos);
            return respuesta;
        }

        //Metodo que lista la tabla de la base de datos (Para efectos de administracion)

        public DataTable listar_tabla()
        {
            DataTable datatable = new DataTable();
            DProductos dproductos = new DProductos();
            datatable = dproductos.listar();
            return datatable;
        }

        //El siguiente metodo lista de una forma mas ordenada
        //Para que pueda ser legible por cualquier usuario.

        public DataTable listar_ordenado()
        {
            DataTable datatable = new DataTable();
            DProductos dproductos = new DProductos();
            datatable = dproductos.listar_ordenado();
            return datatable;
        }

    }
}
