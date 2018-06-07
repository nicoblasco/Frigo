USE [FRIGORIFICO]
GO

/****** Object:  StoredProcedure [dbo].[Add_Articulos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Articulos]
(@codigoextra nvarchar(400),
@fechaalta datetime,
@descripcion nvarchar(500),
@proveedor int,
@rubro nvarchar(200),
@marca nvarchar(200),
@ubicacion nvarchar(200),
@stock int,
@stockminimo int,
@costo decimal (15,5),
@ganancia decimal (15,5),
@iva decimal (15,5),
@precioefectivo decimal (15,5),
@preciotarjeta decimal (15,5),
@imagen nvarchar(2000),
@preciolista2 decimal(15,2),
@preciolista3 decimal(15,2),
@desccorta  nvarchar(100),
@moneda numeric(10,0),
@unidaddeventa nvarchar(50),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT FRIGORIFICO.[dbo].[Articulos]
           ([idextra]
           ,[fechaalta]
		   ,[descripcion]
           ,[proveedor]
           ,[rubro]
           ,[marca]
           ,[ubicacion]
           ,[stock]
           ,[stockminimo]
           ,[costo]
           ,[ganancia]
           ,[iva]
           ,[precioefectivo]
           ,[preciotarjeta]
		   ,[imagen]
		   ,preciolista2
		   ,preciolista3,desccorta,monedaid,unidaddeventa)
     VALUES
           (@codigoextra,@fechaalta,@descripcion, @proveedor,@rubro,@marca,@ubicacion,@stock,@stockminimo,@costo,@ganancia,@iva,@precioefectivo,@preciotarjeta,@imagen,@preciolista2,@preciolista3,@desccorta, isnull(@moneda,1),@unidaddeventa)


SET @codigo= @@identity
/*
commit

if @codigoextra is null 
	UPDATE [BDSystemGeneric].[dbo].[Articulos]
	   SET [idextra] = @codigo
		  ,[fechaalta] = @fechaalta
		  ,[descripcion]=@descripcion
		  ,[proveedor] =@proveedor
		  ,[rubro] = @rubro
		  ,[marca] = @marca
		  ,[ubicacion] = @ubicacion
		  ,[stock] = @stock
		  ,[stockminimo] = @stockminimo
		  ,[costo] =@costo
		  ,[ganancia] = @ganancia
		  ,[iva] = @iva
		  ,[precioefectivo] = @precioefectivo
		  ,[preciotarjeta] = @preciotarjeta
	 WHERE id=@codigo*/


END 




































GO

