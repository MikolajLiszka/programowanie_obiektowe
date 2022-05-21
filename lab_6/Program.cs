using System;
using System.Collections.Generic;

namespace lab_6
{
    class Student
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");
            return obj is Student student &&
                   Name == student.Name &&
                   Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Student HashCode");
            return HashCode.Combine(Name, Ects);
        }

        public override string ToString()
        {
            return $"Name = {Name} {Ects}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("ewa");
            names.Add("karol");
            names.Add("robert");
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names.Contains("ewa"));

            ICollection <Student> students = new List<Student>();
            students.Add(new Student() { Name = "Ewa", Ects = 12 });
            students.Add(new Student() { Name = "karol", Ects = 14 });
            Console.WriteLine(students.Contains(new Student() { Name = "Ewa", Ects = 12 }));

            IList<Student> list = (IList<Student>)students;
            Console.WriteLine(list[0]);
            list.Insert(0, new Student() { Name = "mikolaj", Ects = 16 });
            int i = list.IndexOf(new Student() { Name = "karol", Ects = 14 });
            Console.WriteLine(i);

            ISet<string> nameSet = new HashSet<string>();
            nameSet.Add("ewa");
            nameSet.Add("ewa");
            nameSet.Add("ewa");
            Console.WriteLine(string.Join(", ", nameSet));

            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "karol", Ects = 14 });
            studentGroup.Add(new Student() { Name = "karol", Ects = 14 });
            studentGroup.Add(new Student() { Name = "ewa", Ects = 14 });
            Console.WriteLine(string.Join(", ", studentGroup));
            Console.WriteLine(studentGroup.Contains(new Student() { Name = "ewa", Ects = 14 }));
            ISet<Student> team = new HashSet<Student>();
            team.Add(new Student() { Name = "ewa", Ects = 14 });
            ISet<Student> result = new HashSet<Student>(studentGroup);
            result.IntersectWith(team);
            Console.WriteLine(string.Join(", ", result));
            
            Dictionary<string, Person> addresBook = new Dictionary<string, Person>();
            Person person = new Person() { Name = "karol", Email = "karol@op.pl", Phone = "456654456" };
            addresBook.Add(person.Phone, person);
            person = new Person() { Name = "ewa", Email = "ewa@op.pl", Phone = "123321123" };
            addresBook.Add(person.Phone, person);
            Console.WriteLine(addresBook["123321123"]);
            Console.WriteLine(addresBook.Keys);

            foreach(var item in addresBook)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            string[] arr = { "dd", "aa", "cc", "ss", "aa", "dd", "r", "aa" };

            //oblicz liczbe wystapien z kazdego z lancuchow arr
            int[] set1 = { 2, 33, 6, 6, 1, 7, 8, 9, 10 };
            int[] set2 = { 3, 6, 8, 9, 11, 2, 1, 78 };
            //wyznacz czesc wspolna
        }

    }

    class Person
    {
        public String Phone { get; set; }

        public String Email { get; set; }

        public String Name { get; set; }
    }
}
