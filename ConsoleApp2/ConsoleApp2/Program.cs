using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LOC_DOOR = 1;
            const int LOC_TABLE = 2;
            const int LOC_PICTURE = 3;

            int location = LOC_DOOR;
            int safeCode = Random.Next(100, 1000);
            bool hasKey = false;
            bool pictureDown = false;
            bool safeOpen = false;
            bool doorOpen = false;

            //игра
            while (!doorOpen)
            {
                if (location == LOC_DOOR)
                {
                    //описане
                    Console.WriteLine();
                    Console.WriteLine("Перед вами тяжелая дубоваядверь. У двери есть замочная скважина.");
                    //действие
                    Console.WriteLine("перейти к столику");
                    Console.WriteLine("перейти к картине");
                    Console.WriteLine("открыть дверь");
                    Console.WriteLine("Ваш выбор? ");
                    int action = int.Parse(Console.ReadLine());
                    //обработка
                    if (action == 1) location = LOC_TABLE;
                    if (action == 2) location = LOC_PICTURE;
                    if (action == 3)
                    {
                        if (hasKey)
                        {

                        }
                    }
                }

                if (location == LOC_TABLE)
                {
                    //описание
                    Console.WriteLine();
                    Console.WriteLine("Вы видите журнальный столик, на котором лежит газета");
                    //действия

                }

                if (location == LOC_PICTURE)
                {
                    //описание
                    if (!pictureDown) Console.WriteLine("Перед вами висит картина");
                    else if (!safeOpen) Console.WriteLine("Перед вами закрытый сейф");
                    else if (!hasKey) Console.WriteLine("В открытом сейфе лежит ключ");
                    else Console.WriteLine("Вы видитепустой сейф");

                    //выбор действий
                    Console.WriteLine("1) перейти к двери");
                    Console.WriteLine("2) перейти к столику");
                    if ()
                }
            }
            //поздравление
            Console.WriteLine();
            Console.WriteLine("Поздравляю. Вы прошли игру!");
        }
    }
}
