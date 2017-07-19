using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace WindowsFormsApplication1
{
    
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            
            tabControl1.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage2"])
            {
                NInventario ninventario = new NInventario();
                DataTable datatable = new DataTable();
                datatable = ninventario.listar_tabla();
                datagrid_inventario.DataSource = datatable;
            }

           
        }
        private void button1_Click(object sender, EventArgs e)
        {


            // DCategoria cat = new DCategoria(22, "julian");
            // Console.Write(cat.Insertar(cat));
            //SqlDateTime dt = new SqlDateTime(2010, 10, 19);
            //DInventario inv = new DInventario(3,"ef2263", 1, 1, null, null, 2010 - 10 - 19, 2017 - 05 - 05, 1, false);
            //DInventario inv = new DInventario(7, "exito", 2, 1, SqlDateTime.MaxValue, dateTimePicker1.Value, dt,dt, 1, false);
            //Console.Write(inv.Insertar(inv));
            //Console.Write(inv.Modificar(inv));
            //inv.Id = 9;
            //Console.Write(inv.Eliminar(inv));
            //DInventario inv = new DInventario();
            //DataTable dat1 = new DataTable();
            //dat1 = inv.listar();
            //dataGridView1.DataSource = dat1;

            //DProductos prods = new DProductos(1,1,1,"Jacks",12350);
            //prods.Insertar(prods);
            //Console.Write(prods.Modificar(prods));
            //prods.Id_producto = 3;
            //Console.Write(prods.Eliminar(prods));

            //DataTable dat1 = prods.listar();
            //dataGridView1.DataSource = dat1;

            //DProveedor prov = new DProveedor(1, "Adolfo","8868-7487");
            //Console.Write(prov.Modificar(prov));
            //Console.Write(prov.Insertar(prov));
            //DProveedor prov = new DProveedor();
            //DataTable dat1 = prov.listar();
            //dataGridView1.DataSource = dat1;

            //DSucursal suc = new DSucursal(3, "Guana");
            //Console.Write(suc.Modificar(suc));
            //Console.Write(suc.Eliminar(suc));
            //DataTable dat1 = suc.listar();
            //dataGridView1.DataSource = dat1;
            //Console.Write(suc.Insertar(suc));

            //DUsuarios users = new DUsuarios(4,1,"tomela","2343",false);
            //Console.Write(users.Eliminar(users));
            //DataTable dat1 = new DataTable();
            //dat1 = users.listar();
            //dataGridView1.DataSource = dat1;


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Boolean respuesta = false;
            NUsuarios nusuarios = new NUsuarios();
            respuesta = nusuarios.autenticar_usuario(box_user.Text, box_pass.Text, true);

            if (respuesta == false)
            {
                mensaje_auth.Text = "Autenticacion Fallida";
            }
            else
            {
                mensaje_auth.Text = "Atenticacion Exitosa";
            }


        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }
    }
}
