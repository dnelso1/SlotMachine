using System;
namespace SlotMachine_console
{
	public class InputValidation
	{
        public static int GetUserInputAsInt(string msg, bool confirmInput = true)
        {
            bool isValid;
            int input;
            do
            {
                isValid = false;
                Console.WriteLine(msg);

                bool success = int.TryParse(Console.ReadLine(), out input);
                if (!success)
                {
                    Console.WriteLine("\nInvalid Input. Please try again.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                //if (confirmInput)
                //{
                //    isValid = ConfirmUserInput($"{input}");
                //    if (!isValid)
                //    {
                //        PrintStringToUser("Input value reset. Please try again.");
                //    }
                //}
                isValid = true;
            } while (!isValid);

            Console.Clear();

            return input;
        }
    }
}

