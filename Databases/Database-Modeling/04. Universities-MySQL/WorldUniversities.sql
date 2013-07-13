CREATE DATABASE  IF NOT EXISTS `worlduniversities` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `worlduniversities`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win32 (x86)
--
-- Host: localhost    Database: worlduniversities
-- ------------------------------------------------------
-- Server version	5.6.12-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Departments_id` int(11) NOT NULL,
  `Professors_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Courses_Departments1_idx` (`Departments_id`),
  KEY `fk_Courses_Professors1_idx` (`Professors_id`),
  CONSTRAINT `fk_Courses_Departments1` FOREIGN KEY (`Departments_id`) REFERENCES `departments` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Professors1` FOREIGN KEY (`Professors_id`) REFERENCES `professors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (1,'HTML Bascis',1,1),(2,'CSS Basics',1,2),(3,'Algebra',2,1);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Faculties_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Departments_Faculties_idx` (`Faculties_id`),
  CONSTRAINT `fk_Departments_Faculties` FOREIGN KEY (`Faculties_id`) REFERENCES `faculties` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'IT',1),(2,'Math',2);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` VALUES (1,'FMI'),(2,'FEA');
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Departments_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Professors_Departments1_idx` (`Departments_id`),
  CONSTRAINT `fk_Professors_Departments1` FOREIGN KEY (`Departments_id`) REFERENCES `departments` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
INSERT INTO `professors` VALUES (1,'Pesho','Peshov',1),(2,'Gosho','Goshov',2),(3,'Ivan','Ivanov',1);
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors_titles`
--

DROP TABLE IF EXISTS `professors_titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors_titles` (
  `Professors_id` int(11) NOT NULL,
  `Titles_id` int(11) NOT NULL,
  PRIMARY KEY (`Professors_id`,`Titles_id`),
  KEY `fk_Professors_Titles_Professors1_idx` (`Professors_id`),
  KEY `fk_Professors_Titles_Titles1_idx` (`Titles_id`),
  CONSTRAINT `fk_Professors_Titles_Professors1` FOREIGN KEY (`Professors_id`) REFERENCES `professors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_Titles_Titles1` FOREIGN KEY (`Titles_id`) REFERENCES `titles` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors_titles`
--

LOCK TABLES `professors_titles` WRITE;
/*!40000 ALTER TABLE `professors_titles` DISABLE KEYS */;
INSERT INTO `professors_titles` VALUES (1,1),(1,2),(1,3),(2,1),(2,2),(3,1);
/*!40000 ALTER TABLE `professors_titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `FacultyNumber` int(11) NOT NULL,
  `Faculties_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Students_Faculties1_idx` (`Faculties_id`),
  CONSTRAINT `fk_Students_Faculties1` FOREIGN KEY (`Faculties_id`) REFERENCES `faculties` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Miro','Mirov',1234,1),(2,'Koko','Kokov',234,2),(3,'Peshko','Troshkata',222,1);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students_courses`
--

DROP TABLE IF EXISTS `students_courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students_courses` (
  `Students_id` int(11) NOT NULL,
  `Courses_id` int(11) NOT NULL,
  PRIMARY KEY (`Students_id`,`Courses_id`),
  KEY `fk_Students_Courses_Students1_idx` (`Students_id`),
  KEY `fk_Students_Courses_Courses1_idx` (`Courses_id`),
  CONSTRAINT `fk_Students_Courses_Students1` FOREIGN KEY (`Students_id`) REFERENCES `students` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_Courses_Courses1` FOREIGN KEY (`Courses_id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students_courses`
--

LOCK TABLES `students_courses` WRITE;
/*!40000 ALTER TABLE `students_courses` DISABLE KEYS */;
INSERT INTO `students_courses` VALUES (1,1),(1,2),(1,3),(2,1),(2,2),(3,1);
/*!40000 ALTER TABLE `students_courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,'Ph. D'),(2,'Academician'),(3,'Senior Assistant');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'worlduniversities'
--

--
-- Dumping routines for database 'worlduniversities'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-11 22:39:51
