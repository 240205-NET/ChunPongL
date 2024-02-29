using System;
using Store.Data;
using Store.Logic;

namespace Store.App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Store Application is running...");

            try
            {
                PetStore n1 = new PetStore("Local Pets","Pet Store","111 Here Ave, B City, CA , 12345","no@noway.com","611-456-666");
                n1.onlineService();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Store Application is closing...");
        }
    }
}