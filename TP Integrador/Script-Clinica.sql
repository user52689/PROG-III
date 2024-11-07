CREATE DATABASE Clinica
GO

USE Clinica
GO

------------------------------------------------------------------------Dias
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


------------------------------------------------------------------------Horario
CREATE TABLE Horarios (
    Id_h INT IDENTITY(1,1) NOT NULL,
    Horario_h CHAR(5), 
	CONSTRAINT IdHorario_h PRIMARY KEY (Id_h),
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



-----------------------------------------------------------------------Tabla intermedia MedicosxDias
CREATE TABLE MedicoXDias (
    Legajo_med_mxd INT NOT NULL,
    IdDia_d_mxd INT NOT NULL,
	IdHorario_h_mxd INT NOT NULL,
    CONSTRAINT PK_MedicoDias PRIMARY KEY (Legajo_med_mxd, IdDia_d_mxd,IdHorario_h_mxd),
    CONSTRAINT FK_MedicoDias_Medico FOREIGN KEY (Legajo_med_mxd) REFERENCES Medicos(Legajo_med),
    CONSTRAINT FK_MedicoDias_Dia FOREIGN KEY (IdDia_d_mxd) REFERENCES Dias(IdDia_d),
	CONSTRAINT FK_MedicosDias_Horario FOREIGN KEY (IdHorario_h_mxd) REFERENCES Horarios(Id_h)
)
GO






--------------------------------------------------------------------------Especialidad
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
SELECT 'Medicina General'

GO


---------------------------------------------------------------------------Medico
CREATE TABLE Medicos (
    Legajo_med INT IDENTITY(1,1) NOT NULL,
    DNI_med CHAR(10) NOT NULL,
	IdUsuario_med int NOT NULL,
    Nombre_med VARCHAR(50) NOT NULL,
    Apellido_med VARCHAR(50) NOT NULL,
    Genero_med CHAR(50) NOT NULL,
    Nacionalidad_med CHAR(50) NOT NULL,
    FechaNacimiento_med DATE NOT NULL,
    Direccion_med VARCHAR(50) NOT NULL,
    Localidad_medAR INT NOT NULL,
    Provincia_med INT NOT NULL,
    CorreoElectronico_med VARCHAR(50) NOT NULL,
    Telefono_med VARCHAR(15) NOT NULL,
    Especialidad_med INT NOT NULL,
    HorarioAtencion_med INT NOT NULL,
    CONSTRAINT PK_Medico PRIMARY KEY (Legajo_med),
	CONSTRAINT UK_DNI_med UNIQUE (DNI_med),
	CONSTRAINT FK_Medico_Usuario FOREIGN KEY (IdUsuario_med) REFERENCES Usuarios(Id_usr),
    CONSTRAINT FK_Medico_Especialidad FOREIGN KEY (Especialidad_med) REFERENCES Especialidades(IdEspecialidad_esp),
	CONSTRAINT FK_Medico_Provincia FOREIGN KEY (Provincia_med) REFERENCES Provincias (IdProvincia_prov)
)
GO

INSERT INTO Medicos (DNI_med, Nombre_med, Apellido_med, Genero_med, Nacionalidad_med, FechaNacimiento_med, Direccion_med, Localidad_medAR, Provincia_med, CorreoElectronico_med, Telefono_med, Especialidad_med, DiasAtencion_med, HorarioAtencion_med)
SELECT '1234567890', 'Juan', 'Pérez', 'Masculino', 'Argentino', '1980-05-20', 'Calle Falsa 123', 'La Plata', 'Buenos Aires', 'juan.perez@email.com', '01123456789', 'Pediatría', 'Lunes a Viernes', '09:00-17:00' UNION
SELECT '1234567891', 'María', 'Gómez', 'Femenino', 'Argentina', '1985-03-15', 'Avenida Siempre Viva 456', 'Mar del Plata', 'Buenos Aires', 'maria.gomez@email.com', '02234567890', 'Cardiología', 'Martes a Sábado', '10:00-18:00' UNION
SELECT '1234567892', 'Carlos', 'Rodríguez', 'Masculino', 'Argentino', '1990-07-30', 'Ruta 1 Km 10', 'Bahía Blanca', 'Buenos Aires', 'carlos.rodriguez@email.com', '02914567891', 'Dermatología', 'Miércoles a Domingo', '11:00-19:00' UNION
SELECT '1234567893', 'Ana', 'Martínez', 'Femenino', 'Argentina', '1982-12-01', 'Calle 10', 'Tandil', 'Buenos Aires', 'ana.martinez@email.com', '01198765432', 'Neurología', 'Lunes, Miércoles y Viernes', '08:00-16:00' UNION
SELECT '1234567894', 'Laura', 'López', 'Femenino', 'Argentina', '1995-09-25', 'Calle 20', 'General Pacheco', 'Buenos Aires', 'laura.lopez@email.com', '01112345678', 'Medicina General', 'Lunes a Viernes', '09:00-17:00' UNION
SELECT '1234567895', 'Pedro', 'García', 'Masculino', 'Argentino', '1988-11-20', 'Avenida Libertador 789', 'Córdoba', 'Córdoba', 'pedro.garcia@email.com', '03514567892', 'Traumatología', 'Lunes a Jueves', '08:30-16:30' UNION
SELECT '1234567896', 'Luisa', 'Fernández', 'Femenino', 'Argentina', '1992-04-05', 'Calle 30', 'San Fernando', 'Buenos Aires', 'luisa.fernandez@email.com', '01123456780', 'Ginecología', 'Martes a Viernes', '09:00-18:00' UNION
SELECT '1234567897', 'Javier', 'Mendoza', 'Masculino', 'Argentino', '1987-08-10', 'Calle 50', 'Lanús', 'Buenos Aires', 'javier.mendoza@email.com', '01123456781', 'Oftalmología', 'Lunes a Sábado', '09:00-17:00';

GO




-------------------------------------------------------------------------Usuarios
CREATE TABLE Usuarios (
    Id_usr INT IDENTITY(1,1) NOT NULL, 
    NombreUsuario_usr VARCHAR(20) NOT NULL,
    Contraseña_usr nVARCHAR(64) NOT NULL,
    Rol_usr VARCHAR(15) NOT NULL,  
    CONSTRAINT PK_Usuario PRIMARY KEY (Id_usr)
)
GO

INSERT INTO Usuarios (NombreUsuario_usr, Contraseña_usr, Rol_usr)
SELECT 'admin', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Administrador' UNION
SELECT 'medico','bcbc6a61932168321c3693b41d7251d7888ead27c66c51150f4feae1d6327642', 'Medico';

GO

--------------------------------------------------------------------------Administrador
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

-----------------------------------------------------------------------------Paciente
CREATE TABLE Pacientes (
    DNI_pac CHAR(10) NOT NULL,
    Nombre_pac CHAR(50) NOT NULL,
    Apellido_pac CHAR(50) NOT NULL,
    Genero_pac CHAR(10) NOT NULL,
    Nacionalidad_pac CHAR(30) NOT NULL,
    FechaNacimiento_pac DATE NOT NULL,
    Direccion_pac CHAR(100) NOT NULL,
    Localidad_pac CHAR(50) NOT NULL,
    Provincia_pac CHAR(50) NOT NULL,
    CorreoElectronico_pac CHAR(100) NOT NULL,
    Telefono_pac CHAR(15) NOT NULL,
    CONSTRAINT PK_Paciente PRIMARY KEY (DNI_pac),
	CONSTRAINT FK_IdProvincia FOREIGN KEY(Provincia_pac) REFERENCES Provincias(IdProvincia_prov)
)
GO

INSERT INTO Pacientes (DNI_pac, Nombre_pac, Apellido_pac, Genero_pac, Nacionalidad_pac, FechaNacimiento_pac, Direccion_pac, Localidad_pac, Provincia_pac, CorreoElectronico_pac, Telefono_pac)
SELECT '1234567890', 'Juan', 'Perez', 'Masculino', 'Argentina', '1980-05-20', 'Av. Siempre Viva 123', 'La Plata', '1', 'juan.perez@mail.com', '123456789' UNION
SELECT '2345678901', 'Maria', 'Gomez', 'Femenino', 'Argentina', '1992-08-15', 'Calle Falsa 456', 'Mar del Plata', '1', 'maria.gomez@mail.com', '234567890' UNION
SELECT '3456789012', 'Carlos', 'Lopez', 'Masculino', 'Argentina', '1985-02-10', 'Av. Belgrano 789', 'Bahía Blanca', '1', 'carlos.lopez@mail.com', '345678901' UNION
SELECT '4567890123', 'Ana', 'Martinez', 'Femenino', 'Argentina', '1978-11-25', 'San Martin 321', 'Tandil', '1', 'ana.martinez@mail.com', '456789012' UNION
SELECT '5678901234', 'Jose', 'Fernandez', 'Masculino', 'Argentina', '1990-04-18', 'Rivadavia 654', 'General Pacheco', '1', 'jose.fernandez@mail.com', '567890123' UNION
SELECT '6789012345', 'Laura', 'Diaz', 'Femenino', 'Argentina', '1987-07-07', 'Mitre 987', 'San Fernando del Valle', '2', 'laura.diaz@mail.com', '678901234' UNION
SELECT '7890123456', 'Miguel', 'Garcia', 'Masculino', 'Argentina', '1995-10-12', 'Sarmiento 1234', 'Belén', '2', 'miguel.garcia@mail.com', '789012345' UNION
SELECT '8901234567', 'Lucia', 'Ruiz', 'Femenino', 'Argentina', '1991-03-28', 'Urquiza 567', 'Tinogasta', '2', 'lucia.ruiz@mail.com', '890123456' UNION
SELECT '9012345678', 'Diego', 'Sanchez', 'Masculino', 'Argentina', '1983-12-17', 'Independencia 890', 'Andalgalá', '2', 'diego.sanchez@mail.com', '901234567' UNION
SELECT '0123456789', 'Marta', 'Benitez', 'Femenino', 'Argentina', '1975-01-05', 'Av. Libertador 1357', 'Santa María', '2', 'marta.benitez@mail.com', '012345678'

GO


-------------------------------------------------------------------------Informe
CREATE TABLE Informes (
    IdInforme_inf INT IDENTITY(1,1) NOT NULL,       
    IdPaciente_inf CHAR(10) NOT NULL,       
    IdMedico_inf CHAR(5) NOT NULL,          
    Fecha_inf DATE NOT NULL,                  
    Descripcion_inf CHAR(255) NOT NULL,
    CONSTRAINT PK_Informe PRIMARY KEY (IdInforme_inf),
    CONSTRAINT FK_Informe_Paciente FOREIGN KEY (IdPaciente_inf) REFERENCES Pacientes(DNI_pac),
    CONSTRAINT FK_Informe_Medico FOREIGN KEY (IdMedico_inf) REFERENCES Medicos(Legajo_med)
)
GO





-------------------------------------------------------------------------Provincias
CREATE TABLE Provincias (
    IdProvincia_prov INT NOT NULL,
    Nombre_prov VARCHAR(50) NOT NULL,
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


-------------------------------------------------------------------------Localidades
CREATE TABLE Localidades (
    IdLocalidad_loc INT IDENTITY(1,1) NOT NULL,
	IdProvincia_prov int NOT NULL,
    Nombre_loc VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Localidad PRIMARY KEY (IdLocalidad_loc),
	CONSTRAINT FK_Localidad_Provincia FOREIGN KEY (IdProvincia_prov) REFERENCES Provincias(IdProvincia_prov)
)
GO

INSERT INTO Localidades (IdProvincia_prov, Nombre_loc)
VALUES
    (1, 'San Telmo'),
    (1, 'Belgrano'),
    (1, 'Caballito'),
    (1, 'San Nicolas'),
    (1, 'Retiro'),

    (2, 'La Plata'),
    (2, 'Mar del Plata'),
    (2, 'Bahía Blanca'),
    (2, 'Tandil'),
    (2, 'General Pacheco'),

    (3, 'San Fernando del Valle'),
    (3, 'Belén'),
    (3, 'Tinogasta'),
    (3, 'Andalgalá'),
    (3, 'Santa María'),

    (4, 'Resistencia'),
    (4, 'Presidencia Roque Sáenz Peña'),
    (4, 'Villa Ángela'),
    (4, 'Charata'),
    (4, 'General San Martín'),

    (5, 'Rawson'),
    (5, 'Comodoro Rivadavia'),
    (5, 'Trelew'),
    (5, 'Puerto Madryn'),
    (5, 'Esquel'),

    (6, 'Córdoba'),
    (6, 'Río Cuarto'),
    (6, 'Villa María'),
    (6, 'San Francisco'),
    (6, 'Alta Gracia'),

    (7, 'Corrientes'),
    (7, 'Goya'),
    (7, 'Paso de los Libres'),
    (7, 'Mercedes'),
    (7, 'Curuzú Cuatiá'),

    (8, 'Paraná'),
    (8, 'Concordia'),
    (8, 'Gualeguaychú'),
    (8, 'Concepción del Uruguay'),
    (8, 'Villaguay'),

    (9, 'Formosa'),
    (9, 'Clorinda'),
    (9, 'Pirané'),
    (9, 'Ingeniero Juárez'),
    (9, 'El Colorado'),

    (10, 'San Salvador de Jujuy'),
    (10, 'Palpalá'),
    (10, 'Libertador General San Martín'),
    (10, 'Perico'),
    (10, 'El Carmen'),

    (11, 'Santa Rosa'),
    (11, 'General Pico'),
    (11, 'Toay'),
    (11, 'General Acha'),
    (11, '25 de Mayo'),

    (12, 'La Rioja'),
    (12, 'Chilecito'),
    (12, 'Arauco'),
    (12, 'Chamical'),
    (12, 'Villa Unión'),

    (13, 'Mendoza'),
    (13, 'San Rafael'),
    (13, 'Godoy Cruz'),
    (13, 'Luján de Cuyo'),
    (13, 'Maipú'),

    (14, 'Posadas'),
    (14, 'Oberá'),
    (14, 'Eldorado'),
    (14, 'Apóstoles'),
    (14, 'Puerto Iguazú'),

    (15, 'Neuquén'),
    (15, 'Plottier'),
    (15, 'Centenario'),
    (15, 'Zapala'),
    (15, 'San Martín de los Andes'),

    (16, 'Viedma'),
    (16, 'San Carlos de Bariloche'),
    (16, 'General Roca'),
    (16, 'Cipolletti'),
    (16, 'Villa Regina'),

    (17, 'Salta'),
    (17, 'San Ramón de la Nueva Orán'),
    (17, 'Tartagal'),
    (17, 'General Güemes'),
    (17, 'Metán'),

    (18, 'San Juan'),
    (18, 'Rawson'),
    (18, 'Chimbas'),
    (18, 'Rivadavia'),
    (18, 'Caucete'),

    (19, 'San Luis'),
    (19, 'Villa Mercedes'),
    (19, 'Merlo'),
    (19, 'La Punta'),
    (19, 'Justo Daract'),

    (20, 'Río Gallegos'),
    (20, 'Caleta Olivia'),
    (20, 'Pico Truncado'),
    (20, 'Puerto Deseado'),
    (20, 'Las Heras'),

    (21, 'Santa Fe'),
    (21, 'Rosario'),
    (21, 'Rafaela'),
    (21, 'Venado Tuerto'),
    (21, 'Reconquista'),

    (22, 'Santiago del Estero'),
    (22, 'La Banda'),
    (22, 'Añatuya'),
    (22, 'Termas de Río Hondo'),
    (22, 'Fernández'),

    (23, 'Ushuaia'),
    (23, 'Río Grande'),
    (23, 'Tolhuin'),
    (23, 'Puerto Almanza'),
    (23, 'Cerro Sombrero'),

    (24, 'San Miguel de Tucumán'),
    (24, 'Tafí Viejo'),
    (24, 'Concepción'),
    (24, 'Yerba Buena'),
    (24, 'Monteros');

---------------------------------------------------- Paises

CREATE TABLE Paises (
    IdPais INT NOT NULL,
    Nombre_pais VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Pais PRIMARY KEY (IdPais)
)
GO

INSERT INTO Paises (IdPais, Nombre_pais)
VALUES
    (1, 'Argentina'),
    (2, 'Bolivia'),
    (3, 'Brasil'),
    (4, 'Chile'),
    (5, 'Colombia'),
    (6, 'Ecuador'),
    (7, 'Guyana'),
    (8, 'Paraguay'),
    (9, 'Perú'),
    (10, 'Surinam'),
    (11, 'Uruguay'),
    (12, 'Venezuela')
GO


-------------------------------------------------------------------------EstadosTurnos
CREATE TABLE EstadoTurnos (
    IdEstadoTurno_et INT IDENTITY(1,1) NOT NULL,
    Nombre_et VARCHAR(50) NOT NULL,
    CONSTRAINT PK_EstadoTurno PRIMARY KEY (IdEstadoTurno_et)
)
GO

INSERT INTO EstadoTurnos (Nombre_et)
SELECT 'Pendiente' UNION
SELECT 'Cancelado' UNION
SELECT 'Asistido' UNION
SELECT 'No Asistido'
GO




-------------------------------------------------------------------------Turnos
CREATE TABLE Turnos (
    IdTurno_tu INT IDENTITY(1,1) NOT NULL,            
    IdPaciente_tu CHAR(10) NOT NULL,         
    IdMedico_tu INT NOT NULL,           
    FechaTurno_tu DATE NOT NULL,             
    IdEstadoTurno_tu INT NOT NULL,
    CONSTRAINT PK_Turno PRIMARY KEY (IdTurno_tu),
    CONSTRAINT FK_Turno_Paciente FOREIGN KEY (IdPaciente_tu) REFERENCES Pacientes(DNI_pac),
    CONSTRAINT FK_Turno_Medico FOREIGN KEY (IdMedico_tu) REFERENCES Medicos(Legajo_med),
    CONSTRAINT FK_Turno_EstadoTurno FOREIGN KEY (IdEstadoTurno_tu) REFERENCES EstadoTurnos(IdEstadoTurno_et)
)
GO

----------------------------------------------------------------------- Stored Procedures


