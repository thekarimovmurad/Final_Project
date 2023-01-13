using System.Collections.Generic;

namespace Final_Project
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> Marks = new List<int>();

        public int AvarageMark
        {
            get
            {
                int result = 0;
                int count = 1;
                foreach (int item in Marks)
                {
                    result = (result + item) / count;
                    count++;
                }
                return result;
            }
        }

        private static int count;
        public readonly int Id;

        private Student()
        {
            count++;
            Id = count;
            Marks = new List<int>();
        }

        public Student(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"STUDENT: Student ID:{Id} Name:{Name} Surname:{Surname } Avarage mark:{AvarageMark}";
        }

        public override bool Equals(object obj)
        {
            return Name == ((Student)obj).Name;
        }

        public bool AddMark(int mark)
        {
            if (mark > 100 || mark < 0)
            {
                return false;
            }
            Marks.Add(mark);
            return true;
        }
    }
}