/****** Object:  StoredProcedure [dbo].[Add_Cheque_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Cheque_Detalle]
(@facturaid numeric(10),
@chequeabona decimal (15,5),
@chequebanco nvarchar(200),
@chequenumero nvarchar(200),
@chequevenc datetime,
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Cheques_Detalle]
           ([facturaid]
           ,[chequeabona]
           ,[chequebanco]
           ,[chequenumero]
           ,[chequevenc])
     VALUES (@facturaid,@chequeabona,@chequebanco,@chequenumero,@chequevenc)


SET @codigo= @@identity


END 






























GO

/****** Object:  StoredProcedure [dbo].[Add_CierreCaja]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <22/02/2013>
-- Description:	<Cierre de Caja>
-- =============================================
CREATE PROC [dbo].[Add_CierreCaja]
(@total decimal (15,5),
@fecha datetime,
@numero_caja int,
@usuario_apertura numeric(10),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO [FRIGORIFICO].[dbo].[Cierre_Caja]
           ([total]
           ,[fecha], fecha_apertura, numero_caja,usuario_apertura)
     VALUES
           (@total
           ,@fecha,getdate(),@numero_caja,@usuario_apertura)


SET @codigo= @@identity


END 































GO

/****** Object:  StoredProcedure [dbo].[Add_Cliente]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Cliente]
(@documentoid int,
@documento nvarchar(50),
@nombre  nvarchar(200),
@apellido  nvarchar(200),
@fdnac datetime,
@fding datetime,
@direccion  nvarchar(200),
@depto  nvarchar(20),
@piso  nvarchar(200),
@nro  nvarchar(20),
@localidad int,
@provincia int,
@pais int,
@mail  nvarchar(50),
@predeterminado bit,
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

if @predeterminado = 1 
 -- Si el cliente va a ser prederminado, tengo que buscar el cliente predet. anterior y ponerlo en cero
 begin
	 update FRIGORIFICO.[dbo].[Clientes]
		set predeterminado=0
	 where predeterminado = 1
 end


INSERT INTO FRIGORIFICO.[dbo].[Clientes]
           ([doc_id]
           ,[cli_documento]
           ,[cli_nombre]
           ,[cli_apellido]
           ,[cli_fdnac]
           ,[cli_fding]
           ,[cli_direccion]
           ,[cli_depto]
           ,[cli_piso]
           ,[cli_nro]
           ,[loc_id]
           ,[prov_id]
           ,[pais]
           ,[cli_mail]
		   ,[predeterminado])
     VALUES(@documentoid,@documento,@nombre,@apellido,@fdnac,@fding,@direccion,@depto,@piso,@nro,@localidad,@provincia,@pais,@mail,@predeterminado)
  
SET @codigo= @@identity

END 






















GO

/****** Object:  StoredProcedure [dbo].[Add_Compras]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Compras]
(@fechaalta datetime,
@proveedorid int,
@nrofactura nvarchar(100),
@total decimal (15,5),
@observaciones nvarchar (4000),
@cierrecajaid numeric(10),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO [FRIGORIFICO].[dbo].[Compras]
           ([fechaalta]
           ,[proveedorid]
           ,[nrofactura]
           ,[total]
           ,[observaciones]
           ,cierrecajaid)
     VALUES
           (@fechaalta,@proveedorid,@nrofactura,@total,@observaciones,@cierrecajaid)

SET @codigo= @@identity



END 





























GO

/****** Object:  StoredProcedure [dbo].[Add_Configuracion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <18/09/2012>
-- Description:	<Datos de Impresion>
-- =============================================
CREATE PROC [dbo].[Add_Configuracion]
(@nombre_pc nvarchar(100),
@numero_caja int,
@nombreimpresora  nvarchar(4000),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO [FRIGORIFICO].[dbo].[Configuraciones]
           ([nombre_pc]
           ,[numero_caja]
           ,[NombreImpresora])
     VALUES
           (@nombre_pc,@numero_caja,@nombreimpresora)

SET @codigo= @@identity

END 
























GO

/****** Object:  StoredProcedure [dbo].[Add_Contactos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Contactos]
(@prov_id numeric(10),
@nombre  nvarchar(200),
@apellido  nvarchar(200),
@mail  nvarchar(100),
@puesto  nvarchar(100),
@observaciones  nvarchar(4000),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Contactos]
           ([prov_id]
           ,[nombre]
           ,[apellido]
           ,[mail]
           ,[puesto]
           ,[observaciones])
     VALUES (@prov_id, @nombre, @apellido, @mail, @puesto, @observaciones)
  
SET @codigo= @@identity

END 



















GO

/****** Object:  StoredProcedure [dbo].[Add_Contactos_Clientes]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Add_Contactos_Clientes]
(@codigo numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Contactos_cliente]
           ([cli_id]
           ,[cc_vinculo]
           ,[cc_tipotel]
           ,[cc_tel]
			,[interno])
values (@codigo,@vinculo,@tipotel,@telefono,@interno)


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Add_Contactos_Contactos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Add_Contactos_Contactos]
(@codigo numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Contactos_Contactos]
           ([cli_id]
           ,[cc_vinculo]
           ,[cc_tipotel]
           ,[cc_tel]
			,[interno] )
values (@codigo,@vinculo,@tipotel,@telefono,@interno)


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Add_Contactos_Empleados]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Add_Contactos_Empleados]
(@codigo numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Contactos_Empleados]
           ([cli_id]
           ,[cc_vinculo]
           ,[cc_tipotel]
           ,[cc_tel]
		   ,[interno])
values (@codigo,@vinculo,@tipotel,@telefono,@interno)


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Add_Contactos_Proveedores]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Add_Contactos_Proveedores]
(@codigo numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Contactos_Proveedores]
           ([cli_id]
           ,[cc_vinculo]
           ,[cc_tipotel]
           ,[cc_tel]
			,[interno])
values (@codigo,@vinculo,@tipotel,@telefono,@interno)


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Add_Devolucion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <08/03/2017>
-- Description:	<Se da de alta la devolucion>
-- =============================================
CREATE PROC [dbo].[Add_Devolucion]
(@fechaalta datetime,
@empleadoid int,
@clienteid int,
@observaciones nvarchar(4000),
@total decimal (15,5),
@estado nvarchar(200),
@listaprecio nvarchar(50),
@cierrecajaid numeric(10),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO [FRIGORIFICO].[dbo].[Devoluciones]
           ([fechaalta]
           ,[empleadoid]
           ,[clienteid]
           ,[observaciones]
           ,[total]
           ,[estado]
           ,[listaprecio],cierrecajaid)
     VALUES
           (@fechaalta,@empleadoid,@clienteid,@observaciones,@total,@estado,@listaprecio,@cierrecajaid)

SET @codigo= @@identity


END 






































GO

/****** Object:  StoredProcedure [dbo].[Add_Devoluciones_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Devoluciones_Detalle]
(@devolucionid int,
@articuloid int,
@cantidad int,
@puni decimal (15,5),
@total decimal (15,5),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO [FRIGORIFICO].[dbo].[Devoluciones_Detalle]
           ([devolucionid]
           ,[articuloid]
           ,[cantidad]
           ,[puni]
           ,[total])
     VALUES
           (@devolucionid
           ,@articuloid
           ,@cantidad
           ,@puni
           ,@total)

SET @codigo= @@identity


END 


























GO

/****** Object:  StoredProcedure [dbo].[Add_Diccionario]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se agregan los diccionarios>
-- =============================================
CREATE PROC [dbo].[Add_Diccionario]
(@parametro nvarchar(200),
@numero1  numeric(10,0),
@valor1 nvarchar(1000),
@numero2 numeric(10,0),
@valor2  nvarchar(1000),
@codigo numeric(10) OUTPUT)
AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Diccionario]
           ([dd_parametro]
           ,[dd_numero1]
           ,[cc_valor1]
           ,[dd_numero2]
           ,[cc_valor2])
     VALUES (@parametro,@numero1,@valor1,@numero2,@valor2)

SET @codigo= @@identity
commit
END 















GO

/****** Object:  StoredProcedure [dbo].[Add_Empleados]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Empleados]
(@documentoid int,
@documento nvarchar(50),
@nombre  nvarchar(200),
@apellido  nvarchar(200),
@fdnac datetime,
@fding datetime,
@fdegr nvarchar(30),
@nacionalidad  nvarchar(50),
@direccion  nvarchar(200),
@depto  nvarchar(20),
@piso  nvarchar(200),
@nro  nvarchar(20),
@localidad int,
@provincia int,
@cuit nvarchar(50),
@observaciones nvarchar(4000),
@predeterminado bit,
@idusuario int,
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

if @predeterminado = 1 
 -- Si el cliente va a ser prederminado, tengo que buscar el cliente predet. anterior y ponerlo en cero
 begin
	 update FRIGORIFICO.[dbo].[Empleados]
		set predeterminado=0
	 where predeterminado = 1
 end

INSERT INTO FRIGORIFICO.[dbo].[Empleados]
           ([doc_id]
           ,[emp_documento]
           ,[emp_nombre]
           ,[emp_apellido]
           ,[emp_fdnac]
           ,[emp_fding]
           ,[emp_fdegr]
           ,[emp_nacionalidad]
           ,[emp_direccion]
           ,[emp_depto]
           ,[emp_piso]
           ,[emp_nro]
           ,[loc_id]
           ,[prov_id]
           ,[emp_cuit]
           ,[emp_observaciones]
			,[predeterminado], [usuario])
     VALUES 
(@documentoid,@documento,@nombre,@apellido,@fdnac,@fding,@fdegr,@nacionalidad,@direccion,@depto,@piso,@nro,@localidad,@provincia,@cuit,@observaciones, @predeterminado, @idusuario)

SET @codigo= @@identity

END 























GO

/****** Object:  StoredProcedure [dbo].[Add_Factura]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Factura]
(@fechaalta datetime,
@empleadoid int,
@clienteid int,
@observaciones nvarchar(4000),
@neto decimal (15,5),
@descuento int,
@subtotal decimal (15,5),
@iva10 decimal (15,5),
@iva21 decimal (15,5),
@total decimal (15,5),
@efectivoabona decimal (15,5),
@efectivovuelto decimal (15,5),
@ctacte decimal (15,5),
@estado nvarchar(200),
@ubicacion nvarchar(200),
@listaprecio nvarchar(50),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Factura]
           ([fechaalta]
           ,[empleadoid]
           ,[clienteid]
           ,[observaciones]
           ,[neto]
           ,[descuento]
           ,[subtotal]
           ,[iva10]
           ,[iva21]
           ,[total]
           ,[efectivoabona]
           ,[efectivovuelto]
           ,[ctacte]			
			,[estado]
			,[ubicacion]
			,listaprecio)
     VALUES
           (@fechaalta,@empleadoid,@clienteid,@observaciones,@neto,@descuento,@subtotal,@iva10,@iva21,
@total,@efectivoabona,@efectivovuelto,@ctacte,@estado,@ubicacion,@listaprecio)


SET @codigo= @@identity


END 


































GO

/****** Object:  StoredProcedure [dbo].[Add_Factura_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Factura_Detalle]
(@facturaid int,
@articuloid int,
@unidades int,
@cantidad numeric(10,5),
@puni decimal (15,5),
@total decimal (15,5),
@linea int,
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Factura_Detalle]
           ([facturaid]
           ,[articuloid]
           ,[unidades]
		   ,cantidad,puni,total, linea)
     VALUES
           (@facturaid,@articuloid,@unidades,@cantidad,@puni,@total,@linea)


SET @codigo= @@identity


END 

























GO

/****** Object:  StoredProcedure [dbo].[Add_Impresion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <18/09/2012>
-- Description:	<Datos de Impresion>
-- =============================================
CREATE PROC [dbo].[Add_Impresion]
(@comercio nvarchar(4000),
@direccion nvarchar(4000),
@provincia  nvarchar(4000),
@localidad  nvarchar(4000),
@codigointerno nvarchar(4000),
@comentariolinea1 nvarchar(4000),
@comentariolinea2  nvarchar(4000),
@comentariolinea3  nvarchar(4000),
@impresora  nvarchar(4000))

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO [FRIGORIFICO].[dbo].[Impresion]
           ([NombreComercio]
           ,[Direccion]
           ,[Provincia]
           ,[Localidad]
           ,[CodigoInterno]
           ,[ComentarioLinea1]
           ,[ComentarioLinea2]
           ,[ComentarioLinea3]
           ,[NombreImpresora])
     VALUES
           (@comercio,@direccion,@provincia,@localidad,@codigointerno,@comentariolinea1,@comentariolinea2,@comentariolinea3,@impresora)

END 























GO

/****** Object:  StoredProcedure [dbo].[Add_Medio_Pago]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Medio_Pago]
(@descripcion nvarchar(100),
@predeterminado int,
@codigo numeric(10) OUTPUT)

AS
BEGIN 

if @predeterminado = 1 
 -- Si el cliente va a ser prederminado, tengo que buscar el cliente predet. anterior y ponerlo en cero
 begin
	 update dbo.Medio_Pago
		set predeterminado=0
	 where predeterminado = 1
 end

INSERT INTO [dbo].[Medio_Pago]
           ([descripcion], predeterminado)
     VALUES
           (@descripcion, @predeterminado)

SET @codigo= @@identity

END 































GO

/****** Object:  StoredProcedure [dbo].[Add_Monedas]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <05/05/2017>
-- Description:	<Monedas>
-- =============================================
CREATE PROC [dbo].[Add_Monedas]
(@descripcion nvarchar(50),
@cotizacion decimal(10,5),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO Monedas
           ([descripcion]
           ,[cotizacion])
     VALUES
           (@descripcion,@cotizacion)


SET @codigo= @@identity


END 
































GO

/****** Object:  StoredProcedure [dbo].[Add_Perfiles]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <16/06/2016>
-- Description:	<Se da de alta el perfil>
-- =============================================
CREATE PROC [dbo].[Add_Perfiles]
(@usuario_id numeric(10),
@modulo nvarchar(200),
@pantalla nvarchar(200),
@permiso nvarchar(200),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO Perfiles
           ([usuarioid]
           ,[modulo]
           ,[pantalla]
           ,[permiso]
           ,[fecha_alta])
     VALUES
           (@usuario_id,@modulo,@pantalla,@permiso, GETDATE ())


SET @codigo= @@identity


END 































GO

/****** Object:  StoredProcedure [dbo].[Add_Proveedores]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Proveedores]
(@documentoid int,
@documento nvarchar(50),
@razonsocial  nvarchar(400),
@fding datetime,
@direccion  nvarchar(200),
@depto  nvarchar(20),
@piso  nvarchar(200),
@nro  nvarchar(20),
@localidad int,
@provincia int,
@pais int,
@mail  nvarchar(50),
@url  nvarchar(50),
@lunes bit,
@martes bit,
@miercoles bit,
@jueves bit,
@viernes bit,
@sabado bit,
@domingo bit,
@servicios  nvarchar(1000),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Proveedores]
           ([doc_id]
           ,[documento]
           ,[razonsocial]
           ,[fding]
           ,[direccion]
           ,[depto]
           ,[piso]
           ,[nro]
           ,[loc_id]
           ,[prov_id]
           ,[pais]
           ,[mail]
           ,[url]
           ,[Lunes]
           ,[Martes]
           ,[Miercoles]
           ,[Jueves]
           ,[Viernes]
           ,[Sabado]
           ,[Domingo]
			,[servicios])
     VALUES (@documentoid,@documento,@razonsocial,@fding,@direccion,@depto,@piso,@nro,@localidad,@provincia,@pais,@mail,@url,@lunes,@martes,@miercoles,@jueves,@viernes,@sabado,@domingo,@servicios)


SET @codigo= @@identity

END 






















GO

/****** Object:  StoredProcedure [dbo].[Add_Seguimiento]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <07/06/2018>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Seguimiento]
(@facturaid numeric(10,0),
@fecha datetime,
@usuarioid numeric(10,0),
@estadodesde nvarchar(50),
@estadohasta nvarchar(50),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;


INSERT INTO [dbo].[Seguimiento]
           ([facturaid]
           ,[fecha]
           ,[usuarioid]
           ,[estadodesde]
           ,[estadohasta])
     VALUES
           (@facturaid,getdate(),@usuarioid,@estadodesde,@estadohasta)




SET @codigo= @@identity


END 

























GO

/****** Object:  StoredProcedure [dbo].[Add_Tarjeta_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Tarjeta_Detalle]
(@facturaid numeric(10),
@tarjetaabona decimal(15,5),
@tarjetanombre nvarchar(200),
@tarjetanumero nvarchar(200),
@tarjetacuotas nvarchar(20),
@tipo nvarchar(20),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;

INSERT INTO FRIGORIFICO.[dbo].[Tarjetas_Detalle]
           ([facturaid]
           ,[tarjetaabona]
           ,[tarjetanombre]
           ,[tarjetanumero]
           ,[tarjetacuotas]
			,[tipo])
     VALUES (@facturaid,@tarjetaabona,@tarjetanombre,@tarjetanumero,@tarjetacuotas,@tipo)


SET @codigo= @@identity


END 





























GO

/****** Object:  StoredProcedure [dbo].[Add_Usuarios]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <16/06/2016>
-- Description:	<Se da de alta el usuario>
-- =============================================
CREATE PROC [dbo].[Add_Usuarios]
(@usuario nvarchar(50),
@nombre_apellido nvarchar(200),
@es_admin int,
@contraseña nvarchar(50),
@codigo numeric(10) OUTPUT)

AS
BEGIN 

	SET NOCOUNT ON;


INSERT INTO Usuarios
           ([usuario]
           ,[nombre_apellido]
           ,[es_admin]
           ,[fecha_alta]
			,contraseña)
     VALUES
           (@usuario,@nombre_apellido,@es_admin, GETDATE (),@contraseña)

SET @codigo= @@identity


END 































GO

/****** Object:  StoredProcedure [dbo].[Add_Ventas_Pagos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Add_Ventas_Pagos]
(@ventas_id  numeric(10),
@fecha datetime,
@importe money,
@cierrecajaid numeric(10),
@mediopago int)

AS
BEGIN 

INSERT INTO Ventas_Pagos
           ([ventas_id]
           ,[fecha]
           ,[importe],cierrecajaid,mediopago)
     VALUES
           (@ventas_id,@fecha,@importe,@cierrecajaid,@mediopago)

END 






























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Articulos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/02/2012>
-- Description:	<Se da de Baja el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Articulos]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

    --Primero deberia guardarlo en un historico
/*
INSERT INTO [BDSystemGeneric].[dbo].[Articulos_hist]
           ([id]
           ,[idextra]
           ,[fechaalta]
           ,[proveedor]
           ,[rubro]
           ,[marca]
           ,[ubicacion]
           ,[stock]
           ,[stockminimo]
           ,[costo]
           ,[ganancia]
           ,[iva]
           ,[precioefectivo]
           ,[preciotarjeta]
           ,[hist_fecha])
(SELECT [id]
      ,[idextra]
      ,[fechaalta]
      ,[proveedor]
      ,[rubro]
      ,[marca]
      ,[ubicacion]
      ,[stock]
      ,[stockminimo]
      ,[costo]
      ,[ganancia]
      ,[iva]
      ,[precioefectivo]
      ,[preciotarjeta]
      ,getdate()
  FROM [BDSystemGeneric].[dbo].[Articulos] where id=@codigo)



--Luego Lo borro
DELETE FROM dbo.Articulos
      WHERE id=@codigo
*/

