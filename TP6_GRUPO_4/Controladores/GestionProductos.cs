using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TP6_GRUPO_4.Entidades;
using TP6_GRUPO_4.Conexion;



namespace TP6_GRUPO_4.Controladores
{
    public class GestionProductos
    {
        public DataTable ObtenerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "SELECT DISTINCT * FROM Productos");
        }
        private DataTable ObtenerTabla(string nombreTabla, string consulta)
        {
            try
            {
                DataSet ds = new DataSet();
                AccesoDatos datos = new AccesoDatos();
                SqlDataAdapter adp = datos.ObtenerAdaptador(consulta);
                adp.Fill(ds, nombreTabla);
                return ds.Tables[nombreTabla];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la tabla: " + nombreTabla, ex);
            }
        }
        private void ArmarParametrosProductos(ref SqlCommand cmd, Producto prd)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros = cmd.Parameters.Add("@IdProducto", SqlDbType.Int);
            Parametros.Value = prd.IdProducto;
            Parametros = cmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar, 40);
            Parametros.Value = prd.NombreProducto;
            Parametros = cmd.Parameters.Add("@CantidadPorUnidad", SqlDbType.NVarChar, 20);
            Parametros.Value = prd.CantidadPorUnidad;
            Parametros = cmd.Parameters.Add("@PrecioUnidad", SqlDbType.Money);
            Parametros.Value = prd.PrecioUnidad;

        }
        private void ArmarParametrosProductosEliminar(ref SqlCommand cmd, Producto prd)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros = cmd.Parameters.Add("@IdProducto", SqlDbType.Int);
            Parametros.Value = prd.IdProducto;
        }


        public bool ActualizarProductos(Producto prd)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProductos(ref cmd, prd);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(cmd, "spActualizarProducto");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;

            /*
                Procedimiento almacenado para Actualizar producto, ejecutar esta consulta en el SQL server para que se añada a la bd Neptuno.

                CREATE PROCEDURE spActualizarProducto 
                (
                @IdProducto int,
                @NombreProducto nvarchar(40),
                @CantidadPorUnidad nvarchar(20),
                @PrecioUnidad money
                )
                AS
                UPDATE Productos
                SET
                IdProducto = @IdProducto,
                NombreProducto = @NombreProducto,
                CantidadPorUnidad = @CantidadPorUnidad,
                PrecioUnidad = @PrecioUnidad
                WHERE IdProducto = @IdProducto
                RETURN
                GO
             */
        }


        public bool EliminarProducto(Producto prd)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProductosEliminar(ref cmd, prd);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(cmd, "spEliminarProducto");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;

            /*  Procedimiento almacenado para eliminar producto, ejecutar esta consulta en el SQL server para que se añada a la bd Neptuno.
                
                USE Neptuno
                GO

                CREATE PROCEDURE spEliminarProducto 
                (
                @IdProducto int
                )
                AS
                DELETE FROM Productos
                WHERE IdProducto = @IdProducto
                Return
                GO
             
             */
        }
    }
}