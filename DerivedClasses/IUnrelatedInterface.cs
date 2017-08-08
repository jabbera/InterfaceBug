namespace DerivedClasses
{
    // The only commonality between BaseClasses:ITroubleInterface is they both have a property named QueryContext
    // The implementation of QueryContext is also in BaseClasses:TestBase, but that 
    internal interface IUnrelatedInterface
    {
        string QueryContext { get; }
    }
}