update dbo.Articulos
set fechabaja=getdate()
WHERE id=@codigo

END 








GO

/****** Object:  StoredProcedure [dbo].[Dtl_Cheque_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Cheque_Detalle]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

DELETE FROM FRIGORIFICO.[dbo].[Cheques_Detalle]
      WHERE id=@codigo


END 





























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Cliente]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/02/2012>
-- Description:	<Se da de Baja el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Cliente]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

    --Primero deberia guardarlo en un historico
/*
INSERT INTO [BDSystemGeneric].[dbo].[Clientes_hist]
           ([cli_id]
           ,[doc_id]
           ,[cli_documento]
           ,[cli_nombre]
           ,[cli_apellido]
           ,[cli_fdnac]
           ,[cli_fding]
           ,[cli_direccion]
           ,[cli_depto]
           ,[cli_piso]
           ,[cli_nro]
           ,[loc_id]
           ,[prov_id]
           ,[pais]
           ,[cli_mail]
           ,[cli_fecha])
(SELECT [cli_id]
      ,[doc_id]
      ,[cli_documento]
      ,[cli_nombre]
      ,[cli_apellido]
      ,[cli_fdnac]
      ,[cli_fding]
      ,[cli_direccion]
      ,[cli_depto]
      ,[cli_piso]
      ,[cli_nro]
      ,[loc_id]
      ,[prov_id]
      ,[pais]
      ,[cli_mail]
	,getdate()
  FROM [BDSystemGeneric].[dbo].[Clientes] where cli_id=@codigo)


--Luego Lo borro
DELETE FROM [BDSystemGeneric].[dbo].[Clientes]
      WHERE cli_id=@codigo
*/

