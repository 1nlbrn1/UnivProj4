using System;
using System.Collections.Generic;
using System.Text;

namespace UnivLabProj4 {
    public class Student {
        string surname;
        string name;
        int school;
        int score;
        public string Surname {
            get { return surname; }
            set { surname = value; }
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public int School {
            get { return school; }
            set { school = value; }
        }
        public int Score {
            get { return score; }
            set { score = value; }
        }
        public Student() { }
        public Student(string surname, string name, int school, int score) {
            this.surname = surname;
            this.name = name;
            this.school = school;
            this.score = score;
        }
        public new string ToString() {
            return surname + " " + name + " " + school + " " + score;
        }
    }
}
