// Final coding

using System;
using System.Collections.Generic;

class StudentManager
{
    private List<string> names = new List<string>();
    private List<double> g1List = new List<double>();
    private List<double> g2List = new List<double>();
    private List<double> g3List = new List<double>();
    private List<double> avgGrades = new List<double>();

 
    public void AddStudent(string name, double g1, double g2, double g3)
    {
        double average = ComputeAverage(g1, g2, g3);

        names.Add(name);
        g1List.Add(g1);
        g2List.Add(g2);
        g3List.Add(g3);
        avgGrades.Add(average);
    }

    public double ComputeAverage(double g1, double g2, double g3)
    {
        return (g1 + g2 + g3) / 3;
    }

    public List<string> GetAllStudents()
    {
        List<string> result = new List<string>();

        for (int i = 0; i < names.Count; i++)
        {
            string data =
                "Name: " + names[i] + "\n" +
                "Grades: " + g1List[i] + ", " + g2List[i] + ", " + g3List[i] + "\n" +
                "Average: " + avgGrades[i].ToString("F2");

            result.Add(data);
        }

        return result;
    }

   
    public double GetClassAverage()
    {
        if (avgGrades.Count == 0)
            return 0;

        double sum = 0;

        foreach (double avg in avgGrades)
        {
            sum += avg;
        }

        return sum / avgGrades.Count;
    }

    
    public string GetTopStudent()
    {
        if (avgGrades.Count == 0)
            return "No students available.";

        double highest = avgGrades[0];
        int index = 0;

        for (int i = 1; i < avgGrades.Count; i++)
        {
            if (avgGrades[i] > highest)
            {
                highest = avgGrades[i];
                index = i;
            }
        }

        return "Top Student: " + names[index] +
               "\nHighest Grade: " + highest.ToString("F2");
    }
}

class Program
{
    static void Main()
    {
        StudentManager manager = new StudentManager();

        while (true)
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter grade 1: ");
                double g1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter grade 2: ");
                double g2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter grade 3: ");
                double g3 = Convert.ToDouble(Console.ReadLine());

                manager.AddStudent(name, g1, g2, g3);

                Console.WriteLine("Student added successfully!\n");
            }
            else if (choice == 2)
            {
                List<string> students = manager.GetAllStudents();

                foreach (string s in students)
                {
                    Console.WriteLine(s);
                    Console.WriteLine();
                }
            }
            else if (choice == 3)
            {
                double avg = manager.GetClassAverage();

                Console.WriteLine("===== CLASS AVERAGE =====");
                Console.WriteLine("Overall Average Grade: " + avg.ToString("F2") + "\n");
            }
            else if (choice == 4)
            {
                Console.WriteLine("===== HIGHEST GRADE =====");
                Console.WriteLine(manager.GetTopStudent());
                Console.WriteLine();
            }
            else if (choice == 5)
            {
                Console.WriteLine("Exiting program...");
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option!\n");
            }
        }
    }
}