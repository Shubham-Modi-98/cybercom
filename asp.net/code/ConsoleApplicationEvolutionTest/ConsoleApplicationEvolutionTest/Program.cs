using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplicationEvolutionTest
{
    //Program No.1 Palindrome Class
    public class Palindrome
    {
        public static bool IsPalindrome(string word)
        {
            try
            {
                word = word.ToLower();
                string checkWord = string.Empty;
                
                //Implement without function
                for (int i = (word.Length-1); i >= 0; i--)
                {
                    checkWord += word[i];
                }
                if(word == checkWord)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }
            return false;
        }
    }

    //Program no. 2 Class TextInput to NumericInput
    public class TextInput
    {
        string charArray = string.Empty;
        public virtual void Add(char c)
        {
            try
            {
                charArray += c;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public virtual string GetValue()
        {
            try
            {
                return charArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
    }
    
    //Inherite TextInput Method
    public class NumericInput : TextInput
    {
        string numericStringValue = string.Empty;
        string stringInput;
        public override void Add(char charValues)
        {
            try
            {
                stringInput += charValues;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override string GetValue()
        {
            try
            {
                for (int i = 0; i < stringInput.Length; i++)
                {
                    if (stringInput[i] >= '0' && stringInput[i] <= '9')
                    {
                        numericStringValue += stringInput[i];
                    }
                }
                //Console.WriteLine(numericStringValue);
                return numericStringValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
    }

    //Program No.3 Class Count 1's in entered Digit
    public class CountNumber1
    {
        public static int countDigit(int number)
        {
            try
            {
                string checkDigit = Convert.ToString(number);
                int count = 0;
                for (int i = 0; i < checkDigit.Count(); i++)
                {
                    if (checkDigit[i] == '1')
                    {
                        count++;
                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }

    //Program No.5 Class Print Binary Triangle
    public class Triangle
    {
        public static void binaryTriangle(int number)
        {
            int lastValue = 0;
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if(lastValue == 0)
                    {
                        Console.Write("0");
                        lastValue = 1;
                    }
                    else if(lastValue == 1)
                    {
                        Console.Write("1");
                        lastValue = 0;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    //Program No.6 Class Find Smallest Number from Matrix
    public class SmallFromMatrix
    {
        public static void findSmallCreateMatrix(int row, int col)
        {
            try
            {
                int[,] matrixArray = new int[row, col];
                int smallValue = int.MaxValue;
                Console.WriteLine("Create Matrix");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.WriteLine("Enter Matrix Element[{0},{1}]", i, j);
                        matrixArray[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrixArray[i, j] + " ");
                        if (smallValue > matrixArray[i, j])
                        {
                            smallValue = matrixArray[i, j];
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Small Element : {0}", smallValue);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Program No.7 Class Celcius to Farhenheit Conversion
    public class CtoFConversion
    {
        public static float CelsiusToFahrenheit()
        {
            try
            {
                float celcius;
                Console.WriteLine("Enter the Temperature in Celcius (^C) : ");
                celcius = float.Parse(Console.ReadLine());
                float fah = (float)(celcius * 1.8) + 32;
                //double f = (double)Math.Ceiling(fah);
                return fah;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return float.NaN;
        }
    }

    //Program No.8 Class Reverse Array Data
    public class ReverseData
    {
        public static void reverseArray()
        {
            try
            {
                Console.WriteLine("Enter Number of Element you want to Hold in the Array: ");
                int number = Convert.ToInt32(Console.ReadLine());
                int[] numArray = new int[number];
                Console.WriteLine("Enter Array Elements:");
                for (int i = 0; i < numArray.Count(); i++)
                {
                    numArray[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Reversed Array:");
                for (int i = (numArray.Count() - 1); i >= 0; i--)
                {
                    Console.WriteLine("Element is : {0}", numArray[i]);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Program No.12 Class Convert 2-D Array(matrix) into 1-D Array
    public class ConvertMatrixtoArray
    {
        public static void matrix2Dto1D(int col)
        {
            try
            {
                int[,] matrix = new int[2, col];
                int[] convertArray = new int[(2 * col)];
                int count = 0;
                Console.WriteLine("Enter the Elements:");
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.WriteLine("A[{0},{1}] = ", i, j);
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.WriteLine("Given 2-D Array(Matrix) is:");
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                        //convertArray[(i * j)] = matrix[i, j];
                    }
                    Console.WriteLine();
                }
                //convertArray.CopyTo(matrix, 0);
                foreach (int array in matrix)
                {
                    convertArray[count] = array;

                    //Or else you can print here also like
                    //Console.WriteLine(convertArray[count]);

                    //Or you can print
                    //Console.WriteLine(array);

                    count++;
                }
                Console.WriteLine("Converted 1-D Array is :");
                for (int k = 0; k < convertArray.Length; k++)
                {
                    Console.WriteLine(convertArray[k]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Program No.13  Class Get Lower Bound and Upper Bound of Array
    public class ArrayBound
    {
        public static void getBounds()
        {
            try
            {
                Array boundArray = Array.CreateInstance(typeof(int), 6);
                boundArray.SetValue(20, 0);
                boundArray.SetValue(98, 1);
                boundArray.SetValue(47, 2);
                boundArray.SetValue(26, 3);
                boundArray.SetValue(6, 4);
                boundArray.SetValue(1999, 5);
                Console.WriteLine("The Lower Bound of the Array : {0}", boundArray.GetLowerBound(0).ToString());
                Console.WriteLine("The Upper Bound of the Array : {0}", boundArray.GetUpperBound(0).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Program No.14 Class Divide By Zero Exception
    class DivideException
    {
        public static void divideError()
        {
            try
            {
                Console.WriteLine("Enter No. 1:");
                int no1 = Convert.ToInt32(Console.ReadLine());
                labelZero:
                Console.WriteLine("Enter No. 1:");
                int no2 = Convert.ToInt32(Console.ReadLine());
                if(no2 != 0)
                {
                    Console.WriteLine("No 2 must be zero to check exception");
                    goto labelZero;
                }
                int answer = no1/no2;
                Console.WriteLine("Answer : {0}", answer);
            }
            catch (DivideByZeroException divideEx)
            {
                Console.WriteLine("You try to Divide number one with zero");
                Console.WriteLine(divideEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

    //Program No.15 Class Bubble Sort Program
    public class Sort
    {
        public static void buubleSort()
        {
            Console.WriteLine("Enter Number to create Array");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] arraySort = new int[number];
            int temp;
            Console.WriteLine("Enter Array Element:");
            for (int i = 0; i < number; i++)
            {
                arraySort[i] = Convert.ToInt32(Console.ReadLine());
            }
            //int[] arraySort = { 78, 55, 45, 98, 13 };
            Console.WriteLine("Before Sort Array");
            foreach (int element in arraySort)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            for (int j = 0; j <= arraySort.Length - 2; j++)
            {
                for (int i = 0; i <= arraySort.Length - 2; i++)
                {
                    if (arraySort[i] > arraySort[i + 1])
                    {
                        temp = arraySort[i + 1];
                        arraySort[i + 1] = arraySort[i];
                        arraySort[i] = temp;
                    }
                }
            }
            Console.WriteLine("After Perform Bubble Sort:");
            foreach (int element in arraySort)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }

    //Program No.17 Class Calculate Percentage
    public class Calculate
    {
        public static void calcPercentage()
        {
            try
            {
                labelPerformAgain:
                Console.WriteLine("Enter Value/Amount : ");
                double amount = Convert.ToDouble(Console.ReadLine());
                labelCheckPerc:
                Console.WriteLine("Enter Percentage (%) : ");
                float perc = float.Parse(Console.ReadLine());
                if (perc > 100)
                {
                    Console.WriteLine("Percentage value must be less than 100");
                    goto labelCheckPerc;
                }
                float calculate = (float)(amount * perc / 100);
                Console.WriteLine("Percentage : {0}/{1} = {2}", amount, perc, calculate);
                labelInput:
                Console.WriteLine("Do you want to Calculate Again? y/n");
                char check = Convert.ToChar(Console.ReadLine());
                if (check == 'y' || check == 'Y')
                    goto labelPerformAgain;
                else if (check == 'n' || check == 'N')
                    Console.WriteLine("Thank you!");
                else
                {
                    Console.WriteLine("Please enter valid input");
                    goto labelInput;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Program No.18 Class Reading and Writing Files
    public class FileOperations
    {
        public static void writeFile()
        {
            try
            {
                string fileName = @"F:\Cybercom Asp Git\asp.net\code\example.txt";
                StringBuilder content = new StringBuilder();
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    while (streamReader.ReadLine() != null)
                    {
                        content.Append(streamReader.ReadLine());
                    }
                }
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    string dateTime = DateTime.Now.ToString();
                    streamWriter.WriteLine(content);
                    streamWriter.WriteLine(dateTime);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void readFile()
        {
            try
            {
                string fileName = @"F:\Cybercom Asp Git\asp.net\code\example.txt";
                using(StreamReader streamReader = new StreamReader(fileName))
                {
                    string content = string.Empty;
                    while ((content = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Program No.20 Class Fibonacci Series using Recursion
    public class FibonacciSeries
    {
        public static int fibonacci(int number)
        {
            if (number == 0)
            {
                //Console.Write(number + " ");
                return 0;
            }
            if (number == 1)
            {
                //Console.Write(number + " ");
                return 1;
            }
            else
            {
                //Console.Write(number + " ");
                return fibonacci(number - 1) + fibonacci(number - 2);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int choice;
                while(true)
                {
                    Console.WriteLine("1. Check String is Palindrome or Not");
                    Console.WriteLine("2. TextInput to NumericInput");
                    Console.WriteLine("3. Count the number of 1's");
                    Console.WriteLine("5. Binary Triangle");
                    Console.WriteLine("6. Find Smallest element from Matrix");
                    Console.WriteLine("7. Convert Celsius to Fahrenheit");
                    Console.WriteLine("8. User Input Reverse Array");
                    Console.WriteLine("12. Convert 2-D Array into 1-D Array");
                    Console.WriteLine("13. Fetch Array's Lower Bound and Upper Bound");
                    Console.WriteLine("14. Check Divide by Zero Exception");
                    Console.WriteLine("15. Bubble Sort");
                    Console.WriteLine("17. Calculating Percentage(%)");
                    Console.WriteLine("18. Reading data from file and Writting Data in File");
                    Console.WriteLine("20. Exit");
                    Console.WriteLine();
                    Console.WriteLine("Enter Choice:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            string word;
                            Console.WriteLine("Enter String");
                            word = Console.ReadLine();
                            Console.WriteLine(Palindrome.IsPalindrome(word));
                            Console.WriteLine();
                            break;
                        case 2:
                            TextInput textInput = new NumericInput();
                            textInput.Add('1');
                            textInput.Add('a');
                            textInput.Add('0');
                            Console.WriteLine(textInput.GetValue());
                            NumericInput numInput = new NumericInput();
                            numInput.Add('S');
                            numInput.Add('9');
                            numInput.Add('R');
                            numInput.Add('8');
                            Console.WriteLine(numInput.GetValue());
                            Console.WriteLine();
                            break;
                        case 3:
                            int number;
                            Console.WriteLine("Enter Number");
                            number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Total number contains 1's = {0}", CountNumber1.countDigit(number));
                            Console.WriteLine();
                            break;
                        case 5:
                            int row;
                            Console.WriteLine("Enter the Number of Row : ");
                            row = Convert.ToInt32(Console.ReadLine());
                            Triangle.binaryTriangle(row);
                            break;
                        case 6:
                            SmallFromMatrix.findSmallCreateMatrix(2, 3);
                            break;
                        case 7:
                            Console.WriteLine("Tempreture in Fahrenheit (^F) : {0}",CtoFConversion.CelsiusToFahrenheit());
                            Console.WriteLine();
                            break;
                        case 8:
                            ReverseData.reverseArray();
                            Console.WriteLine();
                            break;
                        case 12:
                            ConvertMatrixtoArray.matrix2Dto1D(3);
                            Console.WriteLine();
                            break;
                        case 13:
                            ArrayBound.getBounds();
                            Console.WriteLine();
                            break;
                        case 14:
                            DivideException.divideError();
                            Console.WriteLine();
                            break;
                        case 15:
                            Sort.buubleSort();
                            Console.WriteLine();
                            break;
                        case 17:
                            Calculate.calcPercentage();
                            Console.WriteLine();
                            break;
                        case 18:
                            FileOperations.writeFile();
                            FileOperations.readFile();
                            Console.WriteLine();
                            break;
                        case 20:
                            int n;
                            Console.WriteLine("Enter Number");
                            n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("The Fibonacci series of {0} is : {1}", n, FibonacciSeries.fibonacci(n));
                            Console.WriteLine();
                            break;
                        case 21:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input, Please enter valid Input");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
