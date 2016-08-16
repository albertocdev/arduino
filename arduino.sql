# Host: localhost  (Version: 6.0.10-alpha-community)
# Date: 2016-08-11 17:09:55
# Generator: MySQL-Front 5.3  (Build 4.249)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "users"
#

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `u_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `u_name` varchar(50) NOT NULL,
  `u_username` varchar(30) NOT NULL,
  `u_password` varchar(80) NOT NULL DEFAULT '',
  `u_level` int(1) NOT NULL,
  PRIMARY KEY (`u_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

#
# Data for table "users"
#

INSERT INTO `users` VALUES (1,'Camacho','camacho','12345',2),(2,'Cesar Estrada','albertocdev','5e543256c480ac577d30f76f9120eb74',1);
