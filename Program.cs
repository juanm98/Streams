using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

var users = new List<User>
{
    new User { Id = 1, Name = "Mamajuana", Company = "Plomero", Salary = 5500, Residency = "US" },
    new User { Id = 2, Name = "Alejandro", Company = "Banco Central", Salary = 1200, Residency = "RD" }
};

void SerializeUsersToJson(List<User> users)
{
        string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("users.json", jsonString);
        Console.WriteLine("User list serialized to JSON file successfully.");
}

void PrintUsers(List<User> users)
{
    Console.WriteLine("User List:");
    foreach (var user in users)
    {
        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Company: {user.Company}, Salary: {user.Salary}, Residency: {user.Residency}");
    }
}

Console.WriteLine("Indica la funcion:");

var main = Console.ReadLine();

void InMemoryStream() 
{
    using (MemoryStream ms = new MemoryStream())
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes("Memory stream example");
        ms.Write(data, 0, data.Length);
        ms.Seek(0, SeekOrigin.Begin); // Reset the position to read from the beginning
        byte[] buffer = new byte[ms.Length];
        ms.Read(buffer, 0, buffer.Length);
        string result = System.Text.Encoding.UTF8.GetString(buffer);
        Console.WriteLine("Data from MemoryStream: ");
        Console.WriteLine(result);
    }
}

void writeFile() {
    string path = "output.txt";
    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        string content = "Estamoooos funcionandooooooo ";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(content);
        fs.Write(data, 0, data.Length);
        Console.WriteLine("Data written to file successfully.");
    }
}

void addline() {
        string path = "output.txt";
        string content = "waos khe pro";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine + content);
        using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
        {
            fs.Write(data, 0, data.Length);
        }

}

void readFile()
{
    string path = "output.txt";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);

            string content = System.Text.Encoding.UTF8.GetString(buffer);
            Console.WriteLine("File Content: ");
            Console.WriteLine(content);
        }
}


switch(main)
{
    case "read":
        readFile();
        break;
    case "write":
        writeFile();
        break;
    case "print":
        PrintUsers(users);
        break;
    case "add":
        addline();
        break;
    default:
        InMemoryStream();
        break;
}

class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Company { get; set; }

    public decimal Salary { get; set; }

    public string Residency { get; set; }
}