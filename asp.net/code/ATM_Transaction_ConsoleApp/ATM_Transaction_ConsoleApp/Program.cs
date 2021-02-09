using System;
using System.Collections;
using System.Collections.Generic;
abstract class AbstractAccount
{
    public abstract void accountForm();
    public abstract void storeData();
    public abstract int verifyUser(int pin);
    public abstract void checkBalance(int pin);
    public abstract void withDrawBalance(int pin);
    public abstract void depositeBalance(int pin);
}

class CreateAccount : AbstractAccount
{
    public Dictionary<int, ArrayList> account_data = new Dictionary<int, ArrayList>();
    private string name;
    private string mobile_no;
    private int pin;
    private double balance;
    private double withdrawl_amount;

    public override void accountForm()
    {
        try
        {
            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Mobile No: ");
            mobile_no = Console.ReadLine();
            Labelpin:
            Console.WriteLine("Enter Pin No: ");
            pin = Convert.ToInt32(Console.ReadLine());
            if (pin.ToString().Length != 4)
            {
                Console.WriteLine("Pin Length must be 4");
                goto Labelpin;
            }
            Console.WriteLine("Enter Balance Amount: ");
            balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Set withdrawl limit: ");
            withdrawl_amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public override void storeData()
    {
        try
        {
            ArrayList userData = new ArrayList();
            userData.Add(name);
            userData.Add(mobile_no);
            userData.Add(pin);
            userData.Add(balance);
            userData.Add(withdrawl_amount);

            account_data.Add(pin, userData);
            Console.WriteLine("Account Created Successfully!!");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }

    public override int verifyUser(int pin)
    {
        try
        {
            foreach (KeyValuePair<int, ArrayList> getData in account_data)
            {
                int getPin = Convert.ToInt32(getData.Value[2]);
                if (pin == getPin)
                {
                    Console.WriteLine("User Verified, Welcome to ATM!!!");
                    Console.WriteLine();
                    return 1;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        return 0;
    }
    
    public override void checkBalance(int pin)
    {
        int verify = verifyUser(pin);
        if (verify == 1)
        {
            try
            {
                foreach (KeyValuePair<int, ArrayList> getBalance in account_data)
                {
                    for (int i = 0; i < getBalance.Value.Count; i++)
                    {
                        int getPin = Convert.ToInt32(getBalance.Value[2]);
                        if (pin == getPin)
                        {
                            Console.WriteLine("Name: {0} \nAccount Balance: {1}", getBalance.Value[0], getBalance.Value[3]);
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

    }

    public override void withDrawBalance(int pin)
    {
        int verify = verifyUser(pin);
        if (verify == 1)
        {
            try
            {
                foreach (KeyValuePair<int, ArrayList> getBalance in account_data)
                {
                    for (int i = 0; i < getBalance.Value.Count; i++)
                    {
                        
                        int getPin = Convert.ToInt32(getBalance.Value[2]);
                        if (pin == getPin)
                        {
                            string name = Convert.ToString(getBalance.Value[0]);
                            string mobile = Convert.ToString(getBalance.Value[1]);
                            double balanceAmount = Convert.ToDouble(getBalance.Value[3]);
                            double limitAmount = Convert.ToDouble(getBalance.Value[4]);
                            Console.WriteLine("Enter Withdrawl Amount: ");
                            int withdrawAmount = Convert.ToInt32(Console.ReadLine()); 
                            if(withdrawAmount <= limitAmount)
                            {
                                balanceAmount = balanceAmount - withdrawAmount;
                                Console.WriteLine("SMS sent on no: {0} \nRemaining Amount: {1}", mobile, balanceAmount);
                                Console.WriteLine();

                                getBalance.Value[3] = balanceAmount;

                                break;
                                //System.Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("You can not withdraw more than your Limit!!!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

    }

    public override void depositeBalance(int pin)
    {
        int verify = verifyUser(pin);
        if (verify == 1)
        {
            try
            {
                foreach (KeyValuePair<int, ArrayList> getBalance in account_data)
                {
                    for (int i = 0; i < getBalance.Value.Count; i++)
                    {

                        int getPin = Convert.ToInt32(getBalance.Value[2]);
                        if (pin == getPin)
                        {
                            string name = Convert.ToString(getBalance.Value[0]);
                            string mobile = Convert.ToString(getBalance.Value[1]);
                            double balanceAmount = Convert.ToDouble(getBalance.Value[3]);
                            double limitAmount = Convert.ToDouble(getBalance.Value[4]);
                            Console.WriteLine("Enter Deposite Amount: ");
                            double depositeAmount = Convert.ToDouble(Console.ReadLine());
                            balanceAmount = balanceAmount + depositeAmount;
                            Console.WriteLine("SMS sent on no: {0} \nCurrent Balance: {1}", mobile, balanceAmount);
                            Console.WriteLine();

                            getBalance.Value[3] = balanceAmount;

                            break;
                            //System.Environment.Exit(0);
                        }
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
class Program
{
    static void Main(string[] args)
    {
        CreateAccount createAccount = new CreateAccount();

        while (true)
        {
            Console.WriteLine("101. Create Account ");
            Console.WriteLine("102. Transaction ");
            Console.WriteLine("103. Exit ");
            Console.WriteLine("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            bool innerQuit = true;
            switch (ch)
            {
                case 101:
                    createAccount.accountForm();
                    createAccount.storeData();
                    break;
                case 102:
                    Console.WriteLine("Please Enter your Pin: ");
                    int pin = Convert.ToInt32(Console.ReadLine());
                    int verify = createAccount.verifyUser(pin);
                    if (verify == 1)
                    {
                        while (innerQuit)
                        {
                            Console.WriteLine("1. Check Balance: ");
                            Console.WriteLine("2. Cash Withdrawl ");
                            Console.WriteLine("3. Cash Deposition ");
                            Console.WriteLine("4. Quit ");
                            Console.WriteLine("Enter Choice: ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    createAccount.checkBalance(pin);
                                    break;
                                case 2:
                                    createAccount.withDrawBalance(pin);
                                    break;
                                case 3:
                                    createAccount.depositeBalance(pin);
                                    break;
                                case 4:
                                    innerQuit = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter Valid Choice!!");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account is not created!!!");
                        break;
                    }
                    break;
                case 103:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter Valid Choice!!");
                    break;
            }
        }
    }
}