update FRIGORIFICO.[dbo].[Clientes]
set fechabaja=getdate()
WHERE cli_id=@codigo

END 




















GO

/****** Object:  StoredProcedure [dbo].[Dtl_Compras]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Compras]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;


UPDATE [FRIGORIFICO].[dbo].[Compras]
 set fechabaja=getdate()
      WHERE compraid=@codigo


END 




























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Contactos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Contactos]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

  DELETE FROM FRIGORIFICO.[dbo].[Contactos]
      WHERE id=@codigo

END 




















GO

/****** Object:  StoredProcedure [dbo].[Dtl_Contactos_Clientes]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Dtl_Contactos_Clientes]
(@idcontacto numeric(10))
AS
BEGIN 

	SET NOCOUNT ON;

Delete from FRIGORIFICO.[dbo].[Contactos_cliente]
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Dtl_Contactos_Contactos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Dtl_Contactos_Contactos]
(@idcontacto numeric(10))
AS
BEGIN 

	SET NOCOUNT ON;

Delete from FRIGORIFICO.[dbo].[Contactos_Contactos]
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Dtl_Contactos_Empleados]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Dtl_Contactos_Empleados]
(@idcontacto numeric(10))
AS
BEGIN 

	SET NOCOUNT ON;

Delete from FRIGORIFICO.[dbo].[Contactos_Empleados]
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Dtl_Contactos_Proveedores]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Dtl_Contactos_Proveedores]
(@idcontacto numeric(10))
AS
BEGIN 

	SET NOCOUNT ON;

Delete from FRIGORIFICO.[dbo].[Contactos_Proveedores]
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Dtl_Devoluciones_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Devoluciones_Detalle]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

Delete FRIGORIFICO.[dbo].[Devoluciones_Detalle]
 WHERE detalleid=@codigo



END 



























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Diccionario]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se eliminan los diccionarios>
-- =============================================
CREATE PROC [dbo].[Dtl_Diccionario]
(@codigo numeric(10,0))
AS
BEGIN 

	SET NOCOUNT ON;

DELETE FROM FRIGORIFICO.[dbo].[Diccionario]
      WHERE dd_id=@codigo

commit
END 















GO

/****** Object:  StoredProcedure [dbo].[Dtl_Empleados]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/02/2012>
-- Description:	<Se da de Baja el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Empleados]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

    --Primero deberia guardarlo en un historico
/*
INSERT INTO [BDSystemGeneric].[dbo].[Empleados_hist]
           ([emp_id]
           ,[doc_id]
           ,[emp_documento]
           ,[emp_nombre]
           ,[emp_apellido]
           ,[emp_fdnac]
           ,[emp_fding]
           ,[emp_fdegr]
           ,[emp_nacionalidad]
           ,[cli_direccion]
           ,[cli_depto]
           ,[cli_piso]
           ,[cli_nro]
           ,[loc_id]
           ,[prov_id]
           ,[emp_cuit]
           ,[emp_observaciones]
           ,[emp_fecha])
(SELECT [emp_id]
      ,[doc_id]
      ,[emp_documento]
      ,[emp_nombre]
      ,[emp_apellido]
      ,[emp_fdnac]
      ,[emp_fding]
      ,[emp_fdegr]
      ,[emp_nacionalidad]
      ,[emp_direccion]
      ,[emp_depto]
      ,[emp_piso]
      ,[emp_nro]
      ,[loc_id]
      ,[prov_id]
      ,[emp_cuit]
      ,[emp_observaciones]
,getdate()
  FROM [BDSystemGeneric].[dbo].[Empleados]
  where emp_id=@codigo)


--Luego Lo borro
DELETE FROM [BDSystemGeneric].[dbo].[Empleados]
      WHERE emp_id=@codigo*/

update FRIGORIFICO.[dbo].[Empleados]
set fechabaja=getdate()
where emp_id=@codigo


END 




















GO

