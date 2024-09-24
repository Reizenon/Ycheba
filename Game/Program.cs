using System.Linq.Expressions;
using System.Reflection.Emit;
using static System.Console;

const int LocDoor = 0;
const int FirstFloor = 1;
const int FirstFloorFirstRoom = 11;
const int FirstFloorSecondRoom = 12;
const int FirstFloorThirdRoom = 13;
const int FirstFloorStairs = 5;
const int SecondFloor = 2;
const int SecondFloorFirstRoom = 21;
const int SecondFloorSecondRoom = 22;
const int SecondFloorThirdRoom = 23;
const int SecondFloorStairs = 6;


int locationNum = 0;


bool door_open = false;
bool hasChestKey = false;
bool hasJewelery = false;
bool firstFloorLeverOn = false;
bool hasMainKey = false;
bool chestOpen = false;
bool hasAxe = false;
bool secondFloorLeverOn = false;
bool thirdRoomOpen = false;
bool plateHasJewelery = false;
bool hasKeyOfSecondRoom = false;
bool stairsOpen = false;


start:
try
{
    //game
    WriteLine("Вы отправились с экспедицией в горы Грейс. На очередном привале вы решили отправиться поискать сухого хвороста для розжига костра. В своих поисках вы далеко отшли от лагеря. К вашему сожалению в этот неудачный момент началась метель. Вы пытались вернуться к товарищам по своим следам, но метель уже все замела. Видимость составляла около 1 метра, и вы не могли ничего разобрать впереди. Поблуждав около 15 минут вы наткнулись на каменную стену старого здания. Похоже оно уже давно стоит тут. Не найдя лучшего выхода вы решили переждать метель внутри. Однако как только вы шагнули за порог, дверь за вами захлопнулась. Видимо сработал старый механизм направленный на непрошеных гостей. Похоже вам придется искать выход.");
    ReadLine();
    while (!door_open)
    {
        if (locationNum == LocDoor) //дверь
        {
            //описание
            WriteLine();
            WriteLine("Перед вами та самая дверь. Ваши действия: ");
            WriteLine();
            //выбор действия
            WriteLine("1) Войти в зал");
            WriteLine("2) Открыть дверь");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            //обработка действия 
            if (action == 1) { locationNum = FirstFloor; }
            if (action == 2)
            {
                if (hasMainKey)
                {
                    WriteLine();
                    WriteLine("Дверь открыта");
                    WriteLine();
                    door_open = true;
                }
                else
                {
                    WriteLine();
                    WriteLine("Дверь заперта");
                    WriteLine();
                }
            }
        }
        if (locationNum == FirstFloor) //Первый этаж
        {
            //описание
            WriteLine();
            WriteLine("Вы видите коридор. В полумраке можно различить 3 двери, а в конце коридора едва различима лестница. Ваши действия: ");
            WriteLine();
            //выбор действия
            WriteLine("1) Войти в первую дверь");
            WriteLine("2) Войти во вторую дверь");
            WriteLine("3) Войти в третью дверь");
            WriteLine("4) Подойти к лестнице");
            WriteLine("5) Вернуться к двери");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            //обработка действия
            if (action == 1) { locationNum = FirstFloorFirstRoom; }
            if (action == 2) { locationNum = FirstFloorSecondRoom; }
            if (action == 3) { locationNum = FirstFloorThirdRoom; }
            if (action == 4) { locationNum = FirstFloorStairs; }
            if (action == 5) { locationNum = LocDoor; }
        }

        if (locationNum == FirstFloorFirstRoom) //Первый этаж первая комната
        {
            //описание
            WriteLine();
            WriteLine("Вы видите в углу комнаты старый деревянный шкаф, а напротив него находится стойка для брони");
            WriteLine();
            //выбор действия
            WriteLine("1) Осмотреть шкаф");
            WriteLine("2) Осмотреть стойку для брони");
            WriteLine("3) Выйти из комнаты");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            //обработка действия 
            if (action == 1)
            {
                if (!hasChestKey)
                {
                    WriteLine();
                    WriteLine("ВЫ открываете шкаф, на второй полке вы находите ключ и берете с собой");
                    WriteLine();
                    hasChestKey = true;
                }
                else
                {
                    WriteLine();
                    WriteLine("Вы уже забрали ключ, шкаф пуст");
                    WriteLine();
                }
            }
            if (action == 2)
            {
                if (!hasJewelery)
                {
                    hasJewelery = true;
                    WriteLine();
                    WriteLine("Осмотрев стойку для брони вы замечаете старую проржавевшую пластинчатую броню, также вы видите золотое ожерелье и забираете себе");
                    WriteLine();
                }
                else
                {
                    WriteLine();
                    WriteLine("Здесь только ржавая броня");
                    WriteLine();
                }
            }
            if (action == 3) { locationNum = FirstFloor; }
        }
        if (locationNum == FirstFloorSecondRoom) //Первый этаж вторая комната
        {
            if (!firstFloorLeverOn)
            {
                WriteLine();
                WriteLine("В этой комнате только рычаг");
                WriteLine();
                WriteLine("1) Нажать рычаг");
                WriteLine("2) Выйти из комнаты");
                Write("Ваш выбор: ");
                int action = int.Parse(ReadLine());
                if (action == 1)
                {
                    WriteLine();
                    WriteLine("Когда вы нажали рычаг из соседней комнаты послышался скрежет");
                    WriteLine();
                    firstFloorLeverOn = true;
                    { locationNum = FirstFloorSecondRoom; }
                }
                if (action == 2) { locationNum = FirstFloor; }
            }
            else
            {
                WriteLine();
                WriteLine("Вы уже активировали рычаг");
                WriteLine();
                WriteLine("1) Выйти из комнаты");
                Write("Ваш выбор: ");
                int action = int.Parse(ReadLine());
                if (action == 1) { locationNum = FirstFloor; }
            }

        }
        if (locationNum == FirstFloorThirdRoom) //Первый этаж третья комната
        {
            if (!firstFloorLeverOn)
            {
                WriteLine();
                WriteLine("В этой комнате вы видите сундук за запертой решеткой");
                WriteLine();
                WriteLine("1) Выйти из комнаты");
                Write("Ваш выбор: ");
                int action = int.Parse(ReadLine());
                if (action == 1) { locationNum = FirstFloor; }
            }
            else
            {
                WriteLine();
                WriteLine("В этой комнате вы видите сундук, решетка открыта");
                WriteLine();
                WriteLine("1) Осмотреть сундук");
                Write("Ваш выбор: ");
                int action = int.Parse(ReadLine());
                if (action == 1) { locationNum = FirstFloor; }
                if (!chestOpen)
                {
                    if (!hasChestKey)
                    {
                        WriteLine();
                        WriteLine("Сундук заперт на замок");
                        WriteLine();
                        WriteLine("1) Выйти из комнаты");
                        Write("Ваш выбор: ");
                        int action1 = int.Parse(ReadLine());

                        if (action == 1) { locationNum = FirstFloor; }
                    }
                    else
                    {
                        if (!hasAxe)
                        {
                            WriteLine();
                            WriteLine("Вы открываете сундук найденным ключем, в нем лежит топор, вы берете его с собой и выходите из комнаты");
                            WriteLine();
                            hasAxe = true;
                            { locationNum = FirstFloor; }
                        }
                        else
                        {
                            WriteLine();
                            WriteLine("Сундук пуст");
                            WriteLine();
                            WriteLine("1) Выйти из комнаты");
                            Write("Ваш выбор: ");
                            int action1 = int.Parse(ReadLine());
                        }
                    }
                }
            }
        }
        if (locationNum == FirstFloorStairs) //Первый этаж лестница
        {
            if (!stairsOpen)
            {
                if (!hasAxe)
                {
                    WriteLine();
                    WriteLine("Лестница завалена досками, нужно как-то их убрать");
                    WriteLine();
                    WriteLine("1) Выйти в коридор");
                    Write("Ваш выбор: ");
                    int action = int.Parse(ReadLine());
                    if (action == 1) { locationNum = FirstFloor; }
                }
                else
                {
                    WriteLine();
                    WriteLine("Вы разрубаете доски и расчищаете проход");
                    WriteLine();
                    WriteLine("1) Подняться наверх");
                    WriteLine("2) Вернуться в коридор");
                    Write("Ваш выбор: ");
                    int action = int.Parse(ReadLine());
                    if (action == 2) { locationNum = FirstFloor; }
                    if (action == 1) { locationNum = SecondFloorStairs; }
                    stairsOpen = true;
                }
            }
            else
            {
                WriteLine();
                WriteLine("Перед вами летница");
                WriteLine();
                WriteLine("1) Подняться наверх");
                WriteLine("2) Вернуться в коридор");
                Write("Ваш выбор: ");
                int action = int.Parse(ReadLine());
                if (action == 2) { locationNum = FirstFloor; }
                if (action == 1) { locationNum = SecondFloorStairs; }
            }
        }
        if (locationNum == SecondFloorStairs) //Второй этаж лестница
        {
            WriteLine();
            WriteLine("Вы поднялись на 2 этаж, перед вами коридор");
            WriteLine();
            WriteLine("1) Спуститься вниз");
            WriteLine("2) Пройти вперед");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            if (action == 1) { locationNum = FirstFloorStairs; }
            if (action == 2) { locationNum = SecondFloor; }
        }
        if (locationNum == SecondFloor) //Второй этаж 
        {
            WriteLine();
            WriteLine("Вы находитесь в коридоре второго этажа, куда пойдете?");
            WriteLine();
            WriteLine("1) Первая комната");
            WriteLine("2) Вторая комната");
            WriteLine("3) Третья комната");
            WriteLine("4) Вернуться к лестнице");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            if (action == 1) { locationNum = SecondFloorFirstRoom; }
            if (action == 2)
            {
                if (hasKeyOfSecondRoom) { locationNum = SecondFloorSecondRoom; }
                if (!hasKeyOfSecondRoom)
                {
                    WriteLine();
                    WriteLine("Дверь закрыта на ключ");
                    WriteLine();
                    { locationNum = SecondFloor; }
                }
            }
            if (action == 3)
            {
                if (thirdRoomOpen) { locationNum = SecondFloorThirdRoom; }
                if (!thirdRoomOpen)
                {
                    WriteLine();
                    WriteLine("Проход закрыт стальной решеткой");
                    WriteLine();
                    { locationNum = SecondFloor; }
                }
            }
            if (action == 4) { locationNum = SecondFloorStairs; }
        }
        if (locationNum == SecondFloorFirstRoom)
        {
            WriteLine();
            WriteLine("Вы заходите в комнату, на одной из стен вы замечаете плиту с выемкой");
            WriteLine();
            WriteLine("1) Осмотреть плиту");
            WriteLine("2) Вернуться в коридор");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            if (action == 1)
            {
                if (!hasJewelery)
                {
                    WriteLine();
                    WriteLine("Похоже сюда нужно что-то положить");
                    WriteLine();
                    { locationNum = SecondFloorFirstRoom; }
                }
                if (hasJewelery)
                {
                    if (!plateHasJewelery)
                    {
                        WriteLine();
                        WriteLine("Вы замечаете что ожерелье по форме напоминает выемкув плите и вставляете его, плита отодвигается в отверстии лежит ключ, вы его берете");
                        WriteLine();
                        plateHasJewelery = true;
                        hasKeyOfSecondRoom = true;
                        { locationNum = SecondFloorFirstRoom; }
                    }
                    else
                    {
                        WriteLine();
                        WriteLine("Вы уже забрали ключ");
                        WriteLine();
                        { locationNum = SecondFloorFirstRoom; }
                    }


                }

            }
            if (action == 2) { locationNum = SecondFloor; }

        }
        if (locationNum == SecondFloorSecondRoom)
        {
            WriteLine();
            WriteLine("Вы заходите в комнату и видите ржавый рычаг");
            WriteLine();
            WriteLine("1) Осмотреть рычаг");
            WriteLine("2) Вернуться в коридор");
            Write("Ваш выбор: ");
            int action = int.Parse(ReadLine());
            if (action == 1)
            {
                if (!secondFloorLeverOn)
                {
                    WriteLine();
                    WriteLine("Вы активируете рычаг");
                    WriteLine();
                    secondFloorLeverOn = true;
                    thirdRoomOpen = true;
                    { locationNum = SecondFloorSecondRoom; }
                }
                else
                {
                    WriteLine();
                    WriteLine("Вы уже активировали рычаг");
                    WriteLine();
                    { locationNum = SecondFloorSecondRoom; }
                }


            }
            if (action == 2) { locationNum = SecondFloor; }
        }
        if (locationNum == SecondFloorThirdRoom)
        {
            if (!hasMainKey)
            {
                WriteLine();
                WriteLine("Вы видите золотой ключ лежащий на постаменте");
                WriteLine();
                WriteLine("1) Взять ключ");
                WriteLine("2) Вернуться в коридор");
                Write("Ваш выбор: ");
                int action = int.Parse(ReadLine());
                if (action == 1)
                {
                    WriteLine();
                    WriteLine("Вы взяли ключ и побежали к входной двери");
                    WriteLine();
                    hasMainKey = true;
                }
                if (action == 2) { locationNum = SecondFloor; }
            }
            if (hasMainKey)
            {
                WriteLine();
                WriteLine("Вы уже забрали ключ");
                WriteLine();
                { locationNum = SecondFloor; }
            }
        }
    }
    //win
    WriteLine();
    WriteLine("Вы выбрались");

}
catch (FormatException)
{
    WriteLine();
    WriteLine("Введено неверное значение");
    WriteLine();
    goto start;
}

