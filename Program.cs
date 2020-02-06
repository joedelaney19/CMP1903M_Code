using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketMachine t = new TicketMachine();
            t.ticketPrice = 10;
            string choice = "y";
            while(choice == "y")
            {
                Console.WriteLine("Insert money: ");
                string money_input = Console.ReadLine();
                int money_input_int = int.Parse(money_input);
                t.insertMoney(money_input_int);

                Console.WriteLine("Enter staff promo code: ");
                string promo = Console.ReadLine();
                bool promo_valid = false;
                if(promo == t.promo)
                {
                    promo_valid = true;
                }

                Console.WriteLine("Enter 'print' to print ticket or 'refund' to refund deposit: ");
                string print_input = Console.ReadLine().ToLower();
                if(print_input == "print")
                {
                    t.printTicket(promo_valid);
                }
                if(print_input == "refund")
                {
                    t.refundMoney();
                }

                choice = "";
                while (!(choice == "y" || choice == "n"))
                {
                    Console.WriteLine("Would you like to print another ticket? (Y/N): ");
                    choice = Console.ReadLine().ToLower();
                    if(!(choice == "y" || choice == "n"))
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
            }
        }
    }
}
