using System;
using System.Collections.Generic;
using System.Runtime;

namespace ATMPracticeConsole
{

    class Customer
    {
        public string name { get; set; }
        public string mobile { get; set; }
        public int pin { get; set; }
        public double balance { get; set; }
        public double limitAmount { get; set; }
    }

    abstract class ATM
    {
        public abstract void createAccount();
        public abstract bool verifyUser(int pin);
        public abstract void checkBalance(int pin);
        public abstract void withDrawBalance(int pin);
        public abstract void despositeBalance(int pin);

    }
    class Program : ATM
    {
        Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();
        public override void createAccount()
        {
            try
            {
                Customer customer = new Customer();
                Console.WriteLine("Enter Customer Name:");
                customer.name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter Customer Mobile no:");
                customer.mobile = Convert.ToString(Console.ReadLine());
                pinValidate:
                Console.WriteLine("Enter Pin Number:");
                customer.pin = Convert.ToInt32(Console.ReadLine());
                if (customer.pin.ToString().Length != 4)
                {
                    goto pinValidate;
                }
                Console.WriteLine("Enter Balance:");
                customer.balance = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter amount to set withdraw Limit:");
                customer.limitAmount = Convert.ToDouble(Console.ReadLine());

                customerDictionary.Add(customer.pin, customer);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override bool verifyUser(int pin)
        {
            try
            {
                //Console.WriteLine(customerDictionary.Count);
                foreach (KeyValuePair<int, Customer> dictData in customerDictionary)
                {
                    if (pin == dictData.Value.pin)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        
        public override void checkBalance(int pin)
        {
            try
            {
                foreach (KeyValuePair<int, Customer> dictData in customerDictionary)
                {
                    if (pin == dictData.Value.pin)
                    {
                        Console.WriteLine("Account Holder Name:{0}\nYour Account balance is: {1}", dictData.Value.name, dictData.Value.balance);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void withDrawBalance(int pin)
        {
            try
            {
                double withDraw;
                foreach (KeyValuePair<int, Customer> dictData in customerDictionary)
                {
                    if (pin == dictData.Value.pin)
                    {
                        Console.WriteLine("Enter Amount to Withdraw");
                        withDraw = Convert.ToDouble(Console.ReadLine());
                        if (withDraw > dictData.Value.limitAmount)
                        {
                            Console.WriteLine("You cannot withdraw more than limit amount");
                        }
                        else
                        {
                            dictData.Value.balance -= withDraw;
                            Console.WriteLine("Debit amount message sent to {0}", dictData.Value.mobile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void despositeBalance(int pin)
        {
            try
            {
                double deposite;
                foreach (KeyValuePair<int, Customer> dictData in customerDictionary)
                {
                    if (pin == dictData.Value.pin)
                    {
                        Console.WriteLine("Enter Deposite Amount");
                        deposite = Convert.ToDouble(Console.ReadLine());
                        dictData.Value.balance += deposite;
                        Console.WriteLine("Debit amount message sent to {0}", dictData.Value.mobile);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        static void Main(string[] args)
        {
            try
            {
                int choice;
                int pin;
                Program prog = new Program();
                while (true)
                {
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Transaction");
                    Console.WriteLine("3. Quit");
                    Console.WriteLine("Enter Choice:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            prog.createAccount();
                            break;
                        case 2:
                            bool flag = true;
                            pinVerify:
                            Console.WriteLine("Enter Pin:");
                            pin = Convert.ToInt32(Console.ReadLine());
                            if (prog.verifyUser(pin))
                            {
                                while (flag)
                                {
                                    Console.WriteLine("101. Check Balance");
                                    Console.WriteLine("102. Deposite Amount");
                                    Console.WriteLine("103. Withdraw Amount");
                                    Console.WriteLine("104. Exit");
                                    Console.WriteLine("Enter Choice:");
                                    choice = Convert.ToInt32(Console.ReadLine());
                                    switch (choice)
                                    {
                                        case 101:
                                            prog.checkBalance(pin);
                                            break;
                                        case 102:
                                            prog.despositeBalance(pin);
                                            break;
                                        case 103:
                                            prog.withDrawBalance(pin);
                                            break;
                                        case 104:
                                            flag = false;
                                            break;
                                        default:
                                            Console.WriteLine("Please enter Valid Choice!!!");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                tryAgain:
                                Console.WriteLine("Do you want a try again Y/N");
                                char t = Convert.ToChar(Console.ReadLine());
                                if (t == 'Y' || t == 'y')
                                {
                                    goto pinVerify;
                                }
                                else if (t == 'N' || t == 'n')
                                {
                                    break;
                                }
                                else
                                {
                                    goto tryAgain;
                                }
                            }
                            break;
                        case 3:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please enter Valid Choice!!!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
