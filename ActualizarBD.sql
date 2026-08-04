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