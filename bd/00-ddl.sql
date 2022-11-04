DROP DATABASE IF EXISTS Fifa;
CREATE DATABASE Fifa;
USE Fifa;

CREATE TABLE Usuario(
idUsuario INT auto_increment,
USER VARCHAR(15) NOT NULL,
Contrasena CHAR(64) NOT NULL,
Nombre VARCHAR(45) NOT NULL,
Apellido VARCHAR(45) NOT NULL,
Monedas MEDIUMINT UNSIGNED NOT NULL,
CONSTRAINT PK_Usuario PRIMARY KEY (idUsuario),
CONSTRAINT UQ_Usuario_User UNIQUE (nombre)
);

CREATE TABLE Habilidad(
idHabilidad TINYINT UNSIGNED NOT NULL,
Nombre VARCHAR (45) NOT NULL,
Descripcion VARCHAR (45) NOT NULL,
CONSTRAINT PK_Habilidad PRIMARY KEY (idHabilidad)
);

CREATE TABLE Posicion(
idPosicion TINYINT UNSIGNED NOT NULL,
Nombre VARCHAR(45) NOT NULL,
CONSTRAINT Pk_Posicion PRIMARY KEY (idPosicion)
);

CREATE TABLE Futbolista(
idFutbolista INT NOT NULL,
idPosicion TINYINT UNSIGNED NOT NULL,
Nombre VARCHAR (45) NOT NULL,
Apellido VARCHAR (45) NOT NULL,
Nacimiento DATE NOT NULL,
Velocidad TINYINT UNSIGNED NOT NULL,
Remate TINYINT UNSIGNED NOT NULL,
Pase TINYINT UNSIGNED NOT NULL,
Defensa TINYINT UNSIGNED NOT NULL,
PRIMARY KEY (idFutbolista),
CONSTRAINT FK_Futbolista_Posicion FOREIGN KEY (idPosicion)
REFERENCES Posicion (idPosicion)
);

CREATE TABLE Propietario(
idUsuario INT NOT NULL,
idFutbolista INT NOT NULL,
PRIMARY KEY (idUsuario, idFutbolista),
CONSTRAINT FK_Propietario_Usuario FOREIGN KEY (idUsuario)
REFERENCES Usuario (idUsuario),
CONSTRAINT FK_Propietario_Futbolista FOREIGN KEY (idFutbolista)
REFERENCES Futbolista (idFutbolista)
);

CREATE TABLE Skill(
idHabilidad TINYINT UNSIGNED NOT NULL,
idFutbolista INT NOT NULL,
PRIMARY KEY (idHabilidad, idFutbolista),
CONSTRAINT FK_Skill_Habilidad FOREIGN KEY (idHabilidad)
REFERENCES Habilidad (idHabilidad),
CONSTRAINT FK_Skill_Futbolista FOREIGN KEY (idFutbolista)
REFERENCES Futbolista (idFutbolista)
);

CREATE TABLE Transferencia(
idVendedor INT NOT NULL,
idComprador INT NULL,
idFutbolista INT NOT NULL,
Publicacion DATETIME NOT NULL,
Confirmacion DATETIME NULL,
PrecioMonedas MEDIUMINT UNSIGNED NOT NULL,
PRIMARY KEY (idVendedor, idFutbolista, Publicacion),
CONSTRAINT FK_TransferenciaVendedor_Usuario FOREIGN KEY (idVendedor)
REFERENCES Usuario (idUsuario),
CONSTRAINT FK_Transferencia_Futbolista FOREIGN KEY (idFutbolista)
REFERENCES Futbolista (idFutbolista)
);
