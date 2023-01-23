using Figgle;

namespace SlotMachine_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOperations.AddToWinners("List of winners is empty");
            string menu;
            bool playing = true;
            while (playing)
            {
                menu = $"************ MENU ************\n" +
                            $"[1] Spin\n" +
                            $"[2] Add previous winner ({ListOperations.winners.Peek()})\n" +
                            $"[3] Add to an existing list\n" +
                            $"[4] Add a new list\n" +
                            $"[5] Exit\n";
                int choice = InputValidation.GetUserInputAsInt(menu);
                
                switch (choice)
                {
                    case 1:
                        TextAnimations.AnimateFrames(TextAnimations.slotMachineFrames, 1, 300);
                        string winner = TextAnimations.Shuffle(ListOperations.CCAD8);
                        TextAnimations.Blink(FiggleFonts.DancingFont.Render(winner));
                        ListOperations.AddToWinners(winner);
                        break;
                    case 2:
                        if (ListOperations.winners.Count > 1)
                        {
                            ListOperations.RemoveLastWinner();
                        }
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        playing = false;
                        break;
                    default:
                        break;
                }

                
                //Console.WriteLine("\nPress escape to exit...");
                //Console.ReadKey(true);
            }




            //for (int i = 20; i < 50; i++)
            //{
            //    Console.SetCursorPosition(20, i);
            //    Console.Write("        ");
            //    Thread.Sleep(50);
            //    Console.SetCursorPosition(20, i);
            //    Console.Write($"Drew{i - 20} ");
            //    Thread.Sleep(100);
            //}

            //falling letters
            //Console.SetCursorPosition(20, 20);
            //var letters = Console.ReadLine();
            //for (int i = 0; i < letters.Length; i++)
            //{
            //    for (int j = 20; j < 50; j++)
            //    {
            //        Console.SetCursorPosition(20 + i, j);
            //        Console.Write(letters[i]);
            //        Console.SetCursorPosition(20 + i, j - 1);
            //        Console.Write(" ");
            //        Thread.Sleep(100);
            //    }
            //}

            //TextAnimations.Blink("Drew");
        }
    }
}