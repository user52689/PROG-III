CREATE DATABASE Clinica
GO

USE Clinica
GO

------------------------------------------------------------------------Dias OK
CREATE TABLE Dias (
    IdDia_d INT NOT NULL,
    NombreDia_d VARCHAR(10) NOT NULL,
    CONSTRAINT PK_Dias PRIMARY KEY (IdDia_d)
)
GO

INSERT INTO Dias (IdDia_d, NombreDia_d)
SELECT 1, 'Lunes' UNION
SELECT 2, 'Martes' UNION
SELECT 3, 'Miércoles' UNION
SELECT 4, 'Jueves' UNION
SELECT 5, 'Viernes' UNION
SELECT 6, 'Sábado' UNION
SELECT 7, 'Domingo'

GO

------------------------------------------------------------------------Horario OK
CREATE TABLE Horarios (
    Id_h INT IDENTITY(1,1) NOT NULL,
    Horario_h CHAR(5), 
	CONSTRAINT IdHorario_h PRIMARY KEY (Id_h)
);

INSERT INTO Horarios (Horario_h)
SELECT '08:00' UNION
SELECT '09:00' UNION
SELECT '10:00' UNION
SELECT '11:00' UNION
SELECT '12:00' UNION
SELECT '13:00' UNION
SELECT '14:00' UNION
SELECT '15:00' UNION
SELECT '16:00' UNION
SELECT '17:00' UNION
SELECT '18:00' UNION
SELECT '19:00' UNION
SELECT '20:00'
GO


--------------------------------------------------------------------------Especialidad OK
CREATE TABLE Especialidades (
    IdEspecialidad_esp INT IDENTITY (1,1) NOT NULL,  
    Nombre_esp VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Especialidad PRIMARY KEY (IdEspecialidad_esp)
)
GO


INSERT INTO Especialidades (Nombre_esp)
SELECT 'Pediatría' UNION
SELECT 'Cardiología' UNION
SELECT 'Dermatología' UNION
SELECT 'Traumatología' UNION
SELECT 'Medicina General' UNION
SELECT 'Ginecología' UNION
SELECT 'Neurología' UNION
SELECT 'Oftalmología' UNION
SELECT 'Otorrinolaringología' UNION
SELECT 'Urología' UNION
SELECT 'Psiquiatría' UNION
SELECT 'Endocrinología' UNION
SELECT 'Oncología' UNION
SELECT 'Reumatología' UNION
SELECT 'Nefrología';

GO


---------------------------------------------------------------------------Genero
CREATE TABLE Generos (
    IdGenero_g INT IDENTITY (1,1) NOT NULL,  
    Descripcion_g VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Genero PRIMARY KEY (IdGenero_g)
)
GO

INSERT INTO Generos (Descripcion_g)
SELECT 'Masculino' UNION
SELECT 'Femenino' UNION
SELECT 'Reservado' 

GO


-------------------------------------------------------------------------Usuarios Ok
CREATE TABLE Usuarios (
    Id_usr INT IDENTITY(1,1) NOT NULL, 
    NombreUsuario_usr VARCHAR(20) NOT NULL,
    Contraseña_usr nVARCHAR(64) NOT NULL,
    Rol_usr VARCHAR(15) NOT NULL,  
    CONSTRAINT PK_Usuario PRIMARY KEY (Id_usr)
)
GO

INSERT INTO Usuarios (NombreUsuario_usr, Contraseña_usr, Rol_usr)
SELECT 'Isaias', '8ac157d90ca277975dbf675fe7bbadf66ce06cc359ca79cb997e9a70cf7be6af', 'Administrador' UNION
SELECT 'Lisandro', '7862b9fc4016a0ba1393e275d07148678eff2f2b16a8a248c1071f83b5f6dcc5', 'Administrador' UNION
SELECT 'Abraham', '0d2404e1b787edbeef129585e848c36769214ed96d0a912dc266db5420cd553a', 'Administrador' UNION
SELECT 'Pedro', 'b28f22bf170d6ae5bbd74ae65f32181ed171b6dbc91edfafb841b17e96f0e669', 'Administrador' UNION
SELECT 'Oscar', '7db45f4d9c557bf99e070b412e6ede1fcb2266af1f291c17d64fce9e54fdabbf', 'Administrador' UNION
SELECT 'Juan', '17d2b68b8b7293b2d6ea3226ca734546f0c42cf056c6a6d2aaeee7fe9b06cdc7', 'Administrador' UNION
SELECT 'Medico3','51337028c8b236deb3a0e12c0d901fd24e95b43630df8346aba2abebea80ab5b', 'Medico';

