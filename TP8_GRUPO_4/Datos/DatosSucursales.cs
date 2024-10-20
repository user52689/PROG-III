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
            sucursal.IdProvincia = Convert.ToInt32(tabla.Rows[0][3].ToString());
            sucursal.Direccion = tabla.Rows[0][4].ToString();
            return sucursal;
        }

        public bool existeSucursal(Sucursal sucursal)
        {
            string consulta = "SELECT * FROM Sucursal WHERE NombreSucursal='" + sucursal.Nombre + "'";
            return ad.ExisteRegistro(consulta);
        }

        public DataTable getTablaSucursal()
        {
            string consulta = "SELECT S.Id_Sucursal, S.NombreSucursal, S.DescripcionSucursal, P.DescripcionProvincia, S.DireccionSucursal " +
                              "FROM Sucursal S INNER JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia";
            return ad.ObtenerTabla("Sucursal", consulta);
        }
        public DataTable FiltrarSucursalID(int id)
        {
            string consulta = "SELECT S.Id_Sucursal, S.NombreSucursal, S.DescripcionSucursal, P.DescripcionProvincia, S.DireccionSucursal " +
                              "FROM Sucursal S INNER JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia " +
                              "WHERE S.Id_Sucursal = @Id_Sucursal";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@Id_Sucursal", id);
            return ad.ObtenerTablaConComando("Sucursal", cmd);
        }

        public int eliminarSucursal(Sucursal sucursal)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_EliminarSucursal";  // Nombre del procedimiento 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Sucursal", sucursal.Id);

            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarSucursal");
        }


        public int agregarSucursal(Sucursal sucursal)
        {
            // el id es autoincremental ojo
            string consulta = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) " +
                              "VALUES (@NombreSucursal, @DescripcionSucursal, @Id_ProvinciaSucursal, @DireccionSucursal)";

            // Crear el comando SQL y agregar los parámetros
            cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@NombreSucursal", sucursal.Nombre);
            cmd.Parameters.AddWithValue("@DescripcionSucursal", sucursal.Descripcion);
            cmd.Parameters.AddWithValue("@Id_ProvinciaSucursal", sucursal.IdProvincia);
            cmd.Parameters.AddWithValue("@DireccionSucursal", sucursal.Direccion);

            // Ejecutar el procedimiento almacenado para agregar la sucursal
            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_AgregarSucursal");
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
            prmt = cmd.Parameters.Add("@Id_ProvinciaSucursal", SqlDbType.Int);
            prmt.Value = sucursal.IdProvincia;
            prmt = cmd.Parameters.Add("@DireccionSucursal", SqlDbType.VarChar);
            prmt.Value= sucursal.Descripcion;
        }
    }
}


/*
 * --- Procedimientos almacenados para aliminar y agregar sucursales, con bloque TRY, y TRANSACTION, 
 * --- para manejar errores y revertir en caso de error consecuentemente.
 * 
///Cambios en el Procedimiento
CREATE PROCEDURE SP_AgregarSucursal
(
    @NombreSucursal VARCHAR(100),
    @DescripcionSucursal VARCHAR(100),
    @Id_ProvinciaSucursal INT,
    @DireccionSucursal VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar una nueva sucursal sin especificar el Id_Sucursal, ya que es autoincremental
        INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal)
        VALUES (@NombreSucursal, @DescripcionSucursal, @Id_ProvinciaSucursal, @DireccionSucursal);

        COMMIT TRANSACTION;
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1;
    END CATCH
END
GO


CREATE PROCEDURE SP_EliminarSucursal
(
	@Id_Sucursal INT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		-- Eliminar la sucursal según el Id
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
*/