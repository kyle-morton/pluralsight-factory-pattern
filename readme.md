# Factory Design Pattern 

## When to use an object factory?

- unsure which concrete implementation of an interface I want to return
- creation should be seperated from representation of an object (instatiation might be very complex)
- lots of if/else when deciding which concrete class to instantiate

## Open/Closed Principle: 

*Software entities (classes, modules, etc) should be open for extension, but closed for modification.*
__In other words,__ We should write code that doesn't have to be changed every time the requirements change.

## Intent 

1. Seperate object creation from decision of which to make (factory decides this, caller passes in value that conditional uses).
2. Add new classes & functionality without breaking Open-Closed Principle
    - Factory-produced objects
    - Factories themselves (abstract factory)
3. Store __which__ object to create outside of the app 
    - database
    - config file

## Factory Method
*Define an interface for creating an object, but let subclasses decide which class to instantiate.*

- Add interface to factory
- Defer object creation to multiple factories that share common interface (IFactory, etc)
- Derived classes implement or override the *factory* method of base 

### Example - Store configuration for instantiating the factory in properties.settings (see Factory 3 project)

```

//properties.settings
//
// AutoFactory = Factory3.Factories.MiniCooperFactory
//
//

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("hit enter to create a car...");
            Console.ReadLine();

            IAutoFactory autoFactory = LoadFactory();

            IAuto car = autoFactory.CreateAutomobile();

            car.TurnOn();
            car.TurnOff();
        }
    }

    //Use reflexion to get FQName of the factory, then instantiate it
    static IAutoFactory LoadFactory()
    {
        string factoryName = Properties.Settings.Default.AutoFactory;
        return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as IAutoFactory;
    }
}


```

## Abstract Factory
*Define an interface for creating families of releated or dependent objects without specifying thier concrete classes*

- Factories create different types of concrete objects (products)
- Factory now represents a "family" of objects that it can create
- Factories may have more than one factory method

### Consequences 

- Add new factories and classes without breaking OCP
- Defer choosing classes to classes that specialize in making that decision
- Using private or internal constructors hides direct construction with the new keyword

