
CREATE DATABASE "ArtistApp3";

USE ArtistApp3;

CREATE TABLE "Users" (
  "UserID" int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  "FirstName" varchar(50) NOT NULL,
  "LastName" varchar(50) NULL,
  "Email" varchar(50) NOT NULL,
  "Password" varchar(50) NOT NULL,
) 

 SET IDENTITY_INSERT "Users" ON;
 INSERT INTO "Users" ("UserID", "FirstName", "LastName", "Email", "Password") VALUES
(1, 'Sam', 'Nightville', 'sammy@mail.com', 'Sam123'),
(2, 'Eleanor', 'Nightville', 'nor@mail.com', 'Quwerty123'),
(1, 'Sansa', 'Watercolor', 'sansa@mail.com', 'sansa'),
(4, 'Margaret', 'Sunflower', 'margo@mail.com', 'margo'),
SET IDENTITY_INSERT "Users" OFF;


--
-- Struktura tabeli dla tabeli "Pictures"
--
CREATE TABLE "Pictures" (
	"PictureID" int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	"Name" varchar(MAX) NOT NULL,
	"UserID" int NULL,
	"TagID" int NULL
	);
--
SET IDENTITY_INSERT "Pictures" ON;
INSERT INTO "Pictures"("PictureID","Name","UserID", "TagID")VALUES
(1, '~/Content/Pictures/Przechwytywanie7204411028.JPG', 1, 1),
(2, '~/Content/Pictures/Przechwytywanie4204422434.JPG', 1, 1),
(3, '~/Content/Pictures/Przechwytywanie5204432366.JPG', 1, 1),
(4, '~/Content/Pictures/Przechwytywanie10204439411.JPG', 1, 1),
(5, '~/Content/Pictures/Przechwytywanie6204449628.JPG', 1, 1),
(6, '~/Content/Pictures/Przechwytywanie11204501709.JPG', 1, 1),
(7, '~/Content/Pictures/Przechwytywanie12204327673.JPG', 1, 1),
(8, '~/Content/Pictures/Przechwytywanie9204400596.JPG', 1, 1),
(9, '~/Content/Pictures/Przechwytywanie14204517310.JPG', 1, 1),
(10, '~/Content/Pictures/Przechwytywanie204656753.JPG', 4, 1),
(11, '~/Content/Pictures/Przechwytywanie6204706639.JPG', 4, 1),
(12, '~/Content/Pictures/Przechwytywanie2204717803.JPG', 4, 1),
(13, '~/Content/Pictures/Przechwytywanie5204728801.JPG', 4, 1)
SET IDENTITY_INSERT "Pictures" OFF;

-- Struktura tabeli dla tabeli "Tags"
--
CREATE TABLE "Tags" (
  "TagID" int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  "TagName" varchar(50) NOT NULL
);

SET IDENTITY_INSERT "Tags" ON;
INSERT INTO "Tags"("TagID", "TagName")VALUES
(1, 'Nature'),
(2, 'Animals'),
(3, 'Geometric');
SET IDENTITY_INSERT "Tags" OFF;

--
-- Klucze obce
--
ALTER TABLE "Pictures"
  ADD FOREIGN KEY (UserID) REFERENCES Users(UserID);
ALTER TABLE "Pictures"
  ADD FOREIGN KEY (TagID) REFERENCES Tags(TagID);
  

  SELECT * FROM Users
  SELECT * FROM Pictures