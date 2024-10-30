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
    Legajo_med INT IDENTItY(1,1) NOT NULL,
    DNI_med CHAR(10) NOT NULL,
    Nombre_med VARCHAR(50) NOT NULL,
    Apellido_med VARCHAR(50) NOT NULL,
    Genero_med CHAR(50) NOT NULL,
    Nacionalidad_med CHAR(50) NOT NULL,
    FechaNacimiento_med DATE NOT NULL,
    Direccion_med VARCHAR(50) NOT NULL,
    Localidad_medAR CHAR(50) NOT NULL,
    Provincia_med VARCHAR(50) NOT NULL,
    CorreoElectronico_med VARCHAR(50) NOT NULL,
    Telefono_med VARCHAR(15) NOT NULL,
    Especialidad_med VARCHAR(50) NOT NULL,
    DiasAtencion_med VARCHAR(10) NOT NULL,
    HorarioAtencion_med VARCHAR(10) NOT NULL,
    CONSTRAINT PK_Medico PRIMARY KEY (Legajo_med),
	CONSTRAINT FK_Medico_Usuario FOREIGN KEY (IdUsuario_med) REFERENCES Usuarios(Id_usr),
    CONSTRAINT FK_Medico_Especialidad FOREIGN KEY (Especialidad_med) REFERENCES Especialidad(IdEspecialidad_esp),
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


-----------------------------------------------------------------------Tabla intermedia MedicosxDias
CREATE TABLE MedicoXDias (
    Legajo_med_mxd CHAR(5) NOT NULL,
    IdDia_d_mxd CHAR(1) NOT NULL,
    CONSTRAINT PK_MedicoDias PRIMARY KEY (Legajo_med_mxd, IdDia_d_mxd),
    CONSTRAINT FK_MedicoDias_Medico FOREIGN KEY (Legajo_med_mxd) REFERENCES Medicos(Legajo_med),
    CONSTRAINT FK_MedicoDias_Dia FOREIGN KEY (IdDia_d_mxd) REFERENCES Dias(IdDia_d)
)
GO

--Falta crear registros



-------------------------------------------------------------------------RolUsuario
CREATE TABLE RolUsuarios (
    IdRolUsuario_tu INT NOT NULL,      
    Descripcion_tu CHAR(13) NOT NULL,
    CONSTRAINT PK_RolUsuario PRIMARY KEY (IdRolUsuario_tu)
)
GO

INSERT INTO RolUsuarios (IdRolUsuario_tu, Descripcion_tu)
SELECT 1, 'Administrador' UNION
SELECT 2, 'Medico'

GO

-------------------------------------------------------------------------Usuarios
CREATE TABLE Usuarios (
    Id_usr INT IDENTITY(1,1) NOT NULL, 
    NombreUsuario_usr VARCHAR(20) NOT NULL,
    Contraseña_usr VARCHAR(20) NOT NULL,
    Rol_usr CHAR(10) NOT NULL,  
    CONSTRAINT PK_Usuario PRIMARY KEY (Id_usr)
)
GO



--------------------------------------------------------------------------Administrador
CREATE TABLE Administradores (
    IdAdministrador_adm INT IDENTITY(1,1) NOT NULL,
	IdUsuario_adm CHAR (5) NOT NULL,
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
    IdProvincia_prov INT IDENTITY(1,1) NOT NULL,
    Nombre_prov CHAR(50) NOT NULL,
    CONSTRAINT PK_Provincia PRIMARY KEY (IdProvincia_prov)
)
GO

INSERT INTO Provincias (Nombre_prov)
SELECT 'Buenos Aires' UNION
SELECT 'Catamarca' UNION
SELECT 'Chaco' UNION
SELECT 'Chubut' UNION
SELECT 'Córdoba' UNION
SELECT 'Corrientes' UNION
SELECT 'Entre Ríos' UNION
SELECT 'Formosa' UNION
SELECT 'Jujuy' UNION
SELECT 'La Pampa' UNION
SELECT 'La Rioja' UNION
SELECT 'Mendoza' UNION
SELECT 'Misiones' UNION
SELECT 'Neuquén' UNION
SELECT 'Río Negro' UNION
SELECT 'Salta' UNION
SELECT 'San Juan' UNION
SELECT 'San Luis' UNION
SELECT 'Santa Cruz' UNION
SELECT 'Santa Fe' UNION
SELECT 'Santiago del Estero' UNION
SELECT 'Tierra del Fuego' UNION
SELECT 'Tucumán';

GO


-------------------------------------------------------------------------Localidades
CREATE TABLE Localidades (
    IdLocalidad_loc INT IDENTITY(1,1) NOT NULL,
    Nombre_loc VARCHAR(40) NOT NULL,
    CONSTRAINT PK_Localidad PRIMARY KEY (IdLocalidad_loc),
	CONSTRAINT FK_Localidad_Provincia FOREIGN KEY (IdProvincia_prov) REFERENCES Provincias(IdProvincia_prov)
)
GO

INSERT INTO Localidades (Nombre_loc)
SELECT 'La Plata' UNION
SELECT 'Mar del Plata' UNION
SELECT 'Bahía Blanca' UNION
SELECT 'Tandil' UNION
SELECT 'General Pacheco' UNION

SELECT 'San Fernando del Valle' UNION
SELECT 'Belén' UNION
SELECT 'Tinogasta' UNION
SELECT 'Andalgalá' UNION
SELECT 'Santa María' UNION

