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
 *En esta forma se llevará a cabo el inicio de sesión de cada uno de los usuarios
 * Aquí validaremos que se halla escrito correctamente el nombre y contraseña
 * para poder darles el acceso, de lo contrario, se mostrará un mensaje donde
 * se especifique que los datos ingresados no son los correctos.
*/

namespace Pantallas
{
    public partial class LogIn : Form
    {
        Empleado empleado; //Instancia de la clase empleado
        bool bandAcceso = true; //Bandera para validar el acceso

        /// <summary>
        /// Constructor principal donde se inicializan los componentes
        /// </summary>
        public LogIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método para comprobar que los datos sean o no los correctos
        /// </summary>
        private void leerCredenciales()
        {
            empleado = new Empleado(); //Inicializamos la instancia de Empleado

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = $"SELECT * FROM Empleado where nicknameEmpleado = '{textUser.Text}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    
                    connection.Open(); //Abrimos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGrid.DataSource = tabla;
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGrid.Rows[0];
                    string password = row.Cells[9].Value.ToString();

                    if (textPass.Text != password) //Indicamos que los datos no coinciden con los especificados en la base de datos
                    {
                        MessageBox.Show("Los datos son invalidos");
                        bandAcceso = false;
                        return;
                    }

                    else//Sí coinciden los datos
                    {
                        empleado.nickname = textUser.Text;
                        bandAcceso = true;
                    }
                       
                    connection.Close(); //Cerramos conexión
                    setEmpleado(row);
                    
                    consultaTipo(row.Cells[10].Value.ToString());
                }

            }

            catch //Obtenemos la excepción si es que existe alguna
            {
                MessageBox.Show("Error al consultar datos de acceso");
                bandAcceso = false;
            }
        }

        /// <summary>
        /// Asignamos los valores de cada uno de los campos en su correspondiente columna
        /// </summary>
        /// <param name="rowAux"></param>
        private void setEmpleado(DataGridViewRow rowAux)
        {
            empleado.id = rowAux.Cells[0].Value.ToString(); //Asignamos el id
            empleado.nombre = rowAux.Cells[1].Value.ToString(); //Asignamos el nombre
            empleado.apellidos = rowAux.Cells[2].Value.ToString(); //Asignamos los apellidos
            empleado.nickname = rowAux.Cells[3].Value.ToString(); //Asignamos el nickname
            empleado.calleN = rowAux.Cells[4].Value.ToString(); //Asignamos la calle
            empleado.colonia = rowAux.Cells[5].Value.ToString(); //Asignamos la colonia
            empleado.celular = rowAux.Cells[6].Value.ToString(); //Asignamos el celular
            empleado.telefono = rowAux.Cells[7].Value.ToString(); //Asignamos el teléfono
            empleado.email = rowAux.Cells[8].Value.ToString(); //Asignamos el e-mail
            empleado.password = rowAux.Cells[9].Value.ToString(); //Asignamos la contraseña
        }

        /// <summary>
        /// Método para consultar qué tipo de usuario es el que ha iniciado sesión
        /// </summary>
        /// <param name="tipo"></param>
        private void consultaTipo(string tipo)
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Estableemos conexión con la base de datos
                {
                    string consultaSQL = $"SELECT * FROM Tipo_Empleado where idTipoEmpleado = '{tipo}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    
                    connection.Open(); //Abrimos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGrid.DataSource = tabla;
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGrid.Rows[0];

                    empleado.tipo = row.Cells[1].Value.ToString();
                    empleado.permiso = row.Cells[2].Value.ToString();
                    connection.Close(); //Cerramos conexión
                }
            }

            catch  //Obtenemos la excepción si es que existe alguna
            {
                MessageBox.Show("Error al consultar el tipo de empleado");
            }
        }

        /// <summary>
        /// Botón para iniciar sesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iniciaSesion_Click(object sender, EventArgs e)
        {
            leerCredenciales(); //Comprobamos que los datos sean correctos

            if (bandAcceso)
            {
                 switch( empleado.tipo)
                {
                    case "Administrador":
                        Administrador administrador = new Administrador(empleado); //Establecemos una nueva instancia de la Forma Administrador
                        this.Hide();
                        administrador.Show(); //Mostramos la ventana del Administrador
                    break;
                    case "Dentista":
                        new HistorialPaciente(empleado).Show();
                        this.Hide();
                        break;
                    case "Capturista":
                        new Citas(empleado).Show();
                        this.Hide();
                        break;

                    
                }
               
               
            }
        }
    }
}
