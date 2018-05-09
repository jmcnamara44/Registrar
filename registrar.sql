-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 10, 2018 at 01:36 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: registrar
--
CREATE DATABASE IF NOT EXISTS registrar DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE registrar;

-- --------------------------------------------------------

--
-- Table structure for table courses
--

CREATE TABLE courses (
  id int(11) NOT NULL,
  course_name varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table courses
--

INSERT INTO courses (id, course_name) VALUES
(1, 'math');

-- --------------------------------------------------------

--
-- Table structure for table course_student
--

CREATE TABLE course_student (
  id int(11) NOT NULL,
  student_id int(11) NOT NULL,
  course_id int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table course_student
--

INSERT INTO course_student (id, student_id, course_id) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table students
--

CREATE TABLE students (
  id int(11) NOT NULL,
  student_name varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table students
--

INSERT INTO students (id, student_name) VALUES
(1, 'Austin Roberts'),
(2, 'Jimmy McNamara');

--
-- Indexes for dumped tables
--

--
-- Indexes for table courses
--
ALTER TABLE courses
  ADD PRIMARY KEY (id);

--
-- Indexes for table course_student
--
ALTER TABLE course_student
  ADD PRIMARY KEY (id);

--
-- Indexes for table students
--
ALTER TABLE students
  ADD PRIMARY KEY (id);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table courses
--
ALTER TABLE courses
  MODIFY id int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table course_student
--
ALTER TABLE course_student
  MODIFY id int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table students
--
ALTER TABLE students
  MODIFY id int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
