using Task1;

Database.CreateDatabase();

Database.InsertHuman(new Human { Firstname = "John", Lastname = "Doe" });
Database.InsertHuman(new Human { Firstname = "Jane", Lastname = "Doe" });

Database.DisplayHumans();