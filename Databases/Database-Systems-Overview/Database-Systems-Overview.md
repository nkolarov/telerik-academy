01. What database models do you know?
- Relational
- Object-oriented
- Hierarchical
- Network / graph

02. Which are the main functions performed by a Relational Database Management System (RDBMS)?
They manage data stored in tables. RDBMS typically implement:
- Creating, alreting, deleting tables and relationships betwenn them.
- Adding, changing, deleting data stored in tables.
- Support for the SQL language.
- Support for transactions.

03. Define what is "table" in database terms.
- "table" in database terms represents a data arranged in rows and columns.

04. Explain the difference between a primary and a foreign key.
- The primary key is a column of the table that uniquely idetifies its rows.
- The foreign key is an identifier of a record located in another table.

05. Explain the different kinds of relationships between tables in relational databases.
- One to Many  (Country - Towns) Ona country may have many towns. One town may have only one country.
- Many to Many (Student - Course) One student may partisipate many courses. One Course may have many students.
- One to One (Human - Student) - (Inheritance) One student is one human.
- Self Relationships - a way to represents hierarchical data.

06. When is a certain database schema normalized? What are the advantages of normalized databases?
- The normalization removes data repetiotions in the tables.
- The database schema becomes more readable.
- Disadvantage - The normalisation slows down the database performance - we need to join more tables.

07. What are database integrity constraints and when are they used?
Integrity constraints ensure data integrity in database tables. They enforce data rules which cannot be violated.
- Primary Key constraint - ensures that the primary key of a table has unique value for each table row.
- Unique key constraint - ensures that all values in a certain colum(or more colums) are unique. 
- Foreign key constraint - ensures that the value in given column is a key from another table.
- Check constraint - ensures that value in certain colum meet some predefined condition.

08. Point out the pros and cons of using indexes in a database.
Pros:
 - Indices speed up searching of values in a certain colum or group of columns.
 - Can be built-in tables (clustered) ot stored externally (non-clustered).
 Cons:
 - Adding and deleting records in indexed tables is slower.

09. What's the main purpose of the SQL language?
The main purpose is manipulation of relational databases.
It consists of:
 - DDL (Data Definition Language)  Create, Alter, Drop
 - DML (Data Manipulation Language) Select, Insert, Update, Delete

10. What are transactions used for? Give an example.
Transactions are a sequence of database operations which are executed as a single unit:
- Either all of them execute successfully or none of them is executed.
Example - a bank transfer from one account to another. Withdrawal from the first and deposit into the second account. 
If either the withdrawal of the deposit fails the entire operation should be cancelled.

11. What is a NoSQL database?
NoSQL is a non-relational database that uses document-based model.

12. Explain the classical non-relational data models.
NoSQL databases use document-based model. 
It`s a schema-free document storage that still supports CRUD, Indexing, Quering, Concurency and Transactions.
It`s highly optimized for append/retreive and has a great performance and scalability.


13. Give few examples of NoSQL databases and their pros and cons.
- MongoDB - JSON-document database.
- CouchDB - JSON-document database with REST API.
Cassandra - Distributed wide-column database.

