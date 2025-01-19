using System;

namespace Module_5_Tasks
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            var user = GetUser();
            ShowUserInfo(user.Name, user.LastName, user.Age, user.IsPet, user.PetNames, user.Colors);
            Console.ReadKey();
        }
        static void ShowUserInfo(string Name, string LastName, int Age, bool IsPet, string[] PetNames, string[] Colors)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Информация по пользователю");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ваше имя: {0}", Name);
            Console.WriteLine("Ваше фамиля: {0}", LastName);
            Console.WriteLine("Ваш возраст: {0}", Age);
            
            if (IsPet) 
            {
                Console.WriteLine("Ваши питомцы:");
                foreach (string PetName in PetNames)
                {
                    Console.WriteLine(PetName);
                }
            }
            else
            {
                Console.WriteLine("Ваши питомцы: {0}", PetNames[0]);
            }
            Console.WriteLine("Ваши любимые цвета:");
            foreach (string color in Colors)
            {
                Console.WriteLine(color);
            }
            Console.ResetColor();
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы:");
        }
        static (string Name, string LastName, int Age, bool IsPet, string[] PetNames, string[] Colors) GetUser()
        {
                       
            string consdata;
            int num;
            string text;
           
            do
            {
                Console.WriteLine("Введите Ваше имя:");
                consdata = Console.ReadLine();
            } while (ChekUserText(consdata, out text) == false);
            string name = text;

            do
            {
                Console.WriteLine("Введите Вашу фамилию:");
                consdata = Console.ReadLine();
            } while (ChekUserText(consdata, out text) == false);
            string lastname = text;

            do
            {
                Console.WriteLine("Введите Ваш возраст:");
                consdata = Console.ReadLine();
            } while (ChekForNumeric(consdata, out num) == false);
            int age = num;

            bool ispet=false;
            bool petset=false;
            string[] petnames;
            do
            {
                Console.WriteLine("У Вас есть питомец (Введите Да/Нет)?:");
                consdata = Console.ReadLine();
                switch (consdata)
                {
                    case "Да":
                        do
                        {
                            Console.WriteLine("Введите количество питомцев цифрами:");
                            consdata = Console.ReadLine();
                        } while (ChekForNumeric(consdata, out num) == false);
                        petnames = FillArray(num, "Введите кличку {0} питомца:");
                        ispet = true;
                        petset = true;
                        break;
                    case "Нет":
                        petnames = ["Нет питомцев"];
                        petset = true;
                        break;
                    default:
                        petnames = ["Нет питомцев"];
                        continue;
                }
            } while (petset == false);
 

            do
            {
                Console.WriteLine("Введите количество Ваших любимых цветов:");
                consdata = Console.ReadLine();
            } while (ChekForNumeric(consdata, out num) == false);
            string[] colors = FillArray(num, "Введите {0} любимый цвет:");

            return (name, lastname, age, ispet, petnames, colors);
        }
        static string[] FillArray(int num, string msgtext)
        {
            
            string[] arr = new string[num];
            string result;
            string utext;

            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    Console.WriteLine(msgtext, i + 1);
                    result = Console.ReadLine();
                } while (ChekUserText(result, out utext) == false);
                arr[i] = utext;
            }
                        
            return arr;
        }

        static bool ChekUserText(string userenter, out string corrtext)
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
                    corrnumeric = 0;
                    return false;
                }
            }
            else
            {
                corrnumeric = 0;
                return false;
            }
            
        }




    }
}