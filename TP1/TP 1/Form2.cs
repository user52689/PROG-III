using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)

        {
            string nombre = txtNombre.Text.ToLower().Trim();
            if(nombre.Trim().Length != 0 && !lbNombres.Items.Contains(nombre))
            {
                lbNombres.Items.Add(nombre);
                txtNombre.Clear();
            }

            else
            {
                MessageBox.Show("Espacio en blanco o ya existe el nombre en la lista");
                txtNombre.Clear();
            }
        }

        private void btnMover1_Click(object sender, EventArgs e)
        {
            if(lbNombres.SelectedItems == null)
            {
                MessageBox.Show("Debe seleccionar un nombre de la lista.");
                return;
            }
            else
            {
                lbSeleccionados.Items.Add(lbNombres.SelectedItem);
                lbNombres.Items.Remove(lbNombres.SelectedItem);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnMoverTodos_Click(object sender, EventArgs e)
        {
            if(lbNombres.Items.Count > 0)
            {
                foreach(var item in lbNombres.Items)
                {
                    lbSeleccionados.Items.Add(item);
                  
                }
                lbNombres.Items.Clear();
            }
            else
            {
                MessageBox.Show("No hay elementos para mover.");
            }
            txtNombre.Focus();
        }
    }
}
