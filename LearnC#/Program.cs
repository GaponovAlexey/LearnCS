using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace LearnC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub cClub = new ComputerClub(8);
            cClub.Work();


            // Console.ReadLine();

        }
    }
    class ComputerClub
    {
        private int _money;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();

        public ComputerClub(int computersCount)
        {
            Random random = new Random();

            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(random.Next(5, 15)));
            }

            CreateNewClients(25, random);

        }
        public void CreateNewClients(int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                _clients.Enqueue(new Client(random.Next(100, 251), random));
            }
        }
        public void Work()
        {
            while (_clients.Count > 0)
            {
                Client client = _clients.Dequeue();
                Console.WriteLine($"balance Computer Clube: {_money}$ ");
                Console.WriteLine($"you have a new Client who wants to buy {client.DesiredMinutes} minutes");
                ShowAllComputerState();

                Console.Write("\n You offer him computer on numbers");
                string UserInput = Console.ReadLine();
                if (int.TryParse(UserInput, out int computerNumber))
                {
                    computerNumber -= 1;
                    if (computerNumber >= 0 && computerNumber < _computers.Count)
                    {
                        if (_computers[computerNumber].IsTaken)
                            Console.WriteLine("you tray sit client on busy computer,  He leaves");
                        else
                        {
                            if (client.ChackSolvency(_computers[computerNumber]))
                            {
                                Console.WriteLine("client pay and sit " + computerNumber + 1);
                                _money += client.Pay();
                                _computers[computerNumber].BecomeTaken(client);
                            }
                            else
                            {
                                Console.WriteLine("can't have money");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("you don't know what computer you need. He leaves");
                    }
                }
                else
                {
                    CreateNewClients(1, new Random());
                    Console.WriteLine("Not Correct Number !");
                }



                Console.WriteLine("next client ");
                Console.ReadKey();
                Console.Clear();
                SpendMinutes();
            }
        }
        private void ShowAllComputerState()
        {
            Console.WriteLine("\nList All computer");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                _computers[i].ShowState();
            }
        }
        private void SpendMinutes()
        {
            foreach (var computer in _computers)
            {
                computer.SpendOneMinutes();
            }
        }
    }
    class Computer
    {
        private Client _client;
        private int _minuteRemaining;
        public bool IsTaken
        {
            get
            {
                return _minuteRemaining > 0;
            }
        }
        public int PricePerMinutes { get; private set; }
        public Computer(int pricePerMinute)
        {
            PricePerMinutes = pricePerMinute;

        }
        public void BecomeTaken(Client client)
        {
            _client = client;
            _minuteRemaining = _client.DesiredMinutes;
        }
        public void BecomeEmpty()
        {
            _client = null;
        }
        public void SpendOneMinutes()
        {
            _minuteRemaining--;
        }
        public void ShowState()
        {
            if (IsTaken)
                Console.WriteLine($"Computer is busy, 10 minutes left: {_minuteRemaining}");
            else
                Console.WriteLine($"Computer is free, pay for minute : {PricePerMinutes}");
        }

    }
    class Client
    {
        private int _money;
        private int _moneyToPay;

        public int DesiredMinutes { get; private set; }
        public Client(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(0, 100);
        }
        public bool ChackSolvency(Computer computer)
        {
            _moneyToPay = DesiredMinutes * computer.PricePerMinutes;
            if (_money >= _moneyToPay)
                return true;
            else

                _moneyToPay = 0;
            return false;

        }
        public int Pay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }

    }
}




