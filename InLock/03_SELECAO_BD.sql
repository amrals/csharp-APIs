USE M_InLock;
SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;
SELECT Jogos.*, Estudios.*
FROM Jogos
JOIN Estudios
	ON Jogos.IdEstudio = Estudios.IdEstudio;

SELECT Jogos.*, Estudios.*
FROM Jogos
FULL JOIN Estudios
	ON Jogos.IdEstudio = Estudios.IdEstudio;
go
SELECT * FROM Usuarios WHERE Email = 'admin@admin' AND Senha = 'admin';
SELECT * FROM Jogos WHERE IdJogo = 2;
SELECT * FROM Estudios WHERE IdEstudio = 2;