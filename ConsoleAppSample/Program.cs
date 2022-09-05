using System;

var x = new SimpleMathComponent.SimpleMath();
Console.WriteLine("Adding 5.5 + 6.5 ...");
Console.WriteLine(x.add(5.5, 6.5).ToString());
Console.WriteLine("Substracting 5 from 13.5 ...");
Console.WriteLine(x.subtract(13.5, 5).ToString());
