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

namespace Pantallas
{
    public partial class HistorialPaciente : Form
    {
        Empleado empleado;
        Historial historialP = new Historial();
        Paciente paciente = new Paciente();
        bool band, bandb = true;
        bool bandModifica = false;
        List<int> indices = new List<int>();
        int contadorHistorial = 0;
        public string cveBusq = "", nombrBusq = "", apellBusq = "";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="em"></param>
        public HistorialPaciente(Empleado em)
        {
            InitializeComponent();
            empleado = em;
            NickNameTxB.Text = em.nickname;
            inhabilita();
            //cargaDatos();
        }

        /// <summary>
        /// Método para inhabilitar los campos
        /// </summary>
        public void inhabilita()
        {
            textCvePaciente.Enabled = false;
            textNombrePac.Enabled = false;
            textApellidoPac.Enabled = false;
            textObservaciones.Enabled = false;
            NickNameTxB.Enabled = false;
        }

        /// <summary>
        /// Método para habilitar los campos
        /// </summary>
        public void habilita()
        {
            textNombrePac.Enabled = true;
            textApellidoPac.Enabled = true;
            textObservaciones.Enabled = true;
        }

        private void HistorialPaciente_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que usamos para cambiar el nombre del botón según se requiera
        /// </summary>
        /// <param name="b"></param>
        /// <param name="s"></param>
        /// <param name="c"></param>
        private void CambiaText(Button b, string s, string c)
        {
            if (!band)
                b.Text = s;
            else
                b.Text = c;
        }

        /// <summary>
        /// Método para acceder al perfil del dentista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil(empleado);
            perfil.Show();
        }

