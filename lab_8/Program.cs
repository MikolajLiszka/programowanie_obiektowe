using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_8
{
    record Student(string Name, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "adam", "ewa", "ela", "karol" };
            Predicate<string> NamesA = s =>
            {
                Console.WriteLine("Predicate " + s);
                return s.StartsWith("a");
            };
            IEnumerable<string> result =
            (from name in names
             where NamesA.Invoke(name) && name.Length == 4
             select name);
            Console.WriteLine(string.Join("\n", result));
            int[] ints = { 4, 5, 6, 7, 8 };

            Student[] students =
            {
                new Student("Ewa", 45),
                new Student("Karol", 72),
                new Student("Krystian", 25),
                new Student("Mikolaj", 47),
                new Student("Patryk", 12),
                new Student("Wojciech", 12),
                new Student("TOmek", 90),
            };

            IEnumerable<string> std = from student in students
                                      where student.Ects > 20
                                      select student.Name.ToUpper();
            Console.WriteLine(string.Join(", ", std));

            IEnumerable<(string name, string)> egzamin =
            from student in students
            select (student.Name, student.Ects > 20 ? "Zdał" : "Nie zdał");
            Console.WriteLine(string.Join(", ", egzamin));

            IEnumerable<IGrouping<int, object>> group =
            from s in students
            group s by s.Ects;
            foreach(var item in group)
            {
                Console.WriteLine(item.Key + " " + string.Join(", ", item));
            }

            IEnumerable<(int value, int count)> enumerable =
            from n in ints
            group n by n into gr
            select(gr.Key, gr.Count<int>());
            foreach(var item in enumerable)
            {
                Console.WriteLine(item.value + ": " + item.count);
            }
            students.Where(student => student.Ects > 20)
                .Select(student => student.Name);

            ints.Where(num => num % 2 == 0)
                .Select(num => num);
            Console.WriteLine(ints.ElementAt(2));
        }
    }
}
