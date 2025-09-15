// CleanSchoolProgram.cs
// Phiên bản clean code cho quản lý trường học

using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanSchoolProgram
{
    // Định nghĩa class Student
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return $"ID:{Id} | Name:{Name} | Age:{Age} | GPA:{GPA}";
        }
    }

    public class Program
    {
        private static List<Student> students = new List<Student>();

        public static void Main(string[] args)
        {
            int menu;
            do
            {
                ShowMainMenu();
                menu = GetChoice();

                switch (menu)
                {
                    case 1:
                        ManageStudents();
                        break;
                    case 99:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (menu != 99);
        }

        // ================= MENU ==================
        private static void ShowMainMenu()
        {
            Console.WriteLine("\n============= MENU CHÍNH =============");
            Console.WriteLine("1. Quản lý Sinh viên");
            Console.WriteLine("99. Thoát");
            Console.Write("Nhập lựa chọn: ");
        }

        private static int GetChoice()
        {
            int choice;
            return int.TryParse(Console.ReadLine(), out choice) ? choice : -1;
        }

        // ================= QUẢN LÝ SINH VIÊN ==================
        private static void ManageStudents()
        {
            int choice;
            do
            {
                ShowStudentMenu();
                choice = GetChoice();

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: RemoveStudent(); break;
                    case 3: UpdateStudent(); break;
                    case 4: ShowAllStudents(); break;
                    case 5: FindStudentByName(); break;
                    case 6: ShowGoodStudents(); break;
                    case 7: SortByName(); break;
                    case 8: SortByGPA(); break;
                    case 9: Console.WriteLine("Quay lại menu chính."); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                }
            } while (choice != 9);
        }

        private static void ShowStudentMenu()
        {
            Console.WriteLine("\n--- QUẢN LÝ SINH VIÊN ---");
            Console.WriteLine("1. Thêm SV");
            Console.WriteLine("2. Xóa SV");
            Console.WriteLine("3. Cập nhật SV");
            Console.WriteLine("4. Hiển thị tất cả SV");
            Console.WriteLine("5. Tìm SV theo tên");
            Console.WriteLine("6. Danh sách SV GPA > 8");
            Console.WriteLine("7. Sắp xếp theo tên");
            Console.WriteLine("8. Sắp xếp theo GPA");
            Console.WriteLine("9. Quay lại");
            Console.Write("Chọn: ");
        }

        // ================== HÀM XỬ LÝ SINH VIÊN ==================
        private static void AddStudent()
        {
            Console.Write("Nhập ID: ");
            string id = Console.ReadLine();
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Nhập GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            students.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
            Console.WriteLine("Đã thêm sinh viên.");
        }

        private static void RemoveStudent()
        {
            Console.Write("Nhập ID cần xóa: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine(" Đã xóa.");
            }
            else Console.WriteLine(" Không tìm thấy sinh viên.");
        }

        private static void UpdateStudent()
        {
            Console.Write("Nhập ID cần cập nhật: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Nhập tên mới: ");
                student.Name = Console.ReadLine();
                Console.Write("Nhập tuổi mới: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Nhập GPA mới: ");
                student.GPA = double.Parse(Console.ReadLine());
                Console.WriteLine(" Đã cập nhật.");
            }
            else Console.WriteLine(" Không tìm thấy sinh viên.");
        }

        private static void ShowAllStudents()
        {
            if (students.Count == 0)
                Console.WriteLine("Danh sách trống.");
            else
                students.ForEach(Console.WriteLine);
        }

        private static void FindStudentByName()
        {
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            var result = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (result.Any())
                result.ForEach(Console.WriteLine);
            else
                Console.WriteLine(" Không tìm thấy.");
        }

        private static void ShowGoodStudents()
        {
            var result = students.Where(s => s.GPA > 8).ToList();
            if (result.Any())
                result.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Không có sinh viên GPA > 8.");
        }

        private static void SortByName()
        {
            students = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine(" Đã sắp xếp theo tên.");
        }

        private static void SortByGPA()
        {
            students = students.OrderByDescending(s => s.GPA).ToList();
            Console.WriteLine(" Đã sắp xếp theo GPA.");
        }
    }
}
