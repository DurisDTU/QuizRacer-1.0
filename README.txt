BEFORE RUNNING:

SETUP Database
Before first run of the program, a database has to be setup.

On SQL Server Object Explorer, create database on local instance, call it "Users" and run script:
the QuizRacerDataBaseTableSetupQuery.sql in order to setup the database.

Should a connection string require change, the use is in:
QuizRacer 1.0.1.Player.cs, line 27
Server.MatchFinder.cs, line 128, 157, 194.




