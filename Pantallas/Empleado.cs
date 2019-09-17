using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *En esta clase se llevará a cabo el control de todos los campos que se
 * usan para los usuarios, en donde se guardarán los siguientes datos:
 * id, nobre, apellidos, nickname, calle, colonia, celular, teléfono,
 * e-mail, contraseña, tipo de usuario y permisos que tenga el empleado
*/

namespace Pantallas
{    
    public class Empleado
    {
        public string id; //Variable para guardar el id del empleado
        public string nombre; //Variable para guardar el nombre del empleado
        public string apellidos; //Variable para guardar los apellidos del empleado
        public string nickname; //Variable para guardar el nickname del empleado
        public string calleN; //Variable para guardar la calle del empleado
        public string colonia; //Variable para guardar la colonia del empleado
        public string celular; //Variable para guardar el celular del empleado
        public string telefono; //Variable para guardar el teléfono del empleado
        public string email; //Variable para guardar el e-mail del empleado
        public string password; //Variable para guardar la contraseña del empleado
        public string tipo; //Variable para guardar el tipo de empleado
        public string permiso; //Variable para guardar los permisos del empleado

        /// <summary>
        /// Constructor principal de la clase Empleado
        /// </summary>
        public Empleado()
        {

        }
    }
}
