/********************************************************
* Jason Thatcher                                        *
* Main - program.cs                                     *
*                                                       *
* verifies UnorderedLinkedList                          *
*                                                       *
* February 2018                                         *
*********************************************************/

using System;
using System.Collections.Generic;
using UnorderedLinkedListNamespace;

namespace GenericLinkedList
{
    class Program
    {
        enum VerifyType {String, Int, Double};

        static void Main(string[] args)
        {
            //First console screen.
            Console.WriteLine("This program tests UnorderedLinkedList Methods: \n");
            Console.WriteLine("\t+ insert()");
            Console.WriteLine("\t+ remove()");
            Console.WriteLine("\t+ removeAll()");
            Console.WriteLine("\t+ Max()");
            Console.WriteLine("\t+ Min()");
            Console.WriteLine("\t+ Sort()");

            Console.Write("\n\nPress <ENTER> to Continue");
            Console.ReadKey();

            //Run through verification of LinkedList methods.
            Console.Clear();
            Console.WriteLine("Verify UnorderedLinkedList - Strings");
            Console.WriteLine();
            Verify(VerifyType.String);  //Writes string report

            Console.Clear();
            Console.WriteLine("Verify UnorderedLinkedList - int");
            Console.WriteLine();
            Verify(VerifyType.Int);  //writes int report

            Console.Clear();
            Console.WriteLine("Verify UnorderedLinkedList - double");
            Console.WriteLine();
            Verify(VerifyType.Double); //writes double report
            
        }

        //array of strings to be inserted into list
        public static string[] TestStrings()
        {
            string[] result = { "ZZ", "GA", "AA", "ZA", "YB", "GA", "XE", "ZA", "IO", "IOD", "GA", "ZA", "IOB" };
            return result;
        }

        //array of int to be inserted into list
        public static int[] TestInts()
        {
            int[] result = { 6, 4, 12, 3, 4, 9, 22, 3, 4, 2, 1 };
            return result;
        }

        //array of doubles to be inserted into list
        public static double[] TestDoubles()
        {
            double[] result = { 1.22, 12.2, 5.99, 1.21, 0.33, 12.2, 122.00, 12.2, 5.99 };
            return result;
        }

        //simple switch on enum to direct reporting.
        private static void Verify(VerifyType t)
        {
            switch (t)
            {
                case VerifyType.String:
                    UnorderedLinkedList<string> listString = new UnorderedLinkedList<string>();
                    foreach (string z in TestStrings())
                       {
                           string y = z;
                           listString.insert(ref y);
                       }

                    PrintStringTest(listString);
                    
                     break;

                case VerifyType.Int:
                    UnorderedLinkedList<int> listInt = new UnorderedLinkedList<int>();
                    foreach (int z in TestInts()) //Load list with int
                        {
                            int y = z;
                            listInt.insert(ref y);
                        }

                    PrintIntTest(listInt);
                    break;

                case VerifyType.Double:
                    UnorderedLinkedList<double> listDouble = new UnorderedLinkedList<double>();
                    foreach (double z in TestDoubles())
                        {
                            double y = z;
                            listDouble.insert(ref y);
                        }
                    PrintDoubleTest(listDouble);
                    break;

                default:
                    break;
            }

            Console.Write("\n\nPress <ENTER> to Continue");
            Console.ReadKey();
        }