/****** Object:  StoredProcedure [dbo].[Dtl_Factura_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Factura_Detalle]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

Delete FRIGORIFICO.[dbo].[Factura_Detalle]
 WHERE detalleid=@codigo



END 


























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Medio_Pago]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Medio_Pago]
(@codigo numeric(10))

AS
BEGIN 

UPDATE [FRIGORIFICO].[dbo].[Medio_Pago]
   SET fechabaja = getdate()
 WHERE mediopago =@codigo

END 





























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Monedas]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <05/05/2017>
-- Description:	<Monedas>
-- =============================================
CREATE PROC [dbo].[Dtl_Monedas]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

DELETE FROM [dbo].[Monedas]
      WHERE monedaid = @codigo

END 
































GO

/****** Object:  StoredProcedure [dbo].[Dtl_Perfiles]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <16/06/2016>
-- Description:	<Se elimina el perfil>
-- =============================================
CREATE PROC [dbo].[Dtl_Perfiles]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;


Delete Perfiles

 WHERE id=@codigo


END 































GO

/****** Object:  StoredProcedure [dbo].[Dtl_Proveedores]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/02/2012>
-- Description:	<Se da de Baja el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Proveedores]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

    --Primero deberia guardarlo en un historico
/*
INSERT INTO [BDSystemGeneric].[dbo].[Proveedores_hist]
           ([id]
           ,[doc_id]
           ,[documento]
           ,[razonsocial]
           ,[fding]
           ,[direccion]
           ,[depto]
           ,[piso]
           ,[nro]
           ,[loc_id]
           ,[prov_id]
           ,[pais]
           ,[mail]
           ,[url]
           ,[Lunes]
           ,[Martes]
           ,[Miercoles]
           ,[Jueves]
           ,[Viernes]
           ,[Sabado]
           ,[Domingo]
		   ,[servicios]
           ,[fecha])
(SELECT [id]
      ,[doc_id]
      ,[documento]
      ,[razonsocial]
      ,[fding]
      ,[direccion]
      ,[depto]
      ,[piso]
      ,[nro]
      ,[loc_id]
      ,[prov_id]
      ,[pais]
      ,[mail]
      ,[url]
      ,[Lunes]
      ,[Martes]
      ,[Miercoles]
      ,[Jueves]
      ,[Viernes]
      ,[Sabado]
      ,[Domingo]
	  ,[servicios]
	  ,getdate()
  FROM [BDSystemGeneric].[dbo].[Proveedores]where id=@codigo)




--Luego Lo borro
DELETE FROM [BDSystemGeneric].[dbo].[Proveedores]
      WHERE id=@codigo*/

update FRIGORIFICO.[dbo].[Proveedores]
 set fechabaja = getdate()
WHERE id=@codigo


END 





















GO

/****** Object:  StoredProcedure [dbo].[Dtl_Tarjeta_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Tarjeta_Detalle]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

DELETE FROM FRIGORIFICO.[dbo].[Tarjetas_Detalle]
      WHERE id=@codigo


END 





























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Usuarios]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <16/06/2016>
-- Description:	<Se Elimina el usuario>
-- =============================================
CREATE PROC [dbo].[Dtl_Usuarios]
(@codigo numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;


Delete Usuarios
 WHERE id= @codigo


END 






























GO

/****** Object:  StoredProcedure [dbo].[Dtl_Ventas_Pagos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Dtl_Ventas_Pagos]
(@codigo numeric(10))

AS
BEGIN 

Delete Ventas_Pagos
 WHERE [ventas_pagos_id] = @codigo


END 


























GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos]
(@codigo numeric(10),
@codigoextra nvarchar(400),
@fechaalta datetime,
@descripcion nvarchar(500),
@proveedor int,
@rubro nvarchar(200),
@marca nvarchar(200),
@ubicacion nvarchar(200),
@stock int,
@stockminimo int,
@costo decimal (15,5),
@ganancia decimal (15,5),
@iva decimal (15,5),
@precioefectivo decimal (15,5),
@preciotarjeta decimal (15,5),
@imagen nvarchar(2000),
@preciolista2 decimal(15,2),
@preciolista3 decimal(15,2),
@desccorta  nvarchar(100),
@moneda numeric(10,0),
@unidaddeventa nvarchar(50))

AS
BEGIN 

	SET NOCOUNT ON;


UPDATE FRIGORIFICO.[dbo].[Articulos]
   SET [idextra] = @codigoextra
      ,[fechaalta] = @fechaalta
	  ,[descripcion]=@descripcion
      ,[proveedor] =@proveedor
      ,[rubro] = @rubro
      ,[marca] = @marca
      ,[ubicacion] = @ubicacion
      ,[stock] = @stock
      ,[stockminimo] = @stockminimo
      ,[costo] =@costo
      ,[ganancia] = @ganancia
      ,[iva] = @iva
      ,[precioefectivo] = @precioefectivo
      ,[preciotarjeta] = @preciotarjeta
	  ,[imagen] = @imagen
	  ,preciolista2 = @preciolista2
	  ,preciolista3 = @preciolista3
      ,desccorta=@desccorta
	  ,monedaid=isnull(@moneda,1)
	  ,unidaddeventa=@unidaddeventa
 WHERE id=@codigo



END 
































GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Codigo_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[Upd_Articulos_Codigo_Masivo]
(@codigo nvarchar(500),
@codigonuevo nvarchar(500))

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET idextra=@codigonuevo
		 WHERE idextra=@codigo
	  END


END 












GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Descclarga_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/12/2016>
-- Description:	<Se actualiza el precio masivamente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_Descclarga_Masivo]
(@codigo nvarchar(500),
@desclarga nvarchar(500))

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET [descripcion]=	@desclarga
		 WHERE idextra=@codigo
	  END


END 





GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Desccorta_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/12/2016>
-- Description:	<Se actualiza el precio masivamente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_Desccorta_Masivo]
(@codigo nvarchar(500),
@desccorta nvarchar(100))

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET [desccorta]=	@desccorta
		 WHERE idextra=@codigo
	  END


END 




GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Marca_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[Upd_Articulos_Marca_Masivo]
(@codigo nvarchar(500),
@marca nvarchar(500))

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET marca = @marca
		 WHERE idextra=@codigo
	  END


END 








GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Porcentaje_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <04/02/2015>
-- Description:	<Stock Masivo>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_Porcentaje_Masivo]
(@codigo nvarchar(500),
@porcentaje money)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE [Articulos] 
		   SET  ganancia = @porcentaje,
			precioefectivo = (select b.costo + (b.costo * @porcentaje/100) from articulos b where b.idextra=@codigo and  fechabaja is null)
		 WHERE idextra=@codigo
	  END


END 











GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Precio_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <04/02/2015>
-- Description:	<Se actualiza el precio masivamente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_Precio_Masivo]
(@codigo nvarchar(500),
@precio money,
@preciounitario money)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET [costo] = @precio,
		   precioefectivo=	@preciounitario
		 WHERE idextra=@codigo
	  END


END 
























GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_PrecioL1_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/12/2016>
-- Description:	<Se actualiza el precio masivamente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_PrecioL1_Masivo]
(@codigo nvarchar(500),
@preciolista1 money)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET [precioefectivo]=	@preciolista1
		 WHERE idextra=@codigo
	  END


END 





















GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_PrecioL2_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/12/2016>
-- Description:	<Se actualiza el precio masivamente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_PrecioL2_Masivo]
(@codigo nvarchar(500),
@preciolista2 money)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET [preciolista2]=	@preciolista2
		 WHERE idextra=@codigo
	  END


END 

























GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_PrecioL3_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/12/2016>
-- Description:	<Se actualiza el precio masivamente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_PrecioL3_Masivo]
(@codigo nvarchar(500),
@preciolista3 money)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET [preciolista3]=	@preciolista3
		 WHERE idextra=@codigo
	  END


END 







GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Proveedor_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[Upd_Articulos_Proveedor_Masivo]
(@codigo nvarchar(500),
@proveedor int)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET proveedor = @proveedor
		 WHERE idextra=@codigo
	  END


END 








GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Rubro_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[Upd_Articulos_Rubro_Masivo]
(@codigo nvarchar(500),
@rubro nvarchar(500))

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET rubro = @rubro
		 WHERE idextra=@codigo
	  END


END 








GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Stock]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_Stock]
(@codigo numeric(10),
@cantidad int,
@operacion nvarchar(20))

AS
BEGIN 

	SET NOCOUNT ON;
/*	select *
	from articulos b 
	where b.idextra=@codigo and  fechabaja is null
	IF @@ROWCOUNT > 0*/
		if (@operacion ='CANCELADA') 
		  BEGIN
			UPDATE FRIGORIFICO.[dbo].[Articulos] 
			   SET [stock] = (select b.stock + @cantidad from articulos b where b.id=@codigo)
			 WHERE id=@codigo
		  END

		else
		  BEGIN
			UPDATE FRIGORIFICO.[dbo].[Articulos] 
			   SET [stock] = (select b.stock - @cantidad from articulos b where b.id=@codigo)
			 WHERE id=@codigo
			end	


