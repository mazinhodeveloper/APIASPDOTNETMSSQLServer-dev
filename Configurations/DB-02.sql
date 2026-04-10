-- 1. Usando o banco de dados
USE APIASPDOTNETMSSQLServerDB;
GO

-- 2. Selecionando a tabela ztACL
SELECT * FROM ztACL;

-- # 3. Inserir dado na tabela ztACL
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

-- 4. Selecionando a tabela ztACL
SELECT * FROM ztACL;
