-- 1. Criando o banco de dados
CREATE DATABASE [APIASPDOTNETMSSQLServerDB];
GO

-- 2. Usando o banco de dados
USE APIASPDOTNETMSSQLServerDB;
GO

-- 3. Criar a tabela ztACL
CREATE TABLE ztACL (
    idACL INT IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Master, Admin, Cliente, Funcionario
    descricao VARCHAR(100) NOT NULL
);

-- 4. Selecionando a tabela ztACL
SELECT * FROM ztACL;
