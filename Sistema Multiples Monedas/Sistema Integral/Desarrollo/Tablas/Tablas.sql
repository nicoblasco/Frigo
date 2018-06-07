USE [FRIGORIFICO]
GO

/****** Object:  Table [dbo].[Articulos]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulos](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[idextra] [nvarchar](500) NULL,
	[fechaalta] [datetime] NULL,
	[descripcion] [nvarchar](2000) NULL,
	[proveedor] [int] NULL,
	[rubro] [nvarchar](200) NULL,
	[marca] [nvarchar](200) NULL,
	[ubicacion] [nvarchar](200) NULL,
	[stock] [numeric](10, 0) NULL,
	[stockminimo] [numeric](10, 0) NULL,
	[costo] [money] NULL,
	[ganancia] [money] NULL,
	[iva] [money] NULL,
	[precioefectivo] [money] NULL,
	[preciotarjeta] [money] NULL,
	[fechabaja] [datetime] NULL,
	[imagen] [nvarchar](2000) NULL,
	[preciolista2] [money] NULL,
	[preciolista3] [money] NULL,
	[desccorta] [nvarchar](100) NULL,
	[monedaid] [numeric](10, 0) NULL,
	[unidaddeventa] [nvarchar](50) NULL,
 CONSTRAINT [PK__Articulos__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Cheques_Detalle]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cheques_Detalle](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[facturaid] [numeric](10, 0) NULL,
	[chequeabona] [money] NULL,
	[chequebanco] [nvarchar](200) NULL,
	[chequenumero] [nvarchar](200) NULL,
	[chequevenc] [datetime] NULL,
 CONSTRAINT [PK__Cheque__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Cierre_Caja]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cierre_Caja](
	[cierrecajaid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[total] [money] NULL,
	[fecha] [datetime] NULL,
	[fecha_apertura] [datetime] NULL,
	[fecha_cierre] [datetime] NULL,
	[numero_caja] [int] NULL,
	[total_cierre] [money] NULL,
	[usuario_apertura] [numeric](10, 0) NULL,
	[usuario_cierre] [numeric](10, 0) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[cli_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[doc_id] [int] NULL,
	[cli_documento] [nvarchar](50) NULL,
	[cli_nombre] [nvarchar](200) NULL,
	[cli_apellido] [nvarchar](200) NULL,
	[cli_fdnac] [datetime] NULL,
	[cli_fding] [datetime] NULL,
	[cli_direccion] [nvarchar](200) NULL,
	[cli_depto] [nvarchar](20) NULL,
	[cli_piso] [nvarchar](200) NULL,
	[cli_nro] [nvarchar](20) NULL,
	[loc_id] [int] NULL,
	[prov_id] [int] NULL,
	[pais] [int] NULL,
	[cli_mail] [nvarchar](50) NULL,
	[fechabaja] [datetime] NULL,
	[predeterminado] [bit] NULL,
 CONSTRAINT [PK__Clientes__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[cli_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Compras]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Compras](
	[compraid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[fechaalta] [datetime] NULL,
	[proveedorid] [numeric](10, 0) NULL,
	[nrofactura] [nvarchar](100) NULL,
	[total] [money] NULL,
	[observaciones] [nvarchar](4000) NULL,
	[fechabaja] [nvarchar](20) NULL,
	[cierrecajaid] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[compraid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Configuraciones]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Configuraciones](
	[conf_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[nombre_pc] [nvarchar](100) NULL,
	[numero_caja] [int] NULL,
	[NombreImpresora] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contactos]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contactos](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[prov_id] [numeric](10, 0) NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[apellido] [nvarchar](200) NULL,
	[mail] [nvarchar](100) NULL,
	[puesto] [nvarchar](100) NULL,
	[observaciones] [nvarchar](4000) NULL,
 CONSTRAINT [PK__Contactos__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contactos_cliente]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contactos_cliente](
	[cc_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[cli_id] [numeric](10, 0) NULL,
	[cc_vinculo] [nvarchar](50) NULL,
	[cc_tipotel] [nvarchar](50) NULL,
	[cc_tel] [nvarchar](50) NULL,
	[interno] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contactos_Contactos]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contactos_Contactos](
	[cc_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[cli_id] [numeric](10, 0) NULL,
	[cc_vinculo] [nvarchar](50) NULL,
	[cc_tipotel] [nvarchar](50) NULL,
	[cc_tel] [nvarchar](50) NULL,
	[interno] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contactos_Empleados]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contactos_Empleados](
	[cc_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[cli_id] [numeric](10, 0) NULL,
	[cc_vinculo] [nvarchar](50) NULL,
	[cc_tipotel] [nvarchar](50) NULL,
	[cc_tel] [nvarchar](50) NULL,
	[interno] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contactos_hist]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contactos_hist](
	[hist_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[id] [numeric](10, 0) NOT NULL,
	[prov_id] [numeric](10, 0) NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[apellido] [nvarchar](200) NULL,
	[mail] [nvarchar](100) NULL,
	[puesto] [nvarchar](100) NULL,
	[observaciones] [nvarchar](4000) NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK__Contactos_hist__07F6335A] PRIMARY KEY CLUSTERED 
(
	[hist_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contactos_Proveedores]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contactos_Proveedores](
	[cc_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[cli_id] [numeric](10, 0) NULL,
	[cc_vinculo] [nvarchar](50) NULL,
	[cc_tipotel] [nvarchar](50) NULL,
	[cc_tel] [nvarchar](50) NULL,
	[interno] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Devoluciones]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Devoluciones](
	[devolucionid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[fechaalta] [datetime] NULL,
	[empleadoid] [numeric](10, 0) NULL,
	[clienteid] [numeric](10, 0) NULL,
	[observaciones] [nvarchar](4000) NULL,
	[total] [money] NULL,
	[estado] [nvarchar](200) NULL,
	[listaprecio] [nvarchar](50) NULL,
	[cierrecajaid] [numeric](10, 0) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Devoluciones_Detalle]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Devoluciones_Detalle](
	[detalleid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[devolucionid] [numeric](10, 0) NULL,
	[articuloid] [numeric](10, 0) NULL,
	[cantidad] [numeric](10, 0) NULL,
	[puni] [money] NULL,
	[total] [money] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Diccionario]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Diccionario](
	[dd_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[dd_parametro] [nvarchar](200) NULL,
	[dd_numero1] [numeric](10, 0) NULL,
	[cc_valor1] [nvarchar](1000) NULL,
	[dd_numero2] [numeric](10, 0) NULL,
	[cc_valor2] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[dd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Documentos]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Documentos](
	[doc_id] [int] IDENTITY(1,1) NOT NULL,
	[doc_desc] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[doc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Empleados]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empleados](
	[emp_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[doc_id] [int] NULL,
	[emp_documento] [nvarchar](50) NULL,
	[emp_nombre] [nvarchar](200) NULL,
	[emp_apellido] [nvarchar](200) NULL,
	[emp_fdnac] [datetime] NULL,
	[emp_fding] [datetime] NULL,
	[emp_fdegr] [nvarchar](30) NULL,
	[emp_nacionalidad] [nvarchar](200) NULL,
	[emp_direccion] [nvarchar](200) NULL,
	[emp_depto] [nvarchar](20) NULL,
	[emp_piso] [nvarchar](200) NULL,
	[emp_nro] [nvarchar](20) NULL,
	[loc_id] [int] NULL,
	[prov_id] [int] NULL,
	[emp_cuit] [nvarchar](50) NULL,
	[emp_observaciones] [nvarchar](4000) NULL,
	[fechabaja] [datetime] NULL,
	[predeterminado] [bit] NULL,
	[usuario] [int] NULL,
 CONSTRAINT [PK__Empleados__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Factura]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura](
	[facturaid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[fechaalta] [datetime] NULL,
	[empleadoid] [numeric](10, 0) NULL,
	[clienteid] [numeric](10, 0) NULL,
	[observaciones] [nvarchar](4000) NULL,
	[neto] [money] NULL,
	[descuento] [numeric](10, 0) NULL,
	[subtotal] [money] NULL,
	[iva10] [money] NULL,
	[iva21] [money] NULL,
	[total] [money] NULL,
	[efectivoabona] [money] NULL,
	[efectivovuelto] [money] NULL,
	[ctacte] [money] NULL,
	[estado] [nvarchar](200) NULL,
	[ubicacion] [nvarchar](200) NULL,
	[listaprecio] [nvarchar](50) NULL,
 CONSTRAINT [PK__Factura__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[facturaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Factura_Detalle]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura_Detalle](
	[detalleid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[facturaid] [numeric](10, 0) NULL,
	[articuloid] [numeric](10, 0) NULL,
	[cantidad] [numeric](10, 5) NULL,
	[puni] [money] NULL,
	[descuento] [numeric](10, 0) NULL,
	[total] [money] NULL,
	[unidades] [numeric](10, 0) NULL,
	[linea] [int] NULL,
 CONSTRAINT [PK__Detalle__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[detalleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Impresion]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Impresion](
	[NombreComercio] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Provincia] [nvarchar](max) NULL,
	[Localidad] [nvarchar](max) NULL,
	[CodigoInterno] [nvarchar](max) NULL,
	[ComentarioLinea1] [nvarchar](max) NULL,
	[ComentarioLinea2] [nvarchar](max) NULL,
	[ComentarioLinea3] [nvarchar](max) NULL,
	[NombreImpresora] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Localidades]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Localidades](
	[loc_id] [int] IDENTITY(1,1) NOT NULL,
	[prov_id] [int] NULL,
	[prov_desc] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[loc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Medio_Pago]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Medio_Pago](
	[mediopago] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](100) NULL,
	[fechabaja] [datetime] NULL,
	[predeterminado] [int] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Monedas]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Monedas](
	[monedaid] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[cotizacion] [decimal](10, 5) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Paises]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Paises](
	[pais_id] [int] IDENTITY(1,1) NOT NULL,
	[pais_desc] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[pais_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Perfiles]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Perfiles](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[usuarioid] [numeric](10, 0) NOT NULL,
	[modulo] [nvarchar](50) NOT NULL,
	[pantalla] [nvarchar](200) NOT NULL,
	[permiso] [nvarchar](200) NOT NULL,
	[fecha_alta] [datetime] NOT NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Proveedores]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Proveedores](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[doc_id] [int] NULL,
	[documento] [nvarchar](50) NULL,
	[razonsocial] [nvarchar](400) NULL,
	[fding] [datetime] NULL,
	[direccion] [nvarchar](200) NULL,
	[depto] [nvarchar](20) NULL,
	[piso] [nvarchar](200) NULL,
	[nro] [nvarchar](20) NULL,
	[loc_id] [int] NULL,
	[prov_id] [int] NULL,
	[pais] [int] NULL,
	[mail] [nvarchar](50) NULL,
	[url] [nvarchar](50) NULL,
	[Lunes] [bit] NULL,
	[Martes] [bit] NULL,
	[Miercoles] [bit] NULL,
	[Jueves] [bit] NULL,
	[Viernes] [bit] NULL,
	[Sabado] [bit] NULL,
	[Domingo] [bit] NULL,
	[servicios] [nvarchar](1000) NULL,
	[fechabaja] [datetime] NULL,
 CONSTRAINT [PK__Proveedores__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Provincias]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Provincias](
	[prov_id] [int] IDENTITY(1,1) NOT NULL,
	[pais_id] [int] NULL,
	[prov_desc] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[prov_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Tarjetas_Detalle]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tarjetas_Detalle](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[facturaid] [numeric](10, 0) NULL,
	[tarjetaabona] [money] NULL,
	[tarjetanombre] [nvarchar](200) NULL,
	[tarjetanumero] [nvarchar](200) NULL,
	[tarjetacuotas] [nvarchar](20) NULL,
	[tipo] [nvarchar](20) NULL,
 CONSTRAINT [PK__Tarjetas_Detalle__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[nombre_apellido] [nvarchar](200) NULL,
	[es_admin] [int] NULL,
	[fecha_alta] [datetime] NULL,
	[contraseña] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Ventas_Pagos]    Script Date: 07/06/2018 06:07:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ventas_Pagos](
	[ventas_pagos_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ventas_id] [numeric](10, 0) NOT NULL,
	[fecha] [datetime] NULL,
	[importe] [money] NULL,
	[cierrecajaid] [numeric](10, 0) NULL,
	[mediopago] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD FOREIGN KEY([prov_id])
REFERENCES [dbo].[Provincias] ([prov_id])
GO

ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD FOREIGN KEY([prov_id])
REFERENCES [dbo].[Provincias] ([prov_id])
GO

ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD FOREIGN KEY([pais_id])
REFERENCES [dbo].[Paises] ([pais_id])
GO

ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD FOREIGN KEY([pais_id])
REFERENCES [dbo].[Paises] ([pais_id])
GO

ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD FOREIGN KEY([pais_id])
REFERENCES [dbo].[Paises] ([pais_id])
GO

ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD FOREIGN KEY([pais_id])
REFERENCES [dbo].[Paises] ([pais_id])
GO

