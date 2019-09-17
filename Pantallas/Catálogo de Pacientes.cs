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
 *En esta forma se llevará a cabo el control del catálogo de pacientes,
 * en donde el usuario podrá dar de alta o baja a un paciente, modificar
 * sus datos y buscar uno en específico.
 * Se usan variables locales tipo bool para especificar nuestras banderas
 * sobre alguna de las acciones que se quiera realizar y un delegado para
 * obtener el nombre o clave de un paciente en particular.
*/

namespace Pantallas
{
    public partial class Catálogo_de_Pacientes : Form
    {
        
        bool bandAlta = false; //Bandera que se usa para dar de alta un nuevo paciente
        bool bandModifica = false; //Bandera que se usa para modificar un nuevo paciente
        bool bandBaja = false; //Bandera que se usa para dar de baja un nuevo paciente
        
        public delegate void metBusq(string clave, string nombre); //Delegado que se usa para obtener los datos que sean escritos en la forma de buscar y así poder encontrar el paciente que necesitamos
        int contadorPaciente = 0; //Variable para saber cuántos pacientes hay en el sistema dados de alta
        Paciente paciente = new Paciente();
        List<int> indices = new List<int>();
        public string tipo = "", cveBusq = "", nombrBusq = "", apellBusq = "";
        Historial historial = new Historial();
        /// <summary>
        /// Constructor principal donde se inicializan los componentes
        /// </summary>
        public Catálogo_de_Pacientes()
        {
            InitializeComponent();
            cargaDatos();
        }

        private void cargaDatos()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos la conexión con la base de datos
                {
                    string consultaSQL = ""; //Inicializamos la variable que usaremos para las consultas en lenguaje SQL                    
                    consultaSQL = $"SELECT * FROM Paciente WHERE idPaciente > '{Convert.ToString(contadorPaciente)}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Paciente donde el id sea mayor que el contador
                    OleDbCommand comando; //
                    comando = new OleDbCommand(consultaSQL, connection); //

                    connection.Open(); //Establecemos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando); //
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//

                    dataGrid.DataSource = tabla; //
                    DataGridViewRow row = new DataGridViewRow();//
                    row = dataGrid.Rows[0];//

                    contadorPaciente = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorPaciente);//
                    //contadorEmpleado = indices[indices.Count - 1];

                    connection.Close();//Cerramos la conexión

