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
 *En esta forma se llevará a cabo el control del catálogo de usuarios,
 * en donde el usuario podrá dar de alta o baja a un empleado, modificar
 * sus datos y buscar uno en específico.
 * Se usan variables locales tipo bool para especificar nuestras banderas
 * sobre alguna de las acciones que se quiera realizar; variable tipo Empleado
 * que usaremos para almacenar todos los datos requeridos para un nuevo usuario
 * y una lista de enteros para.................. 
*/

namespace Pantallas
{
    public partial class Catálogo_de_Usuarios : Form
    {
        bool bandAlta = false; //Bandera que se usa para dar de alta un nuevo usuario
        bool bandModifica = false; //Bandera que se usa para modificar un nuevo usuario
        bool bandBaja = false; //Bandera que se usa para dar de baja un nuevo usuario
        Empleado empleado = new Empleado(); //Variable que se usa para almacenar los datos del empleado
        List<int> indices = new List<int>();
        public string tipo = "", cveBusq = "", nombrBusq = "", apellBusq = "";
        int contadorEmpleado = 0; //Variable para saber cuántos empleados hay en el sistema dados de alta

        
        /// <summary>
        /// Constructor principal de la forma donde se inicializan los componentes y se cargan los datos que se hallan en la base de datos.
        /// </summary>
        public Catálogo_de_Usuarios()
        {
            InitializeComponent(); //Inicializamos los componentes
            cargaDatos(); //Mandamos a llamar a la función donde se cargan los datos de los empleados que hay en la base de datos
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
                    consultaSQL = $"SELECT * FROM Empleado where idEmpleado > '{Convert.ToString(contadorEmpleado)}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
                    OleDbCommand comando; //
                    comando = new OleDbCommand(consultaSQL, connection); //
                    
                    connection.Open(); //Establecemos conexión
                    OleDbDataAdapter adapter = new OleDbDataAdapter(comando); //
                    DataTable tabla = new DataTable();//
                    adapter.Fill(tabla);//

                    dataGrid.DataSource = tabla; //
                    DataGridViewRow row = new DataGridViewRow();//
                    row = dataGrid.Rows[0];//

                    contadorEmpleado = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorEmpleado);//
                    //contadorEmpleado = indices[indices.Count - 1];

                    connection.Close();//Cerramos la conexión

                    setEmpleado(row);
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
        /// Método donde asignamos cada uno de los datos a los empleados
        /// </summary>
        /// <param name="rowAux"></param>
        private void setEmpleado(DataGridViewRow rowAux)
        {
            empleado.id = rowAux.Cells[0].Value.ToString(); //Asignamos el id que especifiquemos en la celda 0
            empleado.nombre = rowAux.Cells[1].Value.ToString(); //Asignamos el nombre que especifiquemos en la celda 1
            empleado.apellidos = rowAux.Cells[2].Value.ToString(); //Asignamos los apellidos que especifiquemos en la celda 2
            empleado.nickname = rowAux.Cells[3].Value.ToString(); //Asignamos el nickname/alias que especifiquemos en la celda 3
            empleado.calleN = rowAux.Cells[4].Value.ToString();
            empleado.colonia= rowAux.Cells[5].Value.ToString();
            empleado.celular = rowAux.Cells[6].Value.ToString();
            empleado.telefono= rowAux.Cells[7].Value.ToString();
            empleado.email= rowAux.Cells[8].Value.ToString();
            empleado.password = rowAux.Cells[9].Value.ToString(); //Asignamos la contraseña que especifiquemos en la celda 9
            empleado.tipo= rowAux.Cells[10].Value.ToString();
        }

