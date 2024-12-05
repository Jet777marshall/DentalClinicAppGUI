-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 05, 2024 at 05:53 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dentaldb`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `procInsertStudent` (`p_studentid` VARCHAR(8), `p_lastname` VARCHAR(50), `p_firstname` VARCHAR(50), `p_middlename` VARCHAR(50), `p_birthdate` DATE, `p_address` VARCHAR(50), `p_gender` VARCHAR(8), `p_emailadd` VARCHAR(45), `p_contactno` VARCHAR(11), `p_student_photo` VARCHAR(500))   BEGIN
	       INSERT INTO TBLSTUDENT(
	                              STUDENTID,
	                              LASTNAME,
	                              FIRSTNAME,
	                              MIDDLENAME,
	                              BIRTHDATE,
	                              GENDER,
	                              ADDRESS,
	                              EMAILADD,
	                              CONTACTNO,
	                              STUDENT_PHOTO)
	                              
	                              
	              VALUES(
	              p_studentid,
                      p_lastname,
                      p_firstname,
                      p_middlename,
                      p_birthdate,
                      p_address,
                      p_gender,
                      p_emailadd,
                      p_contactno,
                      p_student_photo);                   
	            

	END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `accreccep`
--

CREATE TABLE `accreccep` (
  `ReceptionistID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `Lastname` varchar(50) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `DateOfBirth` varchar(50) NOT NULL,
  `Address` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `accreccep`
--

INSERT INTO `accreccep` (`ReceptionistID`, `FirstName`, `Lastname`, `gender`, `DateOfBirth`, `Address`, `Username`, `Password`) VALUES
(1, 'qwe', 'qwe', 'Female', 'Thursday, July 8, 2010', 'qwe', 'qwe', 'love'),
(5, 'as', 'fg', 'Male', 'Sunday, 29 September 2024', 'Davao', 'kaan', '123'),
(6, 'ezka', 'malika', 'Female', 'Wednesday, June 13, 1990', 'davao city', 'ezka123', 'ezka');

-- --------------------------------------------------------

--
-- Table structure for table `doctortb`
--

CREATE TABLE `doctortb` (
  `username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctortb`
--

INSERT INTO `doctortb` (`username`, `Password`) VALUES
('dr.jose', 'cliff');

-- --------------------------------------------------------

--
-- Table structure for table `patiencetb`
--

CREATE TABLE `patiencetb` (
  `ProcedureID` int(11) NOT NULL,
  `Firstname` varchar(50) NOT NULL,
  `Lastname` varchar(50) NOT NULL,
  `Procedurename` varchar(50) NOT NULL,
  `Procedurecost` int(11) NOT NULL,
  `Executedate` varchar(50) NOT NULL,
  `Executetime` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patiencetb`
--

INSERT INTO `patiencetb` (`ProcedureID`, `Firstname`, `Lastname`, `Procedurename`, `Procedurecost`, `Executedate`, `Executetime`) VALUES
(10, 'samantha', 'pogi', 'Braces', 50, 'Friday, March 8, 2024', '7:00am');

-- --------------------------------------------------------

--
-- Table structure for table `receptionistdb`
--

CREATE TABLE `receptionistdb` (
  `PatienceID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `DateOfBirth` varchar(50) NOT NULL,
  `Gender` varchar(50) NOT NULL,
  `PhoneNumber` int(11) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Address` varchar(50) NOT NULL,
  `EmergencyContact` int(11) NOT NULL,
  `MedicalHistory` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `receptionistdb`
--

INSERT INTO `receptionistdb` (`PatienceID`, `FirstName`, `LastName`, `DateOfBirth`, `Gender`, `PhoneNumber`, `Email`, `Address`, `EmergencyContact`, `MedicalHistory`) VALUES
(2, 'as', 'lakina', 'Thursday, 14 July 2005', 'female', 911, 'lakina@gmaill.com', 'Davao city', 123, 'none'),
(3, 'df', 'df', 'Monday, 30 September 2024', 'df', 123, 'df', 'df', 1234, 'df'),
(4, 'samantha', 'pogi', 'Thursday, July 18, 2024', 'male', 911, 'asas@gmail.com', 'asdf', 0, 'none'),
(5, 'qwe', 'qwe', 'Thursday, October 3, 2024', 'male', 911, 'df@gmail.com', 'davao city', 911, '911'),
(7, 'as', 'qwe', 'Wednesday, June 12, 2024', 'male', 911, 'as@gmail.com', 'davao city', 911, 'none'),
(8, 'sam', 'Manuel', 'Tuesday, June 18, 2019', 'Female', 91212, 'sam@gmail.com', 'Gensan', 911, 'none');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accreccep`
--
ALTER TABLE `accreccep`
  ADD PRIMARY KEY (`ReceptionistID`),
  ADD UNIQUE KEY `FirstName` (`FirstName`);

--
-- Indexes for table `patiencetb`
--
ALTER TABLE `patiencetb`
  ADD PRIMARY KEY (`ProcedureID`);

--
-- Indexes for table `receptionistdb`
--
ALTER TABLE `receptionistdb`
  ADD PRIMARY KEY (`PatienceID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accreccep`
--
ALTER TABLE `accreccep`
  MODIFY `ReceptionistID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `patiencetb`
--
ALTER TABLE `patiencetb`
  MODIFY `ProcedureID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `receptionistdb`
--
ALTER TABLE `receptionistdb`
  MODIFY `PatienceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