        /// <summary>
        /// Método para cerrar sesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn log_in = new LogIn();
            log_in.Show();
        }

        /// <summary>
        /// Método para modificar los datos del historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifica_Click(object sender, EventArgs e)
        {
            select(0);
        }

        /// <summary>
        /// Método para buscar un historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            select(6);
        }

        /// <summary>
        /// Cancelar cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que recibe un entero para seleccionar la acción a realizar, lo usamos para determinar si el usuario quiere modificar, 
        /// dar de alta o baja, o eliminar a algún empleado de la base de datos
        /// </summary>
        /// <param name="op"></param>
        private void select(int op)
        {
            switch (op)
            {
                case 0: //modifica
                    if (!bandModifica)
                    {
                        CambiaText(modifica, "  Guardar", "  Modifica"); //Cambiamos el textto del botón Modifica por Guardar
                        habilita(); //Habilitamos los campos
                        bandb = !bandb;
                        bandModifica = true; //Cambiamos el estado de la bandera
                    }

                    else
                    {
                        CambiaText(modifica, "  Modifica", "  Guardar");
                        modificaHistorial(); //Mandamos a llamar a la función de modificar un registro
                        bandModifica = false; //Cambiamos el estado de la bandera
                        bandb = !bandb;
                        inhabilita(); //Habilitamos los campos
                    }
                    //modificaReg();
                    break;//Fin case 0

                case 1: //el primero
                    primero(); //Mandamos a llamar a la función de mostrar el primer empleado
                    break;//fin case 3

                case 2: //retrocede uno
                    if (indices.Count > 1)
                    {
                        indices.RemoveAt(indices.Count - 1);
                        contadorHistorial = indices[indices.Count - 1] - 1;
                        cargaDatos();
                    }

                    else //Si llegamos al final del catálogo, se lo hacemos saber al usuario con un mensaje:
                        MessageBox.Show("Fin del catálogo");
                    break;//Fin case 4

                case 3: //avanza uno
                    cargaDatos();//Cargamos los datos
                    break;//Fin case 5

                case 4: //ultimo
                    ultimo(); //Mandamos a llamar a la función de mostrar el último empleado
                    break;//Fin case 4

                case 6: //Buscar
                    Buscar buscar = new Buscar(this); //Abrimos la forma de "Buscar" 
                    buscar.Show();
                    break;
            }
        }

        /// <summary>
        /// Método que usamos para cargar todos los datos en pantalla que se encuentran almacenados en nuestra base de datos
        /// </summary>
        private void cargaDatos()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos la conexión con la base de datos
                {
                    string consultaSQL = ""; //Inicializamos la variable que usaremos para las consultas en lenguaje SQL                    
                    consultaSQL = $"SELECT * FROM Observacion where idObservacion > '{Convert.ToString(contadorHistorial)}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
                    OleDbCommand comando; //
                    comando = new OleDbCommand(consultaSQL, connection); //

                    connection.Open(); //Establecemos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando); //
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//

                    dataGridView1.DataSource = tabla; //
                    DataGridViewRow row = new DataGridViewRow();//
                    row = dataGridView1.Rows[0];//

                    contadorHistorial = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorHistorial);//
                    //contadorEmpleado = indices[indices.Count - 1];

                    connection.Close();//Cerramos la conexión

                    setHistorial(row);
                    consultaDatosP();
                    muestraDatos(); //Mandamos a llamar la función para mostrar los datos en pantallada
                }
            }

            catch //Obtenemos la excepción en caso de que exista una
            {

            }
        }

        /// <summary>
        /// Método para comprobar la entrada de...............
        /// </summary>
        /// <param name="index"></param>
        private void compruebaEntrada(int index)
        {
            bool band = true; //Bandera para.....

            for (int i = 0; i < indices.Count; i++) //Ciclo donde iteramos los índices
            {
                if (indices[i] == index) //Condición para saber si llegamos al final
                {
                    band = false; //Bajamos la bandera
                    return;
                }
            }

            if (band) //Si la bandera está en alto, entonces:
                indices.Add(index); //Lo añadimos a la lista de índices
        }

        /// <summary>
        /// Modifica el historial
        /// </summary>
        private void modificaHistorial()
        {
            historialP = new Historial();  //Nueva instancia de la clase Historial

            historialP.id = textCvePaciente.Text; //Asignamos id            
            paciente.nombre = textNombrePac.Text; //Asignamos nombre
            paciente.apellidos = textApellidoPac.Text; //Asignamos apellidos
            historialP.fecha = dateTimePicker1.Text; //Asignamos nickname
            historialP.observacion = textObservaciones.Text; //Asignamos contraseña

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = $"UPDATE Observacion SET idObservacionPaciente='{historialP.id}', idObservacionEmpleado='{empleado.id}', fechaObservacion='{historialP.fecha}', descripcionObservacion='{historialP.observacion}' WHERE idObservacion='{historialP.id}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    connection.Open(); //Abrimos conexión
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos conexión
                    muestraHistorial(); //Mostramos los datos
                    MessageBox.Show("Los datos se han actualizado");
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al actualizar los datos");
            }
        }

     
        /// <summary>
        /// Función donde recorremos el catálogo hasta llegar al último empleado para mostrarlo
        /// </summary>
        private void ultimo()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = ""; //Inicializamos la variable que usaremos para las consultas
                    consultaSQL = $"SELECT TOP (1) * FROM Observacion'"; //
                    OleDbCommand comando;//
                    comando = new OleDbCommand(consultaSQL, connection);//

                    connection.Open();//Abrimos la conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);//
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//

                    dataGridView1.DataSource = tabla;//
                    DataGridViewRow row = new DataGridViewRow();//
                    row = dataGridView1.Rows[0];//

                    connection.Close();//Cerramos la conexión

                    setHistorial(row);//
                    consultaDatosP();
                }
                muestraDatos();//Mostramos los datos
            }

            catch //Obtenemos la opción en caso de que exista alguna
            {
                MessageBox.Show("Error al consultar los datos");
            }
        }
        private void consultaDatosP()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos la conexión con la base de datos
                {
                    OleDbCommand comando2;
                    string consulta = $"SELECT p.nombrePAciente, p.apellidoPaciente FROM Observacion As c INNER JOIN Paciente As p ON '{historialP.idP}' = p.idPaciente";
                    comando2 = new OleDbCommand(consulta, connection);
                    connection.Open();
                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(comando2);
                    DataTable tabla2 = new DataTable();
                    adapter2.Fill(tabla2);
                    dataGridView2.DataSource = tabla2;
                    DataGridViewRow row2 = new DataGridViewRow();
                    row2 = dataGridView2.Rows[0];
                    connection.Close();
                    textNombrePac.Text = row2.Cells[0].Value.ToString();
                    textApellidoPac.Text = row2.Cells[1].Value.ToString();
                }
            }
            catch //Obtenemos la excepción en caso de que exista una
            {

            }
        }
        /// <summary>
        /// Retrocede todos los expedientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retrocedeTodo_Click(object sender, EventArgs e)
        {
            select(1);
        }

        private void retrocede1_Click(object sender, EventArgs e)
        {
            select(2);
        }

        private void avanza1_Click(object sender, EventArgs e)
        {
            select(3);
        }

        private void avanzaTodo_Click(object sender, EventArgs e)
        {
            select(4);
        }

        /// <summary>
        /// Método para ir al primer empleado que esté en la base de datos
        /// </summary>
        private void primero()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"SELECT TOP (1) * FROM Observacion";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open(); //Abrimos la conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGridView1.DataSource = tabla;
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGridView1.Rows[0];

                    connection.Close(); //Cerramos la conexión

                    setHistorial(row);
                    consultaDatosP();
                }
                muestraDatos(); //Mostramos los datos
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al consultar los datos");
            }
        }

        /// <summary>
        /// Muestra el historial
        /// </summary>
        private void muestraHistorial()
        {
            textCvePaciente.Text = historialP.id; //Establecemos lo que se escriba en el textbox para el id en el campo id del paciente
            textNombrePac.Text = paciente.nombre; //Establecemos lo que se escriba en el textbox para el nombre en el campo nombre del paciente
            textApellidoPac.Text = paciente.apellidos; //Establecemos lo que se escriba en el textbox para los apellidos en el campo apellidos del pacientev
            dateTimePicker1.Text = historialP.fecha; //Establecemos la nueva fecha de actualización
            textObservaciones.Text = historialP.observacion; //Actualizamos las observaciones
        }

        /// <summary>
        /// Método que se usa para mostrar los datos en pantalla
        /// </summary>
        private void muestraDatos()
        {
            textCvePaciente.Text = historialP.id;
            dateTimePicker1.Text = historialP.fecha;
            textObservaciones.Text = historialP.observacion;
        }

        /// <summary>
        /// Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            select(5);
        }

        /// <summary>
        /// Consultar paciente
        /// </summary>
        public void consultaPaciente()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    if (cveBusq != "")
                        consultaSQL = $"SELECT * FROM Paciente where idPaciente = '{paciente.id}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
                    else
                    {
                        if (nombrBusq != "" && apellBusq != "")
                            consultaSQL = $"SELECT * FROM Paciente where nombrePaciente ='{nombrBusq}'AND apellidoPaciente ='{apellBusq}'";
                    }

                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//
                    DataGridViewRow row = new DataGridViewRow();
                    dataGridView1.DataSource = tabla; //

                    row = dataGridView1.Rows[0];
                    connection.Close();

                    textCvePaciente.Text = row.Cells[0].Value.ToString();
                    textNombrePac.Text = nombrBusq;
                    textApellidoPac.Text = apellBusq;
                }
            }
            catch
            {
                MessageBox.Show("No se encuentra el paciente");
            }
        }

        /// <summary>
        /// Método donde asignamos cada uno de los datos a los empleados
        /// </summary>
        /// <param name="rowAux"></param>
        private void setHistorial(DataGridViewRow rowAux)
        {
            historialP.id = rowAux.Cells[0].Value.ToString();
            historialP.idP = rowAux.Cells[1].Value.ToString();
            historialP.idDentista = rowAux.Cells[2].Value.ToString();
            historialP.fecha = rowAux.Cells[3].Value.ToString();
            historialP.observacion = rowAux.Cells[4].Value.ToString();
        }
    }
}
