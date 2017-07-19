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

namespace WindowsFormsApplication1
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