        /// <summary>
        /// Método que se usa para mostrar los datos en pantalla
        /// </summary>
        private void muestraDatos()
        {
            textClave.Text = empleado.id; //Establecemos lo que se escriba en el textbox para el nombre en el campo id del empleado
            textNombre.Text = empleado.nombre; //Establecemos lo que se escriba en el textbox para el nombre en el campo nombre del empleado
            textApellidos.Text = empleado.apellidos; //Establecemos lo que se escriba en el textbox para los apellidos en el campo apellidos del empleado
            textNick.Text = empleado.nickname; //Establecemos lo que se escriba en el textbox para el nickname en el campo nickname del empleado
            textCont.Text = empleado.password; //Establecemos lo que se escriba en el textbox para la contraseña en el campo password del empleado
            tbCalle.Text = empleado.calleN;
            tbCelular.Text = empleado.celular;
            tbColonia.Text = empleado.colonia;
            tbEmail.Text = empleado.email;
            tbTelefono.Text = empleado.telefono;
        }

        /// <summary>
        /// Método del botón Mofica en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifica_Click(object sender, EventArgs e)
        {
            select(0); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "0" para indicar la opción
        }

        /// <summary>
        /// Método del botón Baja en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baja_Click(object sender, EventArgs e)
        {
            select(1); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "1" para indicar la opción
        }

        /// <summary>
        /// Método del botón Alta en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alta_Click(object sender, EventArgs e)
        {
            select(2); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "2" para indicar la opción
        }

        /// <summary>
        /// Método del botón RetrocedeTodo en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retrocedeTodo_Click(object sender, EventArgs e)
        {
            select(3); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "3" para indicar la opción
        }

        /// <summary>
        /// Método del botón RetocedeUno en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retrocede1_Click(object sender, EventArgs e)
        {
            select(4); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "4" para indicar la opción
        }

        /// <summary>
        /// Método del botón AvanzaUno en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void avanza1_Click(object sender, EventArgs e)
        {
            select(5); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "5" para indicar la opción
        }

        /// <summary>
        /// Método del botón AvanzaTodo en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void avanzaTodo_Click(object sender, EventArgs e)
        {
            select(6); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "6" para indicar la opción
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
                    //modificaReg();
                    break;//Fin case 0

                case 1: //baja
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
                    break;//Fin case 1

                case 2: //alta
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
                        limpiaAreas();
                        bandAlta = false;//Cambiamos el estado de la bandera
                        HabilitaText(false);
                    }
                    break;//Fin case 2

                case 3: //el primero
                    primero(); //Mandamos a llamar a la función de mostrar el primer empleado
                    break;//fin case 3

                case 4: //retrocede uno
                    if (indices.Count > 1)
                    {
                        indices.RemoveAt(indices.Count - 1);
                        contadorEmpleado = indices[indices.Count - 1] - 1;
                        cargaDatos();
                    }
                    break;//Fin case 4

                case 5: //avanza uno
                    cargaDatos();//Cargamos los datos
                    break;//Fin case 5

                case 6: //ultimo
                    ultimo(); //Mandamos a llamar a la función de mostrar el último empleado
                    break;//Fin case 6

                case 7:
                    Buscar buscar = new Buscar(this); //Abrimos la forma de "Buscar" 
                    buscar.Show();
                    break;//Fin case 7
                case 8:
                    Permisos permisos = new Permisos(this);
                    permisos.Show();
                    
