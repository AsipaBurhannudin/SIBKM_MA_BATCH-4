using Connection.Contexts;
using Connection.Controllers;
using Connection.Models;
using Connection.Repositories;
using Connection.Views;
using System.Data.SqlClient;

namespace Connection;

public class Program
{
    public static void Main()
    {
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Database Connectivity=========");
            Console.WriteLine("1. Manage Table Region");
            Console.WriteLine("2. Manage Table Country");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Region();
                    break;
                case 2:
                    Country();
                    break;
                case 3:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    public static void Region()
    {
        RegionController regionController = new RegionController(new RegionRepository(), new VRegion());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    regionController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=======Insert Region By Id========");
                    Console.Write("Input Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Region region = regionController.GetById(id);
                    if (region != null)
                    {
                        Console.WriteLine($"Id: {region.Id}, Name: {region.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Region not found!");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Region========");
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    regionController.Insert(new Region
                    {
                        Name = name
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Region========");
                    Console.Write("Input Id: ");
                    var Id = Convert.ToInt32(Console.ReadLine());
                    Region regionToUpdate = regionController.GetById(Id);
                    if (regionToUpdate != null)
                    {
                        Console.Write($"Input new name for {regionToUpdate.Name}: ");
                        string newName = Console.ReadLine();
                        regionToUpdate.Name = newName;
                        regionController.Update(regionToUpdate);
                        Console.WriteLine($"Region with id {Id} updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Country not found!");
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Region========");
                    Console.Write("Input Id: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    Region regionToDelete = regionController.GetById(deleteId);
                    if (regionToDelete != null)
                    {
                        regionController.Delete(deleteId, regionToDelete);
                        Console.WriteLine($"Region with id {deleteId} deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Region not found!");
                    }
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    //===========================================================================================================//
    public static void Country()
    {
        CountryController countryController = new CountryController(new CountryRepository(), new VCountry());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Country========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    countryController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=======Get Country By Id========");
                    Console.Write("Input Id: ");
                    string id = Console.ReadLine();
                    Country country = countryController.GetById(id);
                    if (country != null)
                    {
                        Console.WriteLine($"Id: {country.Id}, Name: {country.Name}, Region: {country.Region}");
                    }
                    else
                    {
                        Console.WriteLine("Country not found!");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Country========");
                    Console.Write("Input ID : ");
                    var idc = Console.ReadLine();
                    Console.Write("Input Name :");
                    var name = Console.ReadLine();
                    Console.Write("Input Region : ");
                    var region = Convert.ToInt32(Console.ReadLine());
                    var countrys = new Country
                    {
                        Id = idc,
                        Name = name,
                        Region = region
                    };
                    countryController.Insert(countrys);
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Country Name========");
                    Console.Write("Input ID : ");
                    var Id = Console.ReadLine();
                    Country countryToUpdate = countryController.GetById(Id);
                    if (countryToUpdate != null)
                    {
                    Console.Write($"Input new name for {countryToUpdate.Name}: ");
                    string newName = Console.ReadLine();
                    countryToUpdate.Name = newName;
                    countryController.Update(countryToUpdate);
                    Console.WriteLine($"Region with id {Id} updated successfully!");
                    }
                    else
                    {
                     Console.WriteLine("Country not found!");
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Country========");
                    Console.Write("Input Id: ");
                    string deleteId = Console.ReadLine();
                    Country countryToDelete = countryController.GetById(deleteId);
                    if (countryToDelete != null)
                    {
                        countryController.Delete(deleteId, countryToDelete);
                        Console.WriteLine($"Region with id {deleteId} deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Region not found!");
                    }
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }
}