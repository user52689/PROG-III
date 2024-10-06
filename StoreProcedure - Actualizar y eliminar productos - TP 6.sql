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