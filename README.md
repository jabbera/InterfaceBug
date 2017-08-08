This is a demo showing how removing a property from an interface that is unused in the application can cause it to break on a class that is not derived from directly or indirectly from said interface. (This sounds crazy..... I can't belive it's true)

Run build.bat for a demo.

It will build a base class library. (Containing an internal interface called ITroubleInterface with a property called QueryContext. This interface is only used from an internal class that is never instanitated.)
Build a derived class library. (It will not use ITroubleInterface as it's internal and not exposed on BaseClasses only public class)
Build a console app
Run the app.

It will then comment out BaseClasses:ITroubleInterface:QueryContext (which is internal and only used by an internal class, not exposed publicly) and recompile BaseClasses.dll
It will re-run the tester app and you will see the following exception:
```
Unhandled Exception: System.TypeLoadException: Method 'get_QueryContext' in type 'DerivedClasses.UnrelatedClass' from assembly 'derivedclasses, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
   at ConsoleDriver.Program.Main()
```

Note that DerivedClass:UnrelatedClass DOES NOT use ITroubleInterface directly or indirectly!!!!!!! It also still has an implementation of QueryContext, it's in BaseClasses:TestApp:QueryContext. ITroubleInterface isn't public and it's not exposed by BaseClasses only public class. It's totally unrelated to TestBase other then the fact that an class that derives from TestBase (TroubleClass) also derives from TestBase.

Below is a class diagram proving I'm not crazy.
![Image of nonCraziness](https://github.com/jabbera/InterfaceBug/blob/master/image.png)
