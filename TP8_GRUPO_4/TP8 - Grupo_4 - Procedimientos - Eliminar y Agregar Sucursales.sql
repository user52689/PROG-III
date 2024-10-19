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


