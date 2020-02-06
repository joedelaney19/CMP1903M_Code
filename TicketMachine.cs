using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M
{
    //class TicketMachine models a simple ticket machine
    //It prints a ticket of a single price if there is enough money
    class TicketMachine
    {
        //fields and properties
        private string _promo = "SoCS2020";

        private int _prevDeposit;
        public int prevDeposit
        {
            get { return _prevDeposit; }
        }
        public string promo
        {
            get { return _promo; }
        }

        private float _ticketPrice;
        public float ticketPrice
        {
            get { return _ticketPrice; }
            set
            {
                if (value >= 0)
                {
                    _ticketPrice = value;
                }
                else
                {
                    Console.WriteLine("Ticket price cannot be less than 0");
                }
            }
        }
        private float _balance;
        public float balance
        {
            get { return _balance; }
        }
        private float _total;
        public float total
        {
            get { return _total; }
        }

        //methods
        //insertMoney - receive an amount of money from the customer
        //parameter: int
        //return: void
        public void insertMoney(int amount)
        {
            if(amount > 0)
            {
                _prevDeposit = amount;
                _balance = _balance + amount;
            }
            else
            {
                Console.WriteLine("Amount must be more than 0");
            }

        }

        //refundMoney - refunds the amount of the previous deposit without printing ticket
        //parameter: none
        //return: void
        public void refundMoney()
        {
            _balance = _balance - _prevDeposit;
            Console.WriteLine($"Previous deposit ({_prevDeposit}) has been refunded");
        }

        //printTicket - simulate the output of a ticket
        //parameter: none
        //return: void
        public void printTicket(bool discount)
        {
            float ticketPrice_loc = _ticketPrice;
            if(discount)
            {
                ticketPrice_loc = (float)(_ticketPrice * 0.8);
            }
            if (balance >= ticketPrice_loc)
            {
                _balance = _balance - ticketPrice_loc;
                _total = _total + ticketPrice_loc;
                Console.WriteLine("*****************");
                Console.WriteLine("SoCS Line Ticket");
                Console.WriteLine($"Price = £{ticketPrice_loc}");
                Console.WriteLine("*****************");
            }
            else
            {
                Console.WriteLine("Insufficient funds to print ticket");
            }
        }

        //status - returns the current total of money in this machine
        //parameter: none
        //return: void
        public void status()
        {
            Console.WriteLine($"Balance: {_balance}");
            Console.WriteLine($"Total money in machine: {_total}");
            Console.WriteLine($"Current ticket price: {_ticketPrice}");
        }

        //empty - empties the contents of the ticket machine
        //parameter: none
        //return: void
        public void empty()
        {
            Console.WriteLine($"Emptying machine - total emptied: {_total}");
            _total = 0;
        }
    }
}
