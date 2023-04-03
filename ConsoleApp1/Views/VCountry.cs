﻿using Connection.Models;

namespace Connection.Views;
public class VCountry
{
    public void GetAll(List<Country> countries)
    {
        foreach (var country in countries)
        {
            Console.WriteLine("=================");
            Console.WriteLine("Id: " + country.Id);
            Console.WriteLine("Name: " + country.Name);
            Console.WriteLine("Region: " + country.Region);
        }
    }

    public void GetById(Country country)
    {
        Console.WriteLine("=================");
        Console.WriteLine("Id: " + country.Id);
        Console.WriteLine("Name: " + country.Name);
        Console.WriteLine("Region: " + country.Region);
    }

    public void Success(string message)
    {
        Console.WriteLine($"Data has been {message}");
    }

    public void Failure(string message)
    {
        Console.WriteLine($"Data has not been {message}");
    }

    public void DataNotFound()
    {
        Console.WriteLine("Data Not Found!");
    }
}