                    setPaciente(row);
                    muestraDatos(); //Mandamos a llamar la función para mostrar los datos en pantallada
                }
            }

            catch //Obtenemos la excepción en caso de que exista una
            {

            }
        }

        /// <summary>
        /// Método donde asignamos cada uno de los datos a los empleados
        /// </summary>
        /// <param name="rowAux"></param>
        private void setPaciente(DataGridViewRow rowAux)
        {
            paciente.id = rowAux.Cells[0].Value.ToString(); //Asignamos el id que especifiquemos en la celda 0
            paciente.nombre = rowAux.Cells[1].Value.ToString(); //Asignamos el nombre que especifiquemos en la celda 1
            paciente.apellidos = rowAux.Cells[2].Value.ToString(); //Asignamos los apellidos que especifiquemos en la celda 2
            paciente.calleN = rowAux.Cells[3].Value.ToString(); //Asignamos calle que especifiquemos en la celda 3
            paciente.colonia = rowAux.Cells[4].Value.ToString(); //Asignamos la colonia que especifiquemos en la celda 4 
            paciente.celular = rowAux.Cells[5].Value.ToString(); //Asignamos el celular que especifiquemos en la celda 5
            paciente.telefono = rowAux.Cells[6].Value.ToString(); //Asignamos el teléfono que específicamos en la celda 6
            paciente.email = rowAux.Cells[7].Value.ToString(); //Asignamos el email que especifícamos en la celda 7
        }

        /// <summary>
        /// Método que se usa para mostrar los datos en pantalla
        /// </summary>
        private void muestraDatos()
        {
            textClave.Text = paciente.id; //Establecemos lo que se escriba en el textbox para el id en el campo id del empleado
            textNombre.Text = paciente.nombre; //Establecemos lo que se escriba en el textbox para el nombre en el campo nombre del empleado
            textApellidos.Text = paciente.apellidos; //Establecemos lo que se escriba en el textbox para los apellidos en el campo apellidos del empleado
            textCalle.Text = paciente.calleN;
            textColonia.Text = paciente.colonia;
            textCel.Text = paciente.celular;
            textTel.Text = paciente.telefono;
            textEmail.Text = paciente.email;
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
        /// Método que usa al delegado
        /// </summary>
        /// <param name="mb"></param>
        public void busq(metBusq mb)
        {
            string c = null, n = null;
            mb(c, n);
        }

        /// <summary>
        /// Método del botón RetrocedeTodo en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retrocedeTodo_Click(object sender, EventArgs e)
        {
            select(0); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "0" para indicar la opción
        }

        /// <summary>
        /// Método del botón Retrocede1 en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retrocede1_Click(object sender, EventArgs e)
        {
            select(1); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "1" para indicar la opción
        }

        /// <summary>
        /// Método del botón Avanza1 en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void avanza1_Click(object sender, EventArgs e)
        {
            select(2); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "2" para indicar la opción
        }

        /// <summary>
        /// Método del botón AvanzaTodo en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void avanzaTodo_Click(object sender, EventArgs e)
        {
            select(3); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "3" para indicar la opción
        }

        /// <summary>
        /// Método del botón Alta en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alta_Click(object sender, EventArgs e)
        {
            select(4); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "4" para indicar la opción
        }

        /// <summary>
        /// Método del botón Baja en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baja_Click(object sender, EventArgs e)
        {
            select(5); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "5" para indicar la opción
        }

        /// <summary>
        /// Método del botón Modifica en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifica_Click(object sender, EventArgs e)
        {
            select(6); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "6" para indicar la opción
        }

        /// <summary>
        /// Método que recibe un entero para seleccionar una de las diferentes
        /// opciones que se pueden realizar en este catálogo.
        /// </summary>
        /// <param name="opcion"></param>
        private void select(int op)
        {
            switch(op)
            {
                case 0: //retocede todo
                    primero(); //Mandamos a llamar a la función de mostrar el primer paciente
                    break;

                case 1: //retrocede uno
                    if (indices.Count > 1)
                    {
                        indices.RemoveAt(indices.Count - 1);
                        contadorPaciente = indices[indices.Count - 1] - 1;
                        cargaDatos();
                    }
                    break;

                case 2: //avanza uno         
                    cargaDatos();//Cargamos los datos
                    break;

                case 3: //avanza todo   
                    ultimo(); //Mandamos a llamar a la función de mostrar el último paciente
                    break;

                case 4: //alta
                    if (!bandAlta)
                    {
                        if (alta.Text == "Alta") //Cambiamos el nombre del botón de Alta por Aceptar
                            alta.Text = "Guardar";
                        limpiaAreas(); //
                        bandAlta = true; //Cambiamos el estado de la bandera
                        HabilitaText(true);//Habilitamos los campos
                    }

                    else
                    {
                        if (alta.Text == "Guardar") //Cambiamos el nombre del botón de Alta por Aceptar
                            alta.Text = "Alta";
                        meteRegistro(); //Mandamos a llamar a la función donde se agregan los registros
                        bandAlta = false;//Cambiamos el estado de la bandera
                        limpiaAreas();
                        HabilitaText(false);
                    }
                    break;

                case 5: //baja
                    if (!bandBaja)
                    {
                        if (baja.Text == "Baja")
                            baja.Text = "Aceptar";
                        bandBaja = true;//Cambiamos el estado de la bandera
                    }

                    else
                    {
                        if (baja.Text == "Aceptar")
                            baja.Text = "Baja";
                        bandBaja = false; //Cambiamos el estado de la bandera
                        bajaReg();//Mandamos a llamar la función de dar de baja un registro
                        cargaDatos(); //Cargamos los datos
                    }
                    break;

                case 6: //modifica 
                    if (!bandModifica)
                    {
                        if (modifica.Text == "  Modifica")
                            modifica.Text = "Guardar";
                        HabilitaText(true); //Habilitamos los campos
                        bandModifica = true; //Cambiamos el estado de la bandera
                    }

                    else
                    {
                        if (modifica.Text == "Guardar")
                            modifica.Text = "  Modifica";
                        modificaReg(); //Mandamos a llamar a la función de modificar un registro
                        bandModifica = false; //Cambiamos el estado de la bandera
                        HabilitaText(false); //Habilitamos los campos
                    }
                    break; 

                case 7:
                    Buscar buscar = new Buscar(this); //Abrimos la forma de "Buscar" 
                    buscar.Show();
                    break;
            }
        }

        /// <summary>
        /// Método apra modificar un empleado de la base de datos
        /// </summary>
        private void modificaReg()
        {
            paciente = new Paciente(); //Establecemos una nueva instancia de la clase Empleado

            paciente.id = textClave.Text; //Obtenemos el id del empleado
            paciente.nombre = textNombre.Text; //Obtenemos el nombre del empleado
            paciente.apellidos = textApellidos.Text; //Obtenemos los apellidos del empleado
            paciente.calleN = textCalle.Text;
            paciente.colonia = textColonia.Text;
            paciente.celular = textCel.Text;
            paciente.telefono = textTel.Text;
            paciente.email = textEmail.Text;

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = $"UPDATE Paciente SET nombrePaciente ='{paciente.nombre}', apellidoPaciente ='{paciente.apellidos}', calleNPaciente='{paciente.calleN}', coloniaPaciente='{paciente.colonia}', celularPaciente='{paciente.celular}', telefonoPaciente='{paciente.telefono}', emailPaciente='{paciente.email}' WHERE idPaciente = '{paciente.id}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    connection.Open(); //Abrimos conexión
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos conexión
                    muestraDatos(); //Mostramos los datos

                    contadorPaciente = Convert.ToInt32(paciente.id);//
                    compruebaEntrada(contadorPaciente);//

                    MessageBox.Show("Los datos se han actualizado");
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                
            }
        }

        /// <summary>
        /// Método para dar de baja un registro en la base de datos
        /// </summary>
        private void bajaReg()
        {
            paciente = new Paciente(); //Establecemos una nueva instancia de la clase Empleado

            paciente.id = textClave.Text; //Obtenemos el id del empleado
            
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"DELETE FROM Paciente WHERE idPaciente = '{paciente.id}'";
                    connection.Open(); //Abrimos la conexión
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos la conexión

                    contadorPaciente = buscaIndex(Convert.ToInt32(paciente.id));
                    MessageBox.Show("Se a borrado el registro");
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al eliminar los datos");
            }
        }

        public void busquedaQuery() //No sé donde mandar llamr a este método :$ se supone que sí regresa los datos
        {
            Paciente paciente = new Paciente();
            
            paciente.id = cveBusq; //Asignamos id
            paciente.nombre = nombrBusq; //Asignamos nombre
            paciente.apellidos = apellBusq;

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    if (paciente.id != "")
                        consultaSQL = $"SELECT * FROM Paciente where idPaciente = '{paciente.id}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Paciente donde el id sea mayor que el contador
                    else
                    {
                        if (paciente.nombre != "" && paciente.apellidos != "")
                            consultaSQL = $"SELECT * FROM Paciente WHERE nombrePaciente = '{paciente.nombre}' AND apellidoPaciente = '{paciente.apellidos}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Paciente donde el id sea mayor que el contador
                    }

                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open(); //Abrimos la conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGrid.DataSource = tabla;
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGrid.Rows[0];

                    connection.Close(); //Cerramos la conexión

                    contadorPaciente = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorPaciente);//
                    setPaciente(row);
                }
                muestraDatos(); //Mostramos los datos
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al hacer la busqueda");
            }
        }

        private int buscaIndex(int x)
        {
            int resp = -1;

            for (int i = 0; i < indices.Count; i++)
            {
                if (indices[i] == x)
                {
                    resp = i;
                }
            }

            indices.RemoveAt(resp);
            resp = indices[indices.Count - 1];
            resp -= 1;
            return resp;
        }

        /// <summary>
        /// Método para dar de alta un registro en la base de datos
        /// </summary>
        private void meteRegistro()
        {
            paciente = new Paciente(); //Nueva instancia de la clase Empleado

            paciente.id = textClave.Text; //Asignamos id
            paciente.nombre = textNombre.Text; //Asignamos nombre
            paciente.apellidos = textApellidos.Text; //Asignamos apellidos
            paciente.calleN = textCalle.Text;
            paciente.colonia = textColonia.Text;
            paciente.celular = textCel.Text;
            paciente.telefono = textTel.Text;
            paciente.email = textEmail.Text;
           

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"INSERT INTO Paciente (nombrePaciente, apellidoPaciente, calleNPaciente, coloniaPaciente, celularPaciente, telefonoPaciente, emailPaciente) VALUES ('{paciente.nombre}', '{paciente.apellidos}', '{paciente.calleN}','{paciente.colonia}','{paciente.celular}','{paciente.telefono}','{paciente.email}')";
                    OleDbCommand comando, comando2;
                    comando = new OleDbCommand(consultaSQL, connection);
                    //idObservacionPaciente='{historialP.id}', idObservacionEmpleado='{empleado.id}', fechaObservacion='{historialP.fecha}', descripcionObservacion='{historialP.observacion}' 
                    connection.Open(); //Abrimos conexión
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos conexión
                    muestraDatos(); //Mostramos los datos
                    MessageBox.Show("Se agregó un registro");
                    AgregaObservacion();
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
               MessageBox.Show("Error al insertar los datos");
            }
        }
        private void AgregaObservacion()
        {
            consultaPaciente();
            historial = new Historial();
            historial.idP = paciente.id;
            historial.nombre = paciente.nombre;
            historial.apellidos = paciente.apellidos;
            historial.observacion = "";
            historial.fecha = "";



            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string c2 = $"INSERT INTO Observacion (idObservacionPaciente, idObservacionEmpleado, fechaObservacion, descripcionObservacion) VALUES('{historial.idP}','{"2"}','{historial.fecha}','{historial.observacion}')";
                    OleDbCommand  comando2;
                    comando2 = new OleDbCommand(c2, connection);
                    //idObservacionPaciente='{historialP.id}', idObservacionEmpleado='{empleado.id}', fechaObservacion='{historialP.fecha}', descripcionObservacion='{historialP.observacion}' 
                    connection.Open(); //Abrimos conexión
                    comando2.ExecuteNonQuery();
                    connection.Close(); //Cerramos conexión
                    ; //Mostramos los datos     
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al insertar los datos");
            }
        }
        public void consultaPaciente()
        {

            try
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"SELECT * FROM Paciente where nombrePaciente ='{textNombre.Text}'AND apellidoPaciente ='{textApellidos.Text}'";
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
                    paciente.id = row.Cells[0].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("No se encuentra el paciente");
            }
        }

        /// <summary>
        /// Método para limpiar los campos textbox que hay en la forma
        /// </summary>
        private void limpiaAreas()
        {
            textClave.Clear(); //Limpiamos la clave
            textNombre.Clear(); //Limpiamos el nombre
            textApellidos.Clear(); //Limpiamos los apellidos
            textCalle.Clear(); //Limpiamos el nickname
            textColonia.Clear();
            textCel.Clear();
            textTel.Clear();
            textEmail.Clear();
        
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
                    consultaSQL = $"SELECT TOP (1) * FROM Paciente ORDER by idPaciente DESC"; //
                    OleDbCommand comando;//
                    comando = new OleDbCommand(consultaSQL, connection);//

                    connection.Open();//Abrimos la conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);//
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//

                    dataGrid.DataSource = tabla;//
                    DataGridViewRow row = new DataGridViewRow();//
                    row = dataGrid.Rows[0];//

                    connection.Close();//Cerramos la conexión

                    contadorPaciente = Convert.ToInt32(paciente.id);//
                    compruebaEntrada(contadorPaciente);//

                    setPaciente(row);//
                }
                muestraDatos();//Mostramos los datos
            }

            catch //Obtenemos la opción en caso de que exista alguna
            {
                MessageBox.Show("Error al consultar los datos");
            }
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void Catálogo_de_Pacientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
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
                    consultaSQL = $"SELECT TOP (1) * FROM Paciente";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open(); //Abrimos la conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dataGrid.DataSource = tabla;
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGrid.Rows[0];

                    connection.Close(); //Cerramos la conexión

                    setPaciente(row);
                }
                muestraDatos(); //Mostramos los datos
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al consultar los datos");
            }
        }

        /// <summary>
        /// Método para habilitar los campos
        /// </summary>
        void HabilitaText(bool band)
        {
            textNombre.Enabled = band; //Habilitamos el nombre
            textApellidos.Enabled = band;
            textCalle.Enabled = band; //Habilitamos la dirección
            textColonia.Enabled = band;
            textTel.Enabled = band; //Habilitamos el teléfono
            textCel.Enabled = band; //Habilitamos el celular
            textEmail.Enabled = band; //Habilitamos el e-mail
        }

        /// <summary>
        /// Método del botón Buscar en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBuscar_Click(object sender, EventArgs e)
        {
            select(7); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "7" para indicar la opción
        }
    }
}
