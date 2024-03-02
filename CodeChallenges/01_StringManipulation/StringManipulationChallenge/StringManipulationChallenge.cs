﻿using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInputString; //this will hold your users message
            int elementNum = 2;         //this will hold the element number within the messsage that your user indicates
            char char1 = 'a';             //this will hold the char value that your user wants to search for in the message.
            string fName = "Chun Pong";           //this will hold the users first name
            string lName = "Lai";           //this will hold the users last name
            string userFullName;    //this will hold the users full name;
            
            //
            //
            //implement the required code here and within the methods below.
            //
            //
            userInputString = StringToUpper("wells fargo");
            userInputString = StringToLower("BOA");
            userInputString = StringTrim("     A B C     ");
            userInputString = StringSubstring(userInputString, elementNum);
            userFullName = ConcatNames(fName,lName);
            elementNum = SearchChar(userFullName,char1);
            Console.WriteLine(userFullName);
            Console.WriteLine(elementNum);


        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x){
            string s = x.ToUpper();
            Console.WriteLine(s);
            return s;

        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x){
            string s = x.ToLower();
            Console.WriteLine(s);
            return s;
        }
        
        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x){
            string s = x.Trim();
            Console.WriteLine(s);
            return s;
        }
        
        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum){
            string s = x.Substring(elementNum);
            Console.WriteLine(s);
            return s;

        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x){
            return userInputString.IndexOf(x);
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName){
            string s = fName +" "+ lName;
            return s;
        }



    }//end of program
}
