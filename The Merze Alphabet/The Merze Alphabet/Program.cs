using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    public class MorseTranslator
    {
        private static readonly Dictionary<char, string> TextToMorse = new Dictionary<char, string>
        {
            { 'A', ".-" },
            { 'B', "-..." },
            { 'C', "-.-." },
            { 'D', "-.." },
            { 'E', "." },
            { 'F', "..-." },
            { 'G', "--." },
            { 'H', "...." },
            { 'I', ".." },
            { 'J', ".---" },
            { 'K', "-.-" },
            { 'L', ".-.." },
            { 'M', "--" },
            { 'N', "-." },
            { 'O', "---" },
            { 'P', ".--." },
            { 'Q', "--.-" },
            { 'R', ".-." },
            { 'S', "..." },
            { 'T', "-" },
            { 'U', "..-" },
            { 'V', "...-" },
            { 'W', ".--" },
            { 'X', "-..-" },
            { 'Y', "-.--" },
            { 'Z', "--.." },
            { '1', ".----" },
            { '2', "..---" },
            { '3', "...--" },
            { '4', "....-" },
            { '5', "....." },
            { '6', "-...." },
            { '7', "--..." },
            { '8', "---.." },
            { '9', "----." },
            { '0', "-----" },
            { ' ', "/" }
        };
        private static readonly Dictionary<string, char> MorseToText = new Dictionary<string, char>();
        static MorseTranslator()
        {
            foreach (var pair in TextToMorse)
            {
                MorseToText[pair.Value] = pair.Key;
            }
        }
        public static string ToMorse(string input)
        {
            input = input.ToUpper();
            var morse = new List<string>();

            foreach (char c in input)
            {
                if (TextToMorse.ContainsKey(c))
                {
                    morse.Add(TextToMorse[c]);
                }
                else
                {
                    throw new ArgumentException($"Символ {c} не поддерживается.");
                }
            }
            return string.Join(" ", morse);
        }
        public static string FromMorse(string input)
        {
            var text = new List<char>();
            var morseSymbols = input.Split(' ');

            foreach (string symbol in morseSymbols)
            {
                if (MorseToText.ContainsKey(symbol))
                {
                    text.Add(MorseToText[symbol]);
                }
                else
                { 
                    throw new ArgumentException($"Морзе-код '{symbol}' не распознан.");
                }
            }
            return new string(text.ToArray());
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Выберите режим:");
                Console.WriteLine("1. Текст -> Морзе:");
                Console.WriteLine("2. Морзе -> Текст:");
                Console.WriteLine("Ваш выбор:");

                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        Console.WriteLine("Введите текст: ");
                        string input = Console.ReadLine();
                        string morse = MorseTranslator.ToMorse(input);
                        Console.WriteLine($"Азбука Морзе: {morse}");
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("Введите Морзе используя пробел для разделения:");
                        string input = Console.ReadLine();
                        string text = MorseTranslator.FromMorse(input);
                        Console.WriteLine($"Текст: {text}");
                    }
                    else
                    {
                        Console.WriteLine("неверный выбор.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}