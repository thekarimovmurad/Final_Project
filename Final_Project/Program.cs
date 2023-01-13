using System;
using System.Collections.Generic;
using System.Threading;

namespace Final_Project
{
    enum AppMenuSelection:byte { AddGroup = 1, AddStudent, AddStudentMark, ViewStudents, FindStudents, DeleteGroup, exit }

    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groupContext = new List<Group>();
            List<Student> studentContext = new List<Student>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Menu: 1 - Add group | 2 - Add student | 3 - Add student mark | 4 - View student list | 5 - Find student | 6 - Delete group | exit");
                Console.ResetColor();
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "exit")
                {
                    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
                    Console.WriteLine("Goodbye");
                    int milliseconds = 1000;
                    Thread.Sleep(milliseconds);
                    break;
                }

                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);
                if (selectionIsValid && selection >= 1 && selection <= 6)
                {
                    switch (selection)
                    {
                        #region AddGroup
                        case (int)AppMenuSelection.AddGroup:
                            Console.Write("Enter group name: ");
                            string groupName = Console.ReadLine();
                            if (string.IsNullOrEmpty(groupName))
                            {
                                Console.WriteLine("Group name invalid.");
                                break;
                            }

                            Console.Write("Enter group max count: ");
                            int maxCount;
                            bool maxCountIsValid = int.TryParse(Console.ReadLine(), out maxCount);
                            if (!maxCountIsValid)
                            {
                                Console.WriteLine("Max count invalid.");
                                break;
                            }

                            Group newGroup = new Group(groupName, maxCount);

                            if (groupContext.Contains(newGroup))
                            {
                                Console.WriteLine("Country already exists.");
                                break;
                            }

                            groupContext.Add(newGroup);
                            Console.WriteLine("Group added successfully.");
                            break;
                        #endregion

                        #region AddStudent
                        case (int)AppMenuSelection.AddStudent:
                            if (groupContext.Count <= 0)
                            {
                                Console.WriteLine("Add a Group first.");
                                break;
                            }

                            Console.Write("Enter student name : ");
                            string studentName = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentName))
                            {
                                Console.WriteLine("Student name invalid.");
                                break;
                            }

                            Console.Write("Enter student surname name: ");
                            string studentSurname = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentSurname))
                            {
                                Console.WriteLine("Student surname invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the group that you want to add the student to: ");
                            int groupId;
                            bool groupIdIsValid = int.TryParse(Console.ReadLine(), out groupId);
                            if (!groupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group addStudentToGroup = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == groupId)
                                {
                                    addStudentToGroup = item;
                                }
                            }

                            if (addStudentToGroup == null)
                            {
                                Console.WriteLine("There is not group.");
                                break;
                            }

                            Student newStudent = new Student(studentName, studentSurname);

                            if (addStudentToGroup.AddStudent(newStudent))
                            {
                                Console.WriteLine("Student added successfully.");
                                studentContext.Add(newStudent);
                            }
                            else
                            {
                                Console.WriteLine("Student already exists.");
                            }
                            break;
                        #endregion

                        #region AddStudentMark
                        case (int)AppMenuSelection.AddStudentMark:
                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }

                            Console.Write("Enter the id of the student that you want to add the mark to: ");
                            int markToStudentId;
                            bool markToStudentIdIsValid = int.TryParse(Console.ReadLine(), out markToStudentId);
                            if (!markToStudentIdIsValid)
                            {
                                Console.WriteLine("Student id invalid.");
                                break;
                            }

                            Console.Write("Enter student mark : ");
                            int studentMark;
                            bool studentMarkIsValid = int.TryParse(Console.ReadLine(), out studentMark);
                            if (!studentMarkIsValid)
                            {
                                Console.WriteLine("The mark should be between 1 and 100.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }

                            Student addMarkToStudent = null;

                            foreach (Student item in studentContext)
                            {
                                if (item.Id == markToStudentId)
                                {
                                    addMarkToStudent = item;
                                }
                            }

                            if (addMarkToStudent == null)
                            {
                                Console.WriteLine("Student does not exist.");
                                break;
                            }

                            //Student newmark = new Student(studentName, studentSurname);

                            if (addMarkToStudent.AddMark(studentMark))
                            {
                                Console.WriteLine("Student added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student already exists.");
                            }
                            break;
                        #endregion

                        #region ViewStudents
                        case (int)AppMenuSelection.ViewStudents:
                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }
                            break;
                        #endregion

                        # region FindStudents
                        case (int)AppMenuSelection.FindStudents:
                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();
                            if (string.IsNullOrEmpty(usersQuery))
                            {
                                Console.WriteLine("Query invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                item.SearchAndPrintStudents(usersQuery);
                            }
                            break;
                        #endregion

                        #region DeleteGroup
                        case (int)AppMenuSelection.DeleteGroup:
                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the Group that you want to delete: ");
                            int deleteGroupId;
                            bool deleteGroupIdIsValid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (!deleteGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group deleteToGroup = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == deleteGroupId)
                                {
                                    deleteToGroup = item;
                                }
                            }

                            if (deleteToGroup == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            groupContext.Remove(deleteToGroup);

                            Console.WriteLine("Group deleted successfully.");
                            break;
                            #endregion
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }
        }
    }
}
