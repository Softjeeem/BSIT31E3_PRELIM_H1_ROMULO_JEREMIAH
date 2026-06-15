// testing

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> names = new List<string>();
        List<double> g1List = new List<double>();
        List<double> g2List = new List<double>();
        List<double> g3List = new List<double>();
        List<double> avgGrades = new List<double>();

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

            // ADD STUDENT
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

                double average = (g1 + g2 + g3) / 3;

                names.Add(name);
                g1List.Add(g1);
                g2List.Add(g2);
                g3List.Add(g3);
                avgGrades.Add(average);

                Console.WriteLine("Student added successfully!");
                Console.WriteLine();
            }

            // VIEW ALL STUDENTS
            else if (choice == 2)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine("Name: " + names[i]);
                    Console.WriteLine("Grades: " + g1List[i] + ", " + g2List[i] + ", " + g3List[i]);
                    Console.WriteLine("Average: " + avgGrades[i].ToString("F2"));
                    Console.WriteLine();
                }
            }

            // CLASS AVERAGE
            else if (choice == 3)
            {
                double sum = 0;

                foreach (double avg in avgGrades)
                {
                    sum += avg;
                }

                double classAverage = names.Count > 0 ? sum / names.Count : 0;

                Console.WriteLine("===== CLASS AVERAGE =====");
                Console.WriteLine("Overall Average Grade: " + classAverage.ToString("F2"));
                Console.WriteLine();
            }

            // HIGHEST GRADE
            else if (choice == 4)
            {
                if (names.Count == 0)
                {
                    Console.WriteLine("No students available.");
                    Console.WriteLine();
                    continue;
                }

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

                Console.WriteLine("===== HIGHEST GRADE =====");
                Console.WriteLine("Top Student: " + names[index]);
                Console.WriteLine("Highest Grade: " + highest.ToString("F2"));
                Console.WriteLine();
            }

            // EXIT
            else if (choice == 5)
            {
                Console.WriteLine("Exiting program...");
                Console.WriteLine("Goodbye!");
                break;
            }

            // INVALID OPTION
            else
            {
                Console.WriteLine("Invalid option!");
                Console.WriteLine();
            }
        }
    }
}