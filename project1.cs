using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();

        stock.Add("Milk", 10);
        stock.Add("Bread", 5);
        stock.Add("Apple", 20);

        PrintStock(stock);

        AddOrIncrease(stock, "Milk", 3);
        AddOrIncrease(stock, "Banana", 7);

        TrySell(stock, "Apple", 5);
        TrySell(stock, "Apple", 500);
        TrySell(stock, "Cheese", 1);

        RemoveProduct(stock, "Bread");
        RemoveProduct(stock, "Bread");

        Console.WriteLine();
        PrintStock(stock);

        // Ryhmittely
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();
        AddToCategory(categories, "Dairy", "Milk");
        AddToCategory(categories, "Fruit", "Apple");
        AddToCategory(categories, "Fruit", "Banana");

        Console.WriteLine();
        PrintCategories(categories);
    }

    static void PrintStock(Dictionary<string, int> stock)
    {
        foreach (var pair in stock)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }

    static void AddOrIncrease(Dictionary<string, int> stock, string name, int amount)
    {
       
        /*Jos tuote sanakirjassa,kasvattaa saldoa,
        muuten lisää tuotteen sanakirjaan*/
        if (stock.ContainsKey(name))
        {
            stock[name] += amount;
        }
        else
        {
            stock.Add(name, amount);
        }
    }

    static void TrySell(Dictionary<string, int> stock, string name, int amount)
    {
        
        //Myy tuotetta (vähennä saldoa) vain jos onnistuu.
        if (stock.TryGetValue(name, out int currentStock))
        {
            if (currentStock >= amount)
            {
                stock[name] -= amount;
                Console.WriteLine("Sold " + amount + " of " + name);
            }
            else
            {
                Console.WriteLine("Not enough stock of " + name);
            }
        }
        else
        {
            Console.WriteLine( name + " not found");
        }
    }

    static void RemoveProduct(Dictionary<string, int> stock, string name)
    {
       
        //Poistaa tuotteen sanakirjasta,ilmoittaa jos tuotetta ei löydy
        if (stock.Remove(name))
        {
            Console.WriteLine("Removed " + name);
        }
        else
        {
            Console.WriteLine(name + " not found"); 
            
        }
    }

    static void AddToCategory(Dictionary<string, List<string>> categories, string category, string product)
    {
        
        // tekee kategorian ja lisää tuotteen listaan, jos sitä ei ole
        if (categories.ContainsKey(category))
        {
            categories[category].Add(product);
        }
        else
        {
            categories.Add(category, new List<string> { product });
        }
    }

    static void PrintCategories(Dictionary<string, List<string>> categories)
    {
        foreach (var pair in categories)
        {
            Console.WriteLine(pair.Key + ":");
            foreach (var product in pair.Value)
            {
                Console.WriteLine(" - " + product);
            }
        }

    }
}