GO

--------------------------------------------------------------------------Administrador Ok
CREATE TABLE Administradores (
    IdAdministrador_adm INT IDENTITY(1,1) NOT NULL,
	IdUsuario_adm int  NOT NULL,
    Nombre_adm CHAR(20) NOT NULL,
	Apellido_adm CHAR(20) NOT NULL,
    Email_adm VARCHAR(500) NOT NULL,
	Telefono_adm CHAR(20) NOT NULL,
	NombreUsuario_adm VARCHAR(20)NOT NULL,
	Contraseña_adm CHAR(5) NOT NULL,
    CONSTRAINT PK_Administrador PRIMARY KEY (IdAdministrador_adm),
	CONSTRAINT UK_IdUsuario UNIQUE (IdUsuario_adm),
	CONSTRAINT FK_Administrador_Usuario FOREIGN KEY (IdUsuario_adm) REFERENCES Usuarios(Id_usr)
)
GO

INSERT INTO Administradores (IdUsuario_adm, Nombre_adm, Apellido_adm, Email_adm, Telefono_adm, NombreUsuario_adm, Contraseña_adm)
SELECT '00001', 'Juan', 'Pérez', 'juan.perez@email.com', '01123456789', 'juanp', '12345' UNION
SELECT '00002', 'María', 'Gómez', 'maria.gomez@email.com', '02234567890', 'mariag', '54321' UNION
SELECT '00003', 'Carlos', 'Rodríguez', 'carlos.rodriguez@email.com', '02914567891', 'carlosr', 'qwert' UNION
SELECT '00004', 'Ana', 'Martínez', 'ana.martinez@email.com', '01198765432', 'anam', 'zxcvb' UNION
SELECT '00005', 'Laura', 'López', 'laura.lopez@email.com', '01112345678', 'laural', 'asdfg';

GO

-------------------------------------------------------------------------Provincias Ok
CREATE TABLE Provincias (
    IdProvincia_prov INT NOT NULL,
    Nombre_prov CHAR(20) NOT NULL,
    CONSTRAINT PK_Provincia PRIMARY KEY (IdProvincia_prov)
)
GO

INSERT INTO Provincias (IdProvincia_prov, Nombre_prov)
VALUES
    (1, 'CABA'),
    (2, 'Buenos Aires'),
    (3, 'Catamarca'),
    (4, 'Chaco'),
    (5, 'Chubut'),
    (6, 'Córdoba'),
    (7, 'Corrientes'),
    (8, 'Entre Ríos'),
    (9, 'Formosa'),
    (10, 'Jujuy'),
    (11, 'La Pampa'),
    (12, 'La Rioja'),
    (13, 'Mendoza'),
    (14, 'Misiones'),
    (15, 'Neuquén'),
    (16, 'Río Negro'),
    (17, 'Salta'),
    (18, 'San Juan'),
    (19, 'San Luis'),
    (20, 'Santa Cruz'),
    (21, 'Santa Fe'),
    (22, 'Santiago del Estero'),
    (23, 'Tierra del Fuego'),
    (24, 'Tucumán');
GO

-------------------------------------------------------------------------Localidades Ok
CREATE TABLE Localidades (
    IdLocalidad_loc INT IDENTITY(1,1) NOT NULL,
	IdProvincia_loc INT NOT NULL,
    Nombre_loc CHAR(50) NOT NULL,
    CONSTRAINT PK_Localidad PRIMARY KEY (IdLocalidad_loc),
	CONSTRAINT FK_Localidad_Provincia FOREIGN KEY (IdProvincia_loc) REFERENCES Provincias(IdProvincia_prov)
)
GO

