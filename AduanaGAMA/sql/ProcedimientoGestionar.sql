If  Object_id(N'DBO.Gestionar','P') IS NOT NULL 
Begin 
 Drop Procedure [DBO].Gestionar;
End;
Go

CREATE PROCEDURE Gestionar
	@Activar VARCHAR(20),
	@nombre NVARCHAR(100) = null,
	@direccion NVARCHAR(100)  = null,
	@telefono NVARCHAR(100)  = null,
	@usuario NVARCHAR(100) = null,
	@contrasenna NVARCHAR(100) = null,
	@rol INT  = null,
	@id INT  = null,
	@descripcion VARCHAR(500) = null,
	@precio DECIMAL(10,2)= null,
	@stock INT = null,
	@idusuario INT = null,
	@idproducto INT = null,
	@TotalProducto INT = null,
	@Total INT = null
AS 
BEGIN
	IF @Activar = 'Insertar'
	BEGIN
		IF NOT EXISTS (SELECT NombreUsuario FROM USUARIO WHERE NombreUsuario = @usuario)
		BEGIN
			INSERT INTO  USUARIO(nombres,Direccion,Telefono,NombreUsuario,contrasenna,EsAdministrador)
			VALUES (@nombre, @direccion, @telefono, @usuario, @contrasenna, @rol)

			--retorna el id de la ultima insercion
			SELECT SCOPE_IDENTITY() AS Id
			RETURN 
		END
	END
	IF @Activar = 'Login'
	BEGIN
		SELECT 
			U.IdUsuario, 
			U.Nombres, 
			U.EsAdministrador AS Rol, 
			(SELECT COUNT(IdProducto) AS Cantidad FROM CARRITO 
			WHERE IdUsuario = U.IdUsuario) AS Cantidad 
		FROM USUARIO U WHERE U.NombreUsuario = @usuario and U.Contrasenna = @Contrasenna

		RETURN
	END
	IF @Activar = 'InsertProducto'
	BEGIN
		IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Descripcion = @Descripcion)
		BEGIN
			INSERT INTO PRODUCTO(Nombre,Descripcion,Precio,Stock) VALUES (
			@Nombre,@Descripcion,@Precio,@Stock)

			SELECT SCOPE_IDENTITY() AS Id
			RETURN
		END
	END

	IF @Activar = 'ConsultarProducto'
	BEGIN
		SELECT IdProducto, Nombre, Descripcion, Precio, Stock FROM PRODUCTO WHERE Activo <> 0
		RETURN
	END

	IF @Activar = 'AgregarCarrito'
	BEGIN
		
		IF (SELECT Stock FROM PRODUCTO WHERE IdProducto = @IdProducto) > 0
			BEGIN
				UPDATE PRODUCTO SET Stock =	(CASE WHEN Stock < 1 THEN 0 ELSE Stock -1 END)  WHERE IdProducto = @IdProducto
			INSERT INTO CARRITO(IdUsuario,IdProducto) VALUES (@IdUsuario,@IdProducto)
			SELECT SCOPE_IDENTITY() AS Id

			RETURN
		END
		
		RETURN SELECT 0 AS Id
	END
	IF @Activar = 'ConsultarCarrito'
	BEGIN
		SELECT DISTINCT P.Nombre, P.precio, C.IdUsuario, C.IdProducto, COUNT(C.IdProducto) AS Cantidad, (COUNT(C.IdProducto) * P.Precio) AS Total, P.Stock FROM CARRITO C
		INNER JOIN PRODUCTO P ON P.IdProducto = C.IdProducto
		WHERE C.IdUsuario = @IdUsuario
		GROUP BY C.IdUsuario, C.IdProducto, P.Nombre, P.Precio, P.Stock

		RETURN
	END
	IF @Activar = 'RetirarCarrito'
	BEGIN
		DELETE CARRITO WHERE IdCarrito = (SELECT TOP 1 IdCarrito FROM CARRITO WHERE IdProducto = @IdProducto AND IdUsuario = @idusuario)
		update PRODUCTO SET Stock = (Stock + 1) WHERE IdProducto = @IdProducto 
		RETURN
	END
	IF @Activar = 'EliminarCarrito'
	BEGIN

		UPDATE PRODUCTO SET Stock = (SELECT COUNT(IdProducto)  FROM CARRITO WHERE IdProducto = @IdProducto ) WHERE IdProducto = @IdProducto 
		DELETE CARRITO WHERE IdCarrito IN(SELECT IdCarrito FROM CARRITO WHERE IdProducto = @IdProducto AND IdUsuario = @idusuario)
		
		RETURN
	END
		IF @Activar = 'RegistrarCompra'
	BEGIN
		DECLARE @Tabla_Temporal TABLE (Cantidad int, Total float)

		INSERT @Tabla_Temporal
		SELECT COUNT(C.IdProducto) AS Cantidad, COUNT(C.IdProducto) * P.Precio AS Total FROM CARRITO C
		INNER JOIN PRODUCTO P ON P.IdProducto = C.IdProducto
		WHERE C.IdUsuario = @IdUsuario
		GROUP BY C.IdUsuario, C.IdProducto, P.Precio

		SELECT  @TotalProducto = SUM(Cantidad),  @Total = SUM(Total) FROM @Tabla_Temporal

		INSERT INTO COMPRA(IdUsuario,TotalProducto,Total) 
		VALUES(@IdUsuario,@TotalProducto,@Total)

		SELECT @id = SCOPE_IDENTITY() 

		INSERT INTO DETALLE_COMPRA(IdCompra,IdProducto,Cantidad,Total)
		SELECT @id, C.IdProducto, COUNT(C.IdProducto) AS Cantidad, (COUNT(C.IdProducto) * P.Precio) AS Total FROM CARRITO C
		INNER JOIN PRODUCTO P ON P.IdProducto = C.IdProducto
		WHERE C.IdUsuario = @IdUsuario
		GROUP BY C.IdUsuario, C.IdProducto, P.Nombre, P.Precio
		
		DELETE CARRITO WHERE IdCarrito IN(SELECT IdCarrito FROM CARRITO WHERE IdUsuario = @IdUsuario)

		RETURN
	END
	IF @Activar = 'ConsultarCompra'
	BEGIN

		SELECT IdCompra AS nfactura, FechaCompra AS fechaCompra
		FROM COMPRA C

		RETURN
	END
		IF @Activar = 'ConsultarDetalle'
	BEGIN

		SELECT CT.IdCompra,P.Nombre, P.Descripcion, CT.Cantidad, CT.Total
		FROM DETALLE_COMPRA CT
		INNER JOIN PRODUCTO P ON P.IdProducto = CT.IdProducto

		RETURN
	END
END
GO
