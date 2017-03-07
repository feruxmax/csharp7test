using System;

namespace hwapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var csharpV7Test = new CsharpV7Test();
            csharpV7Test.Run();
        }
        class CsharpV7Test
        {
            public void Run()
            {
                Console.WriteLine("local functions test:");
                LocalFunction(10);

                void LocalFunction(int i)
                {
                    Console.WriteLine($"from local functcion: {i}");
                }
                Console.WriteLine("");
                /*********************************************************************/

                Console.WriteLine("out declaration test:");
                void outDecl(out int x, out int y)
                {
                    x = 7;
                    y = 2;
                }

                outDecl(out int a, out int b);
                Console.WriteLine($"out {a} {b}.");
                Console.WriteLine("");
                /*********************************************************************/

                Console.WriteLine("pattern matching if test:");
                void patternMatchIf(object o)
                {
                    if (o is null) return;
                    if (o is int i) { Console.WriteLine($"int: {i}"); return; }
                    if (o is double d) { Console.WriteLine($"double: {d}"); return; }
                }

                patternMatchIf(null);
                patternMatchIf(3);
                patternMatchIf(7.0);
                Console.WriteLine("");
                /*********************************************************************/

                Console.WriteLine("pattern matching switch test:");
                void patternSwitch(object o)
                {
                    switch (o)
                    {
                        case int i:
                            Console.WriteLine($"int: {i}");
                            break;
                        case double d:
                            Console.WriteLine($"double: {d}");
                            break;
                        default:
                            Console.WriteLine("unknown type");
                            break;
                    }
                }

                patternSwitch(null);
                patternSwitch(3);
                patternSwitch(7.0);
                Console.WriteLine("");
                /*********************************************************************/

                Console.WriteLine("tuples test:");
                (int code, string message) passthroughTuple((int, string) x)
                {
                    return x;
                }
            
                var pair1 = (42, "hello");
                var (key, message) = passthroughTuple(pair1);
                Console.WriteLine(message);
                Console.WriteLine("");
                /*********************************************************************/

                Console.WriteLine("literals test:");
                var dec=123_456;
                var hex=0xab_cd_ef;
                var bin=0b1010_1010_0101_0101;
                Console.WriteLine($"dec:{dec}, hex:{hex:X}, bin:{bin:X}");
                Console.WriteLine("");
                /*********************************************************************/

                Console.WriteLine("ref return and locals test:");
                ref int Find(int number, int[] numbers)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] == number)
                        {
                            return ref numbers[i]; // return the storage location, not the value
                        }
                    }
                    throw new IndexOutOfRangeException($"{nameof(number)} not found");
                }

                int[] array = { 1, 15, -39, 0, 7, 14, -12 };
                ref int place = ref Find(7, array); // aliases 7's place in the array
                place = 9; // replaces 7 with 9 in the array
                Console.WriteLine($"[{string.Join(", ", array)}]"); // prints 9
                Console.WriteLine("");
            }
        }
    }
}