INSERT INTO Localidades (IdProvincia_loc, Nombre_loc)
SELECT 1, 'San Telmo' UNION
SELECT 1, 'Belgrano' UNION
SELECT 1, 'Caballito' UNION
SELECT 1, 'San Nicolas' UNION
SELECT 1, 'Retiro' UNION
SELECT 2, 'La Plata' UNION
SELECT 2, 'Mar del Plata' UNION
SELECT 2, 'Bahía Blanca' UNION
SELECT 2, 'Tandil' UNION
SELECT 2, 'General Pacheco' UNION
SELECT 3, 'San Fernando del Valle' UNION
SELECT 3, 'Belén' UNION
SELECT 3, 'Tinogasta' UNION
SELECT 3, 'Andalgalá' UNION
SELECT 3, 'Santa María' UNION
SELECT 4, 'Resistencia' UNION
SELECT 4, 'Presidencia Roque Sáenz Peña' UNION
SELECT 4, 'Villa Ángela' UNION
SELECT 4, 'Charata' UNION
SELECT 4, 'General San Martín' UNION
SELECT 5, 'Rawson' UNION
SELECT 5, 'Comodoro Rivadavia' UNION
SELECT 5, 'Trelew' UNION
SELECT 5, 'Puerto Madryn' UNION
SELECT 5, 'Esquel' UNION
SELECT 6, 'Córdoba' UNION
SELECT 6, 'Río Cuarto' UNION
SELECT 6, 'Villa María' UNION
SELECT 6, 'San Francisco' UNION
SELECT 6, 'Alta Gracia' UNION
SELECT 7, 'Corrientes' UNION
SELECT 7, 'Goya' UNION
SELECT 7, 'Paso de los Libres' UNION
SELECT 7, 'Mercedes' UNION
SELECT 7, 'Curuzú Cuatiá' UNION
SELECT 8, 'Paraná' UNION
SELECT 8, 'Concordia' UNION
SELECT 8, 'Gualeguaychú' UNION
SELECT 8, 'Concepción del Uruguay' UNION
SELECT 8, 'Villaguay' UNION
SELECT 9, 'Formosa' UNION
SELECT 9, 'Clorinda' UNION
SELECT 9, 'Pirané' UNION
SELECT 9, 'Ingeniero Juárez' UNION
SELECT 9, 'El Colorado' UNION
SELECT 10, 'San Salvador de Jujuy' UNION
SELECT 10, 'Palpalá' UNION
SELECT 10, 'Libertador General San Martín' UNION
SELECT 10, 'Perico' UNION
SELECT 10, 'El Carmen' UNION
SELECT 11, 'Santa Rosa' UNION
SELECT 11, 'General Pico' UNION
SELECT 11, 'Toay' UNION
SELECT 11, 'General Acha' UNION
SELECT 11, '25 de Mayo' UNION
SELECT 12, 'La Rioja' UNION
SELECT 12, 'Chilecito' UNION
SELECT 12, 'Arauco' UNION
SELECT 12, 'Chamical' UNION
SELECT 12, 'Villa Unión' UNION
SELECT 13, 'Mendoza' UNION
SELECT 13, 'San Rafael' UNION
SELECT 13, 'Godoy Cruz' UNION
SELECT 13, 'Luján de Cuyo' UNION
SELECT 13, 'Maipú' UNION
SELECT 14, 'Posadas' UNION
SELECT 14, 'Oberá' UNION
SELECT 14, 'Eldorado' UNION
SELECT 14, 'Apóstoles' UNION
SELECT 14, 'Puerto Iguazú' UNION
SELECT 15, 'Neuquén' UNION
SELECT 15, 'Plottier' UNION
SELECT 15, 'Centenario' UNION
SELECT 15, 'Zapala' UNION
SELECT 15, 'San Martín de los Andes' UNION
SELECT 16, 'Viedma' UNION
SELECT 16, 'San Carlos de Bariloche' UNION
SELECT 16, 'General Roca' UNION
SELECT 16, 'Cipolletti' UNION
SELECT 16, 'Villa Regina' UNION
SELECT 17, 'Salta' UNION
SELECT 17, 'San Ramón de la Nueva Orán' UNION
SELECT 17, 'Tartagal' UNION
SELECT 17, 'General Güemes' UNION
SELECT 17, 'Metán' UNION
SELECT 18, 'San Juan' UNION
SELECT 18, 'Rawson' UNION
SELECT 18, 'Chimbas' UNION
SELECT 18, 'Rivadavia' UNION
SELECT 18, 'Caucete' UNION
SELECT 19, 'San Luis' UNION
SELECT 19, 'Villa Mercedes' UNION
SELECT 19, 'Merlo' UNION
SELECT 19, 'La Punta' UNION
SELECT 19, 'Justo Daract' UNION
SELECT 20, 'Río Gallegos' UNION
SELECT 20, 'Caleta Olivia' UNION
SELECT 20, 'Pico Truncado' UNION
SELECT 20, 'Puerto Deseado' UNION
SELECT 20, 'Las Heras' UNION
SELECT 21, 'Santa Fe' UNION
SELECT 21, 'Rosario' UNION
SELECT 21, 'Rafaela' UNION
SELECT 21, 'Venado Tuerto' UNION
SELECT 21, 'Reconquista' UNION
SELECT 22, 'Santiago del Estero' UNION
SELECT 22, 'La Banda' UNION
SELECT 22, 'Añatuya' UNION
SELECT 22, 'Termas de Río Hondo' UNION
SELECT 22, 'Fernández' UNION
SELECT 23, 'Ushuaia' UNION
SELECT 23, 'Río Grande' UNION
SELECT 23, 'Tolhuin' UNION
SELECT 23, 'Puerto Almanza' UNION
SELECT 23, 'Cerro Sombrero' UNION
SELECT 24, 'San Miguel de Tucumán' UNION
SELECT 24, 'Tafí Viejo' UNION
SELECT 24, 'Concepción' UNION
SELECT 24, 'Yerba Buena' UNION
SELECT 24, 'Monteros';
GO

