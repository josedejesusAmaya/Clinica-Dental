using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
 *Esta forma sólo la puede visualizar el administrador,
 * aquí él puede acceder a los diferentes catálogos que hay en el sistema. 
*/

namespace Pantallas
{
    public partial class Administrador : Form
    {
        Empleado usuarioAdmon; //Instancia de Empleado

        /// <summary>
        /// Constructor principal donde se inicializan los componentes y la instancia de Empleado
        /// </summary>
        /// <param name="usuarioAux"></param>
        public Administrador(Empleado usuarioAux)
        {
            InitializeComponent();
            usuarioAdmon = usuarioAux; //Inicializamos la instancia Empleado
        }

        /// <summary>
        /// Función que permite cerrar la sesión del administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cerrarSesiónA_Click(object sender, EventArgs e)
        {
            select(2); //Mandamos a llamar al método select con un entero igual a "2" para especificar la acción que queremos
        }

        /// <summary>
        /// Método que recibe un entero para seleccionar una de las diferentes
        /// opciones que puede realizar un súper usuario.
        /// </summary>
        /// <param name="opcion"></param>
        private void select(int opcion)
        {
            switch(opcion)
            {
                case 0: //catálogo dentistas
                    Catálogo_de_Usuarios empleados = new Catálogo_de_Usuarios(); //Nueva instancia de Catálogo de Usuarios
                    empleados.Text = "Empleados";
                    empleados.Show(); //Abrimos el catálogo de usuarios   
                    break;

                case 2: //cerrar sesion
                    LogIn logIn = new LogIn(); //Nueva instancia de Log In
                    logIn.Show(); //Mostramos la forma de log in
                    this.Hide();                    
                    break;                  
                      
                case 4: //catálogo pacientes
                    Catálogo_de_Pacientes cPacientes = new Catálogo_de_Pacientes(); //Nueva instancia de Catálogo de Pacientes
                    cPacientes.Show(); //Abrimos catálogo de pacientes
                    break;

                case 5: //muestra el perfil del superusuario
                    new Perfil(usuarioAdmon).Show();
                    break;
            }
        }

        /// <summary>
        /// Función que permite ver los datos de los pacientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CPacientes_Click(object sender, EventArgs e)
        {
            select(4); //Mandamos a llamar al método select con un entero igual a "4" para especificar la acción que queremos
        }
        
        /// <summary>
        /// Función que permite ver los datos del administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            select(5); //Mandamos a llamar al método select con un entero igual a "5" para especificar la acción que queremos
        }
        
        /// <summary>
        /// Función que permite abrir el catálogo de los empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            select(0); //Mandamos a llamar al método select con un entero igual a "0" para especificar la acción que queremos
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Citas(usuarioAdmon).Show();
        }
    }
}