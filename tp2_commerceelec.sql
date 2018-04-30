-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  lun. 30 avr. 2018 à 02:49
-- Version du serveur :  5.7.19-log
-- Version de PHP :  5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `tp2_commerceelec`
--

-- --------------------------------------------------------

--
-- Structure de la table `participant`
--

DROP TABLE IF EXISTS `participant`;
CREATE TABLE IF NOT EXISTS `participant` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `participant`
--

INSERT INTO `participant` (`id`, `nom`, `prenom`) VALUES
(1, 'Bossé', 'Émile'),
(2, 'Biras', 'Jean');

-- --------------------------------------------------------

--
-- Structure de la table `participertournoi`
--

DROP TABLE IF EXISTS `participertournoi`;
CREATE TABLE IF NOT EXISTS `participertournoi` (
  `idParticipant` int(11) NOT NULL,
  `idTournoi` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  PRIMARY KEY (`idParticipant`,`idTournoi`),
  KEY `idTournoi` (`idTournoi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `participertournoi`
--

INSERT INTO `participertournoi` (`idParticipant`, `idTournoi`, `numero`) VALUES
(2, 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `tournoi`
--

DROP TABLE IF EXISTS `tournoi`;
CREATE TABLE IF NOT EXISTS `tournoi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `idType` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idType` (`idType`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tournoi`
--

INSERT INTO `tournoi` (`id`, `nom`, `idType`) VALUES
(1, 'TestRobin', 1),
(2, 'TestSimple', 2);

-- --------------------------------------------------------

--
-- Structure de la table `typetournoi`
--

DROP TABLE IF EXISTS `typetournoi`;
CREATE TABLE IF NOT EXISTS `typetournoi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typetournoi`
--

INSERT INTO `typetournoi` (`id`, `nom`) VALUES
(1, 'Round Robin'),
(2, 'Simple Elimination');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `participertournoi`
--
ALTER TABLE `participertournoi`
  ADD CONSTRAINT `participertournoi_ibfk_1` FOREIGN KEY (`idParticipant`) REFERENCES `participant` (`id`),
  ADD CONSTRAINT `participertournoi_ibfk_2` FOREIGN KEY (`idTournoi`) REFERENCES `tournoi` (`id`);

--
-- Contraintes pour la table `tournoi`
--
ALTER TABLE `tournoi`
  ADD CONSTRAINT `tournoi_ibfk_1` FOREIGN KEY (`idType`) REFERENCES `typetournoi` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
