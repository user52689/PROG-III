using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_4.Entidades
{
    public class Producto
    {
        private int _idProducto;
        private string _nombreProducto;
        private string _cantidadPorUnidad;
        private decimal _precioUnidad;

        public Producto() { }
        public Producto(int idProducto, string nombreProducto, string cantidadPorUnidad, int precioUnidad)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            CantidadPorUnidad = cantidadPorUnidad;
            PrecioUnidad = precioUnidad;
        }

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public string CantidadPorUnidad { get => _cantidadPorUnidad; set => _cantidadPorUnidad = value; }
        public decimal PrecioUnidad { get => _precioUnidad; set => _precioUnidad = value; }
    }
}