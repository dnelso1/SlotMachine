using System;
namespace SlotMachine_console
{
	public class ListOperations
	{
        public static List<string> CCAD8 = new List<string>() { "Drew", "Josh", "Greg", "Mursal", "Rico", "Donovan", "Patrick",
                                                        "Mark", "Erik", "David", "Rohin", "Brian", "Jackson", "Alex"};
        public static Stack<string> winners = new Stack<string>();
        

        public static void AddToWinners(string winner)
        {
            CCAD8.Remove(winner);
            winners.Push(winner);
        }

        public static string RemoveLastWinner()
        {
            string prevWinner = winners.Pop();
            CCAD8.Add(prevWinner);
            return prevWinner;
        }

        public static (string next, string curr, string prev) GetSlotMachineNamesFromIndex(int index)
        {
            int next;
            int curr;
            int prev;

            if (CCAD8.Count == 0)
            {
                return ("Empty", "Empty", "Empty");
            }
            else if (CCAD8.Count == 1)
            {
                return (CCAD8[index], CCAD8[index], CCAD8[index]);
            }
            else if (CCAD8.Count == 2)
            {
                if (index == 0)
                {
                    return (CCAD8[index + 1], CCAD8[index], CCAD8[index + 1]);
                }
                else
                {
                    return (CCAD8[index - 1], CCAD8[index], CCAD8[index - 1]);
                }
            }
            else if (index == 0)
            {
                return (CCAD8[index + 1], CCAD8[index], CCAD8[CCAD8.Count - 1]);
            }
            else if (index >= 1 && index < CCAD8.Count - 1)
            {
                return (CCAD8[index + 1], CCAD8[index], CCAD8[index - 1]);
            }
            else //if (index == CCAD8.Count - 1)
            {
                return (CCAD8[0], CCAD8[index], CCAD8[index - 1]);
            }

            
        }
    }
}

