using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *En esta clase se llevará a cabo el control de todos los campos que se
 * usan para el historial clínico, en donde se guardarán los siguientes datos:
 * id, nobre, apellidos, fecha  y observaciones.
*/

namespace Pantallas
{
    public class Historial
    {
        public string id; //Variable para guardar el id del Paciente
        public string idP;
        public string idDentista; 
        public string nombre; //Variable para guardar el nombre del Paciente
        public string apellidos; //Variable para guardar los apellidos del Paciente
        public string fecha; //Variable para guardar la fecha del historial
        public string observacion; //Variable para guardar la observación que se haga al paciente
    }
}
