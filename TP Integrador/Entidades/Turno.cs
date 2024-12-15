using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string IdPaciente { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteApellido { get; set; }
        public int IdLegajoMedico { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaTurno { get; set; }
        public string EstadoTurno { get; set; }
        public bool AsistenciaTurno { get; set; }
        public string Observacion { get; set; }

        public Turno(int idTurno, string idPaciente, string pacienteNombre, string pacienteApellido, int idLegajoMedico, string especialidad, DateTime fechaTurno, string estadoTurno, bool asistenciaTurno, string observacion)
        {
            IdTurno = idTurno;
            IdPaciente = idPaciente;
            PacienteNombre = pacienteNombre;
            PacienteApellido = pacienteApellido;
            IdLegajoMedico = idLegajoMedico;
            Especialidad = especialidad;
            FechaTurno = fechaTurno;
            EstadoTurno = estadoTurno;
            AsistenciaTurno = asistenciaTurno;
            Observacion = observacion;
        }
    }
}