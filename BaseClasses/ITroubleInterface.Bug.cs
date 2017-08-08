namespace BaseClasses
{
    internal interface ITroubleInterface
    {
        //string QueryContext { get; }

        // Why does commenting the above out break DerivedClass::UnrelatedClass with the error:
        // Unhandled Exception: System.TypeLoadException: Method 'get_QueryContext' in type 'DerivedClasses.UnrelatedClass' from assembly 'derivedclasses, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
        //at ConsoleDriver.Program.Main()
        
    }
}