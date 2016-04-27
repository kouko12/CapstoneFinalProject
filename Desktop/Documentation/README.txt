/*
Textbook Marketplace Installation Guide:
Created By: Wilson Ho
Date: Apr. 27, 2016
Contact: wilson.ho.12@cnu.edu

Software Used:
-Visual Studio Community 2015
-PgAdmin III (Version 1.22.0)
 *Link: http://www.pgadmin.org/download/

What is provided:
-Visual Studio Source-Code (TextbookMarketplace folder)
-Database
-Npgsql.dll
-tm_database.backup
-README
-TextbookImageSamples (sample images used to upload images on the application)
*/
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
The source code is ran through visual studio while using postgreSQL
as the backend database that stores the user's information, textbooks,
and a collection of universities.

SETUP:
1. Install the necessary software (Visual Studio 2015 & PgAdmin III)

2. Set the password of the server to whatever you'd like after installing PgAdmin III
(prefereably "password" (without quotes), otherwise, change the password on each .aspx
C# code (connString and conn)).

3. Create a database called BookStore in PgAdmin III, and use the backup (tm_database.backup)
provided in the Documentation folder to restore the database.

4. To do so, right click on the database you've just created, and click Restore, find the
tm_database.backup file, and click Restore.

5. Afterwords, move the source code provided into a visual studio project, and import
the Npgsql.dll file (read below for installation guide).

==================================================================================
If by any reason there are errors in the c# file dealing with a database connection,
you might need to:
Setup the connection between C# and the postgreSQL database, follow this guide:
http://www.codeproject.com/Articles/30989/Using-PostgreSQL-in-your-C-NET-application-An-intr

A dll file must be installed in visual studio in order to use
access the postgreSQL database. Provided to you is the Npgsql.dll file
that can be found either online or in the provided Documentation folder.

You can import the dll file to Visual Studio (2015) by going to: 
Solution Explorer -> Project -> Add Reference -> Browse -> then attach the Npgsql.dll
file and click OK.  Your project should then be able to use the package and make
a connectio to a postgreSQL database.
===================================================================================

6. Once Npgsql.dll is added, run the Default.aspx file in the application
from Visual Studio.

7. To use access the collections page or add books, you must:
7.1 Sign up first (use the sign-up tab on the application)
7.2 Sign in
7.3 add books on the Add Books tab, or see list of books through Collections tab.

8. DONE