USE M_Ekips;
INSERT INTO Permissoes(Descricao)
	VALUES('ADMINISTRADOR'),('COMUM');
INSERT INTO Cargos(Nome,Atividade)
	VALUES('Designer','ATIVO'),
	('Desenvolvedor','ATIVO'),
	('Gerente','ATIVO');
INSERT INTO Departamentos(Nome)
	VALUES('Desenvolvimento'),
	('Administração');
INSERT INTO Usuarios(Email,Senha,IdPermissao)
	VALUES('admin@email.com','123456',1),
	('comum1@email.com','123456',2),
	('comum2@email.com','123456',2);
INSERT INTO Funcionarios(Nome,Cpf,DataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario)
	VALUES('Matheus Amaral','048.179.140-09','16/04/2002',2500.00,1,1,1);
INSERT INTO Funcionarios(Nome,Cpf,DataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario)
	VALUES('Daniel Felipe','535.906.880-92','13/01/2003',5000.00,2,3,2);
