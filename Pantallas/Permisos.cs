using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas
{
    public partial class Permisos : Form
    {
        Catálogo_de_Usuarios catUs;

        public Permisos(Catálogo_de_Usuarios ct)
        {
            InitializeComponent();
            dataGridView1.Rows.Add("Administrador");
            dataGridView1.Rows.Add("Capturista");
            dataGridView1.Rows.Add("Dentista");
            catUs = ct;
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            catUs.tipo =(dataGridView1.CurrentCell.RowIndex+1).ToString();
            this.Hide();
        }

        private void usuario(bool band)
        {
            //usuario
            altaUsuario.Checked = band;
            BajaUsuario.Checked = band;
            ModificaUsuario.Checked = band;
            ConsultaUsuario.Checked = band;
        }

        private void paciente(bool band)
        {
            //pacientes
            altaPaciente.Checked = band;
            bajaPaciente.Checked = band;
            ModificaPaciente.Checked = band;
            consultaPaciente.Checked = band;
        }

        private void cita(bool band)
        {
            //citas
            agendaCita.Checked = band;
            cancelaCita.Checked = band;
            reAgendaCita.Checked = band;
            ConsultaCita.Checked = band;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tipo = Convert.ToInt32((dataGridView1.CurrentCell.RowIndex + 1).ToString());
            switch (tipo)
            {
                case 1:
                    usuario(true);
                    paciente(true);
                    cita(true);
                    break;

                case 2:
                    usuario(false);
                    paciente(false);
                    cita(true);
                    break;

                case 3:
                    usuario(false);
                    paciente(true);
                    cita(false);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
