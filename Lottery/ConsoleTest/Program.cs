using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program{
        private class A{
            private int a;
            private int b;
            private int c;
          

            public A(){}

            public A(int a, int b, int c){
                this.a = a;
                this.b = b;
                this.c = c;
               
            }

            public int A1{
                get { return a; }
                set { a = value; }
            }

            public int B{
                get { return b; }
                set { b = value; }
            }

            public int C{
                get { return c; }
                set { c = value; }
            }

            public override string ToString(){
                return a + " " + b + " " + c + " ";
            }
        }

        private static List<A> list = new List<A>(); 
        static  void Main(string[] args)
        {
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            List<int> b = new List<int>(3);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            combine(a,a.Count,b,3,3);
            foreach (var a1 in list){
                Console.WriteLine(a1);
            }
            Console.ReadLine();
        }

        private static void combine(List<int> a, int n, List<int> b, int m , int M){
            for (int i = n; i >= m; i--){
                b[m - 1] = i - 1;
                if (m > 1)
                    combine(a, i - 1, b, m - 1, M);
                else{
                    A tmp = new A(a[b[M -1 ]],a[b[M - 2]], a[b[M - 3]]);
                    list.Add(tmp);    
                }
            }
        }
    }
}
