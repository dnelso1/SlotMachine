using Figgle;
using static System.Net.Mime.MediaTypeNames;

namespace SlotMachine_console
{
	public class TextAnimations
	{
        public static string[] slotMachineFrames = new string[] { $@"
                  _________________________________
                 |===-------===-------===-------===| __
                 ||*|                           |*||(__)
                 ||*|                           |*|| ||
                 ||*|                           |*|| ||
                 ||*|                           |*||_//
                 ||*|                           |*||_/
                 |===-------===-------===-------===|
                 |  /___________________________\  |
                 |   |                         |   |
                _|    \_______________________/    |_
               (_____________________________________)",
        $@"
                  _________________________________
                 |===-------===-------===-------===|
                 ||*|                           |*|| __
                 ||*|                           |*||(__)
                 ||*|                           |*|| ||
                 ||*|                           |*||_//
                 ||*|                           |*||_/
                 |===-------===-------===-------===|
                 |  /___________________________\  |
                 |   |                         |   |
                _|    \_______________________/    |_
               (_____________________________________)",
        $@"
                  _________________________________
                 |===-------===-------===-------===|
                 ||*|                           |*||
                 ||*|                           |*||  __
                 ||*|                           |*|| (__)
                 ||*|                           |*||_//
                 ||*|                           |*||_/
                 |===-------===-------===-------===|
                 |  /___________________________\  |
                 |   |                         |   |
                _|    \_______________________/    |_
               (_____________________________________)",
        $@"
                  _________________________________
                 |===-------===-------===-------===|
                 ||*|                           |*|| __
                 ||*|                           |*||(__)
                 ||*|                           |*|| ||
                 ||*|                           |*||_//
                 ||*|                           |*||_/
                 |===-------===-------===-------===|
                 |  /___________________________\  |
                 |   |                         |   |
                _|    \_______________________/    |_
               (_____________________________________)",
        $@"
                  _________________________________
                 |===-------===-------===-------===| __
                 ||*|                           |*||(__)
                 ||*|                           |*|| ||
                 ||*|                           |*|| ||
                 ||*|                           |*||_//
                 ||*|                           |*||_/
                 |===-------===-------===-------===|
                 |  /___________________________\  |
                 |   |                         |   |
                _|    \_______________________/    |_
               (_____________________________________)"};

        public static void Blink(string text)
		{
            Console.CursorVisible = false;
            for (int i = 0; i < 10; i++)
            {
                Console.Write(text);
                Thread.Sleep(400);
                Console.Clear();
                Thread.Sleep(100);
            }
            Console.CursorVisible = true;
        }

        public static string Shuffle(List<string> words)
        {
            string winner = string.Empty;
            double sleep = 10;
            Random rand = new Random();
            int randIndex;
            (string next, string curr, string prev) text;

            Console.CursorVisible = false;
            for (int i = 0; sleep < 1000; i++)
            {
                randIndex = rand.Next(words.Count - 1);
                if (sleep * 1.15 >= 1000)
                {
                    text = ListOperations.GetSlotMachineNamesFromIndex(randIndex);
                    DisplayTextInBox(text.next, text.curr, text.prev);
                    winner = words[randIndex];
                }
                else
                {
                    text = ListOperations.GetSlotMachineNamesFromIndex(i);
                    DisplayTextInBox(text.next, text.curr, text.prev);
                }

                Thread.Sleep((int)sleep);
                Console.Clear();
                sleep *= 1.15;

                if (i == words.Count - 1)
                {
                    i = 0;
                }
            }
            Console.CursorVisible = true;

            Thread.Sleep(1500);
            return winner;
        }

        public static void DisplayTextInBox(string next, string curr, string prev)
        {
            string nextSpacesPre = new string(' ', (27 - next.Length) / 2);
            string nextSpacesPost = next.Length % 2 == 1 ? nextSpacesPre : new string(' ', (30 - next.Length) / 2 - 1);
            string currSpacesPre = new string(' ', (27 - curr.Length) / 2);
            string currSpacesPost = curr.Length % 2 == 1 ? currSpacesPre : new string(' ', (30 - curr.Length) / 2 - 1);
            string prevSpacesPre = new string(' ', (27 - prev.Length) / 2);
            string prevSpacesPost = prev.Length % 2 == 1 ? prevSpacesPre : new string(' ', (30 - prev.Length) / 2 - 1);

            Console.WriteLine($@"
                  _________________________________
                 |===-------===-------===-------===| __
                 ||*|{nextSpacesPre}{next}{nextSpacesPost}|*||(__)
                 ||*|                           |*|| ||
                 ||*|{currSpacesPre}{curr.ToUpper()}{currSpacesPost}|*|| ||
                 ||*|                           |*||_//
                 ||*|{prevSpacesPre}{prev}{prevSpacesPost}|*||_/
                 |===-------===-------===-------===|
                 |  /___________________________\  |
                 |   |                         |   |
                _|    \_______________________/    |_
               (_____________________________________)");
        }

        public static void Slide(string text)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write($" {text}");
                Thread.Sleep(100);
                //Console.SetCursorPosition(i + 1, 10);
                //Console.Write("          ");
                //Thread.Sleep(500);
            }

            for (int i = 50; i > 0; i--)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write($"{text} ");
                Thread.Sleep(100);
                //Console.SetCursorPosition(i + 1, 10);
                //Console.Write("          ");
                //Thread.Sleep(500);
            }
            Console.CursorVisible = true;
        }

        public static void AnimateFrames(string[] frames, int repeatCount=5, int delay=100)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < repeatCount; i++)
            {
                foreach (string frame in frames)
                {
                    Console.Clear();
                    Console.WriteLine(frame);
                    Thread.Sleep(delay);
                    Console.Clear();
                }
            }
            Console.CursorVisible = true;
        }

        public static void Typing(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(75);

                //skip the rest of the animation if spacebar or enter is pressed
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Write(text.Substring(i + 1));
                        break;
                    }
                }
            }
        }
    }
}