---------------------------------------------------- Paises Ok

CREATE TABLE Paises (
    IdPais_p INT IDENTITY (1,1) NOT NULL,
    Nombre_pais CHAR(10) NOT NULL,
    CONSTRAINT PK_Pais PRIMARY KEY (IdPais_p)
)
GO

INSERT INTO Paises (Nombre_pais)
SELECT 'Argentina' UNION 
SELECT 'Venezuela' UNION 
SELECT 'Brasil' UNION 
SELECT 'Chile' UNION 
SELECT 'Colombia' UNION 
SELECT 'Ecuador' UNION 
SELECT 'Guyana' UNION 
SELECT 'Paraguay' UNION 
SELECT 'Perú' UNION 
SELECT 'Surinam' UNION 
SELECT 'Uruguay' UNION 
SELECT 'Bolivia';
GO

-------------------------------------------------------------------------EstadosTurnos Ok
CREATE TABLE EstadoTurnos (
    IdEstadoTurno_et INT IDENTITY(1,1) NOT NULL,
    Nombre_et CHAR(15) NOT NULL,
    CONSTRAINT PK_EstadoTurno PRIMARY KEY (IdEstadoTurno_et)
)
GO

INSERT INTO EstadoTurnos (Nombre_et)
SELECT 'Pendiente' UNION
SELECT 'Cancelado' UNION
SELECT 'Asistido' UNION
SELECT 'No Asistido'
GO

---------------------------------------------------------------------------Medico Ok
CREATE TABLE Medicos (
    Legajo_med INT IDENTITY(1,1) NOT NULL,
    DNI_med CHAR(10) NOT NULL,
	IdUsuario_med INT  NULL, --LO DEJO EN NULL POR AHORA
    Nombre_med VARCHAR(50) NOT NULL,
    Apellido_med VARCHAR(50) NOT NULL,
    Genero_med INT NOT NULL,
    Nacionalidad_med INT NOT NULL,
    FechaNacimiento_med DATETIME NOT NULL,
    Direccion_med VARCHAR(50) NOT NULL,
    Provincia_med INT NOT NULL,
    Localidad_med INT NOT NULL,
    CorreoElectronico_med VARCHAR(50) NOT NULL,
    Telefono_med VARCHAR(15) NOT NULL,
    Especialidad_med INT  NOT NULL,
	Estado_med BIT NOT NULL,
    CONSTRAINT PK_Medico PRIMARY KEY (Legajo_med),
	CONSTRAINT UK_Medico_DNI_med UNIQUE (DNI_med),
    CONSTRAINT FK_Medico_Especialidad FOREIGN KEY (Especialidad_med) REFERENCES Especialidades(IdEspecialidad_esp),
	CONSTRAINT FK_Medico_Genero FOREIGN KEY (Genero_med) REFERENCES Generos(IdGenero_g)
)
GO


