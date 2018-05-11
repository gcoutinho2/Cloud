CREATE TABLE tbProva (
	IdProva INT IDENTITY(1,100) NOT NULL,
	Nome NVARCHAR(80) NOT NULL,
	DataAplicacao DATETIME NOT NULL,

	CONSTRAINT PK_Prova_Id PRIMARY KEY CLUSTERED (IdProva ASC)
);

CREATE TABLE tbProvaQuestao(
	IdProvaQuestao INT IDENTITY(1,100) NOT NULL,
	Valor FLOAT NOT NULL,
	IdProva INT,
	IdQuestao INT,
	
	CONSTRAINT PK_ProvaQuestao_IdProvaQuestao PRIMARY KEY CLUSTERED (IdProvaQuestao ASC),
	CONSTRAINT FK_ProvaQuestao_Prova FOREIGN KEY (IdProva) REFERENCES tbProva(IdProva),
	CONSTRAINT FK_ProvaQuestao_Questao FOREIGN KEY (IdQuestao) REFERENCES tbQuestao(IdQuestao)
);


CREATE TABLE tbQuestao (
	IdQuestao INT IDENTITY(1,100) NOT NULL,
	Nome NVARCHAR(80) NOT NULL,
	Enunciado NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_Questao_Id PRIMARY KEY CLUSTERED (IdQuestao ASC)
);


CREATE TABLE tbAlunoProvaQuestao(
	IdAlunoProvaQuestao INT IDENTITY(1,100) NOT NULL,
	Resposta NVARCHAR(100) NOT NULL,
	Nota FLOAT NOT NULL,
	IdProvaQuestao INT,
	IdAluno INT,

	CONSTRAINT PK_AlunoProvaQuestao_IdAlunoProvaQuestao PRIMARY KEY CLUSTERED (IdAlunoProvaQuestao ASC),
	CONSTRAINT FK_AlunoProvaQuestao FOREIGN KEY (IdProvaQuestao) REFERENCES tbProvaQuestao(IdProvaQuestao),
	CONSTRAINT FK_AlunoProvaQuestao_IdAluno FOREIGN KEY (IdAluno) REFERENCES tbAluno(IdAluno)
);

CREATE TABLE tbAluno(
	IdAluno INT IDENTITY(1,100) NOT NULL,
	Nome NVARCHAR(80) NOT NULL,
	Email NVARCHAR(80) NOT NULL,
	RA NVARCHAR(80) NOT NULL,

	CONSTRAINT PK_Prova_IdAluno PRIMARY KEY CLUSTERED (IdAluno ASC)
);

select * from tbProvaQuestao;
