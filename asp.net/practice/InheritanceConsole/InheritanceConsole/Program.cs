using System;
using System.Runtime.InteropServices;
using InheritanceConsole;

public class Parent
{
    public string fname;
    public string lname;
    public string course;
    public void study()
    {
        Console.WriteLine("Name:{0} {1} and Study {2} from CMPICA, CHARUSAT University", fname, lname, course);
    }
}

public class Child : Parent
{
    public void printName()
    {
        Console.WriteLine("Name: {0} {1}", fname, lname);
    }
}

public class A
{
    public string fn = "Shubh";
    public string ln = "Modi";
    public void display()
    {
        Console.WriteLine("Parent A {0} {1}", fn, ln);
    }
}
public class B : A
{
    public new void display()
    {
        Console.WriteLine("Child B {0} {1}", fn, ln);
    }
    public void disp()
    {
        Console.WriteLine("Child B Class Disp Method");
    }
}

public class C
{
    public string fn = "Shubh";
    public string ln = "Modi";
    public virtual void display()
    {
        Console.WriteLine("Parent C {0} {1}", fn, ln);
    }
}
public class D : C
{
    public override void display()
    {
        Console.WriteLine("Child D {0} {1}", fn, ln);
    }
    public void disp()
    {
        Console.WriteLine("Child Class Disp Method in D");
    }
}

class Refer
{
    public void refA(ref int a)
    {
        a = 20;
        Console.WriteLine("Method value A {0}", a);
    }
    public void statB(int b)
    {
        b = 10;
        Console.WriteLine("Method value B {0}",b);
    }
}

class Program
{
    public void Add(int a, int b)
    {
        Console.WriteLine("Sum = {0}", a+b);
    }
    public int Add(int a)
    {
        //Console.WriteLine("Sum = {0}", a+b);
        return a * a;
    }
    
    public void ParamLength(params int[] a)
    {
        Console.WriteLine("Length is {0} ",a.Length);
    } 
    public void optParam([Optional] int a)
    {
        Console.WriteLine("Value is {0} ",a);
    }

    static void Main(string[] args)
    {
        Refer r = new Refer();
        int ref_a = 200;
        int stat_b = 100;
        Console.WriteLine("Before value A {0}",ref_a);
        Console.WriteLine("Before value B {0}",stat_b);
        r.refA(ref ref_a);
        r.statB(stat_b);
        Console.WriteLine("After value A {0}", ref_a);
        Console.WriteLine("After value B {0}", stat_b);
        
        Console.WriteLine();

        Program prog = new Program();
        prog.Add(10, 20);
        Console.WriteLine(prog.Add(5));
        prog.ParamLength();
        prog.ParamLength(10,30,40);
        prog.optParam();
        prog.optParam(10);

        Console.WriteLine();

        Child p = new Child();
        p.fname = "Bholu";
        p.lname = "Modi";
        p.course = "MCA";
        p.printName();
        p.study();

        Parent pr = new Parent();
        pr.fname = "Shubham";
        pr.lname = "Modi";
        pr.course = "MCA";
        pr.study();

        Console.WriteLine("Hello World!\n");

        B b = new B();
        b.fn = "BFN";
        b.ln = "LFN";
        b.display();
        b.disp();

        Console.WriteLine();


        A b1 = new B();
        b1.fn = "AFN";
        b1.ln = "ALN";
        b1.display();

        Console.WriteLine();


        A a = new A();
        a.display();

        Console.WriteLine();

        D d = new D();
        //d.fn = "DFN";
        //d.ln = "DLN";
        d.display();

        Console.WriteLine();

        C c = new C();
        //c.fn = "CFN";
        //c.ln = "CLN";
        c.display();

        Console.WriteLine();

        C c1 = new D();
        //c1.fn = "C1FN";
        //c1.ln = "C1LN";
        c1.display();

        Methodsover.main(10, 20);
        Methodsover.main();
        
    }
}