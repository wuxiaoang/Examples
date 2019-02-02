# 委托

委托是一种引用类型，表示对具有特定参数列表和返回类型的方法的引用。

## 委托概述
委托具有以下属性：
- 委托类似于 C++ 函数指针，但委托完全面向对象，不像 C++ 指针会记住函数，委托会同时封装对象实例和方法。
- 委托允许将方法作为参数进行传递。
- 委托可用于定义回调方法。
- 委托可以链接在一起；例如，可以对一个事件调用多个方法。
- 方法不必与委托类型完全匹配。 有关详细信息，请参阅使用委托中的变体。
- C# 2.0 版引入了匿名方法的概念，可以将代码块作为参数（而不是单独定义的方法）进行传递。 C# 3.0 引入了 Lambda 表达式，利用它们可以更简练地编写内联代码块。 匿名方法和 Lambda 表达式（在某些上下文中）都可编译为委托类型。 这些功能现在统称为匿名函数。 有关 lambda 表达式的详细信息，请参阅匿名函数。

### 备注：
    在方法重载的上下文中，方法的签名不包括返回值。 但在委托的上下文中，签名包括返回值。 换句话说，方法和委托必须具有相同的返回类型。

### 参考：
    https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/delegates/index

### 委托的定义与实例化

- 用一个签名定义委托
- 用一个具有相同的签名的方法实例化委托

```C#
public delegate void Del(string message);

// Create a method for a delegate.
public static void DelegateMethod(string message)
{
    System.Console.WriteLine(message);
}

// Instantiate the delegate.
Del handler = DelegateMethod;

// Call the delegate.
handler("Hello World");
```

### 多播

委托内部包含一个方法列表(InvocationList)。委托可以在调用时调用多个方法。 这被称为多播。 
要向委托的方法列表添加额外的方法 - 调用列表 - 只需要使用加法或加法赋值运算符（'+'或'+ ='）添加两个委托。

由于委托类型派生自 System.Delegate，因此可以在委托上调用该类定义的方法和属性。 例如，若要查询委托调用列表中方法的数量，你可以编写：
```C#
int invocationCount = d1.GetInvocationList().GetLength(0);
```

### 多播与事件

Multicast delegates are used extensively in event handling. Event source objects send event notifications to recipient objects that have registered to receive that event. To register for an event, the recipient creates a method designed to handle the event, then creates a delegate for that method and passes the delegate to the event source. The source calls the delegate when the event occurs. The delegate then calls the event handling method on the recipient, delivering the event data. The delegate type for a given event is defined by the event source. For more, see Events.

多播委托广泛用于事件处理中。 事件源对象将事件通知发送到已注册接收该事件的接收方对象。 若要注册一个事件，接收方需要创建用于处理该事件的方法，然后为该方法创建委托并将委托传递到事件源。 事件发生时，源调用委托。 然后，委托将对接收方调用事件处理方法，从而提供事件数据。 给定事件的委托类型由事件源确定。 有关详细信息，请参阅事件。

### 委托的比较

在编译时比较分配的两个不同类型的委托将导致编译错误。 如果委托实例是静态的 System.Delegate 类型，则允许比较，但在运行时将返回 false。

## 使用命名方法的委托与使用匿名方法的委托

### 使用命名方法
委托可以与命名方法相关联。 使用命名方法实例化委托时，该方法作为参数传递

```c#
// Declare a delegate:
delegate void Del(int x);

// Define a named method:
void DoWork(int k) { /* ... */ }

// Instantiate the delegate using the method as a parameter:
Del d = obj.DoWork;
```

使用命名方法构造的委托可以封装静态方法或实例方法。 命名方法是在早期版本的 C# 中实例化委托的唯一方式。 但是，如果创建新方法会造成多余开销，C# 允许你实例化委托并立即指定调用委托时委托将处理的代码块。 代码块可包含 Lambda 表达式或匿名方法。 有关详细信息，请参阅匿名函数。

    备注

    - 作为委托参数传递的方法必须具有与委托声明相同的签名。 
    - 委托实例可以封装静态方法或实例方法。
    - 尽管委托可以使用 out 参数，但不建议将该委托与多播事件委托配合使用，因为你无法知道将调用哪个委托。

## 如何：声明、实例化和使用委托

 ### 在 C# 1.0 和更高版本中，可以如下面的示例所示声明委托
```c#
// Declare a delegate.
delegate void Del(string str);

// Declare a method with the same signature as the delegate.
static void Notify(string name)
{
    Console.WriteLine("Notification received for: {0}", name);
}

// Create an instance of the delegate.
Del del1 = new Del(Notify);
```

 ### C# 2.0 提供了更简单的方法来编写前面的声明
```C#
// C# 2.0 provides a simpler way to declare an instance of Del.
Del del2 = Notify;
```

 ### 在 C# 2.0 和更高版本中，还可以使用匿名方法来声明和初始化委托，
```C#
// Instantiate Del by using an anonymous method.
Del del3 = delegate(string name)
    { Console.WriteLine("Notification received for: {0}", name); };
```

 ### 在 C# 3.0 和更高版本中，还可以通过使用 lambda 表达式声明和实例化委托
```c#
// Instantiate Del by using a lambda expression.
Del del4 = name =>  { Console.WriteLine("Notification received for: {0}", name); };
```

### 调用委托

创建委托对象后，通常会将委托对象传递给将调用该委托的其他代码。 委托对象是通过使用委托对象的名称调用的，后跟用圆括号括起来的将传递给委托的自变量。
```c#
processBook(b);
```
委托可以同步调用（如在本例中）, 或通过使用 BeginInvoke 和 EndInvoke 方法异步调用。
