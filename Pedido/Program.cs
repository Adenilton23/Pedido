﻿using System;
using Pedido.Entities;
using Pedido.Entities.Enums;
using System.Globalization;
namespace Pedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER cliente data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("ENTER order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            

            Client client = new Client( clientName, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #i " + "item data: " );
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);                
                
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();

            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);



        }
    }
}