INSERT INTO Medicos (DNI_med, IdUsuario_med, Nombre_med, Apellido_med, Genero_med, Nacionalidad_med, FechaNacimiento_med, Direccion_med, Localidad_med, Provincia_med, CorreoElectronico_med, Telefono_med, Especialidad_med, Estado_med)
SELECT '1234567890', 1, 'Juan', 'Pérez', 1, 1, '1980-05-20', 'Calle Falsa 123', 1, 1, 'juan.perez@email.com', '01123456789', 1, 1 UNION
SELECT '1234567891', 2, 'María', 'Gómez', 2, 1, '1985-03-15', 'Avenida Siempre Viva 456', 1, 2, 'maria.gomez@email.com', '02234567890', 2, 1 UNION
SELECT '1234567892', 3, 'Carlos', 'Rodríguez', 1, 1, '1990-07-30', 'Ruta 1 Km 10', 1, 3, 'carlos.rodriguez@email.com', '02914567891', 3, 1 UNION
SELECT '1234567893', 4, 'Ana', 'Martínez', 2, 1, '1982-12-01', 'Calle 10', 1, 4, 'ana.martinez@email.com', '01198765432', 4, 1 UNION
SELECT '1234567894', 5, 'Laura', 'López', 3, 1, '1995-09-25', 'Calle 20', 1, 5, 'laura.lopez@email.com', '01112345678', 5, 1 UNION
SELECT '1234567895', 6, 'Pedro', 'García', 1, 1, '1988-11-20', 'Avenida Libertador 789', 2, 6, 'pedro.garcia@email.com', '03514567892', 5, 1 UNION
SELECT '1234567896', 7, 'Luisa', 'Fernández', 2, 1, '1992-04-05', 'Calle 30', 1, 7, 'luisa.fernandez@email.com', '01123456780', 2, 1 UNION
SELECT '1234567897', 8, 'Javier', 'Mendoza', 1, 1, '1987-08-10', 'Calle 50', 1, 8, 'javier.mendoza@email.com', '01123456781', 5, 1 UNION
SELECT '1234567898', 9, 'Sofía', 'Morales', 2, 1, '1990-01-15', 'Calle 60', 1, 9, 'sofia.morales@email.com', '01123456782', 1, 1 UNION
SELECT '1234567899', 10, 'Ricardo', 'Ramírez', 1, 1, '1983-06-25', 'Avenida San Martín 123', 1, 10, 'ricardo.ramirez@email.com', '01123456783', 2, 1 UNION
SELECT '1234567800', 11, 'Clara', 'Sánchez', 2, 1, '1991-11-30', 'Calle 70', 1, 11, 'clara.sanchez@email.com', '01123456784', 3, 1 UNION
SELECT '1234567801', 12, 'Martín', 'González', 1, 1, '1987-03-10', 'Calle 80', 1, 12, 'martin.gonzalez@email.com', '01123456785', 4, 1 UNION
SELECT '1234567802', 13, 'Valentina', 'Hernández', 2, 1, '1986-05-22', 'Calle 90', 1, 13, 'valentina.hernandez@email.com', '01123456786', 5, 1 UNION
SELECT '1234567803', 14, 'Joaquín', 'Castro', 1, 1, '1993-09-17', 'Calle 100', 1, 14, 'joaquin.castro@email.com', '01123456787', 2, 1 UNION
SELECT '1234567804', 15, 'Elena', 'Díaz', 2, 1, '1994-04-11', 'Calle 110', 1, 15, 'elena.diaz@email.com', '01123456788', 3, 1;

GO


-----------------------------------------------------------------------------Paciente  Ok
CREATE TABLE Pacientes (
    DNI_pac CHAR(10) NOT NULL,
    Nombre_pac CHAR(50) NOT NULL,
    Apellido_pac CHAR(50) NOT NULL,
    Genero_pac INT NOT NULL,
    Nacionalidad_pac INT NOT NULL,
    FechaNacimiento_pac DATETIME NOT NULL,
    Direccion_pac CHAR(100) NOT NULL,
    Provincia_pac INT NOT NULL,
    Localidad_pac INT NOT NULL,
    CorreoElectronico_pac CHAR(100) NOT NULL,
    Telefono_pac CHAR(15) NOT NULL,
	Estado_pac BIT NOT NULL,
    CONSTRAINT PK_Paciente PRIMARY KEY (DNI_pac),
	CONSTRAINT FK_Paciente_IdProvincia FOREIGN KEY (Provincia_pac) REFERENCES Provincias(IdProvincia_prov),
	CONSTRAINT FK_Paciente_IdLocalidad FOREIGN KEY (Localidad_pac) REFERENCES Localidades (IdLocalidad_loc),
	CONSTRAINT FK_Paciente_IdNacionalidad FOREIGN KEY (Nacionalidad_pac) REFERENCES Paises (IdPais_p),
	CONSTRAINT FK_Paciente_Paciente_Genero FOREIGN KEY (Genero_pac) REFERENCES Generos(IdGenero_g)
)
GO

