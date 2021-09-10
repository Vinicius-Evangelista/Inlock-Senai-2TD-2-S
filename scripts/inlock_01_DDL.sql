CREATE DATABASE inlock_games_tarde;
GO

--DDL

USE inlock_games_tarde;
GO

CREATE TABLE estudio(
	idEstudio SMALLINT PRIMARY KEY IDENTITY(1,1),
	nomeEstudio VARCHAR(100) UNIQUE NOT NULL 
);
GO


CREATE TABLE jogo(
	idJogo INT PRIMARY KEY IDENTITY(1,1),
	idEstudio SMALLINT FOREIGN KEY REFERENCES estudio(idEstudio),
	nomeJogo VARCHAR(100) UNIQUE NOT NULL,
	dataLancamento DATE NOT NULL,
	descricao VARCHAR(250),
	valor MONEY NOT NULL
);
GO


CREATE TABLE tipoUsuario(
	idTipoUsuario TINYINT PRIMARY KEY IDENTITY(1,1),
	titulo VARCHAR(75) UNIQUE NOT NULL
);
GO


CREATE TABLE usuario(
	idUsuario INT PRIMARY KEY IDENTITY(1,1),
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	email VARCHAR(256) UNIQUE NOT NULL,
	senha VARCHAR(12) NOT NULL CHECK(len(senha) >=8	) 
);
GO