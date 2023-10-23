IsNextTime:
try
{
	Console.Write("Enter your Name:");
	string name = Console.ReadLine();
	Console.Write("Enter your age:");
	int age = Convert.ToInt32(Console.ReadLine());//-10
	IsValidAge(age);
	Console.WriteLine("Hello," + name + ". You can vote in election in this year.");
}
catch (Exception e)
{
	Console.WriteLine("error occurs please read the following message");
	Console.WriteLine(e.Message);
	goto IsNextTime;
}
static void IsValidAge(int age)
{
    if (age < 0 || age>100)
        throw new Exception("invalid age input .age value should be between 1 and 100");
    else if (age<18)
        throw new Exception("invalid age input .you should be over 18 years old.");
}