                    break;
            }
        }

        /// <summary>
        /// Método donde habilitamos todos los campos disponibles a modificar
        /// </summary>
        void HabilitaText(bool band)
        {
            textNombre.Enabled = band; //Habilitamos el campo de nombre
            textApellidos.Enabled = band; //Habilitamos el campo de apellidos
            textNick.Enabled = band; //Habilitamos el campo de nickname
            textCont.Enabled = band; //Habilitamos el campo de contraseña
            tbCalle.Enabled = band;
            tbCelular.Enabled = band;
            tbColonia.Enabled = band;
            tbEmail.Enabled = band;
            tbTelefono.Enabled = band;
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
                    consultaSQL = $"SELECT TOP (1) * FROM Empleado ORDER by idEmpleado DESC"; //
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

                    contadorEmpleado = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorEmpleado);//
                    setEmpleado(row);//
                }
                muestraDatos();//Mostramos los datos
            }

            catch //Obtenemos la opción en caso de que exista alguna
            {

            }
        }

        /// <summary>
        /// Método para dar de baja un registro en la base de datos
        /// </summary>
        private void bajaReg()
        {
            empleado = new Empleado(); //Establecemos una nueva instancia de la clase Empleado

            empleado.id = textClave.Text; //Obtenemos el id del empleado
            
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    consultaSQL = $"DELETE FROM Empleado WHERE idEmpleado = '{empleado.id}'";
                    connection.Open(); //Abrimos la conexión
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos la conexión

                    contadorEmpleado = buscaIndex(Convert.ToInt32(empleado.id));

                    MessageBox.Show("Se a borrado el registro");
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {

            }
        }

        private int buscaIndex(int x)
        {
            int resp = -1;

            for (int i = 0; i < indices.Count; i++)
            {
                if (indices[i] == x)
                {
                    resp =  i;
                }
            }

            indices.RemoveAt(resp);
            resp = indices[indices.Count - 1];
            resp -= 1;
            return resp;
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
                    consultaSQL = $"SELECT TOP (1) * FROM Empleado";
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

                    contadorEmpleado = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorEmpleado);//
                    setEmpleado(row);
                }
                muestraDatos(); //Mostramos los datos
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {

            }
        }

        
        public void busquedaQuery() //No sé donde mandar llamr a este método :$ se supone que sí regresa los datos
        {
            Empleado empleado = new Empleado();

            empleado.id = cveBusq; //Asignamos id
            empleado.nombre = nombrBusq; //Asignamos nombre
            empleado.apellidos = apellBusq;
            
            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = "";
                    if (empleado.id != "")
                        consultaSQL = $"SELECT * FROM Empleado where idEmpleado = '{empleado.id}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
                    else
                    {
                        if (empleado.nombre != ""  && empleado.apellidos != "")
                            consultaSQL = $"SELECT * FROM Empleado WHERE nombreEmpleado = '{empleado.nombre}' AND apellidoEmpleado = '{empleado.apellidos}'"; //Sentencia SQL donde pedimos que muestre todas las columnas de la tabla Empleados donde el id sea mayor que el contador
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

                    contadorEmpleado = Convert.ToInt32(row.Cells[0].Value.ToString());//
                    compruebaEntrada(contadorEmpleado);//
                    setEmpleado(row);
                }
                muestraDatos(); //Mostramos los datos
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al hacer la busqueda");
            }
        }

        /// <summary>
        /// Método para dar de alta un registro en la base de datos
        /// </summary>
        private void meteRegistro()
        {
            empleado = new Empleado(); //Nueva instancia de la clase Empleado

            //empleado.id = textClave.Text; //Asignamos id
            empleado.nombre = textNombre.Text; //Asignamos nombre
            empleado.apellidos = textApellidos.Text; //Asignamos apellidos
            empleado.nickname = textNick.Text; //Asignamos nickname
            empleado.password = textCont.Text; //Asignamos contraseña
            empleado.celular = tbCelular.Text;
            empleado.telefono = tbTelefono.Text;
            empleado.email = tbEmail.Text;
            empleado.colonia = tbColonia.Text;
            empleado.calleN = tbCalle.Text;

            if (tipo != "")
            {
                empleado.tipo = tipo;
                empleado.permiso = "xxxxxxxxxxxxx";
                try //Establecemos un try catch para detectar excepciones
                {
                    using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                    {
                        string consultaSQL = "";
                        consultaSQL = $"INSERT INTO Empleado (nombreEmpleado, apellidoEmpleado, nicknameEmpleado, calleNEmpleado, coloniaEmpleado, celularEmpleado, telefonoEmpleado, emailEmpleado, passwordEmpleado, idEmpleadoTipoEmpleado) VALUES ('{empleado.nombre}', '{empleado.apellidos}', '{empleado.nickname}','{empleado.calleN}','{empleado.colonia}','{empleado.celular}','{empleado.telefono}','{empleado.email}','{empleado.password}', '{empleado.tipo}')";
                        OleDbCommand comando;
                        comando = new OleDbCommand(consultaSQL, connection);

                        connection.Open(); //Abrimos conexión
                        comando.ExecuteNonQuery();

                        connection.Close(); //Cerramos conexión
                        muestraDatos(); //Mostramos los datos
                        MessageBox.Show("Se agregó un registro");
                    }
                }

                catch //Obtenemos la excepción en caso de que exista alguna
                {
                    MessageBox.Show("Error al insertar los datos");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un tipo para el usuario");
            }
        }

        /// <summary>
        /// Método apra modificar un empleado de la base de datos
        /// </summary>
        private void modificaReg()
        {
            empleado = new Empleado();  //Nueva instancia de la clase Empleado

            empleado.id = textClave.Text; //Asignamos id
            empleado.nombre = textNombre.Text; //Asignamos nombre
            empleado.apellidos = textApellidos.Text; //Asignamos apellidos
            empleado.nickname = textNick.Text; //Asignamos nickname
            empleado.password = textCont.Text; //Asignamos contraseña
            empleado.calleN = tbCalle.Text;
            empleado.colonia = tbColonia.Text;
            empleado.celular = tbCelular.Text;
            empleado.telefono = tbCelular.Text;
            empleado.email = tbEmail.Text;

            try //Establecemos un try catch para detectar excepciones
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=LAPTOP-0BD02V9A;Database=ClinicaSql5;Trusted_Connection=yes;")) //Establecemos conexión con la base de datos
                {
                    string consultaSQL = $"UPDATE Empleado SET nombreEmpleado='{empleado.nombre}', apellidoEmpleado='{empleado.apellidos}', nicknameEmpleado='{empleado.nickname}', calleNEmpleado='{empleado.calleN}', coloniaEmpleado='{empleado.colonia}', celularEmpleado='{empleado.celular}', telefonoEmpleado='{empleado.telefono}', emailEmpleado='{empleado.email}', passwordEmpleado='{empleado.password}' WHERE idEmpleado = '{empleado.id}'";
                    OleDbCommand comando;
                    comando = new OleDbCommand(consultaSQL, connection);
                    connection.Open(); //Abrimos conexión
                    comando.ExecuteNonQuery();
                    connection.Close(); //Cerramos conexión
                    muestraDatos(); //Mostramos los datos
                    contadorEmpleado = Convert.ToInt32(empleado.id);//
                    compruebaEntrada(contadorEmpleado);//


                    MessageBox.Show("Los datos se han actualizado");
                }
            }

            catch //Obtenemos la excepción en caso de que exista alguna
            {
                MessageBox.Show("Error al actualizar los datos");
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

        /// <summary>
        /// Método para limpiar los campos textbox que hay en la forma
        /// </summary>
        private void limpiaAreas()
        {
            textClave.Clear(); //Limpiamos la clave
            textNombre.Clear(); //Limpiamos el nombre
            textCont.Clear(); //Limpiamos la contraseña
            textApellidos.Clear(); //Limpiamos los apellidos
            textNick.Clear(); //Limpiamos el nickname
            tbCalle.Clear();
            tbCelular.Clear();
            tbColonia.Clear();
            tbEmail.Clear();
            tbTelefono.Clear();
        }

        /// <summary>
        /// Método del botón Mofica en donde especificamos la opción que vamos a requerir, para ello, se manda a llamar al método select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBuscar_Click(object sender, EventArgs e)
        {
            select(7); //Mandamos a llamar al método y le pasamos como parámetro un entero con valor "7" para indicar la opción
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select(8);
        }
    }
}