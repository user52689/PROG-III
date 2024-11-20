USE Clinica
GO


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
    @Especialidad_med INT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Medicos (DNI_med, Nombre_med, Apellido_med, Genero_med, Nacionalidad_med, FechaNacimiento_med, Direccion_med, Localidad_med, Provincia_med, CorreoElectronico_med, Telefono_med, Especialidad_med)
        VALUES ( @DNI_med, @Nombre_med, @Apellido_med, @Genero_med, @Nacionalidad_med, @FechaNacimiento_med, @Direccion_med, @Localidad_med, @Provincia_med, @CorreoElectronico_med, @Telefono_med, @Especialidad_med);

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO




CREATE OR ALTER PROCEDURE SP_ModificarMedico
(	
	@Legajo_med INT,
	@DNI_med char(10),
    @Nombre_med VARCHAR(50),
    @Apellido_med VARCHAR(50),
    @Genero_med int,
    @Nacionalidad_med INT,
    @FechaNacimiento_med DATE,
    @Direccion_med VARCHAR(50),
    @Localidad_med INT,
    @Provincia_med INT,
    @CorreoElectronico_med VARCHAR(50),
    @Telefono_med VARCHAR(15),
    @Especialidad_med INT
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
            Especialidad_med = @Especialidad_med
        WHERE Legajo_med = @Legajo_med;

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO

EXEC SP_ModificarMedico
    @Legajo_med = 6,
    @DNI_med = '1234567895',
    @Nombre_med = 'Peedro', -- Cambiamos el nombre de Pedro a Pep
    @Apellido_med = 'García',
    @Genero_med = 1,
    @Nacionalidad_med = 1,
    @FechaNacimiento_med = '1988-11-20',
    @Direccion_med = 'Avenida Libertador 789',
    @Localidad_med = 6,
    @Provincia_med = 2,
    @CorreoElectronico_med = 'pedro.garcia@email.com',
    @Telefono_med = '03514567892',
    @Especialidad_med = 5;



CREATE PROCEDURE SP_EliminarMedico
(
    @Legajo_med INT
)
AS
BEGIN
    BEGIN TRY
		BEGIN TRANSACTION;

		DELETE FROM MedicoXDias
		WHERE Legajo_med_mxd = @Legajo_med
		
		DELETE FROM Turnos
		WHERE IdMedico_tu = @Legajo_med

		DELETE FROM Informes
		WHERE IdMedico_inf = @Legajo_med

        DELETE FROM Medicos 
        WHERE Legajo_med = @Legajo_med

        COMMIT TRANSACTION
        RETURN @@ROWCOUNT
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        RETURN -1
    END CATCH
END
GO


CREATE OR ALTER PROCEDURE SP_AgregarPaciente
(
    @DNI_pac CHAR(10),
    @Nombre_pac CHAR(50),
    @Apellido_pac CHAR(50),
    @Genero_pac int,
    @Nacionalidad_pac INT,
    @FechaNacimiento_pac DATE,
    @Direccion_pac CHAR(100),
    @Localidad_pac INT,
    @Provincia_pac INT,
    @CorreoElectronico_pac CHAR(100),
    @Telefono_pac CHAR(15)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Pacientes (DNI_pac, Nombre_pac, Apellido_pac, Genero_pac, Nacionalidad_pac, FechaNacimiento_pac, Direccion_pac, Localidad_pac, Provincia_pac, CorreoElectronico_pac, Telefono_pac)
        VALUES (@DNI_pac, @Nombre_pac, @Apellido_pac, @Genero_pac, @Nacionalidad_pac, @FechaNacimiento_pac, @Direccion_pac, @Localidad_pac, @Provincia_pac, @CorreoElectronico_pac, @Telefono_pac);

        COMMIT TRANSACTION;
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO



CREATE OR ALTER PROCEDURE SP_ModificarPaciente
(
    @DNI_pac CHAR(10),
    @Nombre_pac CHAR(50),
    @Apellido_pac CHAR(50),
    @Genero_pac int,
    @Nacionalidad_pac INT,
    @FechaNacimiento_pac DATE,
    @Direccion_pac CHAR(100),
    @Localidad_pac INT,
    @Provincia_pac INT,
    @CorreoElectronico_pac CHAR(100),
    @Telefono_pac CHAR(15)
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
            Telefono_pac = @Telefono_pac
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




CREATE PROCEDURE SP_EliminarPaciente
(
    @DNI_pac CHAR(10)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM Turnos
        WHERE IdPaciente_tu = @DNI_pac;

        DELETE FROM Informes
        WHERE IdPaciente_inf = @DNI_pac;

        DELETE FROM Pacientes 
        WHERE DNI_pac = @DNI_pac;

        COMMIT TRANSACTION;
        RETURN @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN -1; 
    END CATCH
END
GO




