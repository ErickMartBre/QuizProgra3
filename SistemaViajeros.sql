USE master

CREATE DATABASE SistemaViajeros;
GO

USE SistemaViajeros;
GO

-- Tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(150) NOT NULL UNIQUE,
    Contrasena NVARCHAR(255) NOT NULL
);
GO

-- Tabla Viajeros
CREATE TABLE Viajeros (
    ViajeroID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    ApellidoPaterno NVARCHAR(100) NOT NULL,
    ApellidoMaterno NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Nacionalidad NVARCHAR(50) NOT NULL,
    Genero NVARCHAR(10) NOT NULL,
    UsuarioID INT NOT NULL,
    CONSTRAINT FK_Viajeros_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

-- Tabla Documentos
CREATE TABLE Documentos (
    DocumentoID INT IDENTITY(1,1) PRIMARY KEY,
    TipoDocumento NVARCHAR(50) NOT NULL,
    Numero NVARCHAR(50) NOT NULL UNIQUE,
    FechaExpiracion DATE NOT NULL,
    ViajeroID INT NOT NULL,
    CONSTRAINT FK_Documentos_Viajeros FOREIGN KEY (ViajeroID) REFERENCES Viajeros(ViajeroID)
);
GO

-- Tabla Puntos de Control
CREATE TABLE PuntosDeControl (
    PuntoControlID INT IDENTITY(1,1) PRIMARY KEY,
    NombreControl NVARCHAR(100) NOT NULL,
    Ubicacion NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    UsuarioID INT NOT NULL,
    CONSTRAINT FK_PuntosDeControl_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

-- Tabla Movimientos
CREATE TABLE Movimientos (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    ViajeroID INT NOT NULL,
    DocumentoID INT NOT NULL,
    PuntoControlOrigen INT NOT NULL,
    PuntoControlDestino INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    TipoSolicitud NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Movimientos_Viajeros FOREIGN KEY (ViajeroID) REFERENCES Viajeros(ViajeroID),
    CONSTRAINT FK_Movimientos_Documentos FOREIGN KEY (DocumentoID) REFERENCES Documentos(DocumentoID),
    CONSTRAINT FK_Movimientos_Origen FOREIGN KEY (PuntoControlOrigen) REFERENCES PuntosDeControl(PuntoControlID),
    CONSTRAINT FK_Movimientos_Destino FOREIGN KEY (PuntoControlDestino) REFERENCES PuntosDeControl(PuntoControlID)
);
GO