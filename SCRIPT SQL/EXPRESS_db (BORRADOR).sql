use master
go

CREATE DATABASE EXPRESS_SOLUTIONS_DB_borrador
GO

use EXPRESS_SOLUTIONS_DB_borrador
go

CREATE TABLE TIPO_USUARIO(
	ID INT IDENTITY (1,1),
	TipoUsuario VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TYPE PRIMARY KEY(ID),
	CONSTRAINT UQ_TYPES UNIQUE(ID, TipoUsuario)
)
GO

CREATE TABLE USUARIO( 
	ID INT IDENTITY (1,1),
	IDTipoUsuario INT NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	Apellido NVARCHAR(50) NOT NULL, 
	Email NVARCHAR(50) NOT NULL,
	Pass NVARCHAR(50) NOT NULL,
	CONSTRAINT FK_USER_TYPE FOREIGN KEY (IDTipoUsuario) REFERENCES TIPO_USUARIO(ID),
	CONSTRAINT UQ_USERS UNIQUE (Nombre, Apellido, Email),
	CONSTRAINT PK_USER PRIMARY KEY(ID)
)
GO

CREATE TABLE TIPO_INCIDENCIA(
	ID INT IDENTITY (1,1),
	Descripcion NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_INCIDENCE PRIMARY KEY(ID),
	CONSTRAINT UQ_INCIDENCES UNIQUE(ID, Descripcion)
)
GO
CREATE TABLE PRIORIDAD_INCIDENCIA(
	ID INT IDENTITY (1,1),
	Descripcion NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_PRIORITY PRIMARY KEY(ID),
	CONSTRAINT UQ_PRIORITYS UNIQUE(ID, Descripcion)
)
GO

CREATE TABLE ESTADO_INCIDENCIA(
	ID INT IDENTITY (1,1),
	Descripcion NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_STATE PRIMARY KEY(ID),
	CONSTRAINT UQ_STATES UNIQUE(ID, Descripcion)
)
GO

CREATE TABLE INCIDENCIAS(
	ID INT IDENTITY (1,1),
	IDTipoIncidencia INT NULL,
	IDPrioridadIncidencia INT NULL,
	IDEstado INT NULL,
	Comentarios NVARCHAR(300) NULL,
	CONSTRAINT FK_INCIDENCE_TYPE FOREIGN KEY (IDTipoIncidencia) REFERENCES TIPO_INCIDENCIA(ID),
	CONSTRAINT FK_INCIDENCE_PRIORITY FOREIGN KEY (IDPrioridadIncidencia) REFERENCES PRIORIDAD_INCIDENCIA(ID),
	CONSTRAINT FK_INCIDENCE_STATE FOREIGN KEY (IDEstado) REFERENCES ESTADO_INCIDENCIA(ID),
	CONSTRAINT PK_INCIDENCE_ID PRIMARY KEY (ID)
)
GO

CREATE TABLE USUARIOS_X_INCIDENCIA(
	ID INT IDENTITY (1,1),
	Nombre NVARCHAR(50) NULL,
	IDIncidencia INT NOT NULL,
	IDCliente INT NOT NULL,
	IDTelefonista INT NULL,
	Descripcion NVARCHAR(300) NOT NULL,
	CONSTRAINT FK_INCIDENCE_USER FOREIGN KEY (IDIncidencia) REFERENCES INCIDENCIAS(ID),
	CONSTRAINT FK_USER_INCIDENCE FOREIGN KEY (IDCliente) REFERENCES USUARIO(ID),
	CONSTRAINT FK_TELEFONIST_INCIDENCE FOREIGN KEY (IDTelefonista) REFERENCES USUARIO(ID),
	CONSTRAINT PK_INCIDENCE_X_USER PRIMARY KEY (ID)
)

INSERT INTO TIPO_USUARIO VALUES 
('CLIENTE'),
('TELEFONISTA'),
('ADMINISTRADOR'),
('SUPERVISOR')

INSERT INTO TIPO_INCIDENCIA VALUES 
('SOFWARE'),
('HARDWARE'),
('RED'),
('BASE DE DATOS')

INSERT INTO PRIORIDAD_INCIDENCIA VALUES 
('BAJA'),
('MODERADA'),
('ALTA'),
('URGENTE')

INSERT INTO ESTADO_INCIDENCIA VALUES 
('ABIERTO'),
('EN ANALISIS'),
('CERRADO'),
('REABIERTO'),
('ASIGNADO'),
('RESUELTO')

INSERT INTO USUARIO (IDTipoUsuario, Nombre, Apellido, Email, Pass) VALUES 
(3, 'Carlos', 'Gonzalez', 'carlos.gonzalez@admin.com', '123456'), 
(4, 'Maria', 'Perez', 'maria.perez@supervisor.com', '987654'), 
(2, 'Luis', 'Martinez', 'luis.martinez@telefonista.com', '111111'), 
(2, 'Ana', 'Rodriguez', 'ana.rodriguez@telefonista.com', '222222'), 
(2, 'Jorge', 'Sanchez', 'jorge.sanchez@telefonista.com', '333333'), 
(1, 'Juan', 'Lopez', 'juan.lopez@cliente.com', '444444'), 
(1, 'Laura', 'Fernandez', 'laura.fernandez@cliente.com', '555555'), 
(1, 'Sofia', 'Ramirez', 'sofia.ramirez@cliente.com', '666666'), 
(1, 'Pedro', 'Gomez', 'pedro.gomez@cliente.com', '777777'), 
(1, 'Lucia', 'Diaz', 'lucia.diaz@cliente.com', '888888'),

