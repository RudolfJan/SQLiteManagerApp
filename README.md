# SQLiteManagerApp

## Summary
A toolkit for database management of SQLite databases from C#.

SQLite is a nice zero admin datbasemanagement system. It performs quite well and uses just one file at a disk. If you want to use it as an embedded database from C# applications, you face a numer of issues when updating the datamodel for existing users as well as syou need to create dapprt access methods to use the database. In this little project, a class library is provided to solve this issue.

Teh project also is a learning project to learn how to use unit testing and test driven development. The project at some day may be published as a Nuget project, but that is still far away.

At this moment there is not yet any code, work just started.

## Roadmap

* Create a first unit test
* A class to create a new SQLite Database
** Create the database and connectiostring
** Method to add tables from a file or from command parameters
* Create first integration test
* Add data access methods using Dapper
