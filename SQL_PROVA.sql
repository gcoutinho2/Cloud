CREATE TABLE tbProva (
	IdProva INT IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(80) NOT NULL,
	DataAplicacao DATETIME NOT NULL,

	CONSTRAINT PK_Prova_Id PRIMARY KEY CLUSTERED (IdProva ASC)
);

CREATE TABLE tbProvaQuestao(
	IdProvaQuestao INT IDENTITY(1,1) NOT NULL,
	Valor FLOAT NOT NULL,
	IdProva INT,
	IdQuestao INT,
	
	CONSTRAINT PK_ProvaQuestao_IdProvaQuestao PRIMARY KEY CLUSTERED (IdProvaQuestao ASC),
	CONSTRAINT FK_ProvaQuestao_Prova FOREIGN KEY (IdProva) REFERENCES tbProva(IdProva),
	CONSTRAINT FK_ProvaQuestao_Questao FOREIGN KEY (IdQuestao) REFERENCES tbQuestao(IdQuestao)
);


CREATE TABLE tbQuestao (
	IdQuestao INT IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(80) NOT NULL,
	Enunciado NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_Questao_Id PRIMARY KEY CLUSTERED (IdQuestao ASC)
);


CREATE TABLE tbAlunoProvaQuestao(
	IdAlunoProvaQuestao INT IDENTITY(1,1) NOT NULL,
	Resposta NVARCHAR(100) NOT NULL,
	Nota FLOAT NOT NULL,
	IdProvaQuestao INT,
	IdAluno INT,

	CONSTRAINT PK_AlunoProvaQuestao_IdAlunoProvaQuestao PRIMARY KEY CLUSTERED (IdAlunoProvaQuestao ASC),
	CONSTRAINT FK_AlunoProvaQuestao FOREIGN KEY (IdProvaQuestao) REFERENCES tbProvaQuestao(IdProvaQuestao),
	CONSTRAINT FK_AlunoProvaQuestao_IdAluno FOREIGN KEY (IdAluno) REFERENCES tbAluno(IdAluno)
);

CREATE TABLE tbAluno(
	IdAluno INT IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(80) NOT NULL,
	Email NVARCHAR(80) NOT NULL,
	RA NVARCHAR(80) NOT NULL,

	CONSTRAINT PK_Prova_IdAluno PRIMARY KEY CLUSTERED (IdAluno ASC)
);

select * from tbProvaQuestao;
SELECT * FROM tbProva;
SELECT * FROM tbQuestao;
SELECT * FROM tbProvaQuestao;

-- DELETANDO CONSTRAINT
ALTER TABLE tbProva DROP CONSTRAINT PK_Prova_Id;
ALTER TABLE tbProvaQuestao DROP CONSTRAINT PK_ProvaQuestao_IdProvaQuestao;
ALTER TABLE tbProvaQuestao DROP CONSTRAINT FK_ProvaQuestao_Prova;
ALTER TABLE tbProvaQuestao DROP CONSTRAINT FK_ProvaQuestao_Questao;
ALTER TABLE tbQuestao DROP CONSTRAINT PK_Questao_Id;
ALTER TABLE tbAlunoProvaQuestao DROP CONSTRAINT PK_AlunoProvaQuestao_IdAlunoProvaQuestao;
ALTER TABLE tbAlunoProvaQuestao DROP CONSTRAINT FK_AlunoProvaQuestao;
ALTER TABLE tbAlunoProvaQuestao DROP CONSTRAINT FK_AlunoProvaQuestao_IdAluno;
ALTER TABLE tbAluno DROP CONSTRAINT PK_Prova_IdAluno;

-- DELETANDO TABLES
drop table tbProva;
drop table tbProvaQuestao;
drop table tbQuestao;
drop table tbAlunoProvaQuestao;
drop table tbAluno;

INSERT INTO tbQuestao (Nome,Enunciado) VALUES ('Questão Logica','blablbalbalblablbalabablabllba');
INSERT INTO tbProvaQuestao (Valor,IdProva,IdQuestao) VALUES (8,1,101);
