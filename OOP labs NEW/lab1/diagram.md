classDiagram
direction LR

%% ===== Абстрактний базовий клас =====
class Person {
  <<abstract>>
  - string FirstName
  - string LastName
  + string FullName
}

%% ===== Конкретні сутності =====
class Student {
  + string StudentId
  + int Course
  + Gender Gender
  + bool LivesInDorm
  + int DormNumber
  + string DormRoom
  + string City
  + SetDorm()
  + SetCity()
  + Skate()
}

class Musician {
  + string Instrument
  + Play()
}

class Pilot {
  + string License
}

%% ===== Інтерфейси =====
class ICanPlay {
  <<interface>>
  + Play()
}

class ISkater {
  <<interface>>
  + Skate()
}

%% ===== Службові класи =====
class TextFileDataSource {
  - string _path
  + SaveAll()
  + LoadAll()
}

class ConsoleMenu {
  <<static>>
  + PrintHeader()
  + ShowCountAndList()
}

class Program {
  <<static>>
  - Student[] _students
  - Musician[] _musicians
  - Pilot[] _pilots
  + Main()
}

%% ===== Зв’язки =====
Person <|-- Student
Person <|-- Musician
Person <|-- Pilot

ICanPlay <|.. Musician
ISkater <|.. Student

Program --> TextFileDataSource
Program --> ConsoleMenu
