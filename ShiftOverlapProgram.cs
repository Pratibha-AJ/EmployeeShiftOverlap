using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlap
{
    class Program
    {
        public class EmployeeShift
        {
           public int EmpId { get; set; }

           public int DepartmentId { get; set; } 

           public DateTime StartTime { get; set; }

           public DateTime EndTime { get; set; }
        }

        public static class WeekRoster
        {
           public static List<EmployeeShift> Roster { get; set; }

            static WeekRoster()
            {
                Roster = new List<EmployeeShift>();
            }
        }



        static void Main(string[] args)
        {

            Program.GetWeekRoster();
            EmployeeShift NewShift = new EmployeeShift();
            NewShift.EmpId = 1;
            NewShift.DepartmentId = 1;
            NewShift.StartTime = new DateTime(2020, 07, 15, 16, 00, 00);
            NewShift.EndTime = NewShift.StartTime.AddHours(8);


            if (isShiftOverlap(NewShift))
            {
                Console.WriteLine("Shift Overlap for " + NewShift.EmpId);
                Console.ReadLine();
            }
            else {
                Console.WriteLine("No Overlap");
                Console.ReadLine();

            }

        }

        public static void GetWeekRoster()
        {

          
            EmployeeShift EmpA = new EmployeeShift();
            EmpA.EmpId = 1;
            EmpA.DepartmentId = 1;
            EmpA.StartTime = new DateTime(2020, 07, 15, 09, 00, 00);
            EmpA.EndTime = EmpA.StartTime.AddHours(8);
            WeekRoster.Roster.Add(EmpA);

            EmployeeShift EmpB = new EmployeeShift();
            EmpB.EmpId = 2;
            EmpB.DepartmentId = 1;
            EmpB.StartTime = new DateTime(2020, 07, 15, 09, 00, 00);
            EmpB.EndTime = EmpA.StartTime.AddHours(8);
            WeekRoster.Roster.Add(EmpB);

        }

        /// <summary>
        /// Check if the start time and endtime falls between start time and endtime of existing shifts 
        /// </summary>
        /// <param name="NewShift"></param>
        /// <returns></returns>
        public static bool  isShiftOverlap(EmployeeShift NewShift)
        {

           var t = WeekRoster.Roster.Where(i => i.EmpId == NewShift.EmpId && i.DepartmentId == NewShift.DepartmentId  && ((NewShift.StartTime > i.StartTime && NewShift.StartTime < i.EndTime)) ||(NewShift.EndTime > i.StartTime && NewShift.EndTime < i.EndTime)).ToList();
            if (t.Count >0)
            {
                return true;

            }

            return false;

        }
    }
}
