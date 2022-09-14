using System;
try
{
    var x = new SimpleMathComponent.SimpleMath();
    Console.WriteLine("Adding 5.5 + 6.5 ...");
    Console.WriteLine(x.add(5.5, 6.5).ToString());
    Console.WriteLine("Substracting 5.21 from 13.2 ...");
    Console.WriteLine(x.subtract(13.2, 5.21).ToString());
}
catch(Exception e)
{
    Console.WriteLine("Exception Message: " + e.Message);
}