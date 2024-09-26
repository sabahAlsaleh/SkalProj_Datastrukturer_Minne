using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            List<string> theList = new List<string>();
            bool isRunning = true;
            while (isRunning)
            {
                // Prompt the user for input
                Console.WriteLine("Enter '+' followed by a name to add to the list, or '-' followed by a name to remove. Type '0' to return to the menu.");

                string input = Console.ReadLine();
                char nav = input[0];
                string name = input.Substring(1).Trim(); // Remaining characters, the name

                switch (nav)
                {
                    case '+':
                        theList.Add(name);
                        Console.WriteLine($"{name} has been added to the list.");
                        break;

                    case '-':
                        if (theList.Contains(name))
                        {
                            theList.Remove(name);
                            Console.WriteLine($"{name} has been removed from the list.");
                        }
                        else
                        {
                            Console.WriteLine($"{name} is not in the list.");
                        }
                        break;

                    case '0':
                        isRunning = false; // Exit the method
                        Console.WriteLine("ExamineList is exiting.");
                        break;
                    default:
                        // Invalid input
                        Console.WriteLine("Use only '+' or '-' or '0'. Please try again.");
                        break;
                }

                // Print current count and capacity of the list
                Console.WriteLine($"Number of elements in the list: {theList.Count}");
                Console.WriteLine($"List capacity: {theList.Capacity} \n");


                // F2 :  Kapaciteten ökar när det tillkommer ett nytt element som inte får plats i den aktuella kapaciteten.
                // C#-listor har en underliggande array, och när denna array blir full, allokeras en ny array med större storlek
                // i mitt exaple hade list 4 capacity och när jag la 4 namn ökade listan till 8


                // F3: När kapaciteten ökar, fördubblas den vanligtvis.

                // F4: Nej, kapaciteten minskar inte när element tas bort. Listans kapacitet förblir densamma tills en "TrimExcess()" kallas,
                // som minskar kapaciteten till det faktiska antalet element i listan.

                //F5: arrayer kan vara fördelaktiga om mzn vet exakt hur många element
                //man kommer att hantera och vill ha direkt kontroll över minnesanvändningen ( tillexample pixlar i en bild) 






            }
        }

            /// <summary>
            /// Examines the datastructure Queue
            /// </summary>
            static void ExamineQueue()
            {
                /*
                 * Loop this method untill the user inputs something to exit to main menue.
                 * Create a switch with cases to enqueue items or dequeue items
                 * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
                */
                Queue<string> queue = new Queue<string>();

                bool isRunning = true;
                Console.WriteLine("\n ICA queue simulator. Use '+' to enqueue someone and '-' to dequeue someone.");

                while (isRunning)
                {
                    // Prompt the user for input
                    Console.Write("Enter a command (+person, - or '0' to return to the menu): ");

                    string input = Console.ReadLine();
                    char nav = input[0];
                    string name = input.Substring(1).Trim(); // Remaining characters, the name

                    switch (nav)
                    {
                        case '+':
                            queue.Enqueue(name);
                            Console.WriteLine($"{name} has been added to the queue.");
                            break;

                        case '-':
                            if (queue.Count > 0) // Check if the queue is not empty
                            {
                                string DequeueName = queue.Dequeue();
                                Console.WriteLine($"{DequeueName} has been dequeued.");
                            }
                            else
                            {
                                Console.WriteLine("The queue is empty, no one to dequeue.");
                            }
                            break;

                        case '0':
                            isRunning = false; // Exit the method
                            Console.WriteLine("The simulation is exiting.");
                            break;
                        default:
                            // Invalid input
                            Console.WriteLine("Use only '+' or '-' or '0'. Please try again.");
                            break;
                    }

                    // Show the current queue
                    Console.WriteLine("\n Current queue:");
                    if (queue.Count > 0)
                    {
                        foreach (string item in queue)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The queue is empty, no one to dequeue \n ");
                    }
                }

            }

            /// <summary>
            /// Examines the datastructure Stack
            /// </summary>
            static void ExamineStack()
            {
                /*
                 * Loop this method until the user inputs something to exit to main menue.
                 * Create a switch with cases to push or pop items
                 * Make sure to look at the stack after pushing and and poping to see how it behaves
                */


                // F1: En stack fungerar enligt principen (FILO). Detta innebär att det sista elementet som läggs till är det första som tas bort.
                // Om vi använder en stack för att simulera en ICA-kö blir resultatet att den senaste personen som ställer sig i kön blir den första att expedieras,
                // medan den som ställde sig först får vänta längst.


                Console.Write("Enter a string to reverse: ");
                string input = Console.ReadLine();

                // Reverse the string using a stack
                string reversed = ReverseText(input);

                Console.WriteLine($"The reversed string is: {reversed} \n");
            }

            static string ReverseText(string input)
            {
                // Create a stack to store each character
                Stack<char> stack = new Stack<char>();

                // Push each character from the input string onto the stack
                foreach (char c in input)
                {
                    stack.Push(c);
                }

                // Pop the characters from the stack and build the reversed string
                string reversed = "";
                while (stack.Count > 0)
                {
                    reversed += stack.Pop();
                }

                return reversed;
            }


            static void CheckParanthesis()
            {
                /*
                 * Use this method to check if the paranthesis in a string is Correct or incorrect.
                 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
                 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
                 */

                Console.WriteLine("Enter a string to check for well-formed parentheses:");
                string input = Console.ReadLine();

                Stack<char> stack = new Stack<char>(); // Stack to hold opening parentheses
                bool isWellFormed = true; // Flag 

                foreach (char c in input)
                {
                    // Check for opening parentheses
                    if (c == '(' || c == '{' || c == '[')
                    {
                        stack.Push(c);
                    }
                    // Check for closing parentheses
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        // Check if stack is empty or the top of the stack does not match
                        if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), c))
                        {
                            isWellFormed = false;
                            break; // Exit loop if not well-formed
                        }
                    }
                }

                // If stack is not empty( it means there are unmatched opening parentheses)
                if (isWellFormed && stack.Count == 0)
                {
                    Console.WriteLine("The string is well-formed. \n");
                }
                else
                {
                    Console.WriteLine("The string is not well-formed. \n");
                }




            }
            // Helper method to check if the opening and closing parentheses match

            static bool IsMatchingPair(char opening, char closing)
            {
                return (opening == '(' && closing == ')') ||
                       (opening == '{' && closing == '}') ||
                       (opening == '[' && closing == ']');
            }

    }
    
    
}

