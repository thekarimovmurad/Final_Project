using System;
using System.Collections.Generic;

namespace Final_Project
{
    class Group
    {
        public string Name { get; set; }
        public int MaxCount { get; set; }
        private List<Student> Students { get; set; }

        private static int count;
        public readonly int Id;

        private Group()
        {
            count++;
            Id = count;
            Students = new List<Student>();
        }

        public Group(string name, int maxCount) : this()
        {
            Name = name;
            MaxCount = maxCount;
        }

        public override string ToString()
        {
            return $"GROUP:Group ID:{Id} Name:{Name} Max Count:{MaxCount}";
        }

        public override bool Equals(object obj)
        {
            return Name == ((Group)obj).Name;
        }

        public bool AddStudent(Student student)
        {
            if (MaxCount > Students.Count)
            {
                if (Students.Contains(student))
                {
                    return false;
                }
                Students.Add(student);
                return true;
            }
            return false;
        }

        public void PrintAllStudents()
        {
            foreach (Student item in Students)
            {
                Console.WriteLine($"{item}");
            }
        }

        public void SearchAndPrintStudents(string query)
        {
            bool resultFound = false;
            foreach (Student item in Students)
            {
                if (item.Name.Contains(query) || item.Surname.Contains(query))
                {
                    Console.WriteLine($"{item.Surname} {item.Name}");
                    resultFound = true;
                }
            }

            if (!resultFound)
            {
                Console.WriteLine($"No results were found.");
            }
        }
    }
}
