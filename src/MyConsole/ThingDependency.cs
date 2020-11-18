using System;

namespace MyConsole
{
    public interface IThingDependency
    {
        string JoinUpper(string a, string b);
        int Meaning { get; }
    }
 
    // "Real" implementation
    public class ThingDependency : IThingDependency
    {
        public string JoinUpper(string a, string b)
        {
            throw new NotImplementedException();
        }
 
        public int Meaning => throw new NotImplementedException();
    }
 
    // Class we want to test in isolation of ThingDependency
    public class ThingBeingTested
    {
        private readonly IThingDependency _thingDependency;
 
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public ThingBeingTested(IThingDependency thingDependency)
        {
            _thingDependency = thingDependency;
        }
 
        public string X()
        {
            var fullName = _thingDependency.JoinUpper(FirstName, LastName);
 
            return $"{fullName} = {_thingDependency.Meaning}";
        }
    }
}