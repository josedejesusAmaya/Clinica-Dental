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
    public partial class Citas : Form
    {
        Empleado empleadoAux;
        Cita cita = new Cita();
        bool band, bandb = true;
        bool bandAgenda = false; //Bandera que se usa para dar de alta un nuevo usuario
        bool bandModifica = false; //Bandera que se usa para modificar un nuevo usuario
        bool bandBaja = false; //Bandera que se usa para dar de baja un nuevo usuario
        int contadorCita = 0;
        List<int> indices = new List<int>();
        public string cveBusq = "", nombrBusq = "", apellBusq = "";

        public Citas(Empleado e)
        {
            InitializeComponent();
            empleadoAux = e;
            NickNameTxB.Text = e.nickname;
            cargaDatos();
        }

        private void Citas_Load(object sender, EventArgs e)
        {
            
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
                    consultaSQL = $"SELECT * FROM Cita where idCita > '{Convert.ToString(contadorCita)}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
                    OleDbCommand comando; //
                    
                    comando = new OleDbCommand(consultaSQL, connection); //
                    
                    connection.Open(); //Establecemos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando); //                   
                    DataTable tabla = new DataTable();// 
                    adapter.Fill(tabla);//                    
                    dataGridView1.DataSource = tabla; //
                    DataGridViewRow row = new DataGridViewRow();//                   
                    row = dataGridView1.Rows[0];//                  
                    contadorCita = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorCita);//
                    //contadorCita = indices[indices.Count - 1];
                    connection.Close();//Cerramos la conexión  
                    setCita(row);
                    consultaDatosP();
                    muestraDatos(); //Mandamos a llamar la función para mostrar los datos en pantallada
                }
            }

            catch //Obtenemos la excepción en caso de que exista una
            {

            }
        }

        private void consultaDatosP()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos la conexión con la base de datos
                {
                    OleDbCommand comando2;
                    string consulta = $"SELECT p.nombrePAciente, p.apellidoPaciente FROM Cita As c INNER JOIN Paciente As p ON '{cita.Clave}' = p.idPaciente";
                    comando2 = new OleDbCommand(consulta, connection);
                    connection.Open();
                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(comando2);
                    DataTable tabla2 = new DataTable();
                    adapter2.Fill(tabla2);
                    dataGridView2.DataSource = tabla2;
                    DataGridViewRow row2 = new DataGridViewRow();
                    row2 = dataGridView2.Rows[0];
                    connection.Close();
                    tbNombre.Text = row2.Cells[0].Value.ToString();
                    tbApellido.Text = row2.Cells[1].Value.ToString();
                }
            }
            catch //Obtenemos la excepción en caso de que exista una
            {

            }
        }
        /// <summary>
        /// Método para dar de alta un registro en la base de datos
        /// </summary>
        private void meteRegistro()
        {
            cita = new Cita(); //Nueva instancia de la clase Empleado
            
            cita.Clave = tbClaveP.Text;
            cita.Fecha =  dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            cita.Hora = tbHora.Text;

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"INSERT INTO Cita (idCitaPaciente, fechaCita, horaCita ) VALUES ('{cita.Clave}', '{cita.Fecha}', '{cita.Hora}')";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open(); //Abrimos conexión
                    comando.ExecuteNonQuery();  
                    connection.Close(); //Cerramos conexión
                    muestraDatos(); //Mostramos los datos
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al insertar los datos");
            }
        }

        private void consultaCita()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos la conexión con la base de datos
                {
                    string consultaSQL = ""; //Inicializamos la variable que usaremos para las consultas en lenguaje SQL                    
                    consultaSQL = $"SELECT * FROM Cita where idCita > '{tbIdCita.Text}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
                    OleDbCommand comando; //
                    comando = new OleDbCommand(consultaSQL, connection); //

                    connection.Open(); //Establecemos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando); //
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//

                    dataGridView1.DataSource = tabla; //
                    DataGridViewRow row = new DataGridViewRow();//
                    row = dataGridView1.Rows[0];//        

                    connection.Close();//Cerramos la conexión

                    setCita(row);
                    muestraDatos(); //Mandamos a llamar la función para mostrar los datos en pantallada
                }
            }
            catch
            {
                MessageBox.Show("El usuario no existe");
            }
        }

        private void bajaReg()
        {
            cita = new Cita(); //Nueva instancia de la clase Empleado

            
            cita.Clave = tbClaveP.Text;
            cita.id = tbIdCita.Text;
            cita.Fecha = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            cita.Hora = tbHora.Text;
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"DELETE FROM Cita WHERE idCita = '{cita.id}'";
                    connection.Open(); //Abrimos la conexión
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos la conexión

                    contadorCita = Convert.ToInt16(cita.Clave);
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al eliminar los datos");
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
        /// Método de selección de Funciones
        /// </summary>
        /// <param name="op"></param>
        private void select(int op)
        {
            
            switch (op)
            {
                case 0:
                    this.Hide();
                    new LogIn().Show();
                    break;
                case 1:
                    new Catálogo_de_Pacientes().Show();
                    break;
                case 2:
                    new Perfil(empleadoAux).Show();
                    break;
                case 3:
                    new Buscar(this).Show();  
                    consultaCita();
                break;    
                   //string fecha = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"); 
                case 4://Agenda
                    if (!bandAgenda)
                    {
                        CambiaText(Agenda, "  Guardar", " Agendar"); //Cambiamos el nombre del botón de Alta por Aceptar
                        limpiaAreas(); // 
                        HabilitaText();//Habilitamos los campos
                        bandAgenda = true; //Cambiamos el estado de la bandera
                        bandb = !bandb;
                    }

                    else
                    {
                        CambiaText(Agenda, " Agendar", " Guardar");
                        meteRegistro();
                        HabilitaText();
                        bandAgenda = false;//Cambiamos el estado de la bandera
                    }
                    break;
                case 5://Cancela
                    if (!bandBaja)
                    {
                        CambiaText(Cancela, "  Aceptar", " Cancelar"); //Cambiamos el nombre del botón de Baja por Aceptar
                        bandBaja = true;//Cambiamos el estado de la bandera
                    }

                    else
                    {
                        CambiaText(Cancela, "  Cancelar", " Aceptar"); //Cambiamos el nombre del botón de Baja por Aceptar
                        bandBaja = false; //Cambiamos el estado de la bandera
                        bajaReg();//Mandamos a llamar la función de dar de baja un registro
                        cargaDatos(); //Cargamos los datos
                    }
                    break;
                case 6://Reagenda
                    if (!bandModifica)
                    {
                        CambiaText(Agenda, "  Guardar", " Reagendar"); //Cambiamos el nombre del botón de Alta por Aceptar
                        HabilitaText();//Habilitamos los campos
                        bandModifica = true; //Cambiamos el estado de la bandera
                        bandb = !bandb;
                    }

                    else
                    {
                        CambiaText(Agenda, " Reagendar", " Guardar");
                        meteRegistro();
                        HabilitaText();
                        bandModifica = false;//Cambiamos el estado de la bandera
                    }
                    break;
                case 7:   //retrocede todo
                    primero();
                    break;
                case 8:   //retrocede uno
                    if (indices.Count > 1)
                    {
                        indices.RemoveAt(indices.Count - 1);
                        contadorCita = indices[indices.Count - 1] - 1;
                        cargaDatos();
                    }

                    else //Si llegamos al final del catálogo, se lo hacemos saber al usuario con un mensaje:
                        MessageBox.Show("Fin del catálogo");
                    break;
                case 9://avanza uno
                    cargaDatos();//Cargamos los datos
                    break;
                case 10://Avanza todo
                    ultimo(); //Mandamos a llamar a la función de mostrar el último empleado
                    break;
                case 11:
                    new Buscar(this).Show();
                    break;


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
                    consultaSQL = $"SELECT TOP(1) * FROM Cita ORDER by idCita DESC";
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

                    setCita(row);//
                    consultaDatosP();
                }
                muestraDatos();//Mostramos los datos
            }

            catch //Obtenemos la opción en caso de que exista alguna
            {
                MessageBox.Show("Error al consultar los datos");
            }
        }

        /// <summary>
        /// Método apra modificar un empleado de la base de datos
        /// </summary>
        private void modificaReg()
        {
            cita = new Cita(); //Nueva instancia de la clase Empleado

            cita.Clave = tbClaveP.Text;
            cita.Fecha = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");         
            cita.Hora = tbHora.Text;

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"UPDATE INTO Cita (idCitaPaciente, fechaCita, horaCita ) VALUES ('{cita.Clave}', '{cita.Fecha}', '{cita.Hora}')";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);

                    connection.Open(); //Abrimos conexión
                    comando.ExecuteNonQuery();  
                    connection.Close(); //Cerramos conexión
                    muestraDatos(); //Mostramos los datos
                }
            }
            catch //Obtenemos la opción en caso de que exista alguna
            {
                MessageBox.Show("Error al actualizar los datos");
            }
        }
        public void consultaPaciente()
        {
            
          try
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"SELECT * FROM Paciente where nombrePaciente ='{nombrBusq}'AND apellidoPaciente ='{apellBusq}'";
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
                    tbClaveP.Text = row.Cells[0].Value.ToString();
                    tbApellido.Text = apellBusq;
                    tbNombre.Text = nombrBusq;
                }
            }
            catch
            {
                MessageBox.Show("No se encuentra el paciente");
            } 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            select(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            select(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select(2);
        }

        private void Agenda_Click(object sender, EventArgs e)
        {
            select(4);
        }

        private void Cancela_Click(object sender, EventArgs e)
        {
            select(5);
        }

        private void Reagenda_Click(object sender, EventArgs e)
        {
            select(6);
        }
        /// <summary>
        /// Cambia El texto de los botones
        /// Fecha: 3/05/2018
        /// </summary>
        /// <param name="b"></param>
        /// <param name="s"></param>
        /// <param name="c"></param>
        void CambiaText(Button b, string s, string c)
        {
            //band = !band;
            if (!band)
                b.Text = s;
            else
                b.Text = c;
        }

        private void limpiaAreas()
        {
            tbApellido.Clear();
            tbNombre.Clear();
            tbHora.Clear();
            tbIdCita.Clear();
            tbClaveP.Clear();
        }

        private void retrocedeTodo_Click(object sender, EventArgs e)
        {
            select(7);
        }

        private void HabilitaText()
        {
            tbApellido.Enabled =!bandAgenda ;
            tbClaveP.Enabled = !bandAgenda;
            tbNombre.Enabled = !bandAgenda;
        }
        /// <summary>
        /// Método para ir al primer empleado que esté en la base de datos
        /// Fecha:3/05/2018
        /// </summary>
        private void primero()
        {
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"SELECT TOP (1) * FROM Cita";
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

                    setCita(row);
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
        /// Método donde asignamos cada uno de los datos a los empleados
        /// Fecha:3/05/2018
        /// </summary>
        /// <param name="rowAux"></param>
        private void setCita(DataGridViewRow rowAux)
        {
            cita.id = rowAux.Cells[0].Value.ToString();
            cita.Clave = rowAux.Cells[1].Value.ToString();
            cita.Fecha = rowAux.Cells[2].Value.ToString();
            cita.Hora = rowAux.Cells[3].Value.ToString();

        }

        private void retrocede1_Click(object sender, EventArgs e)
        {
            select(8);
        }

        private void avanza1_Click(object sender, EventArgs e)
        {
            select(9);
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            select(3);
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbClaveP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void avanzaTodo_Click(object sender, EventArgs e)
        {
            select(10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            select(11);
        }

        /// <summary>
        /// Método que se usa para mostrar los datos en pantalla
        /// Fecha:3/05/2018
        /// </summary>
        private void muestraDatos()
        {
            tbIdCita.Text = cita.id;
            tbClaveP.Text = cita.Clave;
            dateTimePicker1.Text = cita.Fecha; 
            tbHora.Text = cita.Hora;        
        }

    }
}
