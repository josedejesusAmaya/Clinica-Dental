using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas
{
    public class Paciente
    {
        public string id; //Variable para guardar el id del paciente
        public string nombre; //Variable para guardar el nombre del paciente
        public string apellidos; //Variable para guardar los apellidos del paciente
        public string calleN; //Variable para guardar la calle del paciente
        public string colonia; //Variable para guardar la colonia del paciente
        public string celular; //Variable para guardar el celular del paciente
        public string telefono; //Variable para guardar el teléfono del paciente
        public string email; //Variable para guardar el e-mail del paciente
        public Historial historial;
        public Paciente()
        {

        }
    }
}
