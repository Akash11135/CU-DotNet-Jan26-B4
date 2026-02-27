Refactoring :  means when we change the folder structure of files, the names of the files also changes. Basically carefully changing the name of the files.
Context file : Any file derived from DbContext.
DbContext : A class that contains database and its tables.
In Entity Framework Core (EF Core), DbContext is the main class that manages database operations.

Think of it like this:

👉 DbContext = bridge between your C# code and the database

It is responsible for:

Connecting to the database

Querying data (SELECT)

Saving data (INSERT, UPDATE, DELETE)

Tracking changes in objects

Mapping C# classes → database tables
