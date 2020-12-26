USE BD_DEMO;

DROP PROCEDURE SP_GET_CLIENTES;
DROP PROCEDURE SP_SET_CLIENTES;
DROP PROCEDURE SP_DEL_CLIENTES;

GO
-- COMANDO SELECT
CREATE PROCEDURE SP_GET_CLIENTES ( @ID INT = NULL ) AS
BEGIN
    IF @ID IS NULL
    BEGIN
        -- CMD LISTA DA TABELA
        SELECT * FROM TB_CLIENTES
    END
    ELSE 
    BEGIN
        -- CMD ITEM DA TABELA
        SELECT * FROM TB_CLIENTES WHERE IdClientes = @ID
    END
END
GO
-- COMANDO INSERT E UPDATE
CREATE PROCEDURE SP_SET_CLIENTES ( 
		 @ID INT = NULL 
		,@Nome VARCHAR(50) = NULL
		,@SobreNome VARCHAR(150) = NULL
		,@CPF VARCHAR(50) = NULL
		,@CEP VARCHAR(15) = NULL
		,@Endereco VARCHAR(250) = NULL
		,@Num INT = NULL
		,@Complemento VARCHAR(25) = NULL
		,@Bairro VARCHAR(250) = NULL
		,@Telefone1 VARCHAR(15) = NULL
		,@Telefone2 VARCHAR(15) = NULL
		,@Email VARCHAR(250) = NULL
		,@Excluido BIT = 0
) AS 
BEGIN
    IF @ID IS NULL
    BEGIN 
        -- CMD ADD NOVO ITEM NA TABELA
        INSERT INTO TB_CLIENTES( 
			Nome, SobreNome, CPF, CEP, Endereco, Num, Complemento, Bairro, Telefone1, Telefone2, Email) 
			VALUES( @Nome, @SobreNome, @CPF, @CEP, @Endereco, @Num, @Complemento, @Bairro, @Telefone1, @Telefone2, @Email)
			SET @Id = @@IDENTITY
    END		
    ELSE 
    BEGIN
        -- CMD ALTERA NOVO ITEM NA TABELA
        UPDATE TB_CLIENTES SET 
			Nome = @Nome
			,SobreNome = @SobreNome
			,CPF = @CPF
			,CEP = @CEP
			,Endereco = @Endereco
			,Num = @Num
			,Complemento = @Complemento
			,Bairro = @Bairro
			,Telefone1 = @Telefone1
			,Telefone2 = @Telefone2
			,Email = @Email
			,DataAlteracao = CONVERT(datetime, SYSDATETIMEOFFSET() AT TIME ZONE 'E. South America Standard Time') 
        -- DADOS
        WHERE IdClientes = @ID
    END
    SELECT @Id
END
GO
-- COMANDO DELETE
CREATE PROCEDURE SP_DEL_CLIENTES ( @ID INT ) AS 
BEGIN
    -- CMD DELETA ITEM DA TABELA
    DELETE FROM TB_CLIENTES WHERE IdClientes = @ID
	SELECT @Id
END
GO

-- TESTE - INSERT E UPDATE
EXEC SP_SET_CLIENTES NULL, 'Celso', 'de Almeida Leite Filho', '37975642878', '02210070', 'R. Marisa de Sousa', 148, 'Casa A', 'JD. Brasil', '(11)2201-3249'
	, '(11)99787-0299', 'celso.almeida.leite@hotmail.com', 0;
--TESTE - DELETE
EXEC SP_DEL_CLIENTES 1005;
-- TESTE - SELET E SELECT BY ID
EXEC SP_GET_CLIENTES;