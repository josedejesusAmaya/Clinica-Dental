using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

/*
 *En esta forma se mostrarán los datos que un empleado tiene;
 * es una pantalla sobre el perfil del empleado.
 * Se muestran sus datos esenciales
*/

namespace Pantallas
{
    public partial class Perfil : Form
    {
        Empleado usuarioPerf; //Instancia de Empleado

        /// <summary>
        /// Constructor inicial de la forma Perfil donde inicializamos los componentes,
        /// la instancia de Empleado y mandamos llamar al método de mostrar datos.
        /// </summary>
        /// <param name="usuarioAux"></param>
        public Perfil(Empleado usuarioAux)
        {
            InitializeComponent();
            usuarioPerf = usuarioAux; //Inicializamos instancia de Empleado
            muestraDatos(); //Mandamos a llamar a función para mostrar datos en pantalla
        }

        /// <summary>
        /// Método que muestra los datos en pantalla en su textbox correspondiente
        /// </summary>
        private void muestraDatos()
        {
            textClave.Text = usuarioPerf.id; //mostramos el id
            textNombre.Text = usuarioPerf.nombre;//mostramos el nombre
            textApellidos.Text = usuarioPerf.apellidos; //mostramos los apellidos
            textNickname.Text = usuarioPerf.nickname; //mostramos el nickname
            textCalleN.Text = usuarioPerf.calleN; //mostramos la calle
            textColonia.Text = usuarioPerf.colonia; //mostramos la colonia
            textCelular.Text = usuarioPerf.celular; //mostramos el celular
            textTelefono.Text = usuarioPerf.telefono; //mostramos el teléfono
            textCorreo.Text = usuarioPerf.email; //mostramos el e-mail
            textPassword.Text = usuarioPerf.password; //mostramos la contraseña
        }

        /// <summary>
        /// Botón para guardar los cambios en caso de haber realizado alguno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bGuarda_Click(object sender, EventArgs e)
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=COMPUTER\SQLEXPRESS01;Database=ClinicaSql5;Trusted_Connection=yes;"))
                {
                    string consultaSQL = $"UPDATE Empleado SET nombreEmpleado='{textNombre.Text}', apellidoEmpleado='{textApellidos.Text}', nicknameEmpleado='{textNickname.Text}', calleNEmpleado='{textCalleN.Text}', coloniaEmpleado='{textColonia.Text}', celularEmpleado='{textCelular.Text}', telefonoEmpleado='{textTelefono.Text}', emailEmpleado='{textCorreo.Text}', passwordEmpleado='{textPassword.Text}' WHERE idEmpleado = '{usuarioPerf.id}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    connection.Open(); //Abrimos la conexión
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos la conexion
                    actualizaDatos(); //Mandamos a llamar a la función para actualizar los datos
                    MessageBox.Show("Los datos se han actualizado");
                }
            }

            catch //Obtenemos una exceepción en caso de existir alguna
            {
                MessageBox.Show("Error al actualizar los datos");
            }
        }

        /// <summary>
        /// Método que actualiza los datos según las modificaciones que se hayan realizado
        /// </summary>
        private void actualizaDatos()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=COMPUTER\SQLEXPRESS01;Database=ClinicaSql3;Trusted_Connection=yes;"))
                {
                    string consultaSQL = $"SELECT * FROM Empleado where idEmpleado = '{usuarioPerf.id}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open(); //Abrimos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGrid.DataSource = tabla;
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGrid.Rows[0];

                    connection.Close(); //Cerramos conexión

                    usuarioPerf.id = row.Cells[0].Value.ToString(); //Asignamos el id en la celda 0
                    usuarioPerf.nombre = row.Cells[1].Value.ToString(); //Asignamos el nombre en la celda 1
                    usuarioPerf.apellidos = row.Cells[2].Value.ToString(); //Asignamos los apellidos en la celda 2
                    usuarioPerf.nickname = row.Cells[3].Value.ToString(); //Asignamos el nickname en la celda 3
                    usuarioPerf.calleN = row.Cells[4].Value.ToString(); //Asignamos la calle en la celda 4
                    usuarioPerf.colonia = row.Cells[5].Value.ToString(); //Asignamos la colonia en la celda 5
                    usuarioPerf.celular = row.Cells[6].Value.ToString(); //Asignamos el celular en la celda 6
                    usuarioPerf.telefono = row.Cells[7].Value.ToString(); //Asignamos el teléfono en la celda 7
                    usuarioPerf.email = row.Cells[8].Value.ToString(); //Asignamos el e-mail en la celda 8
                    usuarioPerf.password = row.Cells[9].Value.ToString(); //Asignamos la contraseña en la celda 9
                }
            }

            catch //Obtenemos la excepción en caso de existir alguna
            {
                MessageBox.Show("Error al consultar datos de acceso");
            }
        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
