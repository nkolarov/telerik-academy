CREATE DATABASE  IF NOT EXISTS `chainofmarkets` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `chainofmarkets`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win64 (x86_64)
--
-- Host: localhost    Database: chainofmarkets
-- ------------------------------------------------------
-- Server version	5.6.12

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
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `VendorID` int(11) NOT NULL,
  `ProductName` varchar(45) NOT NULL,
  `MeasureID` int(11) NOT NULL,
  `BasePrice` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `ID_idx` (`VendorID`),
  KEY `MeasureID_idx` (`MeasureID`),
  CONSTRAINT `ID` FOREIGN KEY (`VendorID`) REFERENCES `vendors` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `MeasureID` FOREIGN KEY (`MeasureID`) REFERENCES `measures` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,1,'Beer\"Zagorka\"',1,1.20),(2,1,'Beer “Beck’s”',1,1.30),(3,4,'Vodka “Targovishte”',1,1.10),(4,2,'Chocolate “Milka”',3,1.80),(5,13,'Chocolate “Nuttela”',3,4.60),(6,9,'Sushard Figaro',5,3.80),(7,20,'Kashkaval Elena',3,5.00),(8,3,'Rakia Karnobat',1,11.60),(9,6,'Peanuts FF',3,1.00),(10,7,'Yougurt',3,1.00),(11,8,'Soup Maggi',4,1.00),(12,8,'Broth Maggi',4,0.30),(13,10,'Eclairs',2,1.45),(14,10,'Plaisirs',2,1.80),(15,10,'Waffles',2,2.20),(16,11,'Patties',2,1.70),(17,12,'Chicken',3,6.30),(18,18,'Olio',1,3.00),(19,19,'Caberne Sauvignon',1,12.00),(20,19,'Merlot',1,12.00),(21,12,'Chips',3,3.00),(22,12,'Croissant',3,1.10),(23,2,'Crunch',3,1.20),(24,2,'ButtterFinger',3,1.40),(25,2,'PowerBar',3,1.50),(26,2,'Chocolata Chip',3,0.80),(27,3,'Rakia Karnobat',1,6.90),(28,3,'Menta Karnobat',1,5.40),(29,3,'Brendy',1,11.90),(30,3,'Wine Romantsa',1,22.30),(31,7,'Kashkaval',3,4.60),(32,7,'Cheese',3,5.20),(33,11,'Milinki',2,0.30),(34,11,'Beagle',2,0.85),(35,14,'Minereal Water',1,0.75),(36,14,'Spring Water',1,0.75),(37,18,'Margarine',3,1.25),(38,20,'Cheese',3,4.60),(39,1,'Beer\"Kamenitza\"',1,0.90),(40,1,'Beer\"Ariana\"',1,0.85);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-22 16:30:26