(3, 'John', 'Doe', 'john.doe@admin.com', '999999'),
(4, 'Jane', 'Smith', 'jane.smith@supervisor.com', 'aaabbb'),
(2, 'Alice', 'Johnson', 'alice.johnson@telefonista.com', 'bbbccc'),
(2, 'Bob', 'Williams', 'bob.williams@telefonista.com', 'cccddd'),
(2, 'Clara', 'Brown', 'clara.brown@telefonista.com', 'dddeee'),
(1, 'David', 'Jones', 'david.jones@cliente.com', 'eeefff'),
(1, 'Eve', 'Garcia', 'eve.garcia@cliente.com', 'fffggg'),
(1, 'Frank', 'Martinez', 'frank.martinez@cliente.com', 'ggghhh'),
(1, 'Grace', 'Lopez', 'grace.lopez@cliente.com', 'hhhiii'),
(1, 'Henry', 'Gonzalez', 'henry.gonzalez@cliente.com', 'iiijjj')


--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


-- COMANDOS
USE EXPRESS_SOLUTIONS_DB_borrador
GO

-- SELECT TODO
SELECT * FROM USUARIO;
GO

-- Modificar campo email en tabla usuarios para que sea unique
ALTER TABLE USUARIO
ADD CONSTRAINT U_Email UNIQUE (email);
GO


-- REGISTRAR
CREATE or ALTER PROCEDURE RegistrarUsuario (
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Email nvarchar(50),
	@Pass nvarchar(50)
)
AS BEGIN
	INSERT INTO USUARIO(Nombre, Apellido, Email, Pass, IDTipoUsuario)
	OUTPUT inserted.Id
	VALUES(@Nombre, @Apellido, @Email, @Pass, 1) --Es 1 ya que al registrar, automaticamente te identifica como cliente
END
GO

-- EJEMPLO
EXEC RegistrarUsuario 'Braian', 'Pirelli', 'braian@mail', 'soybraian';
GO


--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


CREATE OR ALTER PROCEDURE MODIFICAR_USUARIO(
	@ID INT,
	@ID_TIPO_USUARIO INT,
	@NOMBRE NVARCHAR(50), 
	@APELLIDO NVARCHAR(50),
	@EMAIL NVARCHAR(50),
	@PASS NVARCHAR(50)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE USUARIO 
			SET IDTipoUsuario = @ID_TIPO_USUARIO, Nombre = @NOMBRE, Apellido = @APELLIDO, Email = @EMAIL, Pass = @PASS
			WHERE ID = @ID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF (@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION
		RAISERROR('SE PRODUJO UN ERROR AL REALIZAR LA MODIFICACION DEL USUARIO INTENTE DE NUEVO MAS TARDE!', 16, 10)
	END CATCH
END

-- EJEMPLO PARA PEGAR EN EL CODEBEHIND
EXEC MODIFICAR_USUARIO @ID, @ID_TIPO_USUARIO, @NOMBRE, @APELLIDO, @EMAIL, @PASS


--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


CREATE OR ALTER FUNCTION TELEFONISTA_SIN_INCIDENCIAS( @ID INT )
RETURNS INT
AS
BEGIN
	DECLARE @CANTIDAD INT


	SELECT @CANTIDAD = COUNT(*)
	FROM USUARIOS_X_INCIDENCIA AS UXI
	INNER JOIN INCIDENCIAS AS I ON I.ID = UXI.IDIncidencia
	INNER JOIN ESTADO_INCIDENCIA AS EI ON EI.ID = I.IDEstado
	WHERE UXI.IDTelefonista = @ID
	AND EI.Descripcion NOT IN('CERRADO', 'RESUELTO')

	RETURN @CANTIDAD
END

-- EJEMPLO PARA PEGAR EN EL CODEBEHIND
SELECT DBO.TELEFONISTA_SIN_INCIDENCIAS (@ID)


--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


CREATE OR ALTER PROCEDURE BUSCAR_USUARIO(
	@ID INT
)
AS
BEGIN
	BEGIN TRY
		SELECT IDTipoUsuario, Nombre, Apellido, Email, Pass FROM USUARIO -- EL ID TIPO DE USUARIO ES PARA PASAR COMO DEFAULT A LA DDL TIPO USUARIO
		WHERE ID = @ID
	END TRY
	BEGIN CATCH
		RAISERROR('SE PRODUJO UN ERROR USUARIO INCORRECTO O NO EXISTE!', 16, 10)
	END CATCH
END

-- EJEMPLO PARA PEGAR EN EL CODEBEHIND
EXEC BUSCAR_USUARIO @ID


--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
