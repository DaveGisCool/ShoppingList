using System;
using System.Collections.Generic;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepLooping = true;
            double averagePrice, totalCost = 0;
            int cartCount = 0;

            Dictionary<string, double> items = new Dictionary<string, double>(); //Menu
            items["apple"] = .99;
            items["banana"] = .59;
            items["cauliflower"] = 1.59;
            items["dragonfruit"] = 2.19;
            items["Elderberry"] = 1.79;
            items["figs"] = 2.09;
            items["grapefruit"] = 1.99;
            items["honeydew"] = 3.49;

            Dictionary<string, double> buyList = new Dictionary<string, double>(); //Shopping cart

            Console.WriteLine("Welcome to Guenther's Market!"); //Welcome Message

            while (keepLooping)
            {
                Console.WriteLine($"\r\nItem            Price"); //Menu display
                Console.WriteLine("==============================");

                foreach (var item in items)
                {
                    Console.WriteLine("{0,-15} {1,5:C2}", item.Key, item.Value);
                }

                Console.Write($"\r\nWhat item would you like to order? ");
                string userSelect = Console.ReadLine();
                if (!items.ContainsKey(userSelect))
                {
                    Console.Write("Sorry, we don't have those. Please try again.");
                }
                else
                {
                    Console.WriteLine($"Adding {userSelect} to cart at {items[userSelect]}");//Read input, add to users buyList
                        buyList.Add(userSelect, items[userSelect]);
                }

                Console.Write($"\r\nWould you like to order anything else (y/n)?");
                string cont = Console.ReadLine();
                if (cont == "no" || cont == "NO" || cont == "No" || cont == "nO" || cont == "n" || cont == "N")
                {
                    keepLooping = false;
                }
                else if (cont != "yes" && cont != "YES" && cont != "Yes" && cont != "y" && cont != "Y")
                {
                    Console.WriteLine("You have not selected yes or no, exiting");
                    keepLooping = false;
                }
            }

            Console.WriteLine($"\r\nThanks for your order!");//Finalize shopping
            Console.WriteLine("Here's what you got:");
            foreach (var item in buyList)//List purchases
            {
                Console.WriteLine("{0,-15} {1,5:C2}", item.Key, item.Value);
            }
            foreach (var value in buyList.Values)//Sum values and count items in cart
            {
                totalCost = totalCost + value;
                cartCount = cartCount + 1;
            }
            averagePrice = (totalCost / cartCount);
            Console.WriteLine($"Average price per item in order was {averagePrice:C2}.");
        }
    }
}

