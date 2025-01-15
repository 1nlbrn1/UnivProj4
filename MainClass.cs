using System;
using System.Collections.Generic;
using System.Text;
namespace UnivLabProj4 {
    class MainClass {
        static void Main(string[] args) {
            List<int> l1 = new List<int> { 2, 1, 2, 2, 2, 3, 4, 4 };
            Console.WriteLine("task1:");
            Console.WriteLine("From: { 2, 1, 2, 2, 2, 3, 4, 4 } To:");
            L4.task1(l1);

            int[] nums = { 1, 2, 3, 4, 5 };
            LinkedList<int> l2 = new LinkedList<int>(nums);
            Console.WriteLine("\ntask2:");
            Console.WriteLine("From: { 1, 2, 3, 4, 5 } To: ");
            L4.task2(l2, 2);
            Console.WriteLine("using  L4.task2(l2, 2);");
            Console.WriteLine("\ntask3:");
            L4.task3();
            Console.WriteLine("\ntask4:");
            L4.task4();
            Console.WriteLine("\ntask5:");
            L4.task5();
            //Student s = new Student();
            //Console.WriteLine(s.Surname);
            //Console.WriteLine(s.surname);
        }
    }
}
