USE M_Inlock;

INSERT INTO Usuarios(Email, Senha, Permissao)
	VALUES	('admin@admin', 'admin',1),
			('cliente@cliente', 'cliente',0);


INSERT INTO Estudios(Nome, PaisOrigem, IdUsuario,DataCriacao)
		VALUES	('Blizzard','USA',2,GETDATE()),
				('Rockstar Studios','USA',2,GETDATE()),
				('Square Enix','Jap�o',2,GETDATE());

INSERT INTO Jogos(Nome, DataLancamento, Valor, IdEstudio, Descricao)
		VALUES ('Diablo 3', '2012-05-15',99.00,2,'� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.'),
				('Red Dead Redemption II', '2018-10-26',120.00,3,'jogo eletr�nico de a��o-aventura western');