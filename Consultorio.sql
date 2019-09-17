CREATE DATABASE ClinicaSql3

USE ClinicaSql3

CREATE TABLE Paciente(
	idPaciente BIGINT IDENTITY(1,1) NOT NULL,
	nombrePaciente VARCHAR(30) NOT NULL,
	apellidoPaciente VARCHAR(30) NOT NULL,
	calleNPaciente VARCHAR(25) NOT NULL,
	coloniaPaciente VARCHAR(25) NOT NULL,
	celularPaciente VARCHAR(20) NOT NULL,
	telefonoPaciente VARCHAR(20),
	emailPaciente VARCHAR(35),
	
	CONSTRAINT PK_Paciente PRIMARY KEY (idPaciente)
)

CREATE TABLE Cita(
	idCita BIGINT IDENTITY(1,1) NOT NULL,
	idCitaPaciente BIGINT NOT NULL,
	fechaCita DATE NOT NULL,
	horaCita VARCHAR(20) NOT NULL,

	CONSTRAINT PK_Cita PRIMARY KEY (idCita),
	CONSTRAINT FK_Cita_Paciente FOREIGN KEY (idCitaPaciente) REFERENCES Paciente (idPaciente)
)

-- ____________________________________________
CREATE TABLE Imagen(
	idImagen BIGINT IDENTITY(1,1) NOT NULL,
	idImagenPaciente BIGINT NOT NULL,
	fechaImagen DATE NOT NULL,
	descripcionImagen VARCHAR(80),

	CONSTRAINT PK_Imagen PRIMARY KEY (idImagen),
	CONSTRAINT FK_Imagen_Paciente FOREIGN KEY (idImagenPaciente) REFERENCES Paciente (idPaciente)
)

CREATE TABLE Tipo_Empleado(
	idTipoEmpleado BIGINT IDENTITY(1,1) NOT NULL,
	nombreTipo VARCHAR(30) NOT NULL,
	permisoTipo VARCHAR(23) NOT NULL,

	CONSTRAINT PK_Tipo_Empleado PRIMARY KEY (idTipoEmpleado)
)

CREATE TABLE Empleado(
	idEmpleado BIGINT IDENTITY(1,1) NOT NULL,
	nombreEmpleado VARCHAR(30) NOT NULL,
	apellidoEmpleado VARCHAR(30) NOT NULL,
	nicknameEmpleado VARCHAR(35) NOT NULL,
	calleNEmpleado VARCHAR(25),
	coloniaEmpleado VARCHAR(25),
	celularEmpleado VARCHAR(20) NOT NULL,
	telefonoEmpleado VARCHAR(20),
	emailEmpleado VARCHAR(35),
	passwordEmpleado VARCHAR(25) NOT NULL,
	idEmpleadoTipoEmpleado BIGINT NOT NULL,

	CONSTRAINT PK_Usuario PRIMARY KEY (idEmpleado),
	CONSTRAINT FK_Empleado_Tipo_Empleado FOREIGN KEY (idEmpleadoTipoEmpleado) REFERENCES Tipo_Empleado (idTipoEmpleado)
)

CREATE TABLE Observacion(
	idObservacion BIGINT IDENTITY(1,1) NOT NULL,
	idObservacionPaciente BIGINT NOT NULL,
	idObservacionEmpleado BIGINT NOT NULL,
	fechaObservacion DATE NOT NULL,
	descripcionObservacion VARCHAR(80) NOT NULL,

	CONSTRAINT PK_Observacion PRIMARY KEY (idObservacion),
	CONSTRAINT FK_Observacion_Paciente FOREIGN KEY (idObservacionPaciente) REFERENCES Paciente (idPaciente),
	CONSTRAINT FK_Observacion_Empleado FOREIGN KEY (idObservacionEmpleado) REFERENCES Empleado (idEmpleado)
)