SELECT 'Resistencia' UNION
SELECT 'Presidencia Roque Sáenz Peña' UNION
SELECT 'Villa Ángela' UNION
SELECT 'Charata' UNION
SELECT 'General San Martín' UNION

SELECT 'Rawson' UNION
SELECT 'Comodoro Rivadavia' UNION
SELECT 'Trelew' UNION
SELECT 'Puerto Madryn' UNION
SELECT 'Esquel' UNION

SELECT 'Córdoba' UNION
SELECT 'Río Cuarto' UNION
SELECT 'Villa María' UNION
SELECT 'San Francisco' UNION
SELECT 'Alta Gracia' UNION

SELECT 'Corrientes' UNION
SELECT 'Goya' UNION
SELECT 'Paso de los Libres' UNION
SELECT 'Mercedes' UNION
SELECT 'Curuzú Cuatiá' UNION

SELECT 'Paraná' UNION
SELECT 'Concordia' UNION
SELECT 'Gualeguaychú' UNION
SELECT 'Concepción del Uruguay' UNION
SELECT 'Villaguay' UNION

SELECT 'Formosa' UNION
SELECT 'Clorinda' UNION
SELECT 'Pirané' UNION
SELECT 'Ingeniero Juárez' UNION
SELECT 'El Colorado' UNION

SELECT 'San Salvador de Jujuy' UNION
SELECT 'Palpalá' UNION
SELECT 'Libertador General San Martín' UNION
SELECT 'Perico' UNION
SELECT 'El Carmen' UNION

SELECT 'Santa Rosa' UNION
SELECT 'General Pico' UNION
SELECT 'Toay' UNION
SELECT 'General Acha' UNION
SELECT '25 de Mayo' UNION

SELECT 'La Rioja' UNION
SELECT 'Chilecito' UNION
SELECT 'Arauco' UNION
SELECT 'Chamical' UNION
SELECT 'Villa Unión' UNION

SELECT 'Mendoza' UNION
SELECT 'San Rafael' UNION
SELECT 'Godoy Cruz' UNION
SELECT 'Luján de Cuyo' UNION
SELECT 'Maipú' UNION

SELECT 'Posadas' UNION
SELECT 'Oberá' UNION
SELECT 'Eldorado' UNION
SELECT 'Apóstoles' UNION
SELECT 'Puerto Iguazú' UNION

SELECT 'Neuquén' UNION
SELECT 'Plottier' UNION
SELECT 'Centenario' UNION
SELECT 'Zapala' UNION
SELECT 'San Martín de los Andes' UNION

SELECT 'Viedma' UNION
SELECT 'San Carlos de Bariloche' UNION
SELECT 'General Roca' UNION
SELECT 'Cipolletti' UNION
SELECT 'Villa Regina' UNION

SELECT 'Salta' UNION
SELECT 'San Ramón de la Nueva Orán' UNION
SELECT 'Tartagal' UNION
SELECT 'General Güemes' UNION
SELECT 'Metán' UNION

SELECT 'San Juan' UNION
SELECT 'Rawson' UNION
SELECT 'Chimbas' UNION
SELECT 'Rivadavia' UNION
SELECT 'Caucete' UNION

SELECT 'San Luis' UNION
SELECT 'Villa Mercedes' UNION
SELECT 'Merlo' UNION
SELECT 'La Punta' UNION
SELECT 'Justo Daract' UNION

SELECT 'Río Gallegos' UNION
SELECT 'Caleta Olivia' UNION
SELECT 'Pico Truncado' UNION
SELECT 'Puerto Deseado' UNION
SELECT 'Las Heras' UNION

SELECT 'Santa Fe' UNION
SELECT 'Rosario' UNION
SELECT 'Rafaela' UNION
SELECT 'Venado Tuerto' UNION
SELECT 'Reconquista' UNION

SELECT 'Santiago del Estero' UNION
SELECT 'La Banda' UNION
SELECT 'Añatuya' UNION
SELECT 'Termas de Río Hondo' UNION
SELECT 'Fernández' UNION

SELECT 'Ushuaia' UNION
SELECT 'Río Grande' UNION
SELECT 'Tolhuin' UNION
SELECT 'Puerto Almanza' UNION
SELECT 'Cerro Sombrero' UNION

SELECT 'San Miguel de Tucumán' UNION
SELECT 'Tafí Viejo' UNION
SELECT 'Concepción' UNION
SELECT 'Yerba Buena' UNION
SELECT 'Monteros';





-------------------------------------------------------------------------EstadosTurnos
CREATE TABLE EstadoTurnos (
    IdEstadoTurno_et INT IDENTITY(1,1) NOT NULL,
    Nombre_et CHAR(50) NOT NULL,
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
    IdMedico_tu CHAR(10) NOT NULL,           
    FechaTurno_tu DATE NOT NULL,             
    IdEstadoTurno_tu CHAR(10) NOT NULL,
    CONSTRAINT PK_Turno PRIMARY KEY (IdTurno_tu),
    CONSTRAINT FK_Turno_Paciente FOREIGN KEY (IdPaciente_tu) REFERENCES Paciente(DNI_pac),
    CONSTRAINT FK_Turno_Medico FOREIGN KEY (IdMedico_tu) REFERENCES Medico(DNI_med),
    CONSTRAINT FK_Turno_EstadoTurno FOREIGN KEY (IdEstadoTurno_tu) REFERENCES EstadoTurno(IdEstadoTurno_et)
)
GO