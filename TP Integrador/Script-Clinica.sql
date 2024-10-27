CREATE DATABASE Clinica;
GO

CREATE TABLE Usuario (
    Id_usr CHAR(10), 
    NombreUsuario_usr CHAR(50),
    Contraseña_usr CHAR(50),
    Rol_usr CHAR(30),
    CONSTRAINT PK_Usuario PRIMARY KEY (Id_usr)
);

CREATE TABLE TipoUsuario (
    IdTipoUsuario_tu CHAR(10),      
    Descripcion_tu CHAR(50),
    CONSTRAINT PK_TipoUsuario PRIMARY KEY (IdTipoUsuario_tu)
);

CREATE TABLE Medico (
    Legajo_med CHAR(20),
    DNI_med CHAR(10),
    Nombre_med CHAR(50),
    Apellido_med CHAR(50),
    Genero_med CHAR(10),
    Nacionalidad_med CHAR(30),
    FechaNacimiento_med DATE,
    Direccion_med CHAR(100),
    Localidad_med CHAR(50),
    Provincia_med CHAR(50),
    CorreoElectronico_med CHAR(100),
    Telefono_med CHAR(15),
    Especialidad_med CHAR(50),
    DiasAtencion_med CHAR(50),
    HorarioAtencion_med CHAR(50),
    CONSTRAINT PK_Medico PRIMARY KEY (DNI_med)
);

CREATE TABLE Paciente (
    DNI_pac CHAR(10),
    Nombre_pac CHAR(50),
    Apellido_pac CHAR(50),
    Sexo_pac CHAR(10),
    Nacionalidad_pac CHAR(30),
    FechaNacimiento_pac DATE,
    Direccion_pac CHAR(100),
    Localidad_pac CHAR(50),
    Provincia_pac CHAR(50),
    CorreoElectronico_pac CHAR(100),
    Telefono_pac CHAR(15),
    CONSTRAINT PK_Paciente PRIMARY KEY (DNI_pac)
);

CREATE TABLE Especialidad (
    IdEspecialidad_esp CHAR(10),  
    Nombre_esp CHAR(50),
    CONSTRAINT PK_Especialidad PRIMARY KEY (IdEspecialidad_esp)
);

CREATE TABLE Informe (
    IdInforme_inf CHAR(10),       
    IdPaciente_inf CHAR(10),       
    IdMedico_inf CHAR(10),          
    Fecha_inf DATE,                  
    Descripcion_inf CHAR(255),
    CONSTRAINT PK_Informe PRIMARY KEY (IdInforme_inf)
);

CREATE TABLE Provincia (
    IdProvincia_prov CHAR(10),
    Nombre_prov CHAR(50),
    CONSTRAINT PK_Provincia PRIMARY KEY (IdProvincia_prov)
);

CREATE TABLE Localidad (
    IdLocalidad_loc CHAR(10),
    Nombre_loc CHAR(50),
    CONSTRAINT PK_Localidad PRIMARY KEY (IdLocalidad_loc)
);

CREATE TABLE EstadoTurno (
    IdEstadoTurno_et CHAR(10),
    Nombre_et CHAR(50),
    CONSTRAINT PK_EstadoTurno PRIMARY KEY (IdEstadoTurno_et)
);

CREATE TABLE Turno (
    IdTurno_tu CHAR(10),            
    IdPaciente_tu CHAR(10),         
    IdMedico_tu CHAR(10),           
    FechaTurno_tu DATE,             
    IdEstadoTurno_tu CHAR(10),
    CONSTRAINT PK_Turno PRIMARY KEY (IdTurno_tu)
);
