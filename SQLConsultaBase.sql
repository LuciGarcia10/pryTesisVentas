-- Eliminar columna Estado de Categorias
DECLARE @ConstraintCategorias nvarchar(200);
SELECT @ConstraintCategorias = dc.name
FROM sys.default_constraints dc
JOIN sys.columns c ON dc.parent_object_id = c.object_id AND dc.parent_column_id = c.column_id
WHERE dc.parent_object_id = OBJECT_ID('Categorias') AND c.name = 'Estado';

IF @ConstraintCategorias IS NOT NULL
    EXEC('ALTER TABLE Categorias DROP CONSTRAINT ' + @ConstraintCategorias);

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Categorias') AND name = 'Estado')
    ALTER TABLE Categorias DROP COLUMN Estado;
GO

-- Renombrar Tickets a Soporte y sus columnas
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Tickets') AND name = 'IDTicket')
    EXEC sp_rename 'Tickets.IDTicket', 'IdActualizacion', 'COLUMN';

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Tickets') AND name = 'TituloProblema')
    EXEC sp_rename 'Tickets.TituloProblema', 'Problema', 'COLUMN';

IF OBJECT_ID('Tickets', 'U') IS NOT NULL
    EXEC sp_rename 'Tickets', 'Soporte';
GO

-- Eliminar relación y tabla Vendedor
DECLARE @ConstraintVendedor nvarchar(200);
SELECT @ConstraintVendedor = fk.name
FROM sys.foreign_keys fk
JOIN sys.tables t ON fk.referenced_object_id = t.object_id
WHERE t.name = 'Vendedor' AND OBJECT_NAME(fk.parent_object_id) = 'Usuarios';

IF @ConstraintVendedor IS NOT NULL
    EXEC('ALTER TABLE Usuarios DROP CONSTRAINT ' + @ConstraintVendedor);

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Usuarios') AND name = 'IdVendedor')
    ALTER TABLE Usuarios DROP COLUMN IdVendedor;

IF OBJECT_ID('Vendedor', 'U') IS NOT NULL
    DROP TABLE Vendedor;
GO

-- Eliminar columna Estado de Productos
DECLARE @ConstraintProductos nvarchar(200);
SELECT @ConstraintProductos = dc.name
FROM sys.default_constraints dc
JOIN sys.columns c ON dc.parent_object_id = c.object_id AND dc.parent_column_id = c.column_id
WHERE dc.parent_object_id = OBJECT_ID('Productos') AND c.name = 'Estado';

IF @ConstraintProductos IS NOT NULL
    EXEC('ALTER TABLE Productos DROP CONSTRAINT ' + @ConstraintProductos);

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Productos') AND name = 'Estado')
    ALTER TABLE Productos DROP COLUMN Estado;
GO

-- Renombrar columna en Pedidos
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Pedidos') AND name = 'FechaEntrega')
    EXEC sp_rename 'Pedidos.FechaEntrega', 'FechaRecibido', 'COLUMN';
GO

-- Eliminar tabla Mensajes si existe
DECLARE @ConstraintMensajes nvarchar(200);
DECLARE @TableName nvarchar(200);
DECLARE @Sql NVARCHAR(MAX);

SELECT 
    @ConstraintMensajes = fk.name,
    @TableName = OBJECT_NAME(fk.parent_object_id)
FROM sys.foreign_keys fk
JOIN sys.tables t ON fk.referenced_object_id = t.object_id
WHERE t.name = 'Mensajes';

IF @ConstraintMensajes IS NOT NULL
BEGIN
    SET @Sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' DROP CONSTRAINT ' + QUOTENAME(@ConstraintMensajes);
    EXEC sp_executesql @Sql;
END;

IF OBJECT_ID('Mensajes', 'U') IS NOT NULL
    DROP TABLE Mensajes;
GO

-- Añadir Estado a la tabla Mensaje (si existe la tabla Mensaje)
IF OBJECT_ID('Mensaje', 'U') IS NOT NULL AND NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Mensaje') AND name = 'Estado')
BEGIN
    ALTER TABLE Mensaje ADD Estado VARCHAR(50) NULL;
END
GO

-- Clave foránea entre Usuarios y Roles
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Usuarios_Roles')
BEGIN
    ALTER TABLE Usuarios DROP CONSTRAINT FK_Usuarios_Roles;
END;

ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_Roles 
FOREIGN KEY (id_rol) REFERENCES Roles(id_rol);
GO