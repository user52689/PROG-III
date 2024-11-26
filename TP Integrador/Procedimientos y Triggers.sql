USE Clinica
GO

-- ------------------------------------------------------------------------------------ Medico

-- Procedimiento: Agregar Medico
CREATE OR ALTER PROCEDURE SP_AgregarMedico
(
    @DNI_med CHAR(10),
    @Nombre_med VARCHAR(50),
    @Apellido_med VARCHAR(50),
    @Genero_med INT,
    @Nacionalidad_med CHAR(50),
    @FechaNacimiento_med DATE,
    @Direccion_med VARCHAR(50),
    @Localidad_med INT,
    @Provincia_med INT,
    @CorreoElectronico_med VARCHAR(50),
    @Telefono_med VARCHAR(15),
    @Especialidad_med INT,
	@Estado_med BIT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Medicos (DNI_med, Nombre_med, Apellido_med, Genero_med, Nacionalidad_med, FechaNacimiento_med, Direccion_med, Localidad_med, Provincia_med, CorreoElectronico_med, Telefono_med, Especialidad_med, Estado_med)
        VALUES (@DNI_med, @Nombre_med, @Apellido_med, @Genero_med, @Nacionalidad_med, @FechaNacimiento_med, @Direccion_med, @Localidad_med, @Provincia_med, @CorreoElectronico_med, @Telefono_med, @Especialidad_med, @Estado_med);

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO

-- Procedimiento: Modificar Medico
CREATE OR ALTER PROCEDURE SP_ModificarMedico
(	
	@Legajo_med INT,
	@DNI_med CHAR(10),
    @Nombre_med VARCHAR(50),
    @Apellido_med VARCHAR(50),
    @Genero_med INT,
    @Nacionalidad_med INT,
    @FechaNacimiento_med DATE,
    @Direccion_med VARCHAR(50),
    @Localidad_med INT,
    @Provincia_med INT,
    @CorreoElectronico_med VARCHAR(50),
    @Telefono_med VARCHAR(15),
    @Especialidad_med INT,
	@Estado_med BIT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Medicos
        SET
            Nombre_med = @Nombre_med,
            Apellido_med = @Apellido_med,
            Genero_med = @Genero_med,
            Nacionalidad_med = @Nacionalidad_med,
            FechaNacimiento_med = @FechaNacimiento_med,
            Direccion_med = @Direccion_med,
            Localidad_med = @Localidad_med,
            Provincia_med = @Provincia_med,
            CorreoElectronico_med = @CorreoElectronico_med,
            Telefono_med = @Telefono_med,
            Especialidad_med = @Especialidad_med,
			Estado_med = @Estado_med
        WHERE Legajo_med = @Legajo_med;

        UPDATE MedicoXDias
        SET Estado_mxd = 0
        WHERE Legajo_med_mxd = @Legajo_med;


        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO

-- Trigger: Eliminar Medico
CREATE TRIGGER TR_EliminarMedico
ON Medicos
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT * FROM inserted WHERE Estado_med = 0)
			BEGIN
				DECLARE @Legajo_med INT;

				SELECT @Legajo_med = Legajo_med FROM deleted;

				UPDATE MedicoXDias
				SET Estado_mxd = 0 
				WHERE Legajo_med_mxd = @Legajo_med;

				UPDATE Turnos
				SET Estado_tur = 0
				WHERE IdMedico_tu = @Legajo_med;

				UPDATE Informes
				SET Estado_inf = 0
				WHERE IdMedico_inf = @Legajo_med;		
			END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO

-- ------------------------------------------------------------------------------------ Paciente

-- Procedimiento: Agregar Paciente
CREATE OR ALTER PROCEDURE SP_AgregarPaciente
(
    @DNI_pac CHAR(10),
    @Nombre_pac CHAR(50),
    @Apellido_pac CHAR(50),
    @Genero_pac INT,
    @Nacionalidad_pac INT,
    @FechaNacimiento_pac DATE,
    @Direccion_pac CHAR(100),
    @Localidad_pac INT,
    @Provincia_pac INT,
    @CorreoElectronico_pac CHAR(100),
    @Telefono_pac CHAR(15),
	@Estado_pac BIT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Pacientes (DNI_pac, Nombre_pac, Apellido_pac, Genero_pac, Nacionalidad_pac, FechaNacimiento_pac, Direccion_pac, Localidad_pac, Provincia_pac, CorreoElectronico_pac, Telefono_pac, Estado_pac)
        VALUES (@DNI_pac, @Nombre_pac, @Apellido_pac, @Genero_pac, @Nacionalidad_pac, @FechaNacimiento_pac, @Direccion_pac, @Localidad_pac, @Provincia_pac, @CorreoElectronico_pac, @Telefono_pac, @Estado_pac);

        COMMIT TRANSACTION;
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO

-- Procedimiento: Modificar Paciente
CREATE OR ALTER PROCEDURE SP_ModificarPaciente
(
    @DNI_pac CHAR(10),
    @Nombre_pac CHAR(50),
    @Apellido_pac CHAR(50),
    @Genero_pac INT,
    @Nacionalidad_pac INT,
    @FechaNacimiento_pac DATE,
    @Direccion_pac CHAR(100),
    @Localidad_pac INT,
    @Provincia_pac INT,
    @CorreoElectronico_pac CHAR(100),
    @Telefono_pac CHAR(15),
	@Estado_pac BIT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Pacientes
        SET
			Nombre_pac = @Nombre_pac,
            Apellido_pac = @Apellido_pac,
            Genero_pac = @Genero_pac,
            Nacionalidad_pac = @Nacionalidad_pac,
            FechaNacimiento_pac = @FechaNacimiento_pac,
            Direccion_pac = @Direccion_pac,
            Localidad_pac = @Localidad_pac,
            Provincia_pac = @Provincia_pac,
            CorreoElectronico_pac = @CorreoElectronico_pac,
            Telefono_pac = @Telefono_pac,
			Estado_pac = @Estado_pac
        WHERE DNI_pac = @DNI_pac;

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO

-- Trigger: Eliminar Paciente
CREATE TRIGGER TR_EliminarPaciente
ON Pacientes
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @DNI_pac CHAR(10);

        IF EXISTS (SELECT * FROM inserted WHERE Estado_pac = 0) 
			BEGIN
				SELECT @DNI_pac = DNI_pac FROM inserted;

				UPDATE Turnos
				SET Estado_tur = 0
				WHERE IdPaciente_tu = @DNI_pac;

				UPDATE Informes
				SET Estado_inf = 0
				WHERE IdPaciente_inf = @DNI_pac;
			END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
