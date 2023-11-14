using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BEROOPLaba8._1HW
{
    class Program
    {
        static void Main()
        {
            // Путь к входному файлу
            string inputFilePath = "C:\\Users\\Coolsinee\\source\\repos\\BEROOPLaba8.1HW\\BEROOPLaba8.1HW\\input.txt";

            // Путь к выходному файлу
            string outputFilePath = "C:\\Users\\Coolsinee\\source\\repos\\BEROOPLaba8.1HW\\BEROOPLaba8.1HW\\output.txt";

            // Чтение текстового файла и создание списка адресов электронной почты
            List<string> emailAddresses = ReadEmailAddressesFromFile(inputFilePath);

            // Запись списка адресов электронной почты в новый файл
            WriteEmailAddressesToFile(outputFilePath, emailAddresses);

            Console.WriteLine("Обработка завершена. Результаты сохранены в output.txt.");
        }

        public static List<string> ReadEmailAddressesFromFile(string filePath)
        {
            List<string> emailAddresses = new List<string>();

            // Чтение строк из файла
            string[] lines = File.ReadAllLines(filePath);

            // Обработка каждой строки и поиск адреса электронной почты
            foreach (string line in lines)
            {
                string emailAddress = line;
                SearchMail(ref emailAddress);
                if (!string.IsNullOrEmpty(emailAddress) && IsValidEmail(emailAddress))
                {
                    emailAddresses.Add(emailAddress);
                }
            }

            return emailAddresses;
        }

        public static void SearchMail(ref string s)
        {
            // Разделитель между ФИО и адресом электронной почты
            char separator = '#';

            // Находим индекс разделителя в строке
            int index = s.IndexOf(separator);

            // Если разделитель найден
            if (index != -1)
            {
                // Выделяем подстроку, содержащую адрес электронной почты
                s = s.Substring(index + 1).Trim();
            }
            else
            {
                // Если разделитель не найден, обнуляем строку
                s = string.Empty;
            }
        }

        public static bool IsValidEmail(string email)
        {
            // Проверка адреса электронной почты с использованием регулярного выражения
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static void WriteEmailAddressesToFile(string filePath, List<string> emailAddresses)
        {
            // Запись списка адресов электронной почты в новый файл
            File.WriteAllLines(filePath, emailAddresses);
        }
    }
}