INSERT INTO Pacientes (DNI_pac, Nombre_pac, Apellido_pac, Genero_pac, Nacionalidad_pac, FechaNacimiento_pac, Direccion_pac, Provincia_pac, Localidad_pac, CorreoElectronico_pac, Telefono_pac, Estado_pac)
SELECT '1234567890', 'Juan', 'Perez', 1, 2, '1980-05-20', 'Av. Siempre Viva 123', 1, 1, 'juan.perez@mail.com', '123456789', 1 UNION
SELECT '2345678901', 'Maria', 'Gomez', 2, 1, '1992-08-15', 'Calle Falsa 456', 1, 2, 'maria.gomez@mail.com', '234567890', 1 UNION
SELECT '3456789012', 'Carlos', 'Lopez', 1, 3, '1985-02-10', 'Av. Belgrano 789', 1, 3, 'carlos.lopez@mail.com', '345678901', 1 UNION
SELECT '4567890123', 'Ana', 'Martinez', 3, 1, '1978-11-25', 'San Martin 321', 1, 4, 'ana.martinez@mail.com', '456789012', 1 UNION
SELECT '5678901234', 'Jose', 'Fernandez', 1, 2, '1990-04-18', 'Rivadavia 654', 1, 5, 'jose.fernandez@mail.com', '567890123', 1 UNION
SELECT '6789012345', 'Laura', 'Diaz', 3, 1, '1987-07-07', 'Mitre 987', 2, 6, 'laura.diaz@mail.com', '678901234', 1 UNION
SELECT '7890123456', 'Miguel', 'Garcia', 1, 4, '1995-10-12', 'Sarmiento 1234', 2, 7, 'miguel.garcia@mail.com', '789012345', 1 UNION
SELECT '8901234567', 'Lucia', 'Ruiz', 2, 1, '1991-03-28', 'Urquiza 567', 2, 8, 'lucia.ruiz@mail.com', '890123456', 1 UNION
SELECT '9012345678', 'Diego', 'Sanchez', 3, 6, '1983-12-17', 'Independencia 890', 2, 9, 'diego.sanchez@mail.com', '901234567', 1 UNION
SELECT '0123456789', 'Marta', 'Benitez', 2, 1, '1975-01-05', 'Av. Libertador 1357', 2, 10, 'marta.benitez@mail.com', '012345678', 1 UNION
SELECT '1234567800', 'Pedro', 'Mendoza', 1, 2, '1984-11-13', 'Calle San Juan 101', 1, 11, 'pedro.mendoza@mail.com', '123456781', 1 UNION
SELECT '2345678902', 'Silvia', 'Martinez', 2, 3, '1993-07-22', 'Avenida Buenos Aires 100', 2, 12, 'silvia.martinez@mail.com', '234567891', 1 UNION
SELECT '3456789013', 'Ricardo', 'Morales', 1, 4, '1988-01-17', 'Avenida San Martin 456', 2, 13, 'ricardo.morales@mail.com', '345678902', 1 UNION
SELECT '4567890124', 'Elena', 'Garcia', 3, 1, '1996-09-03', 'Calle Rivadavia 89', 3, 14, 'elena.garcia@mail.com', '456789013', 1 UNION
SELECT '5678901235', 'Marcelo', 'Lopez', 1, 2, '1982-03-05', 'Av. General Paz 567', 3, 15, 'marcelo.lopez@mail.com', '567890124', 1;

GO


-----------------------------------------------------------------------Tabla intermedia MedicosxDias ok
CREATE TABLE MedicoXDias (
    Legajo_med_mxd INT NOT NULL,
    IdDia_d_mxd INT NOT NULL,
	IdHorario_h_mxd INT NOT NULL,
	Estado_mxd BIT NOT NULL,
    CONSTRAINT PK_MedicoDias PRIMARY KEY (Legajo_med_mxd, IdDia_d_mxd,IdHorario_h_mxd),
    CONSTRAINT FK_MedicoDias_Medico FOREIGN KEY (Legajo_med_mxd) REFERENCES Medicos(Legajo_med),
    CONSTRAINT FK_MedicoDias_Dia FOREIGN KEY (IdDia_d_mxd) REFERENCES Dias(IdDia_d),
	CONSTRAINT FK_MedicosDias_Horario FOREIGN KEY (IdHorario_h_mxd) REFERENCES Horarios(Id_h)
)
GO
-- Insertando registros para MedicoXDias
-- Juan Pérez, Pediatría (Legajo_med = 1)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 1, 1, 1, 1 UNION 
SELECT 1, 2, 2, 1 UNION 
SELECT 1, 3, 3, 1 UNION 
SELECT 1, 4, 4, 1 UNION 
SELECT 1, 5, 5, 1;     
GO

