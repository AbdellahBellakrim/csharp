
Console.WriteLine("abdellah test done");

Console.Clear();
int i = 3;
string str = "";

if (!string.IsNullOrEmpty(str) && str.All(char.IsDigit))
    Console.WriteLine(i + Convert.ToInt64(str));

int[,] arr = { { 1 }, { 2 }, { 3 } };


foreach (int item in arr)
{
    Console.WriteLine(item);
}

sbyte test = 0;

Console.WriteLine(test);