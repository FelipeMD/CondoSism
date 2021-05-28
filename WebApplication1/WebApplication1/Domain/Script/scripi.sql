CREATE TABLE IF NOT EXISTS `morador` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `sobrenome` varchar(300) NOT NULL,
  `nascimento` datetime NOT NULL,
  `telefone` varchar(6) NOT NULL,
  `cpf` varchar(80) NOT NULL,
  `email` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) 