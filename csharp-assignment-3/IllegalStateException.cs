///////////////////////////////////////////////////////////////////////////////////////////////////
// Test your knowledge
///////////////////////////////////////////////////////////////////////////////////////////////////
/*
1. What are the six combinations of access modifier keywords and what do they do?
- private: The caller can only be within the class itself.
- private internal: The caller can be within the class itself or in any derived class within the same assembly.
- protected: The caller can be within the class itself or in any derived class in any assembly.
- protected internal: The caller can be anywhere within the same assembly, but if the caller is outside of the assembly, then it must be within a derived class.
- internal: The caller can be anywhere within the same assembly.
- public: The caller can be anything in any assembly.

2. What is the difference between the static, const, and readonly keywords when applied to a type member?
- const means that member will be constant and can't be change throughout the entire program. It is also implicitly static which means the definition must be define at compile time.
- readonly is the same as const but it can be define at runtime through the constructor, once the value is define, it can't be change.
- static means that the member belong to the class rather than the instance, sp there can only be 1 copy of it throughout the entire program.

3. What does a constructor do?
To initialize the class when a new instance is created.

4. Why is the partial keyword useful?
It allows you to seperate the a class or method into seperate files for organizatin purposes. It is useful when you have a really large class/method.

5. What is a tuple?
A data structure that can store 2 values.

6. What does the C# record keyword do?
It will auto implement a value-based equality comparator to the class or struct.

7. What does overloading and overriding mean?
Overloading is the ability to have multiple methods with the same name but different parameters and return type. It is a compile time polymorphism. Whereas, overriding is the ability redefine the implementation of the method through a derived class, but the method must have the same paramaters, and return type. The return type can be a subtype of the base return type. It is a runtime polymorphism.

8. What is the difference between a field and a property?
A field is just a variable within a class. Whereas a property is syntax sugar for getter and setter methods.

9. How do you make a method parameter optional?
Method overloading or assign the paramater a value.

10. What is an interface and how is it different from abstract class?
An interface is just a contract for a class to implement, the interface can't be instantiated because it is not an actual object.
On the other hand, an abstract class is like an 'unfinished' base class that jsut happen to contain some 'unfinished' methods that the derived class must implement in order to instantiate it.

When a class inherit an interface, it represent a "is-able" relationship. While inheriting a class or an abstract class represent a "is a" relation.

11. What accessibility level are members of an interface?
public

12. True/False. Polymorphism allows derived classes to provide different implementations of the same method.
False

13. True/False. The override keyword is used to indicate that a method in a derived class is providing its own implementation of a method.
True

14. True/False. The new keyword is used to indicate that a method in a derived class is providing its own implementation of a method.
True

15. True/False. Abstract methods can be used in a normal (non-abstract) class.
False

16. True/False. Normal (non-abstract) methods can be used in an abstract class.
True

17. True/False. Derived classes can override methods that were virtual in the base class.
True

18. True/False. Derived classes can override methods that were abstract in the base class.
True

19. True/False. In a derived class, you can override a method that was neither virtual non abstract in the base class.
False, but you can use the 'new' keyword to hide the base class method.

20. True/False. A class that implements an interface does not have to provide an implementation for all of the members of the interface.
False

21. True/False. A class that implements an interface is allowed to have other members that aren’t defined in the interface.
True

22. True/False. A class can have more than one base class.
False

23. True/False. A class can implement more than one interface.
True
 */

using System.Runtime.Serialization;

[Serializable]
internal class IllegalStateException : Exception
{
    public IllegalStateException()
    {
    }

    public IllegalStateException(string? message) : base(message)
    {
    }

    public IllegalStateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected IllegalStateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}