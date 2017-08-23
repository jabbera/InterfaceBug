using System;
using DerivedClasses;

namespace ConsoleDriver
{
    public class Program
    {
        public static void Main() 
        {
            // When BaseClasses is built with ITroubleInterface.Bug.cs this fails with the exception:
            // Unhandled Exception: System.TypeLoadException: Method 'get_QueryContext' in type 'DerivedClasses.UnrelatedClass' from assembly 'derivedclasses, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
            ///at ConsoleDriver.Program.Main()

            // This exception makes no sense as UnrelatedClass still implements QueryContext in it's base class BaseClasses::TestBase
            var v = new UnrelatedClass();
            Console.WriteLine("App worked!!!");
        }
    }
}