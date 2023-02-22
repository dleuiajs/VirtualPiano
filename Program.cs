using System;

namespace VirtualPiano
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Please enter the duration of the note playback in milliseconds (150 is the recommended value)");
            bool success = false;
            int ms = 0;
            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out ms); // получаем длительность воспроизведения ноты в миллисекундах
                if (success)
                {
                    if (ms > 0 && ms <= 10000)
                        Console.WriteLine("Success! To exit the application, press the 'Esc' key.");
                    else
                        success = false;
                }
                if (!success)
                    Console.WriteLine("Error! Please enter a number between 1 and 10000 ms.");
            }

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) // если нажата клавиша esc
                    break;

                if (key.Modifiers == ConsoleModifiers.Shift) // если была зажата клавиша шифт
                {
                    bool founded = false;
                    for (int i = 0; founded == false && i < Arrays.vp.Length;)
                    {
                        if (Arrays.vpshift[i] == true) // если данная клавиша в массиве с шифтом, то
                        {
                            if (Arrays.vp[i] == key.Key) // если клавиша в массиве равна клавише нажатой пользователем, то
                            {
                                Console.Beep(Arrays.freq[i], ms); // воспроизводим ноту 
                                Console.Write(Arrays.keysString[i]); // пишем в одну строку нажатую клавишу
                                founded = true;
                            }
                            else i++; // иначе идем к след. клавише
                        }
                        else i++; // иначе идем к след. клавише
                    }
                }
                else if (key.Modifiers != ConsoleModifiers.Shift) // если не была зажата клавиша шифт
                {
                    bool founded = false;
                    for (int i = 0; founded == false && i < Arrays.vp.Length;)
                    {
                        if (Arrays.vpshift[i] == false) // если данная клавиша в массиве без шифта, то
                        {
                            if (Arrays.vp[i] == key.Key) // если клавиша в массиве равна клавише нажатой пользователем, то
                            {
                                Console.Beep(Arrays.freq[i], ms); // воспроизводим ноту 
                                Console.Write(Arrays.keysString[i]); // пишем в одну строку нажатую клавишу
                                founded = true;
                            }
                            else i++; // иначе идем к след. клавише
                        }
                        else i++; // иначе идем к след. клавише
                    }
                }
            }
        }
    }
}