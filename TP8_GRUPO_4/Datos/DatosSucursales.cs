using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DatosSucursales
    {
        AccesoDatos ad = new AccesoDatos();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        public Sucursal getSucursal(Sucursal sucursal)
        {
            DataTable tabla = ad.ObtenerTabla("Sucursal", "SELECT * FROM Sucursal WHERE Id_Sucursal=" + sucursal.Id);
            sucursal.Id = Convert.ToInt32(tabla.Rows[0][0].ToString());
            sucursal.Nombre = tabla.Rows[0][1].ToString();
            sucursal.Descripcion = tabla.Rows[0][2].ToString();
            sucursal.Direccion = tabla.Rows[0][3].ToString();
            return sucursal;
        }

        public bool existeSucursal(Sucursal sucursal)
        {
            string consulta = "SELECT * FROM Sucursal WHERE NombreSucursal='" + sucursal.Nombre + "'";
            return ad.ExisteRegistro(consulta);
        }

        public DataTable getTablaSucursal()
        {
            dt = ad.ObtenerTabla("Sucursal", "SELECT * FROM Sucursal");
            return dt;
        }
        public DataTable FiltrarSucursalID(int id) 
        {
            cmd = new SqlCommand("SELECT * FROM Sucursal WHERE Id_Sucursal = @Id_Sucursal");
            cmd.Parameters.AddWithValue("@Id_Sucursal", id);
            return ad.ObtenerTablaConComando("Sucursal", cmd);
        }

        public int eliminarSucursal(Sucursal sucursal)
        {
            ArmarParametrosSucursalEliminar(ref cmd, sucursal);
            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarSucursal");
        }


        public int agregarSucursal(Sucursal sucursal)
        {
            sucursal.Id = ad.ObtenerMaximo("SELECT max(Id_Sucursal) FROM Sucursal") + 1;
            ArmarParametrosSucursalAgregar(ref cmd, sucursal);
            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_AgregarCategoria");
        }

        private void ArmarParametrosSucursalEliminar(ref SqlCommand cmd, Sucursal sucursal)
        {
            SqlParameter prmt = new SqlParameter();
            prmt = cmd.Parameters.Add("@Id_sucursal", SqlDbType.Int);
            prmt.Value = sucursal.Id;
        }

        private void ArmarParametrosSucursalAgregar(ref SqlCommand cmd, Sucursal sucursal)
        {
            SqlParameter prmt = new SqlParameter();
            prmt = cmd.Parameters.Add("@Id_Sucursal", SqlDbType.Int);
            prmt.Value = sucursal.Id;
            prmt = cmd.Parameters.Add("@NombreSucursal", SqlDbType.VarChar);
            prmt.Value = sucursal.Nombre;
            prmt = cmd.Parameters.Add("@DescripcionSucursal" , SqlDbType.VarChar);
            prmt.Value = sucursal.Descripcion;
            prmt = cmd.Parameters.Add("@DireccionSucursal", SqlDbType.VarChar);
            prmt.Value= sucursal.Descripcion;
        }
    }
}


/*
 * --- Procedimientos almacenados para aliminar y agregar sucursales, con bloque TRY, y TRANSACTION, 
 * --- para manejar errores y revertir en caso de error consecuentemente.
 * 
 USE BDSucursales
GO

CREATE PROCEDURE SP_EliminarSucursal
(
    @Id_Sucursal INT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM Sucursal 
        WHERE Id_Sucursal = @Id_Sucursal;

        COMMIT TRANSACTION;
		RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		RETURN -1;        
    END CATCH
END
GO

CREATE PROCEDURE SP_AgregarSucursal
(
	@Id_Sucursal INT,
	@NombreSucursal VARCHAR(100),
	@DescripcionSucursal VARCHAR(100),
	@DireccionSucursal VARCHAR(100)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		INSERT INTO Sucursal (Id_Sucursal, NombreSucursal, DescripcionSucursal, DireccionSucursal)
        VALUES (@Id_Sucursal, @NombreSucursal, @DescripcionSucursal, @DireccionSucursal);

        COMMIT TRANSACTION;

        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO
 */