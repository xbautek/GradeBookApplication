using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using Newtonsoft.Json;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5 ) 
            {
                throw new InvalidOperationException();
            }

            double ile = (1/Students.Count)*100;
            double suma = 0;

            foreach(var student in Students) 
            {
                suma += ile;
                foreach(var grade in student.Grades)
                {
                    if (averageGrade < grade)
                    {
                        suma -= ile;
                        break;
                    }
                }
            }

            if (averageGrade >= 80)
                return 'A';
            else if (averageGrade >= 60)
                return 'B';
            else if (averageGrade >= 40)
                return 'C';
            else if (averageGrade >= 20)
                return 'D';
            else
                return 'F';


        }


        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
