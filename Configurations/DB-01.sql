USE master; 
GO 

-- Criando o banco de dados 
CREATE DATABASE [APIASPDOTNETMSSQLServerDB];
GO 

USE APIASPDOTNETMSSQLServerDB; 
GO 

-- 2. Criar as tabelas de dependencias 
CREATE TABLE ztACL ( 
    idACL INT IDENTITY(1,1) PRIMARY KEY, 
    tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Master, Admin, Cliente, Funcionario 
    descricao VARCHAR(100) NOT NULL 
); 


SELECT * FROM ztACL; 

-- # 2. Inserir dado na tabela ztACL 
INSERT INTO ztACL (tipo, descricao) 
    VALUES 
    ('Master', 'Acesso total ao sistema, especifica para o administrador do sistema.'); 
GO 

-- # 3. Inserir multiplos dados na tabela ztACL 
MERGE INTO ztACL AS Target 
    USING (
        VALUES 
        ('Administrador', 'Acesso administrativo, para suporte tecnico.'), 
        ('Funcionário', 'Acesso ao sistema para gestão.'), 
        ('Cliente', 'Acesso ao sistema para uso.') 
    ) AS Source (tipo, descricao) 
    ON Target.tipo = Source.tipo -- Verifica se o tipo já existe 
    -- Se o 'tipo' não existir, insere apenas tipo e descricao (id é automático) 
    WHEN NOT MATCHED BY TARGET THEN 
        INSERT (tipo, descricao) 
        VALUES 
        (Source.tipo, Source.descricao) 
    WHEN MATCHED THEN 
        UPDATE SET Target.descricao = Source.descricao; 
GO 

	



