using System.Runtime.Intrinsics.Arm;

internal class Program
{
    private static void Main(string[] args)
    {
        bool execute = true;
        byte opc;
        while (execute)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("1. Sam Y Kelly");
            Console.WriteLine("2. Encontrar la mayor frecuencia");
            Console.WriteLine("3. Salir");
            Console.Write("> ");
            try
            {
                opc = Convert.ToByte(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        SamAndKelly();
                        break;
                    case 2:
                        findLongestSubsequence();
                        break;
                    default:
                        execute = false;
                        break;
                }
            }
            catch (OverflowException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"El numero de entrada o salida es demasiado grande \n Mensaje: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Error: {e.StackTrace}\n\nMensaje: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Error: {e.StackTrace}\n\nMensaje: {e.Message}");
            }
            Console.ReadKey();
        }

        static void SamAndKelly()
        {
            int flag = 1;
            int day = 0;
            bool run = true;
            int test;
            Console.Write("SamDaily: ");
            test = Convert.ToInt32(Console.ReadLine());
            int SamDaily = test >= 1 && test <= 100 ? test : throw new ArgumentException("los datos de la secuencia no cumplen las restricciones");
            Console.Write("KellyDaily: ");
            test = Convert.ToInt32(Console.ReadLine());
            int KellyDaily = test >= 1 && test <= 100 ? test : throw new ArgumentException("los datos de la secuencia no cumplen las restricciones");
            Console.Write("Difference: ");
            test = Convert.ToInt32(Console.ReadLine());
            int Difference = test >= 0 && test <= 100 ? test : throw new ArgumentException("los datos de la secuencia no cumplen las restricciones");
            Dictionary<int, Dictionary<string, int>> Days = new Dictionary<int, Dictionary<string, int>>();
            if (SamDaily >= KellyDaily)
            {
                Console.WriteLine($"La Secuencia no se puede resolver, -1");
            }
            else
            {
                while (run)
                {
                    day++;
                    Dictionary<string, int> DayData = new Dictionary<string, int>();
                    if (flag == 1)
                    {
                        DayData.Add("samSolved", SamDaily + Difference);
                        DayData.Add("KellySolved", KellyDaily);
                        Days.Add(day, DayData);
                        flag = 0;
                    }
                    else
                    {
                        DayData.Add("samSolved", SamDaily + Days[day - 1]["samSolved"]);
                        DayData.Add("KellySolved", KellyDaily + Days[day - 1]["KellySolved"]);
                        Days.Add(day, DayData);
                    }
                    if (Days[day]["KellySolved"] > Days[day]["samSolved"])
                    {
                        run = false;
                    }

                }
                Console.WriteLine($"A Kelly le tomo {day} dias en superar a Sam");
            }
        }

        static void findLongestSubsequence()
        {
            int sumSecuence = 0;
            List<int> Secuence = new List<int>();
            Console.WriteLine($"Escriba el tamaño de la secuencia");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Escriba los numeros de la secuencia");
            for (int i = 0; i < length; i++)
            {
                Console.Write($"num {i + 1}: ");
                Secuence.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.Write($"Secuencia Normal: [");
            foreach (var item in Secuence)
            {
                Console.Write(item);
            }
            Console.WriteLine("]");
            Secuence.Sort();
            Console.Write($"Secuencia ordenada: [");
            foreach (var item in Secuence)
            {
                Console.Write(item);
            }
            Console.WriteLine("]");
            for (int i = 0; i < Secuence.Count() - 1; i++)
            {
                if (Secuence.Count() - 2 == i)
                {
                    sumSecuence += Secuence[i + 1] - Secuence[i];
                }
                else
                {
                    sumSecuence += Secuence[i];
                }
            }

            Console.Write($"Suma secuencia: {sumSecuence}");
            if (sumSecuence % 2 == 0)
            {
                Console.WriteLine($" (Par)");
                Console.WriteLine($"Secuencia Valida");
            }
            else
            {
                Console.WriteLine($" (impar)");
                Console.WriteLine($"Secuencia No Valida");
            }
            Console.WriteLine($"Cantidad: {length}");
        }
    }
}