using System;

namespace Module_5_Tasks
{
    class Program
    {

        public static void Main(string[] args)
        //Тестовое задание к Модулю 5. Курс Профессия С# Разработчик
        //Немного украсил консоль, чтобы было не скучно, хотя этого небыло в задании не судите строго))
        {
            WriteInColor("ПРЕДУПРЕЖДЕНИЕ! ", false, 12);
            WriteInColor("Вводите данные корректно\n", true, 15);
            WriteInColor("Анкета пользователя", true, 14);
            ShowUserInfo(GetUser());
            Console.ResetColor();
            Console.Write("\nНажмите любую клавишу для выхода из программы:");
            Console.ReadKey();
        }

        static void WriteInColor(string text, bool method, int color)
        //метод выводит сообщение в консоль в заданном цвете и заданным методом
        //если числовое значение превышает допустимое в перечислении вывод в консоль - серым цветом
        {
            if (color <= 15) { Console.ForegroundColor = (ConsoleColor)color; }
            else { Console.ForegroundColor = (ConsoleColor)7; }
            if (method) { Console.WriteLine(text); }
            else { Console.Write(text); }
        }
        static void ShowUserInfo((string Name, string LastName, int Age, bool IsPet, string[] Petnames, string[] favColors) User)
        //Метод выводит информацию указаную пользователем в анкете
        {
            WriteInColor("\nРезультат анкетирования пользователя", true, 14);
            WriteInColor("Ваше имя: ", false, 10);
            WriteInColor(User.Name, true, 15);
            WriteInColor("Ваша фамилия: ", false, 10);
            WriteInColor(User.LastName, true, 15);
            WriteInColor("Ваш возраст: ", false, 10);
            WriteInColor(Convert.ToString(User.Age), true, 15);

            if (User.IsPet)
            {
                WriteInColor("Ваши питомцы:", true, 10);
                foreach (string petname in User.Petnames)
                {
                    WriteInColor(petname, true, 11);
                }
            }
            else
            {
                WriteInColor("Ваши питомцы: ", false, 10);
                WriteInColor(User.Petnames[0], true, 15);
            }

            WriteInColor("Ваши любимые цвета:", true, 10);
            foreach (string color in User.favColors)
            {
                WriteInColor(color, true, 13);
            }
        }
        static (string Name, string LastName, int Age, bool IsPet, string[] PetNames, string[] favColors) GetUser()
        // метод возвращает кортеж с анкетными даннымим пользователя
        {
            (string Name, string LastName, int Age, bool IsPet, string[] PetNames, string[] favColors) User;

            User.Name = TextQuestion("Введите Ваше имя: ");
            User.LastName = TextQuestion("Введите Вашу фамилию: ");
            User.Age = NumQuestion("Введите Ваш возраст цифрами (полных лет): ");

            string consdata;
            bool petset = false;
            do
            {
                WriteInColor("У Вас есть питомец (Введите Да/Нет)?: ", false, 15);
                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();
                consdata = string.IsNullOrWhiteSpace(input) ? string.Empty : input;
                switch (consdata)
                {
                    case "Да":
                        User.PetNames = FillArray(NumQuestion("Введите количество питомцев цифрами: "), "Введите кличку питомца № ");
                        User.IsPet = true;
                        petset = true;
                        break;
                    case "Нет":
                        User.IsPet = false;
                        User.PetNames = ["Нет питомцев"];
                        petset = true;
                        break;
                    default:
                        User.IsPet = false;
                        User.PetNames = ["Нет питомцев"];
                        continue;
                }
            } while (petset == false);

            User.favColors = FillArray(NumQuestion("Введите количество Ваших любимых цветов цифрами: "), "Введите любимый цвет № ");

            return (User);
        }
        static string TextQuestion(string msgtext)
        //метод запрашивает у пользователя строчные данные, вызывает методы проверки и возвращает корректное значение
        {
            string consstring;
            string corrstring;
            do
            {
                WriteInColor(msgtext, false, 15);
                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();
                consstring = string.IsNullOrWhiteSpace(input) ? string.Empty : input;
            } while (ChekUserText(consstring, out corrstring) == false);
            return corrstring;
        }

        static int NumQuestion(string msgtext)
        //метод запрашивает у пользователя числовые данные, вызывает методы проверки и возвращает корректное значение
        {
            string consint;
            int corrint;
            do
            {
                WriteInColor(msgtext, false, 15);
                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();
                consint = string.IsNullOrWhiteSpace(input) ? string.Empty : input;
            } while (ChekForNumeric(consint, out corrint) == false);
            return corrint;
        }
        static string[] FillArray(int num, string msgtext)
        //метод заполняет и возвращает массивы для кличек питомцев и любимых цветов
        //вызывает метод запроса строчных данных у пользователя
        {
            string[] arr = new string[num];
            int number;

            for (int i = 0; i < arr.Length; i++)
            {
                number = i + 1;
                arr[i] = TextQuestion(Convert.ToString(msgtext + number + ": "));
            }

            return arr;
        }

        static bool ChekUserText(string userenter, out string corrtext)
        //мтод проверяет корректность заполнения строковых данных вызывает также метод проверки на числовое значение
        {

            if ((ChekForNumeric(userenter, out int corrnum2) == false) & (userenter.Length >= 2))
            {
                corrtext = userenter;
                return true;
            }
            else
            {
                corrtext = string.Empty;
                return false;
            }

        }
        static bool ChekForNumeric(string userenter, out int corrnumeric)
        //метод проеряет корректность заполнения числовых данных
        //метод Console.Beep(1000, 300) можно раскоментировать если код выполняется на платформе Windows
        {
            if (int.TryParse(userenter, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumeric = intnum;
                    return true;
                }
                else
                {
                    // Console.Beep(1000, 300);
                    corrnumeric = 0;
                    return false;
                }
            }
            else
            {
                // Console.Beep(1000, 300);
                corrnumeric = 0;
                return false;
            }

        }




    }
}