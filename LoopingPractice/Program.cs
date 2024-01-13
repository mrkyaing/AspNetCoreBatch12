//for
//while
//do-while
//for-each 
int count = 1;
Console.Write("Even number between 1 to 100>>");
while (count < -1)
{
    Console.Write("Hi,i come from while.");
    if (count%2==0)
        Console.Write(count+" ");//2
    count++;
}
do
{
    Console.Write("Hi,i come from do-while.");
    if (count % 2 == 0)
        Console.Write(count + " ");//2
    count++;
} while (count < -1);
//1 2 3 4 5 6 7 8 9 10 
//2 4 6 8 10 12 14 16 18 20 
//3 6 9 12 15 18 21 24 27 30 
Console.WriteLine("\nmultiplication results from 1 to 7");
for (int i=1; i <= 7; i++)//columns
{
  for(int j = 1; j <=10; j++)//rows
    {
        Console.Write(i*j+" ");//1 2 
    }
    Console.WriteLine();
}
Console.WriteLine();
int[] marks = new int[100];//0 to 9
for(int i = 0; i < marks.Length; i++)//best practice
{
    marks[i] = new Random().Next(100);
}
Console.WriteLine("\nresult wit for loop");
for (int i = 0; i < marks.Length; i++)
{
    Console.Write(marks[i]+" ");
}//foreach(datatype <varname> in <collectionsName>)
Console.WriteLine("\nresult wit foreach loop");
foreach(int i in marks)
{
    Console.Write(i+" ");
}
int[,] examMark=new int[7,12];// Coluns 5, rows 3 
Console.WriteLine("result from 2D array");
for(int column=0; column <examMark.GetLength(0); column++)//7
{
    for(int row = 0; row <examMark.GetLength(1); row++)
    {
        examMark[column,row] = new Random().Next(100);
    }
}
foreach(int data in examMark)
{
    Console.Write(data+" ");
}