-- María Gómez, Cardiología (Legajo_med = 2)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 2, 1, 6, 1 UNION 
SELECT 2, 2, 7, 1 UNION 
SELECT 2, 3, 8, 1 UNION
SELECT 2, 4, 9, 1 UNION 
SELECT 2, 5, 10, 1;    
GO

-- Carlos Rodríguez, Dermatología (Legajo_med = 3)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 3, 6, 11, 1 UNION 
SELECT 3, 7, 12, 1;      
GO

-- Ana Martínez, Traumatología (Legajo_med = 4)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 4, 1, 1, 1 UNION
SELECT 4, 2, 2, 1 UNION
SELECT 4, 3, 3, 1 UNION
SELECT 4, 4, 4, 1 UNION
SELECT 4, 5, 5, 1;      
GO

-- Laura López, Medicina General (Legajo_med = 5)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 5, 1, 6, 1 UNION 
SELECT 5, 2, 7, 1 UNION
SELECT 5, 3, 8, 1 UNION 
SELECT 5, 4, 9, 1 UNION
SELECT 5, 5, 10, 1;     
GO

-- Pedro García, Traumatología (Legajo_med = 6)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 6, 1, 11, 1 UNION 
SELECT 6, 2, 12, 1;     
GO

-- Luisa Fernández, Cardiología (Legajo_med = 7)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 7, 6, 1, 1 UNION  
SELECT 7, 7, 2, 1;     
Go

-- Javier Mendoza, Pediatría (Legajo_med = 8)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 8, 1, 3, 1 UNION 
SELECT 8, 2, 4, 1 UNION  
SELECT 8, 3, 5, 1 UNION 
SELECT 8, 4, 6, 1 UNION 
SELECT 8, 5, 7, 1;   
GO

--Registros Faltantes
-- Sofía Morales, Pediatría (Legajo_med = 9)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 9, 1, 1, 1 UNION 
SELECT 9, 5, 5, 1;     
GO

-- Ricardo Ramírez, Cardiología (Legajo_med = 10)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 10, 1, 6, 1 UNION 
SELECT 10, 5, 10, 1;     
GO

-- Clara Sánchez, Dermatología (Legajo_med = 11)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 11, 6, 11, 1 UNION 
SELECT 11, 7, 12, 1;      
GO

-- Martín González, Traumatología (Legajo_med = 12)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 12, 1, 1, 1 UNION
SELECT 12, 5, 5, 1;      
GO

-- Valentina Hernández, Medicina General (Legajo_med = 13)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 13, 1, 6, 1 UNION 
SELECT 13, 5, 10, 1;     
GO

-- Joaquín Castro, Traumatología (Legajo_med = 14)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 14, 1, 11, 1 UNION 
SELECT 14, 2, 12, 1;     
GO

-- Elena Díaz, Ginecología (Legajo_med = 15)
INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
SELECT 15, 6, 1, 1 UNION  
SELECT 15, 7, 2, 1;     
GO
-------------------------------------------------------------------------Turnos Ok
CREATE TABLE Turnos (
    IdTurno_tu INT IDENTITY(1,1) NOT NULL,            
    IdPaciente_tu CHAR(10) NOT NULL,         
    IdMedico_tu INT NOT NULL,           
    FechaTurno_tu DATE NOT NULL,             
    IdEstadoTurno_tu INT NOT NULL,
	Estado_tur BIT,
	Observacion varchar(255) NOT NULL,
    CONSTRAINT PK_Turno PRIMARY KEY (IdTurno_tu),
    CONSTRAINT FK_Turno_Paciente FOREIGN KEY (IdPaciente_tu) REFERENCES Pacientes(DNI_pac),
    CONSTRAINT FK_Turno_Medico FOREIGN KEY (IdMedico_tu) REFERENCES Medicos(Legajo_med),
    CONSTRAINT FK_Turno_EstadoTurno FOREIGN KEY (IdEstadoTurno_tu) REFERENCES EstadoTurnos(IdEstadoTurno_et)
)
GO


