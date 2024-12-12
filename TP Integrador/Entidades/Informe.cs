using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Informe
    {
        public int IdTurno { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string EstadoTurno { get; set; }
        public DateTime FechaTurno { get; set; }
    }
}
