CREATE SCHEMA ADMIN

CREATE TABLE ADMIN.ROLE
(
	ID_ROLE INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TIPO_ROLE VARCHAR(100) NOT NULL,
	IS_DELETE BIT DEFAULT 0 NULL
)

CREATE TABLE ADMIN.USUARIO
(
	ID_USUARIO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NOMBRE VARCHAR(30) NOT NULL,
	APELLIDOS VARCHAR (100) NOT NULL,
	CEDULA VARCHAR(30) NOT NULL,
	NOMBRE_USUARIO VARCHAR(100) NOT NULL,
	CONTRASENIA VARCHAR(100) NOT NULL,
	ID_ROLE INT NOT NULL,
	CONSTRAINT fk_id_role FOREIGN KEY (ID_ROLE) REFERENCES ADMIN.ROLE(ID_ROLE),
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.SECTOR
(
	ID_SECTOR INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NOMBRE_SECTOR VARCHAR(32) NOT NULL,
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.AVERIA
(
	ID_AVERIA INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ID_SECTOR INT NULL,
	AFECTADO VARCHAR(100) NOT NULL,
	FECHA_REPORTE DATETIME NOT NULL,
	DETALLES_REPORTE VARCHAR(300) NOT NULL,
	FECHA_EJECUCION DATETIME NULL,
	TRABAJO_EJECUTADO VARCHAR(300) NOT NULL,
	CONSTRAINT fk_id_sector_averia FOREIGN KEY (ID_SECTOR) REFERENCES ADMIN.SECTOR(ID_SECTOR),
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.AVERIA_TRABAJADOR
(
	ID_AVERIA INT NOT NULL,
	ID_TRABAJADOR INT NOT NULL,
	CONSTRAINT pk_id_averia_trabajador PRIMARY KEY (ID_AVERIA, ID_TRABAJADOR),
	CONSTRAINT fk_id_averia_averia FOREIGN KEY (ID_AVERIA) REFERENCES ADMIN.AVERIA(ID_AVERIA),
	CONSTRAINT fk_id_trabajador_averia FOREIGN KEY (ID_TRABAJADOR) REFERENCES ADMIN.USUARIO(ID_USUARIO),
	IS_DELETE BIT DEFAULT 0 NULL
);


CREATE TABLE ADMIN.TAREA
(
	ID_TAREA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FECHA_ASIGNACION DATETIME NOT NULL,
	TITULO VARCHAR(300) NOT NULL,
	DETALLES VARCHAR(300) NULL,
	ID_USUARIO INT NOT NULL,
	REALIZADA BIT DEFAULT 0 NULL,
	CONSTRAINT fk_id_usuario_tarea FOREIGN KEY (ID_USUARIO) REFERENCES ADMIN.USUARIO(ID_USUARIO),
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.RECAUDACION_DIARIA
(
	ID_RECAUDACION INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	ID_USUARIO INT NOT NULL,
	FECHA_RECAUDACION DATETIME NOT NULL,
	CANTIDAD_EFECTIVO VARCHAR (100) NULL, --dinero +
	CANTIDAD_TARJETA VARCHAR (100) NULL, --dinero +
	CANTIDAD_SINPE VARCHAR (100) NULL, --dinero +
	CANTIDAD_IVA VARCHAR (100) NOT NULL, --dinero +
	CUENTA_HIDRANTES INT NOT NULL, --dinero +
	TOTAL_RECAUDADO VARCHAR(100) NOT NULL, --total dinero
	CANTIDAD_RECIBOS INT NULL,
	CONSTRAINT fk_id_usuario_recaudacion FOREIGN KEY (ID_USUARIO) REFERENCES ADMIN.USUARIO(ID_USUARIO),
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.PRODUCTO
(
	CODIGO_PRODUCTO VARCHAR(32) PRIMARY KEY NOT NULL,
	NOMBRE_PRODUCTO VARCHAR(32) NOT NULL,
	VALOR_UNITARIO VARCHAR(30) NOT NULL,
	CANTIDAD INT NOT NULL,
	FECHA_INGRESO DATETIME NULL,
	DESCRIPCION VARCHAR(100) NULL,
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.USUARIO_PRODUCTO
(
	ID_SOLICITUD IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CODIGO_PRODUCTO VARCHAR(32) NOT NULL,
	ID_USUARIO INT NOT NULL,
	CANTIDAD INT NOT NULL,
	DETALLES VARCHAR(300) NULL,
	FECHA_SOLICITUD DATETIME NOT NULL,
	CONSTRAINT fk_id_usuario_producto FOREIGN KEY (ID_USUARIO) REFERENCES ADMIN.USUARIO(ID_USUARIO),
	CONSTRAINT fk_cod_producto_usuario FOREIGN KEY (CODIGO_PRODUCTO) REFERENCES ADMIN.PRODUCTO(CODIGO_PRODUCTO),
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.CLORO_RESIDUAL
(
	ID_CLORO_RESIDUAL INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ID_USUARIO INT,
	NOMBRE_CLIENTE VARCHAR(32) NOT NULL,
	NUMERO_CASA INT NOT NULL,
	FECHA DATETIME NOT NULL,
	PORCENTAJE_CLORO VARCHAR(32) NOT NULL,
	DETALLES VARCHAR(300) NULL,
	CONSTRAINT fk_id_usuario_cloro FOREIGN KEY (ID_USUARIO) REFERENCES ADMIN.USUARIO(ID_USUARIO),
	IS_DELETE BIT DEFAULT 0 NULL
);

CREATE TABLE ADMIN.BITACORA_PERSONAL
(
	ID_BITACORA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DETALLE VARCHAR (500) NOT NULL,
	FECHA DATETIME NOT NULL,
	ID_USUARIO INT NOT NULL,
	CONSTRAINT fk_id_usuario_bitacora FOREIGN KEY (ID_USUARIO) REFERENCES ADMIN.USUARIO(ID_USUARIO),
	IS_DELETE BIT DEFAULT 0 NULL
);
