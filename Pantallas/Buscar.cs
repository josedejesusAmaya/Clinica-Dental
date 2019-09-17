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
    public partial class Buscar : Form
    {
        Empleado empleado;
        Catálogo_de_Usuarios catUs;
        Catálogo_de_Pacientes catPa;
        HistorialPaciente hP;
        Citas citas;
        int op = 0;

        public Buscar(Catálogo_de_Usuarios ct)
        {
            InitializeComponent();
            catUs = ct;
            op = 1;
        }

        public Buscar(Catálogo_de_Pacientes cP)
        {
            InitializeComponent();
            catPa = cP;
            op = 2;
        }
        public Buscar(Citas cP)
        {
            InitializeComponent();
            citas = cP;
            op = 3;
        }
        public Buscar(HistorialPaciente HsP)
        {
            InitializeComponent();
            hP = HsP;
            op = 4;
        }


        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (op == 1)
            {
                catUs.cveBusq = textPorClave.Text;
                catUs.nombrBusq = textPorNombre.Text;
                catUs.apellBusq = textPorApellido.Text;
                this.Hide();
                catUs.busquedaQuery();
            }
            else if (op == 2)
            {
                catPa.cveBusq = textPorClave.Text;
                catPa.nombrBusq = textPorNombre.Text;
                catPa.apellBusq = textPorApellido.Text;
                this.Hide();
                catPa.busquedaQuery();
            } else if(op==3)
            {
                citas.cveBusq = textPorClave.Text;
                citas.nombrBusq = textPorNombre.Text;
                citas.apellBusq = textPorApellido.Text;
                this.Hide();
                citas.consultaPaciente();
            }
            else if (op == 4)
            {
                hP.cveBusq = textPorClave.Text;
                hP.nombrBusq= textPorNombre.Text;
                hP.apellBusq= textPorApellido.Text;
                this.Hide();
                hP.consultaPaciente();
            }
        }
        
        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textPorApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
