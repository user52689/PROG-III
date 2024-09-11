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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int marcados = chlbOpciones.CheckedItems.Count;

            if (marcados == 0)
            {

                MessageBox.Show("Seleccione al menos 1 item del listbox");
            }
            else
            {
                // Obtener la seleccion de estado civil y sexo
                string seleccionEstadoCivil = rbCasado.Checked ? "Estado Civil: Casado" : "Estado Civil: Soltero";
                string seleccionSexo = rbMasculino.Checked ? "Sexo: Masculino" : "Sexo: Femenino";
                string oficios = "Oficio:" + Environment.NewLine; ;
                
                //Obtiene la seleccion del oficio
                foreach (var item in chlbOpciones.CheckedItems)
                {
                    oficios += " -" + item.ToString() + Environment.NewLine;
                }
                
                // Mostrar la seleccion en el Label
                lblSeleccion.Text = "Usted seleccionó los siguientes elementos:"+ Environment.NewLine;
                lblSeleccion.Text += seleccionSexo + Environment.NewLine;
                lblSeleccion.Text += seleccionEstadoCivil + Environment.NewLine;
                lblSeleccion.Text += oficios;
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


//Fase 3: Agregar la Selección del CheckedListBox
//Finalmente, en esta fase, agregamos la funcionalidad para incluir lo que se seleccionó en el CheckedListBox.