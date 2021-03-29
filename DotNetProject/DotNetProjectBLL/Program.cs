using System;

namespace DotNetProject.DotNetProjectBLL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Secret msg = new Secret();
            msg.Message = new Message("pidor");
            Console.WriteLine("Hello");
            Console.WriteLine(msg.Message.message);
            Console.WriteLine("Hello World!");
        }
    }
}