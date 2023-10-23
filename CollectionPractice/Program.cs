nextTime:
try
    {
        Console.Write("Please Enter a number:");
        int n1 = Convert.ToInt32(Console.ReadLine());//12
        string output = n1 % 2 == 0 ? "Even" : "Odd";
        Console.Write($"{n1} is {output} number.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Oh!! sorry, we only accept number input values.please try again");
        goto nextTime;
    }

