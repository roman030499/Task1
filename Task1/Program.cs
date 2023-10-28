using Task1;

Database.InsertHuman(new Human { Firstname = "John", Lastname = "Doe" });
Database.InsertHuman(new Human { Firstname = "Jane", Lastname = "Doe" });
Database.DeleteHuman(2);
var humans = Database.GetHumans();
foreach (var human in humans)
{
    Console.WriteLine($"id: {human.Id}, firstname: {human.Firstname}, lastname: {human.Lastname}");
}