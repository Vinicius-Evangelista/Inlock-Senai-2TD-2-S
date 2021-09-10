USE inlock_games_tarde;
GO

--DQL

SELECT * FROM usuario;
SELECT * FROM estudio;
SELECT * FROM jogo;

SELECT idJogo, nomeJogo, dataLancamento, descricao, valor, nomeEstudio FROM jogo
INNER JOIN estudio ON jogo.idEstudio = estudio.idEstudio;

SELECT estudio.idEstudio, nomeEstudio, idJogo, nomeJogo, dataLancamento, descricao, valor FROM estudio
LEFT JOIN jogo ON estudio.idEstudio = jogo.idEstudio;

SELECT * FROM usuario
WHERE email = 'cliente@cliente.com' AND senha = 'cliente123';

SELECT * FROM jogo
WHERE idJogo = 1;

SELECT * FROM estudio
WHERE idEstudio = 1;

--TRUNCATE TABLE jogo;