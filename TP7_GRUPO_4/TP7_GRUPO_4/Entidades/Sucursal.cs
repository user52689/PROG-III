using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_4.Entidades
{
    public class Sucursal
    {
        private string IDSucursal;
        private string nombreSucursal;
        private string descripcion;
        private string URLImagen;

        public Sucursal(string iDSucursal, string nombreSucursal, string descripcion, string uRLImagen)
        {
            IDSucursal1 = iDSucursal;
            this.NombreSucursal = nombreSucursal;
            this.Descripcion = descripcion;
            URLImagen1 = uRLImagen;
        }

        public string IDSucursal1 { get => IDSucursal; set => IDSucursal = value; }
        public string NombreSucursal { get => nombreSucursal; set => nombreSucursal = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string URLImagen1 { get => URLImagen; set => URLImagen = value; }
    }
}