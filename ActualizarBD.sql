USE master;
GO

-- Si no está adjunta en esta sesión, la adjuntamos temporalmente apuntando a tu archivo del proyecto:
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BDDigitalFarma')
BEGIN
    CREATE DATABASE [BDDigitalFarma] 
    ON (FILENAME = 'C:\Users\lucia\source\repos\Tesis01\LuciGarcia10\pryTesisVentas\Datos\BDDigitalFarma.mdf') 
    FOR ATTACH;
END
GO

USE BDDigitalFarma;
GO

-- Agrega la columna Saldo si no existe
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Clientes' AND COLUMN_NAME = 'Saldo'
)
BEGIN
    ALTER TABLE Clientes ADD Saldo DECIMAL(18, 2) NOT NULL DEFAULT 0;
END
GO

-- Agrega la columna Estado si no existe
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Clientes' AND COLUMN_NAME = 'Estado'
)
BEGIN
    ALTER TABLE Clientes ADD Estado VARCHAR(50) NOT NULL DEFAULT 'Al dia';
END
GO

-- 1. Primero borramos el objeto invisible que bloqueaba todo
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'DF__Clientes__Estado__45F365D3')
BEGIN
    ALTER TABLE Clientes DROP CONSTRAINT DF__Clientes__Estado__45F365D3;
END
GO

-- 2. Ahora que está liberada, borramos la columna vieja de tipo BIT
IF EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Clientes' AND COLUMN_NAME = 'Estado'
)
BEGIN
    ALTER TABLE Clientes DROP COLUMN Estado;
END
GO

-- 3. Finalmente, creamos la columna como VARCHAR(50) y con el texto por defecto
ALTER TABLE Clientes ADD Estado VARCHAR(50) NOT NULL DEFAULT 'Abonado';
GO

SELECT DISTINCT Estado FROM Clientes;



-- DEL DOCUMENTO FALTANTES DE BD
--FrmPedidos
--1-  Agregar la columna DireccionEntrega en la tabla Pedidos (para guardar la dirección)

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND name = 'DireccionEntrega')
BEGIN
    ALTER TABLE Pedidos ADD DireccionEntrega VARCHAR(250) NULL;
END
GO

--2- Permitir que IdProveedor sea NULL temporalmente por si un pedido no especifica proveedor

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND name = 'IdProveedor')
BEGIN
    ALTER TABLE Pedidos ALTER COLUMN IdProveedor INT NULL;
END
GO

--3-  Crear la columna Subtotal en DetallePedido que se calcula automáticamente (Cantidad * PrecioCosto)

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[DetallePedido]') AND name = 'Subtotal')
BEGIN
    ALTER TABLE DetallePedido ADD Subtotal AS (Cantidad * PrecioCosto);
END
GO

--4- Agregar columnas de credenciales en la tabla Proveedores

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Proveedores]') AND name = 'UsuarioWeb')
BEGIN
    ALTER TABLE Proveedores ADD UsuarioWeb VARCHAR(100) NULL;
    ALTER TABLE Proveedores ADD PasswordWeb VARCHAR(100) NULL;
END
GO


--5- Cargar las credenciales de prueba para Droguería del Sud (o poner tus datos reales)

UPDATE Proveedores 
SET UsuarioWeb = 'usuario_ejemplo_farmacia', 
    PasswordWeb = 'clave123'
WHERE RazonSocial LIKE '%del Sud%';
GO

--6- Comprobación de que todo se aplicó correctamente
SELECT IdProveedor, RazonSocial, UsuarioWeb, PasswordWeb FROM Proveedores;
SELECT TOP 1 * FROM Pedidos;
SELECT TOP 1 * FROM DetallePedido;
GO

--7- Creación de la tabla EstadoCuenta:
CREATE TABLE EstadoCuenta (
    IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente),
    Fecha DATETIME DEFAULT GETDATE(),
    Concepto VARCHAR(250),
    Pendiente DECIMAL(18,2) DEFAULT 0.00,
    Abonado DECIMAL(18,2) DEFAULT 0.00
);

--Gráficos de FrmAyuda:
--8- Creación de la tabla Tickets: 
CREATE TABLE Tickets (
    IDTicket INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    TituloProblema VARCHAR(150) NOT NULL,
    Estado VARCHAR(50) DEFAULT 'Pendiente'
);

--9- Registros de Tickets:
INSERT INTO Tickets (TituloProblema, Estado) 
VALUES 
('Stock Incorrecto', 'Pendiente'),
('Error en Acceso', 'Resuelto'),
('Error en Cuenta Corriente', 'Pendiente'),
('Error en Visualizador de Ganancia', 'Resuelto');


--FrmPerfil:
--10- Agregar el campo foto en la base
ALTER TABLE Usuarios ADD foto VARBINARY(MAX) NULL;

--11- Campo activo en la tabla Usuarios
ALTER TABLE Usuarios ADD activo BIT NOT NULL DEFAULT 1;
GO

--12- - Actualizamos a tus usuarios actuales para que queden activos
UPDATE Usuarios SET activo = 1;
GO

--13- Tabla Mensajes sirve para almacenar y gestionar los avisos, alertas o notificaciones internas del soporte técnico dentro del sistema:
CREATE TABLE Mensajes (
    IdMensaje INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    Contenido VARCHAR(MAX),
    Leido BIT DEFAULT 0 -- 0 = No leído, 1 = Leído
);
GO






