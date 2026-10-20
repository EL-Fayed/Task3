using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{    public class Student
    {

        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        //public Student(int studentId, string name, int age, List<Course> courses)
        //{
        //    StudentId = studentId;
        //    Name = name;
        //    Age = age;
        //    Courses = courses;
        //}
        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }

            int index = 0;
            while (index < Courses.Count)
            {
                if (Courses[index].CourseId == course.CourseId)
                    return false;
                index++;
            }
            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            string courseTitles = "";

            if (Courses.Count > 0)
            {
                int index = 0;
                while (index < Courses.Count)
                {
                    courseTitles += Courses[index].Title;

                    if (index < Courses.Count - 1)
                        courseTitles += ", ";

                    index++;
                }
            }
            else
                courseTitles = "No courses enrolled";

            return "ID: " + StudentId + " | Name: " + Name + " | Age: " + Age + " | Courses: " + courseTitles;
        }
    }
    public class Instructor
    {

        public int InstructorId { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        //public Instructor(int instructorId, string name, string specialization)
        //{
        //    InstructorId = instructorId;
        //    Name = name;
        //    Specialization = specialization;
        //}
        public string PrintDetails()
        {
            return "ID: " + InstructorId + " | Name: " + Name + " | Specialization: " + Specialization;
        }
    }

    // 3. فئة الكورس (Course)
    public class Course
    {

        public int CourseId { get; set; }

        public string Title { get; set; }

        public Instructor Instructor { get; set; }

        //public Course(int courseId, string title, Instructor instructor)
        //{
        //    CourseId = courseId;
        //    Title = title;
        //    Instructor = instructor;
        //}
        public string PrintDetails()
        {
            string instructorName = "";

            if (Instructor != null)
                instructorName = Instructor.Name;
            else
                instructorName = "No Instructor Assigned";

            return "Course ID: " + CourseId + " | Title: " + Title + " | Instructor: " + instructorName;
        }
    }
    public class StudentManager
    {

        public List<Student> Students { get; set; } = new List<Student>();

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        //public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructors)
        //{
        //    Students = students;
        //    Courses = courses;
        //    Instructors = instructors;
        //}

        public bool AddStudent(Student student)
        {
            int index = 0;
            while (index < Students.Count)
            {
                if (Students[index].StudentId == student.StudentId)
                    return false; 
                index++;
            }

            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            int index = 0;
            while (index < Courses.Count)
            {
                if (Courses[index].CourseId == course.CourseId)
                    return false;
                index++;
            }

            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            int index = 0;
            while (index < Instructors.Count)
            {
                if (Instructors[index].InstructorId == instructor.InstructorId)
                    return false;
                index++;
            }

            Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            int index = 0;
            while (index < Students.Count)
            {
                if (Students[index].StudentId == studentId)
                    return Students[index];
                index++;
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            int index = 0;
            while (index < Courses.Count)
            {
                if (Courses[index].CourseId == courseId)
                    return Courses[index];
                index++;
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            int index = 0;
            while (index < Instructors.Count)
            {
                if (Instructors[index].InstructorId == instructorId)
                    return Instructors[index];
                index++;
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student != null)
                if (course != null)
                    return student.Enroll(course);
            return false;
        }

        public bool UpdateStudent(int studentId, string newName, int newAge)
        {
            Student student = FindStudent(studentId);

            if (student != null)
            {
                student.Name = newName;
                student.Age = newAge;
                return true;
            }

            return false;
        }

        public bool DeleteStudent(int studentId)
        {
            Student student = FindStudent(studentId);

            if (student != null)
            {
                Students.Remove(student);
                return true;
            }

            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            string choice;

            do
            {

                Selection();
                choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("Enter Student ID: ");
                            int sId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Student Name: ");
                            string sName = Console.ReadLine();

                            Console.Write("Enter Student Age: ");
                            int sAge = int.Parse(Console.ReadLine());

                            Student newStudent = new Student();
                            newStudent.StudentId = sId;
                            newStudent.Name = sName;
                            newStudent.Age = sAge;

                            bool isAdded = manager.AddStudent(newStudent);
                            if (isAdded == true)
                            {
                                Console.WriteLine("Student added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Student ID already exists!");
                            }
                            break;
                        }

                    case "2":
                        {
                            Console.Write("Enter Instructor ID: ");
                            int iId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Instructor Name: ");
                            string iName = Console.ReadLine();

                            Console.Write("Enter Specialization: ");
                            string spec = Console.ReadLine();

                            Instructor newInst = new Instructor();
                            newInst.InstructorId = iId;
                            newInst.Name = iName;
                            newInst.Specialization = spec;

                            bool isAdded = manager.AddInstructor(newInst);
                            if (isAdded == true)
                            {
                                Console.WriteLine("Instructor added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Instructor ID already exists!");
                            }
                            break;
                        }

                    case "3":
                        {
                            Console.Write("Enter Course ID: ");
                            int cId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Course Title: ");
                            string cTitle = Console.ReadLine();

                            Console.WriteLine("Available Instructors:");
                            int iIndex = 0;
                            while (iIndex < manager.Instructors.Count)
                            {
                                Console.WriteLine(manager.Instructors[iIndex].PrintDetails());
                                iIndex++;
                            }

                            Console.Write("Enter Instructor ID for this course: ");
                            int instId = int.Parse(Console.ReadLine());

                            Instructor instructor = manager.FindInstructor(instId);

                            Course newCourse = new Course();
                            newCourse.CourseId = cId;
                            newCourse.Title = cTitle;
                            newCourse.Instructor = instructor;

                            bool isAdded = manager.AddCourse(newCourse);
                            if (isAdded == true)
                            {
                                Console.WriteLine("Course added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Course ID already exists!");
                            }
                            break;
                        }

                    case "4":
                        {
                            Console.Write("Enter Student ID: ");
                            int studentIdToEnroll = int.Parse(Console.ReadLine());

                            Console.Write("Enter Course ID: ");
                            int courseIdToEnroll = int.Parse(Console.ReadLine());

                            bool isEnrolled = manager.EnrollStudentInCourse(studentIdToEnroll, courseIdToEnroll);
                            if (isEnrolled == true)
                            {
                                Console.WriteLine("Student enrolled successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Enrollment failed (Check IDs).");
                            }
                            break;
                        }

                    case "5":
                        {
                            Console.WriteLine("--- All Students ---");
                            int index = 0;
                            while (index < manager.Students.Count)
                            {
                                Console.WriteLine(manager.Students[index].PrintDetails());
                                index++;
                            }
                            break;
                        }

                    case "6":
                        {
                            Console.WriteLine("--- All Courses ---");
                            int index = 0;
                            while (index < manager.Courses.Count)
                            {
                                Console.WriteLine(manager.Courses[index].PrintDetails());
                                index++;
                            }
                            break;
                        }

                    case "7":
                        {
                            Console.WriteLine("--- All Instructors ---");
                            int index = 0;
                            while (index < manager.Instructors.Count)
                            {
                                Console.WriteLine(manager.Instructors[index].PrintDetails());
                                index++;
                            }
                            break;
                        }

                    case "8":
                        {
                            Console.Write("Enter Student ID: ");
                            int id = int.Parse(Console.ReadLine());

                            Student result = manager.FindStudent(id);
                            if (result != null)
                            {
                                Console.WriteLine(result.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;
                        }

                    case "9":
                        {
                            Console.Write("Enter Student ID to Update: ");
                            int updId = int.Parse(Console.ReadLine());

                            Console.Write("Enter New Name: ");
                            string newN = Console.ReadLine();

                            Console.Write("Enter New Age: ");
                            int newA = int.Parse(Console.ReadLine());

                            bool isUpdated = manager.UpdateStudent(updId, newN, newA);
                            if (isUpdated == true)
                            {
                                Console.WriteLine("Student updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;
                        }

                    case "10":
                        {
                            Console.Write("Enter Student ID to Delete: ");
                            int delId = int.Parse(Console.ReadLine());

                            bool isDeleted = manager.DeleteStudent(delId);
                            if (isDeleted == true)
                            {
                                Console.WriteLine("Student deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;
                        }

                    case "11":
                        {
                            
                            Console.WriteLine("Exiting program. Goodbye!");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                        }
                }

            } while (choice != "11");
        }
        static void Selection()
        {
            Console.WriteLine("=== Student Management System Menu ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Instructor");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. Show All Students");
            Console.WriteLine("6. Show All Courses");
            Console.WriteLine("7. Show All Instructors");
            Console.WriteLine("8. Find Student by ID");
            Console.WriteLine("9. Update Student Info");
            Console.WriteLine("10. Delete Student");
            Console.WriteLine("11. Exit");
            Console.Write("Choose an option (1-11): ");
        }
    }
}