END 

























GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Stock_Devolucion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[Upd_Articulos_Stock_Devolucion]
(@codigo numeric(10),
@cantidad int,
@operacion nvarchar(20))

AS
BEGIN 

	SET NOCOUNT ON;
/*	select *
	from articulos b 
	where b.idextra=@codigo and  fechabaja is null
	IF @@ROWCOUNT > 0*/
		if (@operacion ='CANCELADA') 
		  BEGIN
			UPDATE KIOSCO.[dbo].[Articulos] 
			   SET [stock] = (select b.stock - @cantidad from articulos b where b.id=@codigo)
			 WHERE id=@codigo
		  END

		else
		  BEGIN
			UPDATE KIOSCO.[dbo].[Articulos] 
			   SET [stock] = (select b.stock + @cantidad from articulos b where b.id=@codigo)
			 WHERE id=@codigo
			end	


END 




GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Stock_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <04/02/2015>
-- Description:	<Stock Masivo>
-- =============================================
CREATE PROC [dbo].[Upd_Articulos_Stock_Masivo]
(@codigo nvarchar(500),
@cantidad int)

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		
		select *
			from articulos b 
			where b.idextra=@codigo and  fechabaja is null
		IF @@ROWCOUNT > 0
			UPDATE Articulos
			   SET [stock] = (select b.stock + @cantidad from articulos b where b.idextra=@codigo and  fechabaja is null)
			 WHERE idextra=@codigo
	  END


END 








GO