        //prints double test
        private static void PrintDoubleTest(UnorderedLinkedList<double> listDouble)
        {
            string listType = "double";

            Console.Write("Intial List of {0}: ", listType);
            listDouble.print();

            double s = 5.99d;
            Console.WriteLine("\nRemove() - Test.  Removes first occurence of {0}", s);
            Console.Write("Initial List:  \t\t");
            listDouble.print();
            listDouble.remove(ref s);
            Console.Write("List without {0}:\t", s);
            listDouble.print();

            double sAll = 12.2d;
            Console.WriteLine("\nRemoveAll() - Test.  Remove all occurences of {0}", sAll);
            Console.Write("Initial List:\t\t");
            listDouble.print();
            listDouble.removeAll(ref sAll);
            Console.Write("List without ALL {0}:\t", sAll);
            listDouble.print();

            Console.WriteLine("\nMax() Test");
            Console.WriteLine("Maximum {0} value expected:\t122", listType);
            Console.WriteLine("Max() {0} value returned: \t{1}", listType, listDouble.Max().ToString());

            Console.WriteLine("\nMin() Test");
            Console.WriteLine("Minimum {0} value expected: \t0.33", listType);
            Console.WriteLine("Min() {0} value returned: \t{1}", listType, listDouble.Min().ToString());

            Console.WriteLine("\nSort() Test");
            Console.Write("Initial {0} List: \t", listType);
            listDouble.print();
            Console.Write("Sorted {0} List: \t", listType);
            listDouble.Sort();
            listDouble.print();
            Console.WriteLine("Insertion Sort used in Sort() Method");
        }

        //prints int test
        private static void PrintIntTest(UnorderedLinkedList<int> listInt)
        {
            string listType = "int";

            Console.Write("Intial List of {0}: ", listType);
            listInt.print();

            int s = 3;
            Console.WriteLine("\nRemove() - Test.  Removes first occurence of {0}\t", s);
            Console.Write("Initial List:\t\t");
            listInt.print();
            listInt.remove(ref s);
            Console.Write("List without {0}:\t\t", s);
            listInt.print();

            int sAll = 4;
            Console.WriteLine("\nRemoveAll() - Test.  Remove all occurences of {0}", sAll);
            Console.Write("Initial List:\t\t");
            listInt.print();
            listInt.removeAll(ref sAll);
            Console.Write("List without ALL {0}:\t", sAll);
            listInt.print();

            Console.WriteLine("\nMax() Test");
            Console.WriteLine("Maximum {0} value expected:\t22", listType);
            Console.WriteLine("Max() {0} value returned: \t{1}", listType, listInt.Max().ToString());

            Console.WriteLine("\nMin() Test");
            Console.WriteLine("Minimum {0} value expected: \t1", listType);
            Console.WriteLine("Min() {0} value returned: \t{1}", listType, listInt.Min().ToString());

            Console.WriteLine("\nSort() Test");
            Console.Write("Initial {0} List: \t", listType);
            listInt.print();
            Console.Write("Sorted {0} List: \t", listType);
            listInt.Sort();
            listInt.print();
            Console.WriteLine("Insertion Sort used in Sort() Method");
        }

        //prints string test
        private static void PrintStringTest(UnorderedLinkedList<string> listString)
        {
            string listType = "string";

            Console.Write("Intial List of {0}: ", listType);
            listString.print();

            string s = "GA";
            Console.WriteLine("\nRemove() - Test.  Removes first occurence of {0}", s);
            Console.Write("Initial List:  \t\t");
            listString.print();
            listString.remove(ref s);
            Console.Write("List without {0}:\t", s);
            listString.print();

            string sAll = "ZA";
            Console.WriteLine("\nRemoveAll() - Test.  Remove all occurences of {0}", sAll);
            Console.Write("Initial List:\t\t");
            listString.print();
            listString.removeAll(ref sAll);
            Console.Write("List without ALL {0}:\t ", sAll);
            listString.print();

            Console.WriteLine("\nMax() Test");
            Console.WriteLine("Maximum {0} value expected:\tZZ", listType );
            Console.WriteLine("Max() {0} value returned: \t{1}", listType, listString.Max().ToString());

            Console.WriteLine("\nMin() Test");
            Console.WriteLine("Minimum {0} value expected: \tAA", listType);
            Console.WriteLine("Min() {0} value returned: \t{1}", listType, listString.Min().ToString());

            Console.WriteLine("\nSort() Test");
            Console.Write("Initial {0} List: \t", listType);
            listString.print();
            Console.Write("Sorted {0} List: \t", listType);
            listString.Sort();
            listString.print();
            Console.WriteLine("Insertion Sort used in Sort() Method");
        }
    }
}
