using System;

namespace DataTypeAndVariables
{
    public class Program
    {
      public static void Main(string[] args)
      {
          Console.WriteLine("Hello World!");

          byte myByte = 255; 
          sbyte mySbyte = -128;
          int myInt = -2147483648;
          uint myUint = 4294967295;
          short myShort = 32767;
          ushort myUShort = 65535;
          float myFloat = 3.402F;
          double myDouble=1.797;
          char myCharacter = 'a';
          bool myBool = true;
          string myText = "I control text";
          string numText = "7";
          Text2Num(numText);
      }

      public static int Text2Num(string numText)
      {
        if(int.TryParse(numText,out int num))
        {
          Console.WriteLine(num);
          return num;
        }
        else
        {
          Console.WriteLine("Input is not a string" + "which is " + numText);
          return -1;
        }
      }
    }
}
