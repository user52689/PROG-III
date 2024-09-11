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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Convertir a minusculas y eliminar espacios extra
            string nombre = txtBoxNombre.Text.ToLower().Trim();
            string apellido = txtBoxApellido.Text.ToLower().Trim();

            // Combinacion de nombre y apellido
            string nombreCompleto = $"{nombre} {apellido}";

            // Verificar que ambos campos no esten vacios
            if (nombre.Length != 0 && apellido.Length != 0)
            {
                // Verificar si el nombre completo ya existe
                if (lbElementos.Items.Contains(nombreCompleto))
                {
                    MessageBox.Show("Ya existe ese nombre completo en la lista.");
                }
                else
                {
                    // Agregar el nombre completo al ListBox 
                    lbElementos.Items.Add(nombreCompleto);

                    // Convertir los elementos del ListBox en una lista para ordenarlos
                    List<string> nombresOrdenados = lbElementos.Items.Cast<string>().ToList();
                    nombresOrdenados.Sort();

                    // Limpiar el ListBox y volver a agregar los nombres ordenados
                    lbElementos.Items.Clear();
                    foreach (string item in nombresOrdenados)
                    {
                        lbElementos.Items.Add(item);
                    }

                    // Limpiar los TextBoxes despues de agregar
                    txtBoxNombre.Clear();
                    txtBoxApellido.Clear();
                }
            }
            else
            {
                MessageBox.Show("Debe llenar los dos campos (nombre y apellido).");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lbElementos.SelectedItems.Count > 0)
            {
                lbElementos.Items.Remove(lbElementos.SelectedItem);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un elemento para borrar.");
            }
        }

        private void txtBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}