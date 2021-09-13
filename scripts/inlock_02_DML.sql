--DML
USE inlock_games_tarde;
GO

INSERT INTO tipoUsuario (titulo)
VALUES ('ADM'),('CLIENTE');
GO

INSERT INTO usuario (idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'adm12345'),(2, 'cliente@cliente.com', 'cliente123');
GO

INSERT INTO estudio (nomeEstudio)
VALUES ('Blizard'),('Rockstar Studios'),('Square Enix');
GO

INSERT INTO jogo (idEstudio, nomeJogo, dataLancamento, descricao, valor)
VALUES 
        (1,'Diablo 3', '15/05/2012', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '$99.00'),
        (2,'Red Dead Redeption II', '26/08/2018', 'jogo eletrônico de ação-aventura western.','$120.00');
GO

DELETE FROM JOGO;