

create database Shopping_cart

GO
USE Shopping_cart
GO

CREATE TABLE PRODUCTO(
	IdProducto INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(500),
	Descripcion VARCHAR(500),
	Precio DECIMAL(10,2) DEFAULT 0,
	Stock INT,
	Activo BIT DEFAULT 1
)

go

CREATE TABLE USUARIO(
	IdUsuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombres NVARCHAR(100) NOT NULL,
	Direccion NVARCHAR(100) NOT NULL,
	Telefono NVARCHAR(100) NOT NULL,
	NombreUsuario NVARCHAR(100) NOT NULL UNIQUE ,
	Contrasenna NVARCHAR(20) NOT NULL,
	EsAdministrador BIT NOT NULL
)

go


CREATE TABLE CARRITO(
	IdCarrito INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdUsuario INT NOT NULL,
	IdProducto INT NOT NULL,
	FOREIGN KEY (IdUsuario) REFERENCES USUARIO(IdUsuario),
	FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
)

go

CREATE TABLE COMPRA(
	IdCompra INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdUsuario INT NOT NULL,
	TotalProducto INT NOT NULL,
	Total DECIMAL(10,2) NOT NULL,
	FechaCompra DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (IdUsuario) REFERENCES USUARIO(IdUsuario)
) 

GO 

CREATE table DETALLE_COMPRA(
	IdDetalleCompra INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdCompra INT  NOT NULL,
	IdProducto INT  NOT NULL,
	Cantidad INT  NOT NULL,
	Total DECIMAL(10,2)  NOT NULL
	FOREIGN KEY (IdCompra) REFERENCES COMPRA(IdCompra),
	FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
)