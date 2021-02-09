using System;

namespace ConstructorOverloadWithCustomException
{
    class Program
    {
        //Program No.19 Consstructor Overloading
        public class Arithmatic
        {
            public Arithmatic(int a, int b)
            {
                Console.WriteLine("Addtion is : {0}",(a + b));
            }
            public Arithmatic(int a, int b, int c)
            {
                Console.WriteLine("Addtion is : {0}", (a + b + c));
            }
            public Arithmatic(string a, string b)
            {
                Console.WriteLine("String Addtion is : {0}", (a + b ));
            }
            public Arithmatic(int a, string b)
            {
                Console.WriteLine("Int-String Addtion is : {0}", (a + b));
            }

        }

        //Program No.16 User Define Exception

        public class Age
        {
            public void validAgeforVoting(int age)
            {
                try
                {
                    if (age >= 18 && age <= 150)
                    {
                        Console.WriteLine("Age is Valid");
                    }
                    else if(age <=0 && age > 18)
                    {
                        throw new UserDefineException("Age is not Valid, User age is under 18");
                    }
                    else
                    {
                        throw new UserDefineException();
                    }
                }
                catch (UserDefineException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
        public class UserDefineException : Exception
        {
            public UserDefineException() : base()
            {
                Console.WriteLine("Invalid Input, Enter valid Input");
            }
            public UserDefineException(string message) : base(message)
            {
            }
        }

        static void Main(string[] args)
        {
            Arithmatic arithmatic = new Arithmatic(25, 20);
            Arithmatic arithmatic3 = new Arithmatic(6, 99, 98);
            Arithmatic stringArithmatic = new Arithmatic(26," Shubham");
            Arithmatic stringConcat = new Arithmatic("Shubham"," Modi");
            Age age = new Age();
            Console.WriteLine("Enter user Age:");
            int a = Convert.ToInt32(Console.ReadLine());
            //age.validAgeforVoting(20);
            //age.validAgeforVoting(15);
            //age.validAgeforVoting(28);
            age.validAgeforVoting(a);

        }
    }
}
