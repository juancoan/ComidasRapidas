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
    public class NCategoria
    {
        //Constructor Vacio

        public NCategoria()
        {

        }

        //Metodo para insertar
        public string insertar(int id_categoria, string nombre)
        {
            string respuesta = "";
            DCategoria ncategoria = new DCategoria(id_categoria, nombre);
            respuesta = ncategoria.Insertar(ncategoria);
            return respuesta;
        }

        //Metodo para Modificar
        public string modificar(int id_categoria, string nombre)
        {
            string respuesta = "";
            DCategoria ncategoria = new DCategoria(id_categoria, nombre);
            respuesta = ncategoria.Modificar(ncategoria);
            return respuesta;
        }

        //Metodo para Eliminar
        public string eliminar(int id_categoria, string nombre)
        {
            string respuesta = "";
            DCategoria ncategoria = new DCategoria(id_categoria, nombre);
            respuesta = ncategoria.Eliminar(ncategoria);
            return respuesta;
        }

        //Metodo que lista la tabla de la base de datos (Para efectos de administracion)

        public DataTable listar_tabla()
        {
            DataTable datatable = new DataTable();
            DCategoria dcategoria = new DCategoria();
            datatable = dcategoria.listar();
            return datatable;
        }

    }
}
