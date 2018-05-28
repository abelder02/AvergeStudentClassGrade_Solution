using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTasksDLL;

namespace AvergeStudentClassGrade
{
    class AvergeStudentClassGrade : CT
    {
        static void Main(string[] args)
        {
            Header("Average Student Class Grade", "to explore arrays");
            bool flag = true;
            List<string> NewStudents = new List<string>();
            Color("white");
            Console.WriteLine("Please refer to the following example for proper format...");
            Color("magenta");
            Console.WriteLine("FirstName, LastName, Grade");
            Color("w");
            Console.WriteLine("Example: John, Smith, 5");
            while (flag)
            {
                string userInput = AskUserForString("the student's first name"
                    + ", then his/her last name, followed by his/her grade level");
                userInput = CheckInput(userInput);
                string[] input = userInput.Split(',');
                string firstNameInput = input[0].Trim();
                string lastNameInput = input[1].Trim();
                int classGradeInput = Convert.ToInt32(input[2].Trim());
                Student student = new Student(firstNameInput, lastNameInput, classGradeInput);
                NewStudents.Add(student.firstName);
                NewStudents.Add(student.lastName);
                NewStudents.Add(student.classGrade.ToString());
                Console.Write("\nDo you wish to enter another student: (Y/N)");
                string flagInput = Console.ReadLine().ToLower();
                if (!flagInput.Contains("y"))
                {
                    flag = false;
                }
            }
            int i = 1; int totalGrade = 0;
            foreach (string grade in NewStudents)
            {
                if ((i%3) == 0)
                {
                    totalGrade += Convert.ToInt32(grade);
                }
                i++;
            }
            double numOfStudents = (double)NewStudents.Count / 3;
            double schoolClassAverageGrade = totalGrade/numOfStudents;

            Color("m");
            Console.WriteLine("The average class grade of the students is {0:N2}.", 
                schoolClassAverageGrade);

            Footer();
        }

        public static string CheckInput(string input)
        {
            for (int i = 0; i < 1; i++)
            {
                try
                {

                    string gradeInput;
                    int numOfCommas = 0; string input2 = input;

                    while (input2.Contains(','))
                    {
                        input2 = input2.Remove(input2.LastIndexOf(','));
                        numOfCommas++;
                    }
                    if(!input.Contains(','))
                        gradeInput = "X";
                    else if(numOfCommas != 2)
                        gradeInput = "X";
                    else
                        gradeInput = input.Substring(input.LastIndexOf(',')+1).Trim();

                    if (Convert.ToInt32(gradeInput) > 12 || Convert.ToInt32(gradeInput) < 0)
                        gradeInput = "X";
                    int.Parse(gradeInput);
                }
                catch (FormatException)
                {
                    Color("red");
                    Console.WriteLine("\nYOU GOOBER ---> FOLLOW DIRECTIONS");
                    Color("white");
                    Console.WriteLine("Please refer to the following example for proper format...");
                    Color("magenta");
                    Console.WriteLine("FirstName, LastName, Grade");
                    Color("w");
                    Console.WriteLine("Example: John, Smith, 5");
                    input = AskUserForString("the student's first name"
                        + "<,> then his/her last name<,> followed by his/her grade level:");
                    i--;
                }
            }
            return input;
        }

    }

    public class Student
    {        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int classGrade { get; set; }
        public Student(string f, string l, int g)
        {
            firstName = f;
            lastName = l;
            classGrade = g;
        }
    }
}
