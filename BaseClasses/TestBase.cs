using System;

namespace BaseClasses 
{
    public abstract class TestBase
    {       
        public string QueryContext
        {
            get
            {
                Console.WriteLine("QueryContext");
                return null;
            }
        }
    }
}