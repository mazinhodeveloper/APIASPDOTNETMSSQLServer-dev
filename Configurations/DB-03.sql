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
-- URL: http://localhost:8080/swagger
-- POST: /api/acl
{
  "tipo": "Desenvolvedor",
  "descricao": "Acesso de desenvolvimento, para suporte tecnico."
}

-- # 4. Inserir multiplos dados na tabela ztACL
-- URL: http://localhost:8080/swagger
-- POST: /api/acl
{
  "tipo": "Convidado",
  "descricao": "Acesso ao sistema para uso."
}


-- 5. Selecionando a tabela ztACL
SELECT * FROM ztACL;
