/*
Navicat MySQL Data Transfer

Source Server         : Connection
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : elysium_ls

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2017-04-26 00:43:09
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account` varchar(50) NOT NULL DEFAULT '',
  `password` varchar(255) NOT NULL DEFAULT '',
  `email` varchar(100) NOT NULL DEFAULT '',
  `pin` varchar(8) NOT NULL DEFAULT '',
  `cash` int(11) NOT NULL DEFAULT '0',
  `language_id` char(1) NOT NULL DEFAULT '1',
  `logged_in` char(1) NOT NULL DEFAULT '0',
  `access_level` smallint(6) NOT NULL DEFAULT '1',
  `active` char(1) NOT NULL DEFAULT '0',
  `first_name` varchar(50) NOT NULL DEFAULT '',
  `last_name` varchar(50) NOT NULL DEFAULT '',
  `location` varchar(25) NOT NULL DEFAULT '',
  `date_created` datetime NOT NULL,
  `date_last_login` datetime NOT NULL DEFAULT '1990-01-01 00:00:00',
  `creator_ip` varchar(15) NOT NULL DEFAULT '',
  `last_ip` varchar(15) NOT NULL DEFAULT '',
  `current_ip` varchar(15) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES ('1', 'akaruz', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '196760', '5000', '1', '0', '3', '1', 'Julio', 'Sperandio', '中國', '2017-03-23 23:59:37', '2017-04-25 04:44:29', '127.0.0.1', '187.57.69.227', '');
INSERT INTO `account` VALUES ('2', 'dragonick', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '196760', '95800', '1', '0', '3', '1', 'Julio', 'Sperandio', '日本', '2017-03-28 01:39:53', '2017-04-23 02:33:35', '127.0.0.1', '187.57.69.227', '');

-- ----------------------------
-- Table structure for account_ban
-- ----------------------------
DROP TABLE IF EXISTS `account_ban`;
CREATE TABLE `account_ban` (
  `id` int(11) NOT NULL DEFAULT '0',
  `account_id` int(11) NOT NULL DEFAULT '0',
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `reason` varchar(100) NOT NULL DEFAULT '',
  `expired` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `id_account` (`account_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_ban
-- ----------------------------
INSERT INTO `account_ban` VALUES ('1', '1', '2017-01-16 22:00:39', '2017-04-09 22:00:50', 'test', '1');

-- ----------------------------
-- Table structure for account_service
-- ----------------------------
DROP TABLE IF EXISTS `account_service`;
CREATE TABLE `account_service` (
  `id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL DEFAULT '0',
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `expired` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `service_fk` (`account_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_service
-- ----------------------------
INSERT INTO `account_service` VALUES ('1', '1', '4', '2016-12-21 02:42:26', '2017-02-15 02:42:34', '1');

-- ----------------------------
-- Table structure for banned_ip
-- ----------------------------
DROP TABLE IF EXISTS `banned_ip`;
CREATE TABLE `banned_ip` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `address` varchar(45) NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `comment` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`),
  UNIQUE KEY `mask` (`address`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of banned_ip
-- ----------------------------
INSERT INTO `banned_ip` VALUES ('1', '199.199.199', '2016-11-16 00:00:00', '2017-12-16 22:01:21', 'test_cm');
