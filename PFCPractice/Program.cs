using BenchmarkDotNet.Running;
using PFCPractice;

string msg = "Today is SATURDAY";
int i = 10;//declare int variable and iniliaze the value 10
int result = i + 10;
byte b = 10;
Console.WriteLine($"i value is {i}");// i value is 10 ,,string interpoli
Console.WriteLine(msg);
Console.WriteLine($"The result {result}");//20
int y = 1 + 2 / 3 * 2;
Console.WriteLine(y);
float f = 1.0f;
Console.WriteLine(f);
decimal d = 20.7m;
double d1 = 30.7;
float ff = 10.3f + 10.3f;
int k = 10, j = 10;
float r = k + j;
Console.WriteLine(r);
decimal pi = 3.14m;
int myPi = Convert.ToInt32(pi);
int me = (int)pi;
int z = 2;
switch (z)
{
    case 1: Console.WriteLine("hi"); break;
    case 2: Console.WriteLine("you"); goto case 1;
    default: Console.WriteLine("nothing"); break;
}
//terny operation style for if statements
// conditon?true:false ;
int ii = 10;
string output = i % 2 == 0 ? "even" : "odd";
Console.WriteLine(output);
var summary = BenchmarkRunner.Run<BottleneckProcessBenchmark>();