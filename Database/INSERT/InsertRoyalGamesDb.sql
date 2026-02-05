INSERT INTO Usuario (Nome, Email, Senha, StatusUsuario)
VALUES
('Joca Souza', 'jocasouza@email.com', HASHBYTES('SHA-512', 'joca123'), 1)
GO

INSERT INTO ClassificacaoIndicativa (ClassificacaoNome)
VALUES
('Livre'),
('10'),
('12'),
('14'),
('16'),
('+18')
GO

INSERT INTO Jogo (Nome, ClassificacaoId, Descricao, Descricao, Imagem, Valor, StatusJogo)
VALUES
(1, 'Minecraft', 'jogo mundo aberto', CONVERT(varbinary(max), 'foto mine'), 19.00, 1),
(4, 'Mario', 'jogo de aventura muito famoso', CONVERT(varbinary(max), 'foto mario'), 10.00, 1)
GO

INSERT INTO Promocao (Nome, DataExpiracao, StatusPromocao)
VALUES
('Promo de carnaval', 08-02-2026, 1),
('Promo de volta as aulas', 08-02-2026, 1)
GO

INSERT INTO JogoPromocao (JogoId, PromocaoId, Valor)
VALUES
(1, 2, 16.99),
(2, 1, 7.99)
GO

INSERT INTO Plataforma (Nome)
VALUES
('Playstation'),
('Xbox'),
('Desktop'),
('Mobile'),
('Nintendo')
GO

INSERT INTO JogoPlataforma (JogoId, PlataformaId)
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5)
GO

INSERT INTO Genero (Nome)
VALUES
('Terror'),
('Suspense'),
('Aventura'),
('Ação'),
('RPG'),
('FPS'),
('Luta'),
('Sandbox'),
('Soulslike'),
('Plataforma')
GO

INSERT INTO JogoGenero (JogoId, GeneroId)
VALUES
(1, 3),
(1, 4),
(1, 8),
(2, 10)
GO
