using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Turno
    {
        private int idTurno_tu;
        private string idPaciente_tu;
        private int idMedico_tu;
        private DateTime fechaTurno_tu;
        private int idEstadoTurno_tu;

        public int IdTurno_tu { get => idTurno_tu; set => idTurno_tu = value; }
        public string IdPaciente_tu { get => idPaciente_tu; set => idPaciente_tu = value; }
        public int IdMedico_tu { get => idMedico_tu; set => idMedico_tu = value; }
        public DateTime FechaTurno_tu { get => fechaTurno_tu; set => fechaTurno_tu = value; }
        public int IdEstadoTurno_tu { get => idEstadoTurno_tu; set => idEstadoTurno_tu = value; }
    }
}