INSERT INTO Turnos (IdPaciente_tu, IdMedico_tu, FechaTurno_tu, IdEstadoTurno_tu, Estado_tur, Observacion)
SELECT '1234567890', 1, '2024-11-10', 1, 1, 'Consulta general con el Dr. A' UNION
SELECT '2345678901', 2, '2024-11-10', 1, 1, 'Control de rutina con el Dr. B' UNION
SELECT '3456789012', 3, '2024-11-11', 1, 1, 'Evaluación cardiológica con el Dr. C' UNION
SELECT '4567890123', 4, '2024-11-11', 1, 1, 'Chequeo general con el Dr. D' UNION
SELECT '5678901234', 5, '2024-11-12', 2, 1, 'Consulta de seguimiento con el Dr. E' UNION
SELECT '6789012345', 6, '2024-11-12', 2, 1, 'Primera consulta con el Dr. F' UNION
SELECT '7890123456', 7, '2024-11-13', 1, 1, 'Chequeo general con el Dr. G' UNION
SELECT '8901234567', 8, '2024-11-13', 1, 1, 'Consulta pediátrica con el Dr. H' UNION
SELECT '9012345678', 1, '2024-11-14', 2, 1, 'Consulta de especialidad con el Dr. A' UNION
SELECT '0123456789', 2, '2024-11-14', 2, 1, 'Consulta de seguimiento con el Dr. B' UNION
SELECT '1234567890', 3, '2024-11-15', 3, 1, 'Consulta de control con el Dr. C' UNION
SELECT '2345678901', 4, '2024-11-15', 3, 1, 'Chequeo preoperatorio con el Dr. D' UNION
SELECT '3456789012', 5, '2024-11-16', 1, 1, 'Consulta nutricional con el Dr. E' UNION
SELECT '4567890123', 6, '2024-11-16', 1, 1, 'Revisión médica con el Dr. F' UNION
SELECT '5678901234', 7, '2024-11-17', 2, 1, 'Consulta programada con el Dr. G' UNION
SELECT '6789012345', 8, '2024-11-17', 2, 1, 'Chequeo médico general con el Dr. H'; 
GO



-------------------------------------------------------------------------Informe 
CREATE TABLE Informes (
    IdInforme_inf INT IDENTITY(1,1) NOT NULL,       
    IdPaciente_inf CHAR(10) NOT NULL,       
    IdMedico_inf INT NOT NULL,          
    Fecha_inf DATE NOT NULL,                  
    Descripcion_inf CHAR(255) NOT NULL,
	Estado_inf BIT NOT NULL,
    CONSTRAINT PK_Informe PRIMARY KEY (IdInforme_inf),
    CONSTRAINT FK_Informe_Paciente FOREIGN KEY (IdPaciente_inf) REFERENCES Pacientes(DNI_pac),
    CONSTRAINT FK_Informe_Medico FOREIGN KEY (IdMedico_inf) REFERENCES Medicos(Legajo_med)
)
GO

  --SELECT m.Legajo_med, 
  --       m.DNI_med, 
  --               m.Nombre_med, 
  --       m.Apellido_med, 
  --       g.Descripcion_g , 
  --      n.Nombre_pais , 
  --       m.FechaNacimiento_med, 
  --       m.Direccion_med, 
  --      pr.Nombre_prov, 
		--l.Nombre_loc , 
  --       m.CorreoElectronico_med, 
  --      m.Telefono_med, 
  --     es.Nombre_esp
  --    FROM Medicos AS m
  --    INNER JOIN GENEROS AS g ON m.Genero_med = g.IdGenero_g
  --    INNER JOIN Paises AS n ON m.Nacionalidad_med = n.IdPais_p
  --    INNER JOIN Localidades AS l ON m.Localidad_med = l.IdLocalidad_loc
  --    INNER JOIN Provincias AS pr ON m.Provincia_med = pr.IdProvincia_prov
  --    INNER JOIN Especialidades as es ON m.Especialidad_med = es.IdEspecialidad_esp
  --    WHERE m.Legajo_med = 1;
	 -- go
 
 --- Comando para agregar la columna observaciones
/*ALTER TABLE Turnos
ADD Observacion varchar(255)*/