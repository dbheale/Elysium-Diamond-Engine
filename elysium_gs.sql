/*
Navicat MySQL Data Transfer

Source Server         : Connection
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : elysium_gs

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2017-08-10 06:47:36
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for classes
-- ----------------------------
DROP TABLE IF EXISTS `classes`;
CREATE TABLE `classes` (
  `id` int(11) NOT NULL,
  `increment_id` int(11) NOT NULL DEFAULT '0',
  `talent_id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(25) NOT NULL DEFAULT '',
  `sprite` smallint(6) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '1',
  `hp` int(11) NOT NULL DEFAULT '0',
  `mp` int(11) NOT NULL DEFAULT '0',
  `sp` int(11) NOT NULL DEFAULT '0',
  `regen_hp` int(11) NOT NULL DEFAULT '0',
  `regen_mp` int(11) NOT NULL DEFAULT '0',
  `regen_sp` int(11) NOT NULL DEFAULT '0',
  `strenght` int(11) NOT NULL DEFAULT '0',
  `dexterity` int(11) NOT NULL DEFAULT '0',
  `agility` int(11) NOT NULL DEFAULT '0',
  `constitution` int(11) NOT NULL DEFAULT '0',
  `intelligence` int(11) NOT NULL DEFAULT '0',
  `will` int(11) NOT NULL DEFAULT '0',
  `wisdom` int(11) NOT NULL DEFAULT '0',
  `mind` int(11) NOT NULL DEFAULT '0',
  `points` int(11) NOT NULL DEFAULT '0',
  `critical_rate` int(11) NOT NULL DEFAULT '0',
  `critical_damage` int(11) NOT NULL DEFAULT '0',
  `magic_critical_rate` int(11) NOT NULL DEFAULT '0',
  `magic_critical_damage` int(11) NOT NULL DEFAULT '0',
  `healing_power` int(11) NOT NULL DEFAULT '0',
  `concentration` int(11) NOT NULL DEFAULT '0',
  `attack` int(11) NOT NULL DEFAULT '0',
  `accuracy` int(11) NOT NULL DEFAULT '0',
  `defense` int(11) NOT NULL DEFAULT '0',
  `evasion` int(11) NOT NULL DEFAULT '0',
  `block` int(11) NOT NULL DEFAULT '0',
  `parry` int(11) NOT NULL DEFAULT '0',
  `magic_attack` int(11) NOT NULL DEFAULT '0',
  `magic_accuracy` int(11) NOT NULL DEFAULT '0',
  `magic_defense` int(11) NOT NULL DEFAULT '0',
  `magic_resist` int(11) NOT NULL DEFAULT '0',
  `damage_suppression` int(11) NOT NULL DEFAULT '0',
  `additional_damage` int(11) NOT NULL DEFAULT '0',
  `enmity` int(11) NOT NULL DEFAULT '0',
  `attack_speed` int(11) NOT NULL DEFAULT '1000',
  `cast_speed` int(11) NOT NULL DEFAULT '1000',
  `attribute_fire` int(11) NOT NULL DEFAULT '0',
  `attribute_water` int(11) NOT NULL DEFAULT '0',
  `attribute_earth` int(11) NOT NULL DEFAULT '0',
  `attribute_wind` int(11) NOT NULL DEFAULT '0',
  `attribute_light` int(11) NOT NULL DEFAULT '0',
  `attribute_dark` int(11) NOT NULL DEFAULT '0',
  `resist_stun` int(11) NOT NULL DEFAULT '0',
  `resist_silence` int(11) NOT NULL DEFAULT '0',
  `resist_paralysis` int(11) NOT NULL,
  `resist_blind` int(11) NOT NULL DEFAULT '0',
  `resist_critical_rate` int(11) NOT NULL DEFAULT '0',
  `resist_critical_damage` int(11) NOT NULL DEFAULT '0',
  `resist_magic_critical_rate` int(11) NOT NULL DEFAULT '0',
  `resist_magic_critical_damage` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `classe_increment_fk` (`increment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of classes
-- ----------------------------
INSERT INTO `classes` VALUES ('0', '0', '0', 'Novato', '5', '1', '10', '10', '0', '1', '1', '0', '4', '1', '1', '4', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1000', '1000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `classes` VALUES ('1', '1', '0', 'Guerreiro', '15', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '100', '0', '0', '100', '100', '100', '100', '100', '100', '100', '100');
INSERT INTO `classes` VALUES ('2', '2', '0', 'Mago', '0', '1', '10', '10', '100', '100', '100', '100', '2', '1', '1', '4', '5', '1', '2', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `classes` VALUES ('3', '0', '0', 'Arqueiro', '50', '1111', '500', '500', '500', '500', '500', '500', '50', '50', '50', '50', '50', '50', '50', '50', '111', '10', '10', '60', '60', '98', '98', '10', '10', '10', '10', '10', '10', '60', '60', '60', '60', '98', '98', '98', '1000', '1000', '70', '70', '70', '70', '70', '70', '180', '180', '180', '180', '180', '180', '180', '180');

-- ----------------------------
-- Table structure for classe_increment
-- ----------------------------
DROP TABLE IF EXISTS `classe_increment`;
CREATE TABLE `classe_increment` (
  `id` int(11) NOT NULL,
  `name` varchar(25) NOT NULL DEFAULT '',
  `hp` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `mp` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `sp` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `regen_hp` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `regen_mp` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `regen_sp` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `strenght` int(11) NOT NULL DEFAULT '0',
  `dexterity` int(11) NOT NULL DEFAULT '0',
  `agility` int(11) NOT NULL DEFAULT '0',
  `constitution` int(11) NOT NULL DEFAULT '0',
  `intelligence` int(11) NOT NULL DEFAULT '0',
  `wisdom` int(11) NOT NULL DEFAULT '0',
  `will` int(11) NOT NULL DEFAULT '0',
  `mind` int(11) NOT NULL DEFAULT '0',
  `points` int(11) NOT NULL DEFAULT '0',
  `critical_rate` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `critical_damage` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `magic_critical_rate` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `magic_critical_damage` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `healing_power` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `concentration` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attack` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `accuracy` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `defense` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `evasion` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `block` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `parry` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `magic_attack` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `magic_accuracy` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `magic_defense` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `magic_resist` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `damage_suppression` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `additional_damage` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `enmity` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attack_speed` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `cast_speed` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attribute_fire` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attribute_water` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attribute_earth` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attribute_wind` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attribute_light` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `attribute_dark` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_stun` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_silence` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_paralysis` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_blind` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_critical_rate` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_critical_damage` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_magic_critical_rate` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  `resist_magic_critical_damage` varchar(100) NOT NULL DEFAULT '0;0;0;0;0;0;0;0;0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of classe_increment
-- ----------------------------
INSERT INTO `classe_increment` VALUES ('1', 'Guerreiro', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '15', '15', '15', '15', '15', '15', '15', '15', '15', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1', '1;1;1;1;1;1;1;1;1');
INSERT INTO `classe_increment` VALUES ('2', 'Mago', '10;0;0;0;5;0;0;0;0', '5;0;0;0;0;2;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;1;0', '0;0;0;0;0;0;0;0;1', '0;0;0;0;0;0;0;0;0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;1;0', '0;0;0;0;0;0;0;0;0', '1;1;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;1;1;1;0;0;0;0', '0;0;1;1;0;0;0;0;0', '0;1;1;1;0;0;0;0;0', '0;0;1;1;0;0;0;0;0', '1;0;0;0;0;2;1;0;0', '0;0;2;0;0;0;1;0;0', '0;0;0;0;1;1;1;0;0', '0;0;0;0;0;0;0;1;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0', '0;0;0;0;0;0;0;0;0');

-- ----------------------------
-- Table structure for classe_talent
-- ----------------------------
DROP TABLE IF EXISTS `classe_talent`;
CREATE TABLE `classe_talent` (
  `id` int(11) NOT NULL,
  `balance` varchar(255) DEFAULT '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0',
  `physic` varchar(255) DEFAULT '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0',
  `magic` varchar(255) DEFAULT '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0',
  `restoration` varchar(255) DEFAULT '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of classe_talent
-- ----------------------------
INSERT INTO `classe_talent` VALUES ('1', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0');
INSERT INTO `classe_talent` VALUES ('2', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0', '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0');

-- ----------------------------
-- Table structure for data_exp
-- ----------------------------
DROP TABLE IF EXISTS `data_exp`;
CREATE TABLE `data_exp` (
  `level` int(11) unsigned NOT NULL,
  `exp_to_reach_lvl` bigint(20) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of data_exp
-- ----------------------------
INSERT INTO `data_exp` VALUES ('1', '0');
INSERT INTO `data_exp` VALUES ('2', '14');
INSERT INTO `data_exp` VALUES ('3', '20');
INSERT INTO `data_exp` VALUES ('4', '36');
INSERT INTO `data_exp` VALUES ('5', '90');
INSERT INTO `data_exp` VALUES ('6', '152');
INSERT INTO `data_exp` VALUES ('7', '250');
INSERT INTO `data_exp` VALUES ('8', '352');
INSERT INTO `data_exp` VALUES ('9', '480');
INSERT INTO `data_exp` VALUES ('10', '591');
INSERT INTO `data_exp` VALUES ('11', '743');
INSERT INTO `data_exp` VALUES ('12', '973');
INSERT INTO `data_exp` VALUES ('13', '1290');
INSERT INTO `data_exp` VALUES ('14', '1632');
INSERT INTO `data_exp` VALUES ('15', '1928');
INSERT INTO `data_exp` VALUES ('16', '2340');
INSERT INTO `data_exp` VALUES ('17', '3480');
INSERT INTO `data_exp` VALUES ('18', '4125');
INSERT INTO `data_exp` VALUES ('19', '4995');
INSERT INTO `data_exp` VALUES ('20', '5880');
INSERT INTO `data_exp` VALUES ('21', '7840');
INSERT INTO `data_exp` VALUES ('22', '6875');
INSERT INTO `data_exp` VALUES ('23', '8243');
INSERT INTO `data_exp` VALUES ('24', '10380');
INSERT INTO `data_exp` VALUES ('25', '13052');
INSERT INTO `data_exp` VALUES ('26', '16450');
INSERT INTO `data_exp` VALUES ('27', '20700');
INSERT INTO `data_exp` VALUES ('28', '26143');
INSERT INTO `data_exp` VALUES ('29', '31950');
INSERT INTO `data_exp` VALUES ('30', '38640');
INSERT INTO `data_exp` VALUES ('31', '57035');
INSERT INTO `data_exp` VALUES ('32', '65000');
INSERT INTO `data_exp` VALUES ('33', '69125');
INSERT INTO `data_exp` VALUES ('34', '72000');
INSERT INTO `data_exp` VALUES ('35', '87239');
INSERT INTO `data_exp` VALUES ('36', '105863');
INSERT INTO `data_exp` VALUES ('37', '128694');
INSERT INTO `data_exp` VALUES ('38', '182307');
INSERT INTO `data_exp` VALUES ('39', '221450');
INSERT INTO `data_exp` VALUES ('40', '269042');
INSERT INTO `data_exp` VALUES ('41', '390368');
INSERT INTO `data_exp` VALUES ('42', '438550');
INSERT INTO `data_exp` VALUES ('43', '458137');
INSERT INTO `data_exp` VALUES ('44', '468943');
INSERT INTO `data_exp` VALUES ('45', '560177');
INSERT INTO `data_exp` VALUES ('46', '669320');
INSERT INTO `data_exp` VALUES ('47', '799963');
INSERT INTO `data_exp` VALUES ('48', '1115396');
INSERT INTO `data_exp` VALUES ('49', '1331100');
INSERT INTO `data_exp` VALUES ('50', '1590273');
INSERT INTO `data_exp` VALUES ('51', '2306878');
INSERT INTO `data_exp` VALUES ('52', '2594255');
INSERT INTO `data_exp` VALUES ('53', '2711490');
INSERT INTO `data_exp` VALUES ('54', '2777349');
INSERT INTO `data_exp` VALUES ('55', '3318059');
INSERT INTO `data_exp` VALUES ('56', '3963400');
INSERT INTO `data_exp` VALUES ('57', '4735913');
INSERT INTO `data_exp` VALUES ('58', '6600425');
INSERT INTO `data_exp` VALUES ('59', '7886110');
INSERT INTO `data_exp` VALUES ('60', '9421875');
INSERT INTO `data_exp` VALUES ('61', '13547310');
INSERT INTO `data_exp` VALUES ('62', '15099446');
INSERT INTO `data_exp` VALUES ('63', '15644776');
INSERT INTO `data_exp` VALUES ('64', '15885934');
INSERT INTO `data_exp` VALUES ('65', '18817757');
INSERT INTO `data_exp` VALUES ('66', '22280630');
INSERT INTO `data_exp` VALUES ('67', '26392968');
INSERT INTO `data_exp` VALUES ('68', '36465972');
INSERT INTO `data_exp` VALUES ('69', '43184958');
INSERT INTO `data_exp` VALUES ('70', '51141217');
INSERT INTO `data_exp` VALUES ('71', '73556918');
INSERT INTO `data_exp` VALUES ('72', '81991117');
INSERT INTO `data_exp` VALUES ('73', '84966758');
INSERT INTO `data_exp` VALUES ('74', '86252845');
INSERT INTO `data_exp` VALUES ('75', '102171368');
INSERT INTO `data_exp` VALUES ('76', '120995493');
INSERT INTO `data_exp` VALUES ('77', '143307208');
INSERT INTO `data_exp` VALUES ('78', '198000645');
INSERT INTO `data_exp` VALUES ('79', '234477760');
INSERT INTO `data_exp` VALUES ('80', '277716683');
INSERT INTO `data_exp` VALUES ('81', '381795797');
INSERT INTO `data_exp` VALUES ('82', '406848219');
INSERT INTO `data_exp` VALUES ('83', '403044458');
INSERT INTO `data_exp` VALUES ('84', '391191019');
INSERT INTO `data_exp` VALUES ('85', '442876559');
INSERT INTO `data_exp` VALUES ('86', '501408635');
INSERT INTO `data_exp` VALUES ('87', '567694433');
INSERT INTO `data_exp` VALUES ('88', '749813704');
INSERT INTO `data_exp` VALUES ('89', '849001357');
INSERT INTO `data_exp` VALUES ('90', '961154774');
INSERT INTO `data_exp` VALUES ('91', '1309582668');
INSERT INTO `data_exp` VALUES ('92', '1382799035');
INSERT INTO `data_exp` VALUES ('93', '1357505030');
INSERT INTO `data_exp` VALUES ('94', '1305632790');
INSERT INTO `data_exp` VALUES ('95', '1464862605');
INSERT INTO `data_exp` VALUES ('96', '1628695740');
INSERT INTO `data_exp` VALUES ('97', '1810772333');
INSERT INTO `data_exp` VALUES ('98', '2348583653');
INSERT INTO `data_exp` VALUES ('99', '2611145432');
INSERT INTO `data_exp` VALUES ('100', '2903009208');
INSERT INTO `data_exp` VALUES ('101', '3919352097');
INSERT INTO `data_exp` VALUES ('102', '4063358600');
INSERT INTO `data_exp` VALUES ('103', '3916810682');
INSERT INTO `data_exp` VALUES ('104', '4314535354');
INSERT INTO `data_exp` VALUES ('105', '4752892146');
INSERT INTO `data_exp` VALUES ('106', '5235785988');
INSERT INTO `data_exp` VALUES ('107', '5767741845');
INSERT INTO `data_exp` VALUES ('108', '6353744416');
INSERT INTO `data_exp` VALUES ('109', '6999284849');
INSERT INTO `data_exp` VALUES ('110', '7710412189');
INSERT INTO `data_exp` VALUES ('111', '8493790068');
INSERT INTO `data_exp` VALUES ('112', '9356759139');
INSERT INTO `data_exp` VALUES ('113', '10307405867');
INSERT INTO `data_exp` VALUES ('114', '11354638303');
INSERT INTO `data_exp` VALUES ('115', '12508269555');
INSERT INTO `data_exp` VALUES ('116', '13779109742');
INSERT INTO `data_exp` VALUES ('117', '15179067292');
INSERT INTO `data_exp` VALUES ('118', '16721260528');
INSERT INTO `data_exp` VALUES ('119', '18420140598');
INSERT INTO `data_exp` VALUES ('120', '20291626883');
INSERT INTO `data_exp` VALUES ('121', '22353256174');

-- ----------------------------
-- Table structure for data_sxp
-- ----------------------------
DROP TABLE IF EXISTS `data_sxp`;
CREATE TABLE `data_sxp` (
  `skill_level` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `sxp_to_reach_level` bigint(20) NOT NULL,
  PRIMARY KEY (`skill_level`)
) ENGINE=MyISAM AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of data_sxp
-- ----------------------------
INSERT INTO `data_sxp` VALUES ('1', '81');
INSERT INTO `data_sxp` VALUES ('2', '94');
INSERT INTO `data_sxp` VALUES ('3', '112');
INSERT INTO `data_sxp` VALUES ('4', '166');
INSERT INTO `data_sxp` VALUES ('5', '228');
INSERT INTO `data_sxp` VALUES ('6', '326');
INSERT INTO `data_sxp` VALUES ('7', '428');
INSERT INTO `data_sxp` VALUES ('8', '556');
INSERT INTO `data_sxp` VALUES ('9', '666');
INSERT INTO `data_sxp` VALUES ('10', '818');
INSERT INTO `data_sxp` VALUES ('11', '1049');
INSERT INTO `data_sxp` VALUES ('12', '1366');
INSERT INTO `data_sxp` VALUES ('13', '1708');
INSERT INTO `data_sxp` VALUES ('14', '2004');
INSERT INTO `data_sxp` VALUES ('15', '2416');
INSERT INTO `data_sxp` VALUES ('16', '3556');
INSERT INTO `data_sxp` VALUES ('17', '4201');
INSERT INTO `data_sxp` VALUES ('18', '5071');
INSERT INTO `data_sxp` VALUES ('19', '5956');
INSERT INTO `data_sxp` VALUES ('20', '7916');
INSERT INTO `data_sxp` VALUES ('21', '6951');
INSERT INTO `data_sxp` VALUES ('22', '8318');
INSERT INTO `data_sxp` VALUES ('23', '10456');
INSERT INTO `data_sxp` VALUES ('24', '13127');
INSERT INTO `data_sxp` VALUES ('25', '16526');
INSERT INTO `data_sxp` VALUES ('26', '20776');
INSERT INTO `data_sxp` VALUES ('27', '26219');
INSERT INTO `data_sxp` VALUES ('28', '32026');
INSERT INTO `data_sxp` VALUES ('29', '38716');
INSERT INTO `data_sxp` VALUES ('30', '57111');
INSERT INTO `data_sxp` VALUES ('31', '65076');
INSERT INTO `data_sxp` VALUES ('32', '69201');
INSERT INTO `data_sxp` VALUES ('33', '72076');
INSERT INTO `data_sxp` VALUES ('34', '87315');
INSERT INTO `data_sxp` VALUES ('35', '105939');
INSERT INTO `data_sxp` VALUES ('36', '128770');
INSERT INTO `data_sxp` VALUES ('37', '182382');
INSERT INTO `data_sxp` VALUES ('38', '221526');
INSERT INTO `data_sxp` VALUES ('39', '269117');
INSERT INTO `data_sxp` VALUES ('40', '390443');
INSERT INTO `data_sxp` VALUES ('41', '438626');
INSERT INTO `data_sxp` VALUES ('42', '458212');
INSERT INTO `data_sxp` VALUES ('43', '469018');
INSERT INTO `data_sxp` VALUES ('44', '560252');
INSERT INTO `data_sxp` VALUES ('45', '669396');
INSERT INTO `data_sxp` VALUES ('46', '800039');
INSERT INTO `data_sxp` VALUES ('47', '1115471');
INSERT INTO `data_sxp` VALUES ('48', '1331176');
INSERT INTO `data_sxp` VALUES ('49', '1590349');
INSERT INTO `data_sxp` VALUES ('50', '2306953');
INSERT INTO `data_sxp` VALUES ('51', '2594331');
INSERT INTO `data_sxp` VALUES ('52', '2711566');
INSERT INTO `data_sxp` VALUES ('53', '2777425');
INSERT INTO `data_sxp` VALUES ('54', '3318153');
INSERT INTO `data_sxp` VALUES ('55', '3963476');
INSERT INTO `data_sxp` VALUES ('56', '4735988');
INSERT INTO `data_sxp` VALUES ('57', '6600501');
INSERT INTO `data_sxp` VALUES ('58', '7886186');
INSERT INTO `data_sxp` VALUES ('59', '9421951');
INSERT INTO `data_sxp` VALUES ('60', '13547386');
INSERT INTO `data_sxp` VALUES ('61', '15099521');
INSERT INTO `data_sxp` VALUES ('62', '15644851');
INSERT INTO `data_sxp` VALUES ('63', '15886010');
INSERT INTO `data_sxp` VALUES ('64', '18817832');
INSERT INTO `data_sxp` VALUES ('65', '22280706');
INSERT INTO `data_sxp` VALUES ('66', '26393044');
INSERT INTO `data_sxp` VALUES ('67', '36466047');
INSERT INTO `data_sxp` VALUES ('68', '43185033');
INSERT INTO `data_sxp` VALUES ('69', '51141292');
INSERT INTO `data_sxp` VALUES ('70', '73556993');
INSERT INTO `data_sxp` VALUES ('71', '81991192');
INSERT INTO `data_sxp` VALUES ('72', '84966834');
INSERT INTO `data_sxp` VALUES ('73', '86252921');
INSERT INTO `data_sxp` VALUES ('74', '102171444');
INSERT INTO `data_sxp` VALUES ('75', '120995568');
INSERT INTO `data_sxp` VALUES ('76', '143307283');
INSERT INTO `data_sxp` VALUES ('77', '198000721');
INSERT INTO `data_sxp` VALUES ('78', '234477836');
INSERT INTO `data_sxp` VALUES ('79', '277716758');
INSERT INTO `data_sxp` VALUES ('80', '381795872');
INSERT INTO `data_sxp` VALUES ('81', '406848295');
INSERT INTO `data_sxp` VALUES ('82', '403044533');
INSERT INTO `data_sxp` VALUES ('83', '391191095');
INSERT INTO `data_sxp` VALUES ('84', '442876635');
INSERT INTO `data_sxp` VALUES ('85', '501408711');
INSERT INTO `data_sxp` VALUES ('86', '567694509');
INSERT INTO `data_sxp` VALUES ('87', '749813780');
INSERT INTO `data_sxp` VALUES ('88', '849001432');
INSERT INTO `data_sxp` VALUES ('89', '961145850');
INSERT INTO `data_sxp` VALUES ('90', '1309582744');
INSERT INTO `data_sxp` VALUES ('91', '1382799111');
INSERT INTO `data_sxp` VALUES ('92', '1357505106');
INSERT INTO `data_sxp` VALUES ('93', '1305632866');
INSERT INTO `data_sxp` VALUES ('94', '1464862681');
INSERT INTO `data_sxp` VALUES ('95', '1628695816');
INSERT INTO `data_sxp` VALUES ('96', '1810772409');
INSERT INTO `data_sxp` VALUES ('97', '2147483647');
INSERT INTO `data_sxp` VALUES ('98', '2147483647');
INSERT INTO `data_sxp` VALUES ('99', '2147483647');

-- ----------------------------
-- Table structure for data_txp
-- ----------------------------
DROP TABLE IF EXISTS `data_txp`;
CREATE TABLE `data_txp` (
  `talent_level` int(11) DEFAULT NULL,
  `txp_to_reach_level` bigint(20) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of data_txp
-- ----------------------------

-- ----------------------------
-- Table structure for guilds
-- ----------------------------
DROP TABLE IF EXISTS `guilds`;
CREATE TABLE `guilds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `owner_id` int(11) NOT NULL DEFAULT '0',
  `owner_name` varchar(20) NOT NULL DEFAULT '',
  `guild_name` varchar(25) NOT NULL DEFAULT '',
  `level` int(11) NOT NULL DEFAULT '1',
  `exp` int(11) NOT NULL DEFAULT '0',
  `contribution_points` int(11) NOT NULL DEFAULT '0',
  `rank_pos` int(11) NOT NULL DEFAULT '0',
  `announcement` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds
-- ----------------------------

-- ----------------------------
-- Table structure for guilds_exp
-- ----------------------------
DROP TABLE IF EXISTS `guilds_exp`;
CREATE TABLE `guilds_exp` (
  `nextlevel` int(11) unsigned NOT NULL DEFAULT '0',
  `req_exp` int(11) NOT NULL DEFAULT '0',
  `req_contribution` int(11) NOT NULL DEFAULT '0',
  `req_money` int(11) NOT NULL DEFAULT '0',
  `max_members` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of guilds_exp
-- ----------------------------
INSERT INTO `guilds_exp` VALUES ('1', '0', '0', '0', '30');
INSERT INTO `guilds_exp` VALUES ('2', '24', '24', '10', '30');
INSERT INTO `guilds_exp` VALUES ('3', '205', '205', '20', '32');
INSERT INTO `guilds_exp` VALUES ('4', '485', '485', '30', '32');
INSERT INTO `guilds_exp` VALUES ('5', '1353', '1353', '40', '34');
INSERT INTO `guilds_exp` VALUES ('6', '2338', '2338', '50', '34');
INSERT INTO `guilds_exp` VALUES ('7', '4547', '4547', '60', '36');
INSERT INTO `guilds_exp` VALUES ('8', '6788', '6788', '70', '36');
INSERT INTO `guilds_exp` VALUES ('9', '11045', '11045', '80', '38');
INSERT INTO `guilds_exp` VALUES ('10', '15151', '15151', '90', '38');
INSERT INTO `guilds_exp` VALUES ('11', '22183', '22183', '100', '40');
INSERT INTO `guilds_exp` VALUES ('12', '28800', '28800', '110', '40');
INSERT INTO `guilds_exp` VALUES ('13', '39340', '39340', '120', '42');
INSERT INTO `guilds_exp` VALUES ('14', '49135', '49135', '130', '42');
INSERT INTO `guilds_exp` VALUES ('15', '63920', '63920', '140', '44');
INSERT INTO `guilds_exp` VALUES ('16', '71608', '71608', '150', '44');
INSERT INTO `guilds_exp` VALUES ('17', '84365', '84365', '160', '46');
INSERT INTO `guilds_exp` VALUES ('18', '91041', '91041', '170', '46');
INSERT INTO `guilds_exp` VALUES ('19', '109698', '109698', '180', '48');
INSERT INTO `guilds_exp` VALUES ('20', '115152', '115152', '190', '48');
INSERT INTO `guilds_exp` VALUES ('21', '134545', '134545', '200', '49');
INSERT INTO `guilds_exp` VALUES ('22', '156813', '156813', '210', '50');
INSERT INTO `guilds_exp` VALUES ('23', '182351', '182351', '220', '51');
INSERT INTO `guilds_exp` VALUES ('24', '211610', '211610', '230', '52');
INSERT INTO `guilds_exp` VALUES ('25', '245099', '245099', '240', '53');
INSERT INTO `guilds_exp` VALUES ('26', '283396', '283396', '250', '54');
INSERT INTO `guilds_exp` VALUES ('27', '327152', '327152', '260', '55');
INSERT INTO `guilds_exp` VALUES ('28', '377106', '377106', '270', '56');
INSERT INTO `guilds_exp` VALUES ('29', '434090', '434090', '280', '57');
INSERT INTO `guilds_exp` VALUES ('30', '499049', '499049', '290', '58');
INSERT INTO `guilds_exp` VALUES ('31', '573046', '573046', '300', '59');
INSERT INTO `guilds_exp` VALUES ('32', '657283', '657283', '310', '60');
INSERT INTO `guilds_exp` VALUES ('33', '753119', '753119', '320', '61');
INSERT INTO `guilds_exp` VALUES ('34', '862086', '862086', '330', '62');
INSERT INTO `guilds_exp` VALUES ('35', '985913', '985913', '340', '63');
INSERT INTO `guilds_exp` VALUES ('36', '1126550', '1126550', '350', '64');
INSERT INTO `guilds_exp` VALUES ('37', '1286198', '1286198', '360', '65');
INSERT INTO `guilds_exp` VALUES ('38', '1467338', '1467338', '370', '66');
INSERT INTO `guilds_exp` VALUES ('39', '1672765', '1672765', '380', '67');
INSERT INTO `guilds_exp` VALUES ('40', '1905631', '1905631', '390', '68');
INSERT INTO `guilds_exp` VALUES ('41', '2169488', '2169488', '400', '69');
INSERT INTO `guilds_exp` VALUES ('42', '2468335', '2468335', '410', '70');
INSERT INTO `guilds_exp` VALUES ('43', '2806677', '2806677', '420', '71');
INSERT INTO `guilds_exp` VALUES ('44', '3189588', '3189588', '430', '72');
INSERT INTO `guilds_exp` VALUES ('45', '3622778', '3622778', '440', '73');
INSERT INTO `guilds_exp` VALUES ('46', '4112677', '4112677', '450', '74');
INSERT INTO `guilds_exp` VALUES ('47', '4666517', '4666517', '460', '75');
INSERT INTO `guilds_exp` VALUES ('48', '5292439', '5292439', '470', '76');
INSERT INTO `guilds_exp` VALUES ('49', '5999599', '5999599', '480', '77');
INSERT INTO `guilds_exp` VALUES ('50', '7500000', '7500000', '490', '80');

-- ----------------------------
-- Table structure for guilds_history
-- ----------------------------
DROP TABLE IF EXISTS `guilds_history`;
CREATE TABLE `guilds_history` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `guild_id` int(11) NOT NULL DEFAULT '0',
  `date` varchar(35) NOT NULL DEFAULT '',
  `player_name` varchar(20) NOT NULL DEFAULT '',
  `description` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds_history
-- ----------------------------

-- ----------------------------
-- Table structure for guilds_member
-- ----------------------------
DROP TABLE IF EXISTS `guilds_member`;
CREATE TABLE `guilds_member` (
  `guild_id` int(11) NOT NULL DEFAULT '0',
  `player_id` int(11) NOT NULL DEFAULT '0',
  `player_name` varchar(20) NOT NULL DEFAULT '',
  `permission` varchar(20) NOT NULL DEFAULT '0, 0, 0, 0',
  `selfintro` varchar(100) NOT NULL DEFAULT '',
  `contribution_points` int(10) NOT NULL DEFAULT '0',
  `access` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`player_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds_member
-- ----------------------------

-- ----------------------------
-- Table structure for guilds_warehouse
-- ----------------------------
DROP TABLE IF EXISTS `guilds_warehouse`;
CREATE TABLE `guilds_warehouse` (
  `guild_id` int(10) NOT NULL DEFAULT '0',
  `item_id` int(10) NOT NULL DEFAULT '0',
  `item_unique_id` varchar(255) NOT NULL DEFAULT '',
  `item_count` int(10) NOT NULL DEFAULT '0',
  `warehouse_slot` int(10) NOT NULL DEFAULT '0',
  `enchant` int(10) NOT NULL DEFAULT '0',
  `durability` int(10) NOT NULL DEFAULT '0',
  `slots` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`guild_id`,`item_unique_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds_warehouse
-- ----------------------------

-- ----------------------------
-- Table structure for items
-- ----------------------------
DROP TABLE IF EXISTS `items`;
CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `version` varchar(12) NOT NULL DEFAULT '1.0',
  `name` varchar(25) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `useable` tinyint(1) NOT NULL DEFAULT '0',
  `storable` tinyint(1) NOT NULL DEFAULT '0',
  `package` smallint(6) NOT NULL DEFAULT '1',
  `handed` tinyint(1) NOT NULL DEFAULT '1',
  `sprite` smallint(6) NOT NULL DEFAULT '0',
  `price` int(11) NOT NULL DEFAULT '0',
  `durability` smallint(6) NOT NULL DEFAULT '1',
  `rarity` tinyint(2) NOT NULL DEFAULT '0',
  `type` tinyint(2) NOT NULL DEFAULT '0',
  `attack_range` tinyint(2) NOT NULL DEFAULT '1',
  `level` smallint(6) NOT NULL DEFAULT '1',
  `hp` int(11) NOT NULL DEFAULT '0',
  `mp` int(11) NOT NULL DEFAULT '0',
  `sp` int(11) NOT NULL DEFAULT '0',
  `regen_hp` int(11) NOT NULL DEFAULT '0',
  `regen_mp` int(11) NOT NULL DEFAULT '0',
  `regen_sp` int(11) NOT NULL DEFAULT '0',
  `strenght` int(11) NOT NULL DEFAULT '0',
  `dexterity` int(11) NOT NULL DEFAULT '0',
  `agility` int(11) NOT NULL DEFAULT '0',
  `constitution` int(11) NOT NULL DEFAULT '0',
  `intelligence` int(11) NOT NULL DEFAULT '0',
  `wisdom` int(11) NOT NULL DEFAULT '0',
  `will` int(11) NOT NULL DEFAULT '0',
  `mind` int(11) NOT NULL DEFAULT '0',
  `critical_rate` int(11) NOT NULL DEFAULT '0',
  `critical_damage` int(11) NOT NULL DEFAULT '0',
  `magic_critical_rate` int(11) NOT NULL DEFAULT '0',
  `magic_critical_damage` int(11) NOT NULL DEFAULT '0',
  `concentration` int(11) NOT NULL DEFAULT '0',
  `healing_power` int(11) NOT NULL DEFAULT '0',
  `attack` int(11) NOT NULL DEFAULT '0',
  `accuracy` int(11) NOT NULL DEFAULT '0',
  `defense` int(11) NOT NULL DEFAULT '0',
  `evasion` int(11) NOT NULL DEFAULT '0',
  `parry` int(11) NOT NULL DEFAULT '0',
  `block` int(11) NOT NULL DEFAULT '0',
  `magic_attack` int(11) NOT NULL DEFAULT '0',
  `magic_accuracy` int(11) NOT NULL DEFAULT '0',
  `magic_defense` int(11) NOT NULL DEFAULT '0',
  `magic_resist` int(11) NOT NULL DEFAULT '0',
  `damage_suppression` int(11) NOT NULL DEFAULT '0',
  `additional_damage` int(11) NOT NULL DEFAULT '0',
  `enmity` int(11) NOT NULL DEFAULT '0',
  `attack_speed` int(11) NOT NULL DEFAULT '0',
  `cast_speed` int(11) NOT NULL DEFAULT '0',
  `attribute_fire` int(11) NOT NULL DEFAULT '0',
  `attribute_water` int(11) NOT NULL DEFAULT '0',
  `attribute_earth` int(11) NOT NULL DEFAULT '0',
  `attribute_wind` int(11) NOT NULL DEFAULT '0',
  `attribute_dark` int(11) NOT NULL DEFAULT '0',
  `attribute_light` int(11) NOT NULL DEFAULT '0',
  `resist_stun` int(11) NOT NULL DEFAULT '0',
  `resist_silence` int(11) NOT NULL DEFAULT '0',
  `resist_paralysis` int(11) NOT NULL DEFAULT '0',
  `resist_blind` int(11) NOT NULL DEFAULT '0',
  `resist_critical_rate` int(11) NOT NULL DEFAULT '0',
  `resist_critical_damage` int(11) NOT NULL DEFAULT '0',
  `resist_magic_critical_rate` int(11) NOT NULL DEFAULT '0',
  `resist_magic_critical_damage` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of items
-- ----------------------------
INSERT INTO `items` VALUES ('1', '1.2.10', 'Espada de Metal', '', '1', '1', '1', '1', '207', '150', '120', '6', '0', '1', '1', '100', '0', '0', '0', '0', '0', '5', '0', '0', '0', '0', '0', '0', '0', '20', '12', '0', '0', '0', '8', '15', '25', '0', '0', '17', '0', '0', '12', '0', '0', '0', '0', '0', '5', '0', '25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('2', '1.2.10', 'Escudo de Metal', '', '1', '1', '1', '1', '205', '170', '120', '6', '1', '0', '1', '100', '100', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '15', '0', '5', '0', '0', '12', '8', '0', '0', '8', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('3', '1.2.10', 'Luvas do Sacerdote', '', '1', '1', '1', '1', '220', '190', '120', '6', '3', '0', '1', '100', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '15', '0', '0', '15', '22', '12', '8', '0', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('4', '1.2.10', 'Bandana do Sacerdote', '', '1', '1', '1', '1', '221', '190', '120', '6', '2', '0', '1', '0', '50', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '3', '10', '0', '0', '0', '15', '9', '7', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('5', '1.2.10', 'Calça do Sacerdote', '', '1', '1', '1', '1', '222', '142', '120', '6', '6', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '8', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '9', '18', '0', '0', '11', '0', '17', '22', '0', '0', '5', '0', '0', '8', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('6', '1.2.10', 'Botas do Sacerdote', '', '1', '1', '1', '1', '223', '152', '120', '6', '7', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '12', '0', '0', '11', '17', '8', '10', '0', '0', '2', '0', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('7', '1.2.10', 'Ombro do Sacerdote', '', '1', '1', '1', '1', '224', '170', '120', '6', '4', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '12', '0', '0', '11', '17', '8', '10', '25', '19', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('8', '1.2.10', 'Túnica do Sacerdote', '', '1', '1', '1', '1', '225', '170', '120', '6', '5', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '0', '0', '25', '0', '0', '0', '0', '0', '120', '0', '0', '0', '25', '42', '0', '0', '29', '85', '35', '48', '0', '0', '0', '0', '0', '47', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('9', '1.2.10', 'Colar de Magia', '', '1', '1', '1', '1', '196', '180', '120', '6', '9', '0', '1', '750', '500', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '110', '98', '190', '250', '0', '0', '0', '0', '270', '480', '0', '195', '0', '10', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('10', '1.2.10', 'Brinco de Magia', '', '1', '1', '1', '1', '195', '200', '120', '6', '10', '0', '1', '1250', '700', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '110', '120', '185', '350', '0', '0', '0', '0', '470', '780', '0', '100', '0', '0', '0', '0', '0', '115', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('11', '1.2.10', 'Anel de Magia', '', '1', '1', '1', '1', '197', '200', '120', '6', '11', '0', '1', '5250', '1200', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '210', '720', '99', '150', '0', '0', '0', '0', '180', '480', '0', '100', '0', '110', '0', '0', '0', '115', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('12', '1.2.10', 'Cinto de Magia', '', '1', '1', '1', '1', '194', '2000', '120', '6', '8', '0', '1', '5250', '1200', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '210', '720', '99', '150', '0', '0', '0', '0', '180', '480', '0', '100', '0', '110', '0', '0', '0', '115', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for item_statlevel
-- ----------------------------
DROP TABLE IF EXISTS `item_statlevel`;
CREATE TABLE `item_statlevel` (
  `id` int(11) NOT NULL,
  `max_level` smallint(6) NOT NULL DEFAULT '15',
  `hp` tinyint(4) NOT NULL DEFAULT '0',
  `mp` tinyint(4) NOT NULL DEFAULT '0',
  `sp` tinyint(4) NOT NULL DEFAULT '0',
  `regen_hp` tinyint(4) NOT NULL DEFAULT '0',
  `regen_mp` tinyint(4) NOT NULL DEFAULT '0',
  `regen_sp` tinyint(4) NOT NULL DEFAULT '0',
  `strenght` tinyint(4) NOT NULL DEFAULT '0',
  `dexterity` tinyint(4) NOT NULL DEFAULT '0',
  `agility` tinyint(4) NOT NULL DEFAULT '0',
  `constitution` tinyint(4) NOT NULL DEFAULT '0',
  `intelligence` tinyint(4) NOT NULL DEFAULT '0',
  `wisdom` tinyint(4) NOT NULL DEFAULT '0',
  `will` tinyint(4) NOT NULL DEFAULT '0',
  `mind` tinyint(4) NOT NULL DEFAULT '0',
  `critical_rate` tinyint(4) NOT NULL DEFAULT '0',
  `critical_damage` tinyint(4) NOT NULL DEFAULT '0',
  `magic_critical_rate` tinyint(4) NOT NULL DEFAULT '0',
  `magic_critical_damage` tinyint(4) NOT NULL DEFAULT '0',
  `concentration` tinyint(4) NOT NULL DEFAULT '0',
  `healing_power` tinyint(4) NOT NULL DEFAULT '0',
  `attack` tinyint(4) NOT NULL DEFAULT '0',
  `accuracy` tinyint(4) NOT NULL DEFAULT '0',
  `defense` tinyint(4) NOT NULL DEFAULT '0',
  `evasion` tinyint(4) NOT NULL DEFAULT '0',
  `parry` tinyint(4) NOT NULL DEFAULT '0',
  `block` tinyint(4) NOT NULL DEFAULT '0',
  `magic_attack` tinyint(4) NOT NULL DEFAULT '0',
  `magic_accuracy` tinyint(4) NOT NULL DEFAULT '0',
  `magic_defense` tinyint(4) NOT NULL DEFAULT '0',
  `magic_resist` tinyint(4) NOT NULL DEFAULT '0',
  `damage_suppression` tinyint(4) NOT NULL DEFAULT '0',
  `additional_damage` tinyint(4) NOT NULL DEFAULT '0',
  `enmity` tinyint(4) NOT NULL DEFAULT '0',
  `attack_speed` tinyint(4) NOT NULL DEFAULT '0',
  `cast_speed` tinyint(4) NOT NULL DEFAULT '0',
  `attribute_fire` tinyint(4) NOT NULL DEFAULT '0',
  `attribute_water` tinyint(4) NOT NULL DEFAULT '0',
  `attribute_earth` tinyint(4) NOT NULL DEFAULT '0',
  `attribute_wind` tinyint(4) NOT NULL DEFAULT '0',
  `attribute_light` tinyint(4) NOT NULL DEFAULT '0',
  `attribute_dark` tinyint(4) NOT NULL DEFAULT '0',
  `resist_stun` tinyint(4) NOT NULL DEFAULT '0',
  `resist_paralysis` tinyint(4) NOT NULL DEFAULT '0',
  `resist_silence` tinyint(4) NOT NULL DEFAULT '0',
  `resist_blind` tinyint(4) NOT NULL DEFAULT '0',
  `resist_critical_rate` tinyint(4) NOT NULL DEFAULT '0',
  `resist_critical_damage` tinyint(4) NOT NULL DEFAULT '0',
  `resist_magic_critical_rate` tinyint(4) NOT NULL DEFAULT '0',
  `resist_magic_critical_damage` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of item_statlevel
-- ----------------------------
INSERT INTO `item_statlevel` VALUES ('1', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '5', '0', '0', '0', '0', '5', '5', '0', '0', '5', '0', '0', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('2', '15', '5', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '5', '0', '0', '5', '5', '0', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('3', '15', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '0', '5', '5', '5', '5', '0', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('4', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('5', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('6', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('7', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `item_statlevel` VALUES ('8', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '5', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for languages
-- ----------------------------
DROP TABLE IF EXISTS `languages`;
CREATE TABLE `languages` (
  `id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of languages
-- ----------------------------
INSERT INTO `languages` VALUES ('1', 'English');
INSERT INTO `languages` VALUES ('2', 'Portuguese');
INSERT INTO `languages` VALUES ('3', 'Japanese');
INSERT INTO `languages` VALUES ('4', 'Spanish');

-- ----------------------------
-- Table structure for mail
-- ----------------------------
DROP TABLE IF EXISTS `mail`;
CREATE TABLE `mail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sender_id` int(11) DEFAULT '0',
  `sender_name` varchar(25) DEFAULT '',
  `recipient_id` int(11) DEFAULT '0',
  `mail_title` varchar(100) DEFAULT '',
  `mail_message` varchar(255) DEFAULT '',
  `attached_currency` bigint(11) DEFAULT '0',
  `express` tinyint(1) DEFAULT '0',
  `received_date` datetime DEFAULT NULL,
  `status` tinyint(1) DEFAULT '0',
  `item_id` int(11) DEFAULT '0',
  `quantity` smallint(6) DEFAULT '0',
  `enchant` smallint(6) DEFAULT '0',
  `durability` smallint(6) DEFAULT '0',
  `slots` varchar(255) DEFAULT '0,0,0,0,0,0,0,0,0',
  `expire` tinyint(1) DEFAULT '0',
  `expire_days` smallint(6) DEFAULT '0',
  `soul_bound` tinyint(1) DEFAULT '0',
  `tradeable` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mail
-- ----------------------------
INSERT INTO `mail` VALUES ('1', '21', 'Cash Shop', '21', 'Compra de Item', 'Entrega do item', '0', '1', '2017-05-23 05:49:25', '0', '4', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '1', '30', '0', '1');
INSERT INTO `mail` VALUES ('2', '21', 'Cash Shop', '21', 'Compra de Item', 'Entrega do item', '0', '1', '2017-05-23 05:49:53', '0', '2', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '1', '30', '0', '1');

-- ----------------------------
-- Table structure for npc
-- ----------------------------
DROP TABLE IF EXISTS `npc`;
CREATE TABLE `npc` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unique_id` int(11) NOT NULL,
  `version` varchar(20) DEFAULT '',
  `name` varchar(100) DEFAULT '',
  `sprite` smallint(6) DEFAULT NULL,
  `type` tinyint(4) DEFAULT '0',
  `elite` tinyint(4) DEFAULT '0',
  `level` int(11) DEFAULT '1',
  `experience` int(11) DEFAULT NULL,
  `hp` int(11) DEFAULT '0',
  `regen_hp` int(11) DEFAULT '0',
  `attack` int(11) DEFAULT '0',
  `accuracy` int(11) DEFAULT '0',
  `defense` int(11) DEFAULT '0',
  `evasion` int(11) DEFAULT '0',
  `block` int(11) DEFAULT '0',
  `parry` int(11) DEFAULT '0',
  `attack_speed` int(11) DEFAULT '2000',
  `cast_speed` int(11) DEFAULT '2000',
  `magic_attack` int(11) DEFAULT '0',
  `magic_accuracy` int(11) DEFAULT '0',
  `magic_defense` int(11) DEFAULT '0',
  `magic_resist` int(11) DEFAULT '0',
  `attribute_fire` int(11) DEFAULT '0',
  `attribute_water` int(11) DEFAULT '0',
  `attribute_earth` int(11) DEFAULT '0',
  `attribute_wind` int(11) DEFAULT '0',
  `attribute_dark` int(11) DEFAULT '0',
  `attribute_light` int(11) DEFAULT '0',
  `resist_stun` int(11) DEFAULT '0',
  `resist_silence` int(11) DEFAULT '0',
  `resist_paralysis` int(11) DEFAULT '0',
  `resist_blind` int(11) DEFAULT '0',
  `resist_critical_rate` int(11) DEFAULT '0',
  `resist_critical_damage` int(11) DEFAULT '0',
  `resist_magic_critical_rate` int(11) DEFAULT '0',
  `resist_magic_critical_damage` int(11) DEFAULT '0',
  PRIMARY KEY (`id`,`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of npc
-- ----------------------------
INSERT INTO `npc` VALUES ('1', '100', '1.1', 'Alicia', '20', '0', '0', '1', '100', '250', '5', '10', '50', '10', '5', '0', '0', '2000', '2000', '0', '10', '0', '10', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `npc` VALUES ('2', '101', '1.1', 'Janira', '21', '0', '1', '5', '100', '450', '10', '20', '60', '20', '10', '0', '0', '2000', '2000', '0', '20', '0', '20', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `npc` VALUES ('3', '102', '1.1', 'Vartao', '22', '0', '2', '10', '100', '850', '15', '30', '70', '30', '15', '0', '0', '2000', '2000', '0', '30', '0', '30', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `npc` VALUES ('4', '103', '1.1', 'Vandira', '23', '0', '3', '15', '100', '1250', '20', '40', '80', '40', '20', '20', '20', '2000', '2000', '0', '40', '0', '40', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for old_names
-- ----------------------------
DROP TABLE IF EXISTS `old_names`;
CREATE TABLE `old_names` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `player_id` int(11) NOT NULL,
  `old_name` varchar(50) NOT NULL,
  `new_name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of old_names
-- ----------------------------

-- ----------------------------
-- Table structure for players
-- ----------------------------
DROP TABLE IF EXISTS `players`;
CREATE TABLE `players` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_id` int(11) NOT NULL DEFAULT '0',
  `classe_id` int(11) NOT NULL DEFAULT '0',
  `guild_id` int(11) NOT NULL DEFAULT '0',
  `char_slot` int(11) NOT NULL DEFAULT '0',
  `name` varchar(25) NOT NULL DEFAULT '',
  `gender` tinyint(1) NOT NULL DEFAULT '0',
  `sprite` smallint(6) NOT NULL DEFAULT '0',
  `hp` int(11) NOT NULL DEFAULT '0',
  `mp` int(11) NOT NULL DEFAULT '0',
  `sp` int(11) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '1',
  `exp` bigint(20) NOT NULL DEFAULT '0',
  `talent_level` int(11) NOT NULL DEFAULT '0',
  `talent_exp` bigint(20) NOT NULL DEFAULT '0',
  `talent_points` int(11) NOT NULL DEFAULT '0',
  `talent_balance` int(11) NOT NULL DEFAULT '0',
  `talent_physic` int(11) NOT NULL DEFAULT '0',
  `talent_magic` int(11) NOT NULL DEFAULT '0',
  `talent_restoration` int(11) NOT NULL DEFAULT '0',
  `strenght` int(11) NOT NULL DEFAULT '0',
  `dexterity` int(11) NOT NULL DEFAULT '0',
  `agility` int(11) NOT NULL DEFAULT '0',
  `constitution` int(11) NOT NULL DEFAULT '0',
  `intelligence` int(11) NOT NULL DEFAULT '0',
  `wisdom` int(11) NOT NULL DEFAULT '0',
  `will` int(11) NOT NULL DEFAULT '0',
  `mind` int(11) NOT NULL DEFAULT '0',
  `statpoints` int(11) NOT NULL DEFAULT '0',
  `world_id` int(11) NOT NULL DEFAULT '1',
  `region_id` int(11) NOT NULL DEFAULT '1',
  `direction` smallint(6) NOT NULL DEFAULT '1',
  `posx` smallint(6) NOT NULL DEFAULT '0',
  `posy` smallint(6) NOT NULL DEFAULT '0',
  `dead` smallint(3) NOT NULL DEFAULT '0',
  `creation_date` datetime NOT NULL DEFAULT '2000-01-01 00:00:00',
  `deletion_date` datetime NOT NULL DEFAULT '2000-01-01 00:00:00',
  `pending_deletion` tinyint(1) NOT NULL DEFAULT '0',
  `currency` bigint(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of players
-- ----------------------------
INSERT INTO `players` VALUES ('21', '1', '1', '0', '0', 'Caronne', '0', '2', '0', '0', '0', '100', '1', '1', '8', '950', '0', '0', '0', '0', '100', '100', '100', '140', '1013', '116', '116', '125', '5512', '1', '1', '3', '6', '24', '0', '2017-05-22 04:25:46', '2000-01-01 00:00:00', '0', '95000');
INSERT INTO `players` VALUES ('22', '1', '1', '0', '1', 'Saci123', '0', '5', '0', '0', '0', '100', '0', '0', '0', '0', '0', '0', '0', '0', '100', '100', '100', '100', '100', '100', '100', '100', '100', '1', '1', '3', '-7', '0', '0', '2017-06-17 19:43:05', '2000-01-01 00:00:00', '0', '0');
INSERT INTO `players` VALUES ('23', '1', '2', '0', '2', 'Macumba123', '0', '10', '0', '0', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '2', '1', '1', '4', '5', '2', '1', '1', '0', '1', '1', '1', '0', '0', '0', '2017-06-17 19:43:11', '2000-01-01 00:00:00', '0', '0');

-- ----------------------------
-- Table structure for player_equippeditem
-- ----------------------------
DROP TABLE IF EXISTS `player_equippeditem`;
CREATE TABLE `player_equippeditem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `char_id` int(11) NOT NULL DEFAULT '0',
  `item_id` int(11) NOT NULL DEFAULT '0',
  `equip_slot` tinyint(4) NOT NULL DEFAULT '0',
  `quantity` smallint(6) NOT NULL DEFAULT '1',
  `enchant` smallint(6) NOT NULL DEFAULT '0',
  `durability` smallint(6) NOT NULL DEFAULT '0',
  `slots` varchar(255) NOT NULL DEFAULT '0,0,0,0,0,0,0,0,0',
  `expire` tinyint(4) NOT NULL DEFAULT '0',
  `expire_date` datetime NOT NULL DEFAULT '2000-01-01 00:00:00',
  `soul_bound` tinyint(4) NOT NULL DEFAULT '0',
  `tradeable` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=276 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of player_equippeditem
-- ----------------------------
INSERT INTO `player_equippeditem` VALUES ('206', '21', '1', '0', '1', '15', '950', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('207', '21', '2', '1', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('208', '21', '4', '2', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('209', '21', '3', '3', '1', '3', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('210', '21', '7', '4', '1', '7', '110', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('211', '21', '8', '5', '1', '8', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('212', '21', '5', '6', '1', '5', '90', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('213', '21', '6', '7', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('214', '21', '12', '8', '1', '97', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('215', '21', '9', '9', '1', '15', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('216', '21', '10', '10', '1', '14', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('217', '21', '10', '11', '1', '15', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('218', '21', '11', '12', '1', '100', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('219', '21', '11', '13', '1', '255', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:48', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('234', '23', '1', '0', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:37', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('235', '23', '2', '1', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:37', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('236', '23', '4', '2', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:37', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('237', '23', '3', '3', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:37', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('238', '23', '7', '4', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:37', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('239', '23', '8', '5', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:37', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('240', '23', '5', '6', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('241', '23', '6', '7', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('242', '23', '0', '8', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('243', '23', '0', '9', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('244', '23', '0', '10', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('245', '23', '0', '11', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('246', '23', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('247', '23', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('248', '22', '1', '0', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:04', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('249', '22', '2', '1', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:04', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('250', '22', '4', '2', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:04', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('251', '22', '3', '3', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:04', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('252', '22', '7', '4', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('253', '22', '8', '5', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('254', '22', '5', '6', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('255', '22', '6', '7', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('256', '22', '0', '8', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('257', '22', '0', '9', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('258', '22', '0', '10', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('259', '22', '0', '11', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('260', '22', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('261', '22', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('262', '23', '1', '0', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('263', '23', '2', '1', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('264', '23', '4', '2', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('265', '23', '3', '3', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('266', '23', '7', '4', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('267', '23', '8', '5', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('268', '23', '5', '6', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('269', '23', '6', '7', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '1');
INSERT INTO `player_equippeditem` VALUES ('270', '23', '0', '8', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('271', '23', '0', '9', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('272', '23', '0', '10', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('273', '23', '0', '11', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('274', '23', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_equippeditem` VALUES ('275', '23', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');

-- ----------------------------
-- Table structure for player_inventory
-- ----------------------------
DROP TABLE IF EXISTS `player_inventory`;
CREATE TABLE `player_inventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `char_id` int(11) NOT NULL DEFAULT '0',
  `item_id` int(11) NOT NULL DEFAULT '0',
  `inventory_slot` tinyint(4) NOT NULL DEFAULT '0',
  `quantity` smallint(6) NOT NULL DEFAULT '0',
  `enchant` smallint(6) NOT NULL DEFAULT '0',
  `durability` smallint(6) NOT NULL DEFAULT '0',
  `slots` varchar(255) NOT NULL DEFAULT '0,0,0,0,0,0,0,0,0',
  `expire` tinyint(4) NOT NULL DEFAULT '0',
  `expire_date` datetime NOT NULL DEFAULT '2000-01-01 01:01:01',
  `soul_bound` tinyint(1) NOT NULL DEFAULT '0',
  `tradeable` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=301 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of player_inventory
-- ----------------------------
INSERT INTO `player_inventory` VALUES ('21', '21', '1', '0', '1', '1', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('22', '21', '6', '1', '1', '6', '100', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('23', '21', '7', '2', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('24', '21', '11', '3', '1', '50', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('25', '21', '4', '4', '1', '4', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('26', '21', '0', '5', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('27', '21', '0', '6', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('28', '21', '10', '7', '1', '13', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('29', '21', '3', '8', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('30', '21', '2', '9', '1', '2', '60', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:48', '0', '0');
INSERT INTO `player_inventory` VALUES ('31', '21', '8', '10', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('32', '21', '1', '11', '1', '95', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('33', '21', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:48', '0', '0');
INSERT INTO `player_inventory` VALUES ('34', '21', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('35', '21', '12', '14', '1', '98', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('36', '21', '11', '15', '1', '15', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('37', '21', '0', '16', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('38', '21', '0', '17', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('39', '21', '0', '18', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('40', '21', '0', '19', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:48', '0', '0');
INSERT INTO `player_inventory` VALUES ('41', '21', '0', '20', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('42', '21', '0', '21', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('43', '21', '0', '22', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('44', '21', '0', '23', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('45', '21', '0', '24', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:48', '0', '0');
INSERT INTO `player_inventory` VALUES ('46', '21', '0', '25', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('47', '21', '0', '26', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('48', '21', '0', '27', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:48', '0', '0');
INSERT INTO `player_inventory` VALUES ('49', '21', '0', '28', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('50', '21', '0', '29', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('51', '21', '0', '30', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('52', '21', '0', '31', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('53', '21', '0', '32', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('54', '21', '0', '33', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('55', '21', '0', '34', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('56', '21', '0', '35', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('57', '21', '0', '36', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('58', '21', '0', '37', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('59', '21', '0', '38', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('60', '21', '0', '39', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('61', '21', '0', '40', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('62', '21', '0', '41', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('63', '21', '0', '42', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('64', '21', '0', '43', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('65', '21', '0', '44', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('66', '21', '0', '45', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('67', '21', '0', '46', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('68', '21', '0', '47', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('69', '21', '0', '48', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('70', '21', '0', '49', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('71', '21', '0', '50', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('72', '21', '0', '51', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('73', '21', '0', '52', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:47', '0', '0');
INSERT INTO `player_inventory` VALUES ('74', '21', '0', '53', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('75', '21', '0', '54', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('76', '21', '5', '55', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-05-22 04:25:46', '0', '0');
INSERT INTO `player_inventory` VALUES ('133', '23', '8', '0', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '1');
INSERT INTO `player_inventory` VALUES ('134', '23', '0', '1', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('135', '23', '0', '2', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('136', '23', '0', '3', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('137', '23', '0', '4', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('138', '23', '0', '5', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('139', '23', '0', '6', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('140', '23', '0', '7', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('141', '23', '0', '8', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('142', '23', '0', '9', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('143', '23', '0', '10', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('144', '23', '0', '11', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('145', '23', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('146', '23', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('147', '23', '0', '14', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('148', '23', '0', '15', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:38', '0', '0');
INSERT INTO `player_inventory` VALUES ('149', '23', '0', '16', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('150', '23', '0', '17', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('151', '23', '0', '18', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('152', '23', '0', '19', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('153', '23', '0', '20', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('154', '23', '0', '21', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('155', '23', '0', '22', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('156', '23', '0', '23', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('157', '23', '0', '24', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('158', '23', '0', '25', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('159', '23', '0', '26', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('160', '23', '0', '27', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('161', '23', '0', '28', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('162', '23', '0', '29', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('163', '23', '0', '30', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('164', '23', '0', '31', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('165', '23', '0', '32', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('166', '23', '0', '33', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('167', '23', '0', '34', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('168', '23', '0', '35', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('169', '23', '0', '36', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:39', '0', '0');
INSERT INTO `player_inventory` VALUES ('170', '23', '0', '37', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('171', '23', '0', '38', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('172', '23', '0', '39', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('173', '23', '0', '40', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('174', '23', '0', '41', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('175', '23', '0', '42', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('176', '23', '0', '43', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('177', '23', '0', '44', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('178', '23', '0', '45', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('179', '23', '0', '46', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('180', '23', '0', '47', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('181', '23', '0', '48', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('182', '23', '0', '49', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('183', '23', '0', '50', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('184', '23', '0', '51', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('185', '23', '0', '52', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('186', '23', '0', '53', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('187', '23', '0', '54', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('188', '23', '0', '55', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-10 17:43:40', '0', '0');
INSERT INTO `player_inventory` VALUES ('189', '22', '8', '0', '1', '0', '120', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '1');
INSERT INTO `player_inventory` VALUES ('190', '22', '0', '1', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('191', '22', '0', '2', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('192', '22', '0', '3', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('193', '22', '0', '4', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('194', '22', '0', '5', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('195', '22', '0', '6', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('196', '22', '0', '7', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('197', '22', '0', '8', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('198', '22', '0', '9', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('199', '22', '0', '10', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('200', '22', '0', '11', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('201', '22', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('202', '22', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('203', '22', '0', '14', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('204', '22', '0', '15', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('205', '22', '0', '16', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('206', '22', '0', '17', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('207', '22', '0', '18', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('208', '22', '0', '19', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('209', '22', '0', '20', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('210', '22', '0', '21', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('211', '22', '0', '22', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('212', '22', '0', '23', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('213', '22', '0', '24', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:05', '0', '0');
INSERT INTO `player_inventory` VALUES ('214', '22', '0', '25', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('215', '22', '0', '26', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('216', '22', '0', '27', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('217', '22', '0', '28', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('218', '22', '0', '29', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('219', '22', '0', '30', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('220', '22', '0', '31', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('221', '22', '0', '32', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('222', '22', '0', '33', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('223', '22', '0', '34', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('224', '22', '0', '35', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('225', '22', '0', '36', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('226', '22', '0', '37', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('227', '22', '0', '38', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('228', '22', '0', '39', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('229', '22', '0', '40', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('230', '22', '0', '41', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('231', '22', '0', '42', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('232', '22', '0', '43', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('233', '22', '0', '44', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('234', '22', '0', '45', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('235', '22', '0', '46', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('236', '22', '0', '47', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('237', '22', '0', '48', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('238', '22', '0', '49', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('239', '22', '0', '50', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('240', '22', '0', '51', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('241', '22', '0', '52', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('242', '22', '0', '53', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('243', '22', '0', '54', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('244', '22', '0', '55', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:06', '0', '0');
INSERT INTO `player_inventory` VALUES ('245', '23', '0', '0', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('246', '23', '0', '1', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('247', '23', '0', '2', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('248', '23', '0', '3', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('249', '23', '0', '4', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('250', '23', '0', '5', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('251', '23', '0', '6', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('252', '23', '0', '7', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('253', '23', '0', '8', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('254', '23', '0', '9', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('255', '23', '0', '10', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('256', '23', '0', '11', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('257', '23', '0', '12', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:11', '0', '0');
INSERT INTO `player_inventory` VALUES ('258', '23', '0', '13', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('259', '23', '0', '14', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('260', '23', '0', '15', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('261', '23', '0', '16', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('262', '23', '0', '17', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('263', '23', '0', '18', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('264', '23', '0', '19', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('265', '23', '0', '20', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('266', '23', '0', '21', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('267', '23', '0', '22', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('268', '23', '0', '23', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('269', '23', '0', '24', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('270', '23', '0', '25', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('271', '23', '0', '26', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('272', '23', '0', '27', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('273', '23', '0', '28', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('274', '23', '0', '29', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('275', '23', '0', '30', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('276', '23', '0', '31', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('277', '23', '0', '32', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('278', '23', '0', '33', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('279', '23', '0', '34', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('280', '23', '0', '35', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('281', '23', '0', '36', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('282', '23', '0', '37', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('283', '23', '0', '38', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('284', '23', '0', '39', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('285', '23', '0', '40', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('286', '23', '0', '41', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('287', '23', '0', '42', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('288', '23', '0', '43', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('289', '23', '0', '44', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('290', '23', '0', '45', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('291', '23', '0', '46', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('292', '23', '0', '47', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('293', '23', '0', '48', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:12', '0', '0');
INSERT INTO `player_inventory` VALUES ('294', '23', '0', '49', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');
INSERT INTO `player_inventory` VALUES ('295', '23', '0', '50', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');
INSERT INTO `player_inventory` VALUES ('296', '23', '0', '51', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');
INSERT INTO `player_inventory` VALUES ('297', '23', '0', '52', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');
INSERT INTO `player_inventory` VALUES ('298', '23', '0', '53', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');
INSERT INTO `player_inventory` VALUES ('299', '23', '0', '54', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');
INSERT INTO `player_inventory` VALUES ('300', '23', '0', '55', '0', '0', '0', '0,0,0,0,0,0,0,0,0', '0', '2017-06-17 19:43:13', '0', '0');

-- ----------------------------
-- Table structure for player_skill
-- ----------------------------
DROP TABLE IF EXISTS `player_skill`;
CREATE TABLE `player_skill` (
  `char_id` int(11) NOT NULL,
  `skill_id` int(11) NOT NULL,
  `skill_level` smallint(6) NOT NULL DEFAULT '1',
  `skill_exp` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`char_id`,`skill_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of player_skill
-- ----------------------------

-- ----------------------------
-- Table structure for player_talent
-- ----------------------------
DROP TABLE IF EXISTS `player_talent`;
CREATE TABLE `player_talent` (
  `char_id` int(11) NOT NULL DEFAULT '0',
  `talent_id` int(11) NOT NULL DEFAULT '0',
  `talent_level` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`char_id`,`talent_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of player_talent
-- ----------------------------

-- ----------------------------
-- Table structure for talents
-- ----------------------------
DROP TABLE IF EXISTS `talents`;
CREATE TABLE `talents` (
  `id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) NOT NULL DEFAULT '',
  `req_talent_id` int(11) NOT NULL DEFAULT '0',
  `req_talent_level` int(6) NOT NULL DEFAULT '1',
  `type` tinyint(1) NOT NULL DEFAULT '0',
  `data_type` tinyint(1) NOT NULL DEFAULT '0',
  `skill_id` int(11) NOT NULL DEFAULT '0',
  `skill_effect_id` int(11) NOT NULL DEFAULT '0',
  `max_level` int(11) NOT NULL DEFAULT '1',
  `strenght` int(11) NOT NULL DEFAULT '0',
  `dexterity` int(11) NOT NULL DEFAULT '0',
  `agility` int(11) NOT NULL DEFAULT '0',
  `constitution` int(11) NOT NULL DEFAULT '0',
  `intelligence` int(11) NOT NULL DEFAULT '0',
  `wisdom` int(11) NOT NULL DEFAULT '0',
  `will` int(11) NOT NULL DEFAULT '0',
  `mind` int(11) NOT NULL DEFAULT '0',
  `hp` int(11) NOT NULL DEFAULT '0',
  `mp` int(11) NOT NULL DEFAULT '0',
  `sp` int(11) NOT NULL DEFAULT '0',
  `regen_hp` int(11) NOT NULL DEFAULT '0',
  `regen_mp` int(11) NOT NULL DEFAULT '0',
  `regen_sp` int(11) NOT NULL DEFAULT '0',
  `critical_rate` int(11) NOT NULL DEFAULT '0',
  `critical_damage` int(11) NOT NULL DEFAULT '0',
  `magic_critical_rate` int(11) NOT NULL DEFAULT '0',
  `magic_critical_damage` int(11) NOT NULL DEFAULT '0',
  `concentration` int(11) NOT NULL DEFAULT '0',
  `healing_power` int(11) NOT NULL DEFAULT '0',
  `attack` int(11) NOT NULL DEFAULT '0',
  `accuracy` int(11) NOT NULL DEFAULT '0',
  `defense` int(11) NOT NULL DEFAULT '0',
  `evasion` int(11) NOT NULL DEFAULT '0',
  `parry` int(11) NOT NULL DEFAULT '0',
  `block` int(11) NOT NULL DEFAULT '0',
  `magic_attack` int(11) NOT NULL DEFAULT '0',
  `magic_accuracy` int(11) NOT NULL DEFAULT '0',
  `magic_defense` int(11) NOT NULL DEFAULT '0',
  `magic_resist` int(11) NOT NULL DEFAULT '0',
  `damage_suppression` int(11) NOT NULL DEFAULT '0',
  `additional_damage` int(11) NOT NULL DEFAULT '0',
  `enmity` int(11) NOT NULL DEFAULT '0',
  `attack_speed` int(11) NOT NULL DEFAULT '0',
  `cast_speed` int(11) NOT NULL DEFAULT '0',
  `attribute_fire` int(11) NOT NULL DEFAULT '0',
  `attribute_water` int(11) NOT NULL DEFAULT '0',
  `attribute_earth` int(11) NOT NULL DEFAULT '0',
  `attribute_wind` int(11) NOT NULL DEFAULT '0',
  `attribute_dark` int(11) NOT NULL DEFAULT '0',
  `attribute_light` int(11) NOT NULL DEFAULT '0',
  `resist_stun` int(11) NOT NULL DEFAULT '0',
  `resist_silence` int(11) NOT NULL DEFAULT '0',
  `resist_paralysis` int(11) NOT NULL DEFAULT '0',
  `resist_blind` int(11) NOT NULL DEFAULT '0',
  `resist_critical_rate` int(11) NOT NULL DEFAULT '0',
  `resist_critical_damage` int(11) NOT NULL DEFAULT '0',
  `resist_magic_critical_rate` int(11) NOT NULL DEFAULT '0',
  `resist_magic_critical_damage` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of talents
-- ----------------------------
INSERT INTO `talents` VALUES ('1', 'Aumentar Ataque', '0', '0', '0', '0', '0', '0', '100', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `talents` VALUES ('2', 'Aumentar Defesa', '0', '1', '0', '0', '0', '0', '100', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
