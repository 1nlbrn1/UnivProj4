using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace UnivLabProj4 {
    static class L4 {
        static private string lstr(ICollection<int> l) {
            string res = "{";
            foreach(int i in l) {
                res += Convert.ToString(i) + ", ";
            }
            res = res.Remove(res.Length - 2);
            res += "}";
            return res;
        }
        static private string lstr(ICollection<char> l) {
            string res = "{";
            foreach(int i in l) {
                res += Convert.ToChar(i) + ", ";
            }
            res = res.Remove(res.Length - 2);
            res += "}";
            return res;
        }
        static public void task1(List<int> l) {
            // Не сохраняет порядок.
            /*
            l.Sort();
            if(l.Count <= 1) { return; }
            for(int i = 1; i < l.Count; ++i) {
                if(l[i - 1] == l[i]) {
                    l.RemoveAt(i);
                    --i;
                }
            }
        */
            // Сохраняет порядок. Вложенный цикл.
            for(int i = 0; i < l.Count; ++i) {
                for(int j = i+1; j < l.Count; ++j) {
                    if(l[j] == l[i]) {
                        l.RemoveAt(j);
                        --j;
                    }
                }
            }
            Console.WriteLine(lstr(l));
        }
        static public void task2(LinkedList<int> l, int value) {
            int temp = 0;
            LinkedListNode<int> i = l.First;
            var n = l.Find(value);
            if(n.Previous.Value != n.Next.Value) {
                temp = n.Previous.Value;
                n.Previous.Value = n.Next.Value;
                n.Next.Value = temp;
            }
            Console.WriteLine(lstr(l));

        }
        static public void task3() {
            // Все языки
            HashSet<string> allLangs = new HashSet<string> { "English", "French", "German", "Spanish", "Italian", "Russian" };

            // Список работников и их языков
            List<KeyValuePair<string, HashSet<string>>> emplLangs = new List<KeyValuePair<string, HashSet<string>>>
            {
            new KeyValuePair<string, HashSet<string>>("Angela", new HashSet<string> { "English", "French" }),
            new KeyValuePair<string, HashSet<string>>("Susan", new HashSet<string> { "English", "German", "Spanish" }),
            new KeyValuePair<string, HashSet<string>>("Gregor", new HashSet<string> { "English", "Spanish", "Italian" })
        };

            // Знает хотя бы один работник
            HashSet<string> knownByAtLeastOne = new HashSet<string>();
            foreach(var employee in emplLangs) {
                knownByAtLeastOne.UnionWith(employee.Value);
            }

            // Знает каждый работник
            HashSet<string> knownByEveryone = new HashSet<string>(allLangs);
            foreach(var employee in emplLangs) {
                knownByEveryone.IntersectWith(employee.Value);
            }

            // Не знает никто
            HashSet<string> knownByNoOne = new HashSet<string>(allLangs);
            knownByNoOne.ExceptWith(knownByAtLeastOne);

            Console.WriteLine("Знает каждый из работников:");
            Console.WriteLine(string.Join(", ", knownByEveryone));

            Console.WriteLine("\nЗнает хотя бы один из работников:");
            Console.WriteLine(string.Join(", ", knownByAtLeastOne));

            Console.WriteLine("\nНе знает никто из работников:");
            Console.WriteLine(string.Join(", ", knownByNoOne));
        }
        static public void task4() {
            try {
                HashSet<char> fl = new HashSet<char>();
                using(StreamReader sr = new StreamReader(File.Open(@"C:\Users\Dmitry\source\repos\UnivLabProj4\UnivLabProj4\task4file.txt", FileMode.Open))) {
                    string text = sr.ReadToEnd();
                    string[] tokens = text.Split(' ');
                    foreach(string tk in tokens) {
                        fl.Add(tk[0]);
                    }
                    Console.WriteLine(lstr(fl));
                }

            } catch(Exception e) { Console.WriteLine(e.ToString()); }
        }
        static private List<Student> fileout() {
            List<Student> students = new List<Student>();
            try {
                using(StreamReader sr = new StreamReader(File.Open(@"C:\Users\Dmitry\source\repos\UnivLabProj4\UnivLabProj4\task5input.txt", FileMode.Open))) {
                    string text = sr.ReadToEnd();
                    string[] lines = text.Split("\n");
                    int n = Convert.ToInt32(lines[0]);
                    for(int i = 1; i < lines.Length; ++i) {
                        string line = lines[i];
                        string[] tk = line.Split(' ');
                        students.Add(new Student(tk[0], tk[1], Convert.ToInt32(tk[2]), Convert.ToInt32(tk[3])));
                    }
                    
                }

            } catch(Exception e) { Console.WriteLine(e.ToString()); }
            foreach(Student s in students) {
                Console.WriteLine(s.ToString());
            }
            return students;
        }
        static private void xmlser(List<Student> l) {
            XmlSerializer xser = new XmlSerializer(typeof(List<Student>));
            try {
                HashSet<char> fl = new HashSet<char>();
                using(Stream st = File.Open(@"C:\Users\Dmitry\source\repos\UnivLabProj4\UnivLabProj4\XMLFileForTask5.xml", FileMode.Open)) {
                    st.SetLength(0);
                    xser.Serialize(st, l);
                }

            } catch(Exception e) { Console.WriteLine(e.ToString()); }
        }
        static void OutBestAtInformatics(List<Student> students) {
            var stud_from_50 = students.Where(s => s.School == 50).ToList();

            var sorted_by_score = stud_from_50.OrderByDescending(s => s.Score).ToList();

            int top_score = sorted_by_score[0].Score;
            var best_stud = sorted_by_score.Where(s => s.Score == top_score).ToList();

            if(best_stud.Count > 2) {
                Console.WriteLine(best_stud.Count);
            } else if(best_stud.Count == 1) {
                Console.WriteLine($"{best_stud[0].Surname} {best_stud[0].Name}");
            } else {
                Console.WriteLine($"{best_stud[0].Surname} {best_stud[0].Name}");
                Console.WriteLine($"{best_stud[1].Surname} {best_stud[1].Name}");
            }
        }
        static public void task5() {
            Console.WriteLine("\nInput: ");
            List <Student>  l = fileout();

            xmlser(l);
            Console.WriteLine("\nOutput: ");
            OutBestAtInformatics(l);
        }
    }
}
