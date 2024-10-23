USE [BDSucursales]
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarSucursal]    Script Date: 21/10/2024 21:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_AgregarSucursal]
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


---PROCEDIMIENTO ALMACENADO PARA ELIMINAR 

/****** Object:  StoredProcedure [dbo].[SP_EliminarSucursal]    Script Date: 21/10/2024 21:54:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_EliminarSucursal]
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
