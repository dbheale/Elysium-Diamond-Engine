/*
Navicat MySQL Data Transfer

Source Server         : Connection
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : elysium_ls

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2017-08-10 06:47:47
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for accounts
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account` varchar(50) NOT NULL DEFAULT '',
  `password` varchar(255) NOT NULL DEFAULT '',
  `email` varchar(100) NOT NULL DEFAULT '',
  `pin` varchar(255) NOT NULL DEFAULT '',
  `cash` int(11) NOT NULL DEFAULT '0',
  `language_id` tinyint(1) NOT NULL DEFAULT '1',
  `logged_in` tinyint(1) NOT NULL DEFAULT '0',
  `access_level` tinyint(2) NOT NULL DEFAULT '1',
  `active` tinyint(1) NOT NULL DEFAULT '0',
  `first_name` varchar(50) NOT NULL DEFAULT '',
  `last_name` varchar(50) NOT NULL DEFAULT '',
  `location` varchar(25) NOT NULL DEFAULT '',
  `date_created` datetime NOT NULL,
  `date_last_login` datetime NOT NULL DEFAULT '1990-01-01 00:00:00',
  `creator_ip` varchar(15) NOT NULL DEFAULT '',
  `last_ip` varchar(15) NOT NULL DEFAULT '',
  `current_ip` varchar(15) CHARACTER SET ujis NOT NULL DEFAULT '',
  `pin_attempt` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO `accounts` VALUES ('1', 'akaruz', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '10c00993a2651339aa1f415d65b4840827e54a04a9e23331db79e5ed63316d6b', '546202031', '1', '0', '3', '1', 'Julio', 'Sperandio', '中國', '2017-03-23 23:59:37', '2017-08-05 04:38:32', '127.0.0.1', '127.0.0.1', '', '0');
INSERT INTO `accounts` VALUES ('2', 'dragonick', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '10c00993a2651339aa1f415d65b4840827e54a04a9e23331db79e5ed63316d6b', '351635413', '1', '0', '3', '1', 'Julio', 'Sperandio', '日本', '2017-03-28 01:39:53', '2017-05-31 19:41:49', '127.0.0.1', '127.0.0.1', '', '0');
INSERT INTO `accounts` VALUES ('3', 'nadaila', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '10c00993a2651339aa1f415d65b4840827e54a04a9e23331db79e5ed63316d6b', '321657987', '1', '0', '1', '1', 'Julio', 'Sperandio', 'ブラジル', '2017-05-06 17:12:39', '1990-01-01 00:00:00', '127.0.0.1', '', '', '0');
INSERT INTO `accounts` VALUES ('4', 'caronne', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '10c00993a2651339aa1f415d65b4840827e54a04a9e23331db79e5ed63316d6b', '698765465', '1', '0', '1', '1', 'Julio', 'Sperandio', 'Brasil', '2017-05-06 17:36:35', '1990-01-01 00:00:00', '127.0.0.1', '', '', '0');
INSERT INTO `accounts` VALUES ('5', 'satanas', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'seucuca@hotmail.com', '10c00993a2651339aa1f415d65b4840827e54a04a9e23331db79e5ed63316d6b', '351635413', '1', '0', '1', '1', 'Julio', 'Sperandio', 'Brazil', '2017-06-15 14:56:00', '1990-01-01 00:00:00', '::1', '', '', '0');

-- ----------------------------
-- Table structure for account_ban
-- ----------------------------
DROP TABLE IF EXISTS `account_ban`;
CREATE TABLE `account_ban` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_id` int(11) NOT NULL DEFAULT '0',
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `reason` varchar(100) NOT NULL DEFAULT '',
  `expired` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `id_account` (`account_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_ban
-- ----------------------------
INSERT INTO `account_ban` VALUES ('1', '1', '2017-05-04 06:50:40', '2017-05-04 06:51:40', 'invalid pin', '1');
INSERT INTO `account_ban` VALUES ('2', '1', '2017-01-16 22:00:39', '2017-04-09 22:00:50', 'test', '1');

-- ----------------------------
-- Table structure for account_service
-- ----------------------------
DROP TABLE IF EXISTS `account_service`;
CREATE TABLE `account_service` (
  `account_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL DEFAULT '0',
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `expired` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`account_id`,`service_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_service
-- ----------------------------

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
INSERT INTO `banned_ip` VALUES ('1', '199.199.199', '2016-11-16 00:00:00', '2017-12-16 22:01:21', 'teste');
