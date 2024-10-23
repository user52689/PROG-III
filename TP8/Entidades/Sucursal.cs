using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class Sucursal
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private int _idProvincia;
        private string _direccion;

        public Sucursal()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int IdProvincia { get => _idProvincia; set => _idProvincia = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
    }
}