/****** Object:  StoredProcedure [dbo].[Upd_Articulos_Ubicacion_Masivo]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[Upd_Articulos_Ubicacion_Masivo]
(@codigo nvarchar(500),
@ubicacion nvarchar(500))

AS
BEGIN 

	SET NOCOUNT ON;
	  BEGIN
		UPDATE Articulos
		   SET ubicacion = @ubicacion
		 WHERE idextra=@codigo
	  END


END 







GO

/****** Object:  StoredProcedure [dbo].[Upd_Cheque_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Cheque_Detalle]
(@codigo numeric(10),
@chequeabona decimal (15,5),
@chequebanco nvarchar(200),
@chequenumero nvarchar(200),
@chequevenc datetime)

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Cheques_Detalle]
   SET [chequeabona] = @chequeabona
      ,[chequebanco] = @chequebanco
      ,[chequenumero] =@chequenumero
      ,[chequevenc] = @chequevenc
 WHERE id=@codigo


END 




























GO

/****** Object:  StoredProcedure [dbo].[Upd_CierreCaja]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <22/02/2013>
-- Description:	<Se modifica el cierre de caja>
-- =============================================
CREATE PROC [dbo].[Upd_CierreCaja]
(@codigo numeric(10),
@total decimal (15,5),
@fecha datetime,
@usuario_apertura numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE [FRIGORIFICO].[dbo].[Cierre_Caja]
   SET [total] = @total
      ,[fecha] = @fecha
      ,usuario_apertura = @usuario_apertura
 WHERE cierrecajaid=@codigo



END 
































GO

/****** Object:  StoredProcedure [dbo].[Upd_CierreCaja_cierre]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <22/02/2013>
-- Description:	<Se modifica el cierre de caja>
-- =============================================
CREATE PROC [dbo].[Upd_CierreCaja_cierre]
(@codigo numeric(10),
@total_cierre decimal (15,5),
@usuario_cierre numeric(10))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE [dbo].[Cierre_Caja]
   SET fecha_cierre = getdate()
      ,usuario_cierre=@usuario_cierre
	  ,total_cierre = @total_cierre	
 WHERE cierrecajaid=@codigo

END




GO

/****** Object:  StoredProcedure [dbo].[Upd_Cliente]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Cliente]
(@codigo numeric(10),
@documentoid int,
@documento nvarchar(50),
@nombre  nvarchar(200),
@apellido  nvarchar(200),
@fdnac datetime,
@fding datetime,
@direccion  nvarchar(200),
@depto  nvarchar(20),
@piso  nvarchar(200),
@nro  nvarchar(20),
@localidad int,
@provincia int,
@pais int,
@mail  nvarchar(50),
@predeterminado bit)

AS
BEGIN 

	SET NOCOUNT ON;

if @predeterminado = 1 
 -- Si el cliente va a ser prederminado, tengo que buscar el cliente predet. anterior y ponerlo en cero
 begin
	 update FRIGORIFICO.[dbo].[Clientes]
		set predeterminado=0
	 where predeterminado = 1
 end

UPDATE FRIGORIFICO.[dbo].[Clientes]
   SET [doc_id] = @documentoid
      ,[cli_documento] = @documento
      ,[cli_nombre] = @nombre
      ,[cli_apellido] = @apellido
      ,[cli_fdnac] = @fdnac
      ,[cli_fding] = @fding
      ,[cli_direccion] =@direccion
      ,[cli_depto] = @depto
      ,[cli_piso] = @piso
      ,[cli_nro] = @nro
      ,[loc_id] = @localidad
      ,[prov_id] = @provincia
      ,[pais] = @pais
      ,[cli_mail] = @mail
	  ,[predeterminado] = @predeterminado
 WHERE cli_id=@codigo


END 






















GO

/****** Object:  StoredProcedure [dbo].[Upd_Compras]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Compras]
(@codigo numeric(10),
@fechaalta datetime,
@proveedorid int,
@nrofactura nvarchar(100),
@total decimal (15,5),
@observaciones nvarchar (4000))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE [FRIGORIFICO].[dbo].[Compras]
   SET [fechaalta] = @fechaalta
      ,[proveedorid] = @proveedorid
      ,[nrofactura] = @nrofactura
      ,[total] = @total
      ,[observaciones] = @observaciones
 WHERE [compraid] = @codigo




END 






























GO

/****** Object:  StoredProcedure [dbo].[Upd_Configuracion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <18/09/2012>
-- Description:	<Datos de Impresion>
-- =============================================
CREATE PROC [dbo].[Upd_Configuracion]
(@codigo numeric(10),
@numero_caja int,
@nombreimpresora  nvarchar(4000))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE [FRIGORIFICO].[dbo].[Configuraciones]
   SET [numero_caja] = @numero_caja
      ,[NombreImpresora] = @nombreimpresora
 WHERE conf_id = @codigo


END 
























GO

/****** Object:  StoredProcedure [dbo].[Upd_Contactos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Contactos]
(@codigo numeric(10),
@nombre  nvarchar(200),
@apellido  nvarchar(200),
@mail  nvarchar(100),
@puesto  nvarchar(100),
@observaciones  nvarchar(4000))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Contactos]
   SET [nombre] = @nombre
      ,[apellido] = @apellido
      ,[mail] = @mail
      ,[puesto] = @puesto
      ,[observaciones] = @observaciones
 WHERE id=@codigo

END 



















GO

/****** Object:  StoredProcedure [dbo].[Upd_Contactos_Clientes]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Upd_Contactos_Clientes]
(@idcontacto numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Contactos_cliente]
   SET [cc_vinculo] =@vinculo
      ,[cc_tipotel] =@tipotel
      ,[cc_tel] = @telefono
	  ,[interno] = @interno
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Upd_Contactos_Contactos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Upd_Contactos_Contactos]
(@idcontacto numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Contactos_Contactos]
   SET [cc_vinculo] =@vinculo
      ,[cc_tipotel] =@tipotel
      ,[cc_tel] = @telefono
	  ,[interno] = @interno
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Upd_Contactos_Empleados]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Upd_Contactos_Empleados]
(@idcontacto numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Contactos_Empleados]
   SET [cc_vinculo] =@vinculo
      ,[cc_tipotel] =@tipotel
      ,[cc_tel] = @telefono
	  ,[interno]=@interno
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Upd_Contactos_Proveedores]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se agregan los telefonos de los clientes>
-- =============================================
CREATE PROC [dbo].[Upd_Contactos_Proveedores]
(@idcontacto numeric(10),
@vinculo nvarchar(50),
@tipotel nvarchar(50),
@telefono nvarchar(50),
@interno nvarchar(50))
AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Contactos_Proveedores]
   SET [cc_vinculo] =@vinculo
      ,[cc_tipotel] =@tipotel
      ,[cc_tel] = @telefono
	  ,[interno] = @interno	
 WHERE cc_id=@idcontacto


commit
END 













GO

/****** Object:  StoredProcedure [dbo].[Upd_Devolucion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <08/03/2017>
-- Description:	<Se da de alta la devolucion>
-- =============================================
CREATE PROC [dbo].[Upd_Devolucion]
(@codigo numeric(10),
@fechaalta datetime,
@empleadoid int,
@clienteid int,
@observaciones nvarchar(4000),
@total decimal (15,5),
@estado nvarchar(200),
@listaprecio nvarchar(50))

AS
BEGIN 

UPDATE [FRIGORIFICO].[dbo].[Devoluciones]
   SET [fechaalta] = @fechaalta
      ,[empleadoid] = @empleadoid
      ,[clienteid] = @clienteid
      ,[observaciones] = @observaciones
      ,[total] = @total
      ,[estado] = @estado
      ,[listaprecio] = @listaprecio
 WHERE devolucionid=@codigo


END 






































GO

/****** Object:  StoredProcedure [dbo].[Upd_Devoluciones_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Devoluciones_Detalle]
(@codigo numeric(10),
@devolucionid int,
@articuloid int,
@cantidad int,
@puni decimal (15,5),
@total decimal (15,5))

AS
BEGIN 

UPDATE [FRIGORIFICO].[dbo].[Devoluciones_Detalle]
   SET [devolucionid] = @devolucionid
      ,[articuloid] = @articuloid
      ,[cantidad] = @cantidad
      ,[puni] = @puni
      ,[total] = @total
 WHERE detalleid=@codigo


END 


























GO

/****** Object:  StoredProcedure [dbo].[Upd_Diccionario]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se modifican los diccionarios>
-- =============================================
CREATE PROC [dbo].[Upd_Diccionario]
(@codigo numeric(10,0),
@numero1  numeric(10,0),
@valor1 nvarchar(1000),
@numero2 numeric(10,0),
@valor2  nvarchar(1000))
AS
BEGIN 

	SET NOCOUNT ON;


UPDATE FRIGORIFICO.[dbo].[Diccionario]
   SET [dd_numero1] = @numero1
      ,[cc_valor1] = @valor1
      ,[dd_numero2] = @numero2
      ,[cc_valor2] = @valor2
 WHERE dd_id=@codigo

commit
END 















GO

/****** Object:  StoredProcedure [dbo].[Upd_Empleados]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Empleados]
(@codigo numeric(10),
@documentoid int,
@documento nvarchar(50),
@nombre  nvarchar(200),
@apellido  nvarchar(200),
@fdnac datetime,
@fding datetime,
@fdegr nvarchar(30),
@nacionalidad  nvarchar(50),
@direccion  nvarchar(200),
@depto  nvarchar(20),
@piso  nvarchar(200),
@nro  nvarchar(20),
@localidad int,
@provincia int,
@cuit nvarchar(50),
@observaciones nvarchar(4000),
@predeterminado bit,
@idusuario int )

AS
BEGIN 

	SET NOCOUNT ON;

if @predeterminado = 1 
 -- Si el cliente va a ser prederminado, tengo que buscar el cliente predet. anterior y ponerlo en cero
 begin
	 update FRIGORIFICO.[dbo].[Empleados]
		set predeterminado=0
	 where predeterminado = 1
 end


UPDATE FRIGORIFICO.[dbo].[Empleados]
   SET [doc_id] = @documentoid
      ,[emp_documento] = @documento
      ,[emp_nombre] =@nombre
      ,[emp_apellido] =@apellido
      ,[emp_fdnac] = @fdnac
      ,[emp_fding] =@fding
      ,[emp_fdegr] =@fdegr
      ,[emp_nacionalidad] = @nacionalidad
      ,[emp_direccion] = @direccion
      ,[emp_depto] = @depto
      ,[emp_piso] = @piso
      ,[emp_nro] = @nro
      ,[loc_id] = @localidad
      ,[prov_id] = @provincia
      ,[emp_cuit] = @cuit
      ,[emp_observaciones] =@observaciones
	  ,[predeterminado]=@predeterminado
	  ,[usuario] = @idusuario
 WHERE emp_id=@codigo

END 





















GO

/****** Object:  StoredProcedure [dbo].[Upd_Factura]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Factura]
(@codigo numeric(10),
@fechaalta datetime,
@empleadoid int,
@clienteid int,
@observaciones nvarchar(4000),
@neto decimal (15,5),
@descuento int,
@subtotal decimal (15,5),
@iva10 decimal (15,5),
@iva21 decimal (15,5),
@total decimal (15,5),
@efectivoabona decimal (15,5),
@efectivovuelto decimal (15,5),
@estado nvarchar(20),
@ctacte decimal(15,5),
@ubicacion nvarchar(200),
@listaprecio nvarchar(50))

AS
BEGIN 

	SET NOCOUNT ON;


UPDATE FRIGORIFICO.[dbo].[Factura]
   SET [fechaalta] = @fechaalta
      ,[empleadoid] = @empleadoid
      ,[clienteid] = @clienteid
      ,[observaciones] = @observaciones
      ,[neto] = @neto
      ,[descuento] = @descuento
      ,[subtotal] = @subtotal
      ,[iva10] = @iva10
      ,[iva21] = @iva21
      ,[total] = @total
      ,[efectivoabona] = @efectivoabona
      ,[efectivovuelto] = @efectivovuelto
      ,[ctacte] = @ctacte
	  ,[estado] = @estado
	  ,[ubicacion]=@ubicacion
	  ,listaprecio =@listaprecio
 WHERE facturaid=@codigo


END 


































GO

/****** Object:  StoredProcedure [dbo].[Upd_Factura_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Factura_Detalle]
(@codigo numeric(10),
@facturaid int,
@articuloid int,
@cantidad numeric(10,5),
@puni decimal (15,5),
@descuento int,
@total decimal (15,5),
@linea int,
@unidades int)

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Factura_Detalle]
   SET [facturaid] = @facturaid
      ,[articuloid] = @articuloid
      ,[cantidad] = @cantidad
      ,[puni] = @puni
      ,[descuento] = @descuento
      ,[total] = @total
	  ,unidades = @unidades
	  ,linea = @linea
 WHERE detalleid=@codigo



END 

























GO

/****** Object:  StoredProcedure [dbo].[Upd_Impresion]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <18/09/2012>
-- Description:	<Datos de Impresion>
-- =============================================
CREATE PROC [dbo].[Upd_Impresion]
(@comercio nvarchar(4000),
@direccion nvarchar(4000),
@provincia  nvarchar(4000),
@localidad  nvarchar(4000),
@codigointerno nvarchar(4000),
@comentariolinea1 nvarchar(4000),
@comentariolinea2  nvarchar(4000),
@comentariolinea3  nvarchar(4000),
@impresora  nvarchar(4000))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE [FRIGORIFICO].[dbo].[Impresion]
   SET [NombreComercio] = @comercio
      ,[Direccion] = @direccion
      ,[Provincia] = @provincia
      ,[Localidad] = @localidad
      ,[CodigoInterno] = @codigointerno
      ,[ComentarioLinea1] = @comentariolinea1
      ,[ComentarioLinea2] = @comentariolinea2
      ,[ComentarioLinea3] = @comentariolinea3
      ,[NombreImpresora] = @impresora
 

END 























GO

/****** Object:  StoredProcedure [dbo].[Upd_Medio_Pago]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Medio_Pago]
(@codigo numeric(10),
@predeterminado int,
@descripcion nvarchar(100))

AS
BEGIN 

if @predeterminado = 1 
 -- Si el cliente va a ser prederminado, tengo que buscar el cliente predet. anterior y ponerlo en cero
 begin
	 update dbo.Medio_Pago
		set predeterminado=0
	 where predeterminado = 1
 end

UPDATE [FRIGORIFICO].[dbo].[Medio_Pago]
   SET [descripcion] = @descripcion,
	predeterminado = @predeterminado
 WHERE mediopago =@codigo

END 































GO

/****** Object:  StoredProcedure [dbo].[Upd_Monedas]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <05/05/2017>
-- Description:	<Monedas>
-- =============================================
CREATE PROC [dbo].[Upd_Monedas]
(@codigo numeric(10),
@descripcion nvarchar(50),
@cotizacion decimal(10,5))

AS
BEGIN 

	SET NOCOUNT ON;
UPDATE [FRIGORIFICO].[dbo].[Monedas]
   SET [descripcion] = @descripcion
      ,[cotizacion] = @cotizacion
 WHERE monedaid = @codigo


END 
































GO

/****** Object:  StoredProcedure [dbo].[Upd_Perfiles]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <16/06/2016>
-- Description:	<Se actualiza el perfil>
-- =============================================
CREATE PROC [dbo].[Upd_Perfiles]
(@codigo numeric(10),
@usuario_id numeric(10),
@modulo nvarchar(200),
@pantalla nvarchar(200),
@permiso nvarchar(200))

AS
BEGIN 

	SET NOCOUNT ON;


UPDATE Perfiles
   SET [usuarioid] = @usuario_id
      ,[modulo] = @modulo
      ,[pantalla] = @pantalla
      ,[permiso] = @permiso
 WHERE id=@codigo



END 
































GO

/****** Object:  StoredProcedure [dbo].[Upd_Proveedores]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <01/03/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Proveedores]
(@codigo numeric(10),
@documentoid int,
@documento nvarchar(50),
@razonsocial  nvarchar(400),
@fding datetime,
@direccion  nvarchar(200),
@depto  nvarchar(20),
@piso  nvarchar(200),
@nro  nvarchar(20),
@localidad int,
@provincia int,
@pais int,
@mail  nvarchar(50),
@url  nvarchar(50),
@lunes bit,
@martes bit,
@miercoles bit,
@jueves bit,
@viernes bit,
@sabado bit,
@domingo bit,
@servicios nvarchar(1000))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Proveedores]
   SET [doc_id] = @documentoid
      ,[documento] = @documento
      ,[razonsocial] =@razonsocial
      ,[fding] = @fding
      ,[direccion] = @direccion
      ,[depto] = @depto
      ,[piso] = @piso
      ,[nro] = @nro
      ,[loc_id] = @localidad
      ,[prov_id] = @provincia
      ,[pais] = @pais
      ,[mail] =@mail
      ,[url] =@url
      ,[Lunes] = @lunes
      ,[Martes] = @martes
      ,[Miercoles] = @miercoles
      ,[Jueves] = @jueves
      ,[Viernes] =@viernes
      ,[Sabado] = @sabado
      ,[Domingo] = @domingo
	  ,[servicios]=@servicios
 WHERE id=@codigo




END 




















GO

/****** Object:  StoredProcedure [dbo].[Upd_Tarjeta_Detalle]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Tarjeta_Detalle]
(@codigo numeric(10),
@tarjetaabona decimal(15,5),
@tarjetanombre nvarchar(200),
@tarjetanumero nvarchar(200),
@tarjetacuotas nvarchar(20),
@tipo nvarchar(20))

AS
BEGIN 

	SET NOCOUNT ON;

UPDATE FRIGORIFICO.[dbo].[Tarjetas_Detalle]
   SET [tarjetaabona] = @tarjetaabona
      ,[tarjetanombre] = @tarjetanombre
      ,[tarjetanumero] = @tarjetanumero
      ,[tarjetacuotas] =@tarjetacuotas
	  ,[tipo] =@tipo
 WHERE id=@codigo


END 






























GO

/****** Object:  StoredProcedure [dbo].[Upd_Usuarios]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <16/06/2016>
-- Description:	<Se actualiza el usuario>
-- =============================================
CREATE PROC [dbo].[Upd_Usuarios]
(@codigo numeric(10) ,
@usuario nvarchar(50),
@nombre_apellido nvarchar(200),
@es_admin int,
@contraseña nvarchar(50))

AS
BEGIN 

	SET NOCOUNT ON;


UPDATE Usuarios
   SET [usuario] = @usuario
      ,[nombre_apellido] = @nombre_apellido
      ,[es_admin] = @es_admin
		,contraseña = @contraseña
 WHERE id= @codigo



END 
































GO

/****** Object:  StoredProcedure [dbo].[Upd_Ventas_Pagos]    Script Date: 07/06/2018 06:08:23 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Nicolas Blasco>
-- Create date: <03/01/2012>
-- Description:	<Se da de alta el cliente>
-- =============================================
CREATE PROC [dbo].[Upd_Ventas_Pagos]
(@ventas_pagos_id numeric(10), 
@fecha datetime,
@importe money,
@mediopago int)

AS
BEGIN 

UPDATE Ventas_Pagos
   SET [fecha] = @fecha
      ,[importe] = @importe
	  ,mediopago= @mediopago
 WHERE [ventas_pagos_id] = @ventas_pagos_id


END 



























GO

