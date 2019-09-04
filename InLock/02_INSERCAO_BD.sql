USE M_Inlock;

INSERT INTO Usuarios(Email, Senha, Permissao)
	VALUES	('admin@admin', 'admin',1),
			('cliente@cliente', 'cliente',0);


INSERT INTO Estudios(Nome, PaisOrigem, IdUsuario,DataCriacao)
		VALUES	('Blizzard','USA',2,GETDATE()),
				('Rockstar Studios','USA',2,GETDATE()),
				('Square Enix','Japão',2,GETDATE());

INSERT INTO Jogos(Nome, DataLancamento, Valor, IdEstudio, Descricao)
		VALUES ('Diablo 3', '2012-05-15',99.00,2,'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.'),
				('Red Dead Redemption II', '2018-10-26',120.00,3,'jogo eletrônico de ação-aventura western');