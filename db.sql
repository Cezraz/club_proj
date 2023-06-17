CREATE DATABASE  IF NOT EXISTS `club` /*!40100 DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `club`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: club
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `phone` varchar(15) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `phone_UNIQUE` (`phone`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (3,'123','123'),(4,'123123','123123'),(6,'1231234','1231234');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientorder`
--

DROP TABLE IF EXISTS `clientorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientorder` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date` datetime DEFAULT NULL,
  `starttime` varchar(45) DEFAULT NULL,
  `endtime` varchar(45) DEFAULT NULL,
  `idClient` int DEFAULT NULL,
  `pcRange` varchar(45) DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  `selected` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_clientorder_client1_idx` (`idClient`),
  CONSTRAINT `fk_clientorder_client1` FOREIGN KEY (`idClient`) REFERENCES `client` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientorder`
--

LOCK TABLES `clientorder` WRITE;
/*!40000 ALTER TABLE `clientorder` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cluborder`
--

DROP TABLE IF EXISTS `cluborder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cluborder` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date` datetime DEFAULT NULL,
  `starttime` varchar(45) DEFAULT NULL,
  `endtime` varchar(45) DEFAULT NULL,
  `pcRange` varchar(45) DEFAULT NULL,
  `pcCount` int DEFAULT NULL,
  `timeCount` int DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  `idclient` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cluborder_client1_idx` (`idclient`),
  CONSTRAINT `fk_cluborder_client1` FOREIGN KEY (`idclient`) REFERENCES `client` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cluborder`
--

LOCK TABLES `cluborder` WRITE;
/*!40000 ALTER TABLE `cluborder` DISABLE KEYS */;
INSERT INTO `cluborder` VALUES (16,'2023-06-17 00:00:00','12:00','17:00','pc1-pc2',2,5,NULL,3),(17,'2023-06-17 00:00:00','12:00','16:00','pc3-pc5',3,4,NULL,3);
/*!40000 ALTER TABLE `cluborder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `foodorder`
--

DROP TABLE IF EXISTS `foodorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `foodorder` (
  `id` int NOT NULL AUTO_INCREMENT,
  `total` varchar(45) DEFAULT NULL,
  `customer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `foodorder`
--

LOCK TABLES `foodorder` WRITE;
/*!40000 ALTER TABLE `foodorder` DISABLE KEYS */;
INSERT INTO `foodorder` VALUES (1,'1050','2');
/*!40000 ALTER TABLE `foodorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `presto`
--

DROP TABLE IF EXISTS `presto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `presto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `foodname` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  `idOrder` int NOT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_presto_foodorder1_idx` (`idOrder`),
  CONSTRAINT `fk_presto_foodorder1` FOREIGN KEY (`idOrder`) REFERENCES `foodorder` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `presto`
--

LOCK TABLES `presto` WRITE;
/*!40000 ALTER TABLE `presto` DISABLE KEYS */;
/*!40000 ALTER TABLE `presto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `caption` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'admin'),(2,'user');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subway`
--

DROP TABLE IF EXISTS `subway`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subway` (
  `id` int NOT NULL AUTO_INCREMENT,
  `foodname` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  `idOrder` int NOT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_subway_foodorder1_idx` (`idOrder`),
  CONSTRAINT `fk_subway_foodorder1` FOREIGN KEY (`idOrder`) REFERENCES `foodorder` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subway`
--

LOCK TABLES `subway` WRITE;
/*!40000 ALTER TABLE `subway` DISABLE KEYS */;
/*!40000 ALTER TABLE `subway` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `todayorders`
--

DROP TABLE IF EXISTS `todayorders`;
/*!50001 DROP VIEW IF EXISTS `todayorders`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `todayorders` AS SELECT 
 1 AS `id`,
 1 AS `date`,
 1 AS `starttime`,
 1 AS `endtime`,
 1 AS `pcRange`,
 1 AS `pcCount`,
 1 AS `timeCount`,
 1 AS `comment`,
 1 AS `idclient`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(45) DEFAULT NULL,
  `pass` varchar(45) DEFAULT NULL,
  `role_idrole` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_user_role1_idx` (`role_idrole`),
  CONSTRAINT `fk_user_role1` FOREIGN KEY (`role_idrole`) REFERENCES `role` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'1','1',1),(2,'2','2',2);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `verona`
--

DROP TABLE IF EXISTS `verona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `verona` (
  `id` int NOT NULL AUTO_INCREMENT,
  `foodname` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  `idOrder` int NOT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_verona_foodorder1_idx` (`idOrder`),
  CONSTRAINT `fk_verona_foodorder1` FOREIGN KEY (`idOrder`) REFERENCES `foodorder` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `verona`
--

LOCK TABLES `verona` WRITE;
/*!40000 ALTER TABLE `verona` DISABLE KEYS */;
/*!40000 ALTER TABLE `verona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `view_cluborder`
--

DROP TABLE IF EXISTS `view_cluborder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `view_cluborder` (
  `id` int DEFAULT NULL,
  `date` int DEFAULT NULL,
  `starttime` int DEFAULT NULL,
  `endtime` int DEFAULT NULL,
  `pcRange` int DEFAULT NULL,
  `pcCount` int DEFAULT NULL,
  `timeCount` int DEFAULT NULL,
  `comment` int DEFAULT NULL,
  `idprice` int DEFAULT NULL,
  `idclient` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `view_cluborder`
--

LOCK TABLES `view_cluborder` WRITE;
/*!40000 ALTER TABLE `view_cluborder` DISABLE KEYS */;
/*!40000 ALTER TABLE `view_cluborder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yakida`
--

DROP TABLE IF EXISTS `yakida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yakida` (
  `id` int NOT NULL AUTO_INCREMENT,
  `foodname` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  `idOrder` int NOT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_yakida_foodorder1_idx` (`idOrder`),
  CONSTRAINT `fk_yakida_foodorder1` FOREIGN KEY (`idOrder`) REFERENCES `foodorder` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yakida`
--

LOCK TABLES `yakida` WRITE;
/*!40000 ALTER TABLE `yakida` DISABLE KEYS */;
INSERT INTO `yakida` VALUES (1,'Сет \"Харакири\"','1050',NULL,1,1);
/*!40000 ALTER TABLE `yakida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'club'
--

--
-- Dumping routines for database 'club'
--
/*!50003 DROP PROCEDURE IF EXISTS `AddClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddClient`(IN _username CHAR(45), IN _phone CHAR(45))
BEGIN
         Insert into club.client
         (client.name,client.phone) values(_username,_phone);
       END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddOrder`(IN _date datetime, IN _start CHAR(45),
 IN _end CHAR(45), IN _idClient Int, IN _pcrange CHAR(45), IN _comment CHAR(45) )
BEGIN
         Insert into club.cluborder
         (cluborder.date,cluborder.starttime,cluborder.endtime,
         cluborder.idclient,cluborder.pcrange,cluborder.comment) 
         values(_date,_start,_end,_idClient,_pcrange,_comment);
       END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddOrder_short` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddOrder_short`(IN _date DATETIME, IN _start CHAR(45),
IN _end CHAR(45), IN _idClient Int, IN _pcrange CHAR(45), IN _pcCount INT, IN _timeCount INT)
BEGIN
         Insert into club.cluborder
         (cluborder.date,cluborder.starttime,cluborder.endtime,
         cluborder.idclient,cluborder.pcrange, cluborder.pcCount,cluborder.timeCount) 
         values(_date,_start,_end,_idClient,_pcrange,_pcCount,_timeCount);
       END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AutUserWithRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AutUserWithRole`(IN _login CHAR(45), IN _pass CHAR(45))
BEGIN
         SELECT login,role_idrole FROM club.user
         WHERE user.login=_login and user.pass=_pass;
       END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CheckClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckClient`(IN _username CHAR(45), IN _phone CHAR(45))
BEGIN
         SELECT * FROM club.client
         WHERE client.phone=_phone and client.name=_username;
       END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetTooltip` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTooltip`(IN _idClient int, IN _idOrder int)
BEGIN
         SELECT client.name,cluborder.pcRange, cluborder.comment
         from club.client inner join club.cluborder
         on client.id=cluborder.idclient
         WHERE client.id=_idClient and cluborder.id=_idOrder;
       END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `todayorders`
--

/*!50001 DROP VIEW IF EXISTS `todayorders`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `todayorders` AS select `cluborder`.`id` AS `id`,`cluborder`.`date` AS `date`,`cluborder`.`starttime` AS `starttime`,`cluborder`.`endtime` AS `endtime`,`cluborder`.`pcRange` AS `pcRange`,`cluborder`.`pcCount` AS `pcCount`,`cluborder`.`timeCount` AS `timeCount`,`cluborder`.`comment` AS `comment`,`cluborder`.`idclient` AS `idclient` from `cluborder` where (`cluborder`.`date` = curdate()) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-17 21:56:02
