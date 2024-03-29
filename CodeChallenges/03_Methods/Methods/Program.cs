﻿using System;

namespace Methods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            string name = GetName();
            GreetFriend(name);

            //2
            double result1 = GetNumber();
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");


        }

        public static string GetName()
        {
            Console.Wrtie("Enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static void GreetFriend(string name)
        {
            //Greeting should be: Hello, nameVar. You are my friend
            //Ex: Hello, Jim. You are my friend
            Console.WriteLine("Hello, "+name+". You are my friend");
        }

        public static double GetNumber()
        {
            double num = 0.0;
            try{
                Console.WrtieLine("Please enter a number(It can be a decimal number): ");
                num = Double.TryParse(Console.ReadLine());

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return num;
        }

        public static int GetAction()
        {
            throw new NotImplementedException();
        }

        public static double DoAction(double x, double y, int z)
        {
            throw new NotImplementedException();
        }
    }
}
