-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 24, 2018 at 07:01 AM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `it_2d`
--

-- --------------------------------------------------------

--
-- Table structure for table `penalty`
--

CREATE TABLE `penalty` (
  `ID` int(20) NOT NULL,
  `day` int(20) NOT NULL,
  `week` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penalty`
--

INSERT INTO `penalty` (`ID`, `day`, `week`) VALUES
(1, 24, 7),
(2, 28, 8);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_activitylog`
--

CREATE TABLE `tbl_activitylog` (
  `librarian_id` bigint(200) NOT NULL,
  `activity` varchar(200) NOT NULL,
  `account_no` varchar(200) NOT NULL,
  `date_activity` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_activitylog`
--

INSERT INTO `tbl_activitylog` (`librarian_id`, `activity`, `account_no`, `date_activity`) VALUES
(1, ' Login', '1', '2017-03-23 12:46:29'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:46:38'),
(1, ' Paid Fine', '20141113002', '2017-03-23 12:47:08'),
(1, ' Logout', '1', '2017-03-23 12:47:14'),
(1, ' Login', '1', '2017-03-23 12:47:41'),
(1, ' Paid Fine', '20141113002', '2017-03-23 12:47:51'),
(1, ' Login', '1', '2017-03-23 12:48:35'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:48:45'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:48:51'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:48:54'),
(1, ' Logout', '1', '2017-03-23 12:48:58'),
(1, ' Login', '1', '2017-03-23 12:49:10'),
(1, ' Paid Fine', '20141113002', '2017-03-23 12:49:16'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:49:28'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:49:32'),
(1, ' Paid Fine', '20141113000', '2017-03-23 12:49:51'),
(1, ' Logout', '1', '2017-03-23 12:49:58'),
(1, ' Login', '1', '2017-03-23 12:51:49'),
(1, ' Logout', '1', '2017-03-23 12:52:25'),
(1, ' Login', '1', '2017-03-23 12:53:27'),
(1, ' Logout', '1', '2017-03-23 12:53:39'),
(1, ' Login', '1', '2017-03-23 13:06:48'),
(1, ' Paid Fine', '20141113000', '2017-03-23 13:07:13'),
(1, ' Login', '1', '2017-03-23 13:07:58'),
(1, ' Logout', '1', '2017-03-23 13:08:09'),
(1, ' Login', '1', '2017-03-23 13:12:33'),
(1, ' Paid Fine', '20141113000', '2017-03-23 13:12:43'),
(1, ' Logout', '1', '2017-03-23 13:12:57'),
(1, ' Login', '1', '2017-03-23 13:15:12'),
(1, ' Paid Fine', '20141113000', '2017-03-23 13:15:19'),
(1, ' Logout', '1', '2017-03-23 13:15:24'),
(1, ' Login', '1', '2017-03-23 13:37:31'),
(1, ' Login', '1', '2017-03-23 13:41:03'),
(1, ' Login', '1', '2017-03-23 13:46:07'),
(1, ' Logout', '1', '2017-03-23 13:48:53'),
(1, ' Login', '1', '2017-03-23 14:12:28'),
(1, ' Login', '1', '2017-03-23 14:19:35'),
(1, ' Login', '1', '2017-03-23 14:48:23'),
(1, ' Logout', '1', '2017-03-23 14:50:45'),
(1, ' Login', '1', '2017-03-23 14:53:14'),
(1, ' Logout', '1', '2017-03-23 14:53:49'),
(1, ' Login', '1', '2017-03-23 14:54:29'),
(1, ' Logout', '1', '2017-03-23 14:54:53'),
(1, ' Login', '1', '2017-03-23 14:56:46'),
(1, ' Login', '1', '2017-03-23 15:01:27'),
(1, ' Logout', '1', '2017-03-23 15:02:10'),
(1, ' Login', '1', '2017-03-23 15:08:39'),
(1, ' Logout', '1', '2017-03-23 15:09:05'),
(1, ' Login', '1', '2017-03-23 15:09:25'),
(1, ' Logout', '1', '2017-03-23 15:09:34'),
(1, ' Login', '1', '2017-03-23 15:10:26'),
(1, ' Logout', '1', '2017-03-23 15:10:39'),
(1, ' Login', '1', '2017-03-23 15:12:21'),
(1, ' Logout', '1', '2017-03-23 15:13:26'),
(1, ' Login', '1', '2017-03-23 15:19:42'),
(1, ' Logout', '1', '2017-03-23 15:20:05'),
(1, ' Login', '1', '2017-03-23 15:27:44'),
(1, ' Logout', '1', '2017-03-23 15:27:57'),
(1, ' Login', '1', '2017-03-23 15:34:41'),
(1, ' Login', '1', '2017-03-23 15:35:42'),
(1, ' Login', '1', '2017-03-23 15:36:44'),
(1, ' Login', '1', '2017-03-23 15:42:44'),
(1, ' Login', '1', '2017-03-23 15:43:39'),
(1, ' Login', '1', '2017-03-23 15:44:09'),
(1, ' Logout', '1', '2017-03-23 15:44:36'),
(1, ' Login', '1', '2017-03-23 15:50:30'),
(1, ' Logout', '1', '2017-03-23 15:50:44'),
(1, ' Login', '1', '2017-03-23 15:51:33'),
(1, ' Login', '1', '2017-03-23 15:53:54'),
(1, ' Login', '1', '2017-03-23 15:59:15'),
(1, ' Login', '1', '2017-03-23 16:01:21'),
(1, ' Login', '1', '2017-03-23 16:30:39'),
(1, ' Insert new Account', '5', '2017-03-23 16:31:03'),
(1, ' Insert new Account', '6', '2017-03-23 16:31:23'),
(1, ' Insert new Account', '20141113007', '2017-03-23 16:32:20'),
(1, ' Edit Account', '20141113004', '2017-03-23 16:32:34'),
(1, ' Insert new Account', '20141113010', '2017-03-23 16:33:08'),
(1, ' Insert new Account', '20101113011', '2017-03-23 16:33:54'),
(1, ' Edit Account', '20101113011', '2017-03-23 16:34:15'),
(1, ' Insert new item', 'D001', '2017-03-23 16:35:04'),
(1, ' Edit item', 'M002', '2017-03-23 16:35:31'),
(1, ' Edit item', 'D001', '2017-03-23 16:35:36'),
(1, ' Insert new item', 'C003', '2017-03-23 16:36:40'),
(1, ' Insert new item', 'C004', '2017-03-23 16:37:18'),
(1, ' Insert new item', 'D004', '2017-03-23 16:38:35'),
(1, ' Insert new item', 'B010', '2017-03-23 16:39:30'),
(1, ' Logout', '1', '2017-03-23 16:40:09'),
(2, ' Login', '2', '2017-03-23 16:42:27'),
(2, ' Insert new Account', '20091114000', '2017-03-23 16:43:43'),
(2, ' Edit Account', '20101113011', '2017-03-23 16:44:24'),
(2, ' Insert new item', 'M001', '2017-03-23 16:45:38'),
(2, ' Logout', '2', '2017-03-23 16:46:14'),
(1, ' Login', '1', '2017-03-23 17:11:08'),
(1, ' Logout', '1', '2017-03-23 17:14:24'),
(1, ' Login', '1', '2017-03-23 17:14:31'),
(1, ' Logout', '1', '2017-03-23 17:16:23'),
(1, ' Login', '1', '2017-03-23 17:25:08'),
(1, ' Login', '1', '2017-03-23 17:26:19'),
(1, ' Login', '1', '2017-03-23 17:27:26'),
(1, ' Login', '1', '2017-03-23 17:28:00'),
(1, ' Login', '1', '2017-03-23 17:31:16'),
(1, ' Login', '1', '2017-03-23 17:36:10'),
(1, ' Login', '1', '2017-03-23 17:39:04'),
(1, ' Login', '1', '2017-03-23 17:40:43'),
(1, ' Login', '1', '2017-03-23 17:41:48'),
(1, ' Logout', '1', '2017-03-23 17:41:56'),
(1, ' Login', '1', '2017-03-23 17:45:50'),
(1, ' Logout', '1', '2017-03-23 17:46:00'),
(1, ' Login', '1', '2017-03-23 17:46:39'),
(1, ' Logout', '1', '2017-03-23 17:46:44'),
(1, ' Login', '1', '2017-03-23 17:47:41'),
(1, ' Logout', '1', '2017-03-23 17:47:49'),
(1, ' Login', '1', '2017-03-23 17:48:46'),
(1, ' Paid Fine', '2014111', '2017-03-23 17:48:55'),
(1, ' Logout', '1', '2017-03-23 17:49:13'),
(1, ' Login', '1', '2017-03-23 17:50:56'),
(1, ' Logout', '1', '2017-03-23 17:51:34'),
(1, ' Login', '1', '2017-03-23 17:51:46'),
(1, ' Logout', '1', '2017-03-23 17:52:57'),
(1, ' Login', '1', '2017-03-23 17:53:41'),
(1, ' Paid Fine', '20141113000', '2017-03-23 17:53:54'),
(1, ' Logout', '1', '2017-03-23 17:54:37'),
(1, ' Login', '1', '2017-03-23 17:55:32'),
(1, ' Logout', '1', '2017-03-23 17:56:38'),
(1, ' Login', '1', '2017-03-23 18:07:47'),
(1, ' Logout', '1', '2017-03-23 18:08:18'),
(1, ' Login', '1', '2017-03-23 18:08:21'),
(1, ' Paid Fine', '2321321', '2017-03-23 18:08:28'),
(1, ' Login', '1', '2017-03-23 18:10:19'),
(1, ' Paid Fine', '20141113000', '2017-03-23 18:10:26'),
(1, ' Login', '1', '2017-03-23 18:15:08'),
(0, ' Logout', '', '2017-03-23 18:15:12'),
(1, ' Login', '1', '2017-03-23 18:15:48'),
(0, ' Paid Fine', '20141113000', '2017-03-23 18:15:53'),
(0, ' Logout', '', '2017-03-23 18:16:10'),
(1, ' Login', '1', '2017-03-23 18:18:54'),
(0, ' Paid Fine', '3221321', '2017-03-23 18:19:00'),
(1, ' Login', '1', '2017-03-23 18:35:35'),
(0, ' Logout', '', '2017-03-23 18:35:47'),
(1, ' Login', '1', '2017-03-23 18:38:22'),
(1, ' Logout', '1', '2017-03-23 18:39:09'),
(1, ' Login', '1', '2017-03-23 18:39:12'),
(1, ' Paid Fine', '20141113000', '2017-03-23 18:39:26'),
(1, ' Login', '1', '2017-03-23 21:55:13'),
(1, ' Login', '1', '2017-03-23 22:00:31'),
(1, ' Login', '1', '2017-03-23 22:02:36'),
(1, ' Login', '1', '2017-03-23 22:04:01'),
(1, ' Login', '1', '2017-03-23 22:09:24'),
(1, ' Login', '1', '2017-03-23 22:13:30'),
(1, ' Login', '1', '2017-03-23 22:14:50'),
(1, ' Login', '1', '2017-03-23 22:15:46'),
(1, ' Login', '1', '2017-03-23 22:16:44'),
(1, ' Login', '1', '2017-03-23 22:17:13'),
(1, ' Login', '1', '2017-03-23 22:18:57'),
(1, ' Login', '1', '2017-03-23 22:19:46'),
(1, ' Login', '1', '2017-03-23 22:20:50'),
(1, ' Logout', '1', '2017-03-23 22:21:05'),
(1, ' Login', '1', '2017-03-23 22:23:37'),
(1, ' Login', '1', '2017-03-23 22:23:58'),
(1, ' Login', '1', '2017-03-23 22:25:16'),
(1, ' Login', '1', '2017-03-23 22:26:18'),
(1, ' Login', '1', '2017-03-23 22:27:30'),
(1, ' Login', '1', '2017-03-23 22:28:23'),
(1, ' Login', '1', '2017-03-23 22:30:37'),
(1, ' Login', '1', '2017-03-23 22:31:36'),
(1, ' Login', '1', '2017-03-23 22:32:13'),
(1, ' Login', '1', '2017-03-23 22:32:41'),
(1, ' Login', '1', '2017-03-23 22:34:15'),
(1, ' Login', '1', '2017-03-23 22:36:17'),
(1, ' Login', '1', '2017-03-23 22:37:37'),
(1, ' Login', '1', '2017-03-23 22:37:58'),
(1, ' Login', '1', '2017-03-23 22:38:47'),
(1, ' Login', '1', '2017-03-23 22:41:02'),
(1, ' Login', '1', '2017-03-23 22:43:26'),
(1, ' Login', '1', '2017-03-23 22:43:48'),
(1, ' Login', '1', '2017-03-23 22:44:49'),
(1, ' Login', '1', '2017-03-23 22:45:17'),
(1, ' Login', '1', '2017-03-23 22:45:45'),
(1, ' Login', '1', '2017-03-23 22:46:13'),
(1, ' Login', '1', '2017-03-23 22:47:33'),
(1, ' Login', '1', '2017-03-23 22:48:23'),
(1, ' Login', '1', '2017-03-23 22:50:03'),
(1, ' Login', '1', '2017-03-23 22:50:25'),
(1, ' Login', '1', '2017-03-23 22:51:47'),
(1, ' Login', '1', '2017-03-23 22:54:37'),
(1, ' Login', '1', '2017-03-23 22:58:26'),
(1, ' Login', '1', '2017-03-23 22:59:06'),
(1, ' Login', '1', '2017-03-23 23:00:37'),
(1, ' Login', '1', '2017-03-23 23:02:20'),
(1, ' Login', '1', '2017-03-23 23:03:59'),
(1, ' Login', '1', '2017-03-23 23:05:14'),
(1, ' Login', '1', '2017-03-23 23:09:56'),
(1, ' Login', '1', '2017-03-23 23:13:44'),
(1, ' Login', '1', '2017-03-23 23:15:00'),
(1, ' Login', '1', '2017-03-23 23:17:02'),
(1, ' Login', '1', '2017-03-24 13:40:13'),
(1, ' Login', '1', '2017-03-24 13:42:27'),
(1, ' Login', '1', '2017-03-24 13:45:22'),
(1, ' Login', '1', '2017-03-24 13:47:14'),
(1, ' Paid Fine', '20141113000', '2017-03-24 13:47:25'),
(1, ' Login', '1', '2017-03-24 14:08:02'),
(1, ' Login', '1', '2017-03-24 14:22:07'),
(1, ' Login', '1', '2017-03-24 14:24:28'),
(1, ' Login', '1', '2017-03-24 14:27:53'),
(1, ' Login', '1', '2017-03-24 14:29:06'),
(1, ' Login', '1', '2017-03-24 14:32:19'),
(1, ' Paid Fine', '20141113002', '2017-03-24 14:32:55'),
(1, ' Login', '1', '2017-03-24 14:34:17'),
(1, ' Login', '1', '2017-03-24 14:36:10'),
(1, ' Login', '1', '2017-03-24 14:40:39'),
(1, ' Logout', '1', '2017-03-24 14:40:48'),
(1, ' Login', '1', '2017-03-24 14:43:21'),
(1, ' Logout', '1', '2017-03-24 14:43:32'),
(1, ' Login', '1', '2017-03-24 14:44:55'),
(1, ' Borrow Item', '20101113000', '2017-03-24 14:45:19'),
(1, ' Borrow Item', '20141113000', '2017-03-24 14:46:24'),
(1, ' Logout', '1', '2017-03-24 14:46:43'),
(1, ' Login', '1', '2017-03-24 14:46:47'),
(1, ' Login', '1', '2017-03-24 14:53:22'),
(1, ' Login', '1', '2017-03-24 14:59:51'),
(1, ' Logout', '1', '2017-03-24 15:00:09'),
(1, ' Login', '1', '2017-03-24 15:06:09'),
(1, ' Login', '1', '2017-03-24 15:07:19'),
(1, ' Login', '1', '2017-03-24 15:10:41'),
(1, ' Paid Fine', '20141113001', '2017-03-24 15:10:57'),
(1, ' Login', '1', '2017-03-24 15:11:55'),
(1, ' Borrow Item', '20141113010', '2017-03-24 15:12:42'),
(1, ' Borrow Item', '20141113001', '2017-03-24 15:13:08'),
(1, ' Paid Fine', '20141113010', '2017-03-24 15:14:27'),
(1, ' Login', '1', '2017-03-24 15:17:07'),
(1, ' Logout', '1', '2017-03-24 15:17:09'),
(1, ' Login', '1', '2017-03-24 15:18:00'),
(1, ' Logout', '1', '2017-03-24 15:18:09'),
(1, ' Login', '1', '2017-03-24 15:22:26'),
(1, ' Insert new Account', '7', '2017-03-24 15:23:15'),
(1, ' Insert new item', 'B011', '2017-03-24 15:23:56'),
(1, ' Paid Fine', '20141113001', '2017-03-24 15:24:54'),
(1, ' Borrow Item', '20131113002', '2017-03-24 15:25:32'),
(1, ' Logout', '1', '2017-03-24 15:25:37'),
(1, ' Login', '1', '2017-03-24 15:25:43'),
(1, ' Paid Fine', '20131113002', '2017-03-24 15:25:52'),
(1, ' Login', '1', '2017-03-24 15:33:15'),
(1, ' Login', '1', '2017-03-24 15:52:13'),
(1, ' Logout', '1', '2017-03-24 16:07:14'),
(1, ' Login', '1', '2017-03-26 22:21:15'),
(20141113001, ' Login', '20141113001', '2018-08-24 12:24:38'),
(20141113001, ' Logout', '20141113001', '2018-08-24 12:24:56'),
(1, ' Login', '1', '2018-08-24 12:25:09'),
(1, ' Login', '1', '2018-08-24 12:26:27'),
(1, ' Login', '1', '2018-08-24 12:29:29'),
(1, ' Edit Account', '4', '2018-08-24 12:30:02'),
(1, ' Logout', '1', '2018-08-24 12:31:17');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `a_un` bigint(200) NOT NULL,
  `a_pass` varchar(200) NOT NULL,
  `a_fname` char(200) NOT NULL,
  `a_lname` char(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`a_un`, `a_pass`, `a_fname`, `a_lname`) VALUES
(1, 'ad123@', 'bryan', 'ortega'),
(4, 'ad123@', 'keizer', 'devega'),
(2, 'ad123@', 'agee olarde', 'garcia'),
(5, 'ad123@', 'hana', 'directo'),
(6, 'ad123@', 'yuka', 'horiguchi'),
(7, 'ad1234', 'keizer', 'edison');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_borrow`
--

CREATE TABLE `tbl_borrow` (
  `b_no` varchar(200) NOT NULL,
  `b_title` varchar(50) NOT NULL,
  `b_author` varchar(50) NOT NULL,
  `u_un` bigint(255) NOT NULL,
  `d_borrowed` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_borrow`
--

INSERT INTO `tbl_borrow` (`b_no`, `b_title`, `b_author`, `u_un`, `d_borrowed`) VALUES
('M001', 'Time 2016', 'Time Warner', 20101113000, '2017-03-24'),
('B001', 'English Literatue 3', 'Green, D.', 20141113000, '2017-02-27'),
('M001', 'Time 2016', 'Time Warner', 20141113010, '2017-03-17'),
('C003', 'Database Tutorial', 'Ashir, B.', 20141113001, '2017-03-10'),
('B002', 'Electricity', 'Newton, I.', 20131113002, '2017-02-14');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_borrowlist`
--

CREATE TABLE `tbl_borrowlist` (
  `b_no` varchar(200) NOT NULL,
  `u_un` bigint(200) NOT NULL,
  `b_title` varchar(50) NOT NULL,
  `b_author` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_borrowlist`
--

INSERT INTO `tbl_borrowlist` (`b_no`, `u_un`, `b_title`, `b_author`) VALUES
('B002', 20141113004, 'Electricity', 'Newton, I.'),
('B002', 20131113002, 'Electricity', 'Newton, I.'),
('B002', 20101113000, 'Electricity', 'Newton, I.'),
('B001', 20101113000, 'English Literatue 3', 'Green, D.'),
('B002', 20141113002, 'Electricity', 'Newton, I.'),
('B002', 20141113002, 'Electricity', 'Newton, I.'),
('B002', 20101113000, 'Electricity', 'Newton, I.'),
('B002', 20131113002, 'Electricity', 'Newton, I.'),
('B002', 20141113004, 'Electricity', 'Newton, I.'),
('B002', 20141113000, 'Electricity', 'Newton, I.'),
('B002', 20131113002, 'Electricity', 'Newton, I.'),
('B002', 20101113000, 'Electricity', 'Newton, I.'),
('M001', 20101113000, 'Time 2016', 'Time Warner'),
('B001', 20141113000, 'English Literatue 3', 'Green, D.'),
('M001', 20141113010, 'Time 2016', 'Time Warner'),
('C003', 20141113001, 'Database Tutorial', 'Ashir, B.'),
('B002', 20131113002, 'Electricity', 'Newton, I.');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_itemlist`
--

CREATE TABLE `tbl_itemlist` (
  `b_no` varchar(200) NOT NULL,
  `b_medium` varchar(200) NOT NULL,
  `b_title` varchar(200) NOT NULL,
  `b_author` char(200) NOT NULL,
  `b_category` char(200) NOT NULL,
  `b_copies` int(200) NOT NULL,
  `b_copyright` date NOT NULL,
  `b_dateadd` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_itemlist`
--

INSERT INTO `tbl_itemlist` (`b_no`, `b_medium`, `b_title`, `b_author`, `b_category`, `b_copies`, `b_copyright`, `b_dateadd`) VALUES
('B001', 'Book', 'English Literatue 3', 'Green, D.', 'Linguistics', 10, '2017-03-21', '2017-03-21'),
('B002', 'Book', 'Electricity', 'Newton, I.', 'Science', 9, '2013-08-14', '2017-03-21'),
('M002', 'Magazine', 'Time 2015', 'Time Warner', 'Entertainment', 1, '2017-03-21', '2017-03-21'),
('D001', 'Document', 'Thesis Writing', 'Holland, G.', 'Technology', 6, '2017-03-23', '2017-03-23'),
('C003', 'CD/DVD', 'Database Tutorial', 'Ashir, B.', 'Technology', 1, '2003-10-01', '2017-03-23'),
('C004', 'CD/DVD', 'Database Tutorial 2', 'Ashir, B.', 'Technology', 4, '2004-02-04', '2017-03-23'),
('D004', 'Document', 'Thesis Writing Doctoral', 'Holland, G.', 'Technology', 5, '2004-02-04', '2017-03-23'),
('B010', 'Book', 'Electromagnetism', 'Tesla, I.', 'Science', 3, '1975-12-01', '2017-03-23'),
('M001', 'Magazine', 'Time 2016', 'Time Warner', 'Entertainment', 11, '2017-03-23', '2017-03-23'),
('B011', 'Book', 'english', 'green', 'Linguistics', 1, '2017-03-24', '2017-03-24');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_penalty`
--

CREATE TABLE `tbl_penalty` (
  `b_no` varchar(200) NOT NULL,
  `u_un` bigint(200) NOT NULL,
  `d_borrowed` date NOT NULL,
  `d_returned` date NOT NULL,
  `fine` int(200) NOT NULL,
  `fineday` int(20) NOT NULL,
  `fineweek` int(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_penalty`
--

INSERT INTO `tbl_penalty` (`b_no`, `u_un`, `d_borrowed`, `d_returned`, `fine`, `fineday`, `fineweek`) VALUES
('B001', 20141113000, '2017-02-27', '0000-00-00', 0, 0, 0),
('M001', 20101113000, '2017-03-24', '0000-00-00', 3597, 0, 0),
('PENALTY', 0, '2017-03-01', '2017-03-01', 3758, 7, 20);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_receipt`
--

CREATE TABLE `tbl_receipt` (
  `u_un` bigint(255) NOT NULL,
  `b_no` varchar(200) NOT NULL,
  `d_receipt` datetime NOT NULL,
  `librarian_id` int(200) NOT NULL,
  `fine` int(200) NOT NULL,
  `cash` int(200) NOT NULL,
  `fchange` int(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_receipt`
--

INSERT INTO `tbl_receipt` (`u_un`, `b_no`, `d_receipt`, `librarian_id`, `fine`, `cash`, `fchange`) VALUES
(20141113000, 'b2312', '2017-03-23 18:15:53', 0, 87, 200, 113),
(3221321, 'b23', '2017-03-23 18:19:00', 0, 136, 200, 64),
(20141113000, 'b2321', '2017-03-23 18:39:26', 1, 136, 200, 64),
(20141113000, 'B002', '2017-03-24 13:47:25', 1, 54, 60, 6),
(20141113002, 'B001', '2017-03-24 14:32:55', 1, 28, 30, 2),
(20141113001, 'B001', '2017-03-24 15:10:58', 1, 133, 150, 17),
(20141113010, 'M001', '2017-03-24 15:14:27', 1, 20, 20, 0),
(20141113001, 'C003', '2017-03-24 15:24:54', 1, 69, 70, 1),
(20131113002, 'B002', '2017-03-24 15:25:52', 1, 237, 500, 263);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_request`
--

CREATE TABLE `tbl_request` (
  `u_un` bigint(200) NOT NULL,
  `b_title` varchar(200) NOT NULL,
  `b_medium` varchar(200) NOT NULL,
  `d_requested` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_return`
--

CREATE TABLE `tbl_return` (
  `b_no` varchar(200) NOT NULL,
  `u_un` bigint(200) NOT NULL,
  `d_returned` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `u_un` bigint(255) NOT NULL,
  `u_pass` varchar(200) NOT NULL,
  `u_fname` char(200) NOT NULL,
  `u_lname` char(200) NOT NULL,
  `u_type` char(10) NOT NULL,
  `u_dept` char(200) NOT NULL,
  `u_year` int(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`u_un`, `u_pass`, `u_fname`, `u_lname`, `u_type`, `u_dept`, `u_year`) VALUES
(20141113001, 'ad123@', 'erwin', 'lagda', 'Faculty', 'DCSS', 1),
(20141113000, 'ad123@', 'keizer', 'devega', 'Student', 'Engineering', 3),
(20141113002, 'ad123@', 'yuka', 'horiguchi', 'Student', 'Engineering', 3),
(20141113004, 'ad123@', 'hana', 'directo', 'Student', 'DCSS', 2),
(20131113002, 'ad123@', 'martin', 'rumualdez', 'Faculty', 'CSA', 1),
(20101113000, 'ad123@', 'bryan', 'apolonio', 'Faculty', 'Engineering', 13),
(20141113007, 'qwerty123', 'Ricky', 'Martin', 'Student', 'CSA', 2),
(20141113010, 'qwerty123', 'Carlo', 'Anteza', 'Student', 'DCSS', 4),
(20101113011, 'qwerty123', 'John Paul', 'Apolonio', 'Faculty', 'DCSS', 5),
(20091114000, 'qwerty123', 'Ho Lee', 'Shi', 'Faculty', 'DCSS', 11);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `penalty`
--
ALTER TABLE `penalty`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`a_un`);

--
-- Indexes for table `tbl_borrow`
--
ALTER TABLE `tbl_borrow`
  ADD PRIMARY KEY (`u_un`);

--
-- Indexes for table `tbl_itemlist`
--
ALTER TABLE `tbl_itemlist`
  ADD PRIMARY KEY (`b_no`);

--
-- Indexes for table `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`u_un`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `penalty`
--
ALTER TABLE `penalty`
  MODIFY `ID` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
