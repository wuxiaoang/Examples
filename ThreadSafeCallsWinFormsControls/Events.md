# 事件(Events)

事件使类或对象在发生其他类或对象感兴趣的事件时通知它们。 发送（或引发）事件的类称为发布者，接收（或处理）事件的类称为订阅者。

    参考：
    https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/events/index

## 事件概述

事件具有以下属性：
- 发行者确定何时引发事件；订户确定对事件作出何种响应。
- 一个事件可以有多个订户。 订户可以处理来自多个发行者的多个事件。
- 没有订户的事件永远也不会引发。
- 事件通常用于表示用户操作，例如单击按钮或图形用户界面中的菜单选项。
- 当事件具有多个订户时，引发该事件时会同步调用事件处理程序。 若要异步调用事件，请参阅 《使用异步方式调用同步方法》https://docs.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously。
- 在 .NET Framework 类库中，事件基于 EventHandler 委托和 EventArgs 基类。