using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace TestingForProjects
{
    class Program //Abstract CALCmath
    {
        public  ArrayList values = new ArrayList();
        public ArrayList a = new ArrayList();
        public ArrayList b = new ArrayList();
        public ArrayList o = new ArrayList();
        public ArrayList<char> FinalF = new ArrayList<char>();
        public int Nth;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.summarizeForm("-2(234x)(2)");
           // p.reMakeForm();

            for (int i =0;i< p.FinalF.Count;i++)
            {
                Console.WriteLine("out: "+ p.FinalF[i]);
            }
            
        }

        
       
        public void summarizeForm(string formula)
        {
      
            for (int i = 0; i < formula.Length; i++)
            {
                char[] check = formula.ToCharArray();
                string placeHolder;

                if (char.IsNumber(check[i]))
                {
                    placeHolder = "" + check[i];
                    for (int j = 1; j < formula.Length; j++)
                    {
                        if (char.IsNumber(check[i + j]))
                        {
                            placeHolder = "" + placeHolder + check[i + j];
                        }
                        else
                        {
                            i = j+i-1;
                            break;
                        }
                    }
                    values.Add('a');
                    a.Add(placeHolder);
                }
                else if (char.IsLetter(check[i]))
                {
                    values.Add('b');
                    b.Add(check[i]);
                }
                else
                {
                    if ((i > 0) && (check[i-1] == ')' || char.IsLetter(check[i - 1]) || char.IsNumber(check[i - 1])) && check[i] == '(')
                    {
                        values.Add('o');
                        o.Add('*');
                    }
                        values.Add('o');
                        o.Add(check[i]);
                }
            }
            foreach (var aa in a)
            {
                Console.WriteLine(aa);
            }
            foreach (var aa in b)
            {
                Console.WriteLine(aa);
            }
            foreach (var aa in o)
            {
                Console.WriteLine(aa);
            }
            foreach (var aa in values)
            {
                Console.Write(aa);
            }
        }
        public void reMakeForm()
        {
            int aa = 0;
            int bb = 0;
            int oo = 0;
            for (int i = 0; i < values.Count; i++)
            {

                if ((values[i].Equals('a')) || (values[i].Equals('b')))
                {
                    FinalF.Add('(');
                    while (i<values.Count-1&&!(values[i].Equals('o')))
                    {
                        if (values[i].Equals('a'))
                        {
                            FinalF.Add(a[aa]);
                            aa++;
                        }
                        else if (values[i].Equals('b'))
                        {
                            FinalF.Add(b[bb]);
                            bb++;
                        }
                        if (!(values[i + 1].Equals('o'))) FinalF.Add('*');
                        i++;
                    }
                    if (values[i].Equals('a')) FinalF.Add(a[aa]);
                    else if (values[i].Equals('b')) FinalF.Add(b[bb]);
                   
                    FinalF.Add(')');
                    // loop too long or creates infinite loop -1
                }
                else if (values[i].Equals('o'))
                {
                    FinalF.Add(o[oo]);
                    oo++;
                    if (o[oo - 1].Equals(')')&& o[oo].Equals('('))
                    {
                        FinalF.Add('*');
                        FinalF.Add(o[oo]);
                    }
                }
            }
        }
        public ArrayList getFormula()
        {
            return FinalF;
        }

        public class ArrayList<T> : ArrayList
        {
        }
    }
    class RRAM : equation
    {

    }
    class LRAM : equation
    {

    }
    class MRAM : equation
    {

    }
    abstract class equation
    {
        protected int Nth;
        protected string Formula;

        public virtual void getArea()
        {

        }
        public void setNthVar(int Nth)
        {
            this.Nth = Nth;
        }
        public void getIntegral()
        {

        }
    }

}
