using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Turno
    {
        private string _id;
        private Paciente _paciente;
        private Medico _medico;
        private string _descripcion;
        private bool _presentismo;

        public string Id { get => _id; set => _id = value; }
        internal Paciente Paciente { get => _paciente; set => _paciente = value; }
        internal Medico Medico { get => _medico; set => _medico = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Presentismo { get => _presentismo; set => _presentismo = value; }
    }
}
