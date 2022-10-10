using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsCalendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese Fecha inicio");
            DateTime fechainicio = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese Fecha a Calcular");
            DateTime fecha = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(Periodos(fechainicio, fecha));
            Console.WriteLine(Semanas(fechainicio, fecha));
            Console.WriteLine(PxWx(fechainicio, fecha));
            Console.WriteLine(WeekOfYear(fechainicio, fecha));
            MarsCalendar(fechainicio);
            Console.ReadKey();
        }

        public static string Periodos(DateTime fechainicio, DateTime fecha)
        {
            string Periodo = Convert.ToString(Math.Ceiling((fecha.Date.ToOADate() - fechainicio.Date.ToOADate()) * 13 / 364));
            return $"P{Periodo.ToString().PadLeft(2, '0')}";
        }
        public static string Semanas(DateTime fechainicio, DateTime fecha)
        {
            double Semana = Math.Ceiling((fecha.Date.ToOADate() - fechainicio.Date.ToOADate()) / 7 - (Math.Ceiling((fecha.Date.ToOADate() - fechainicio.Date.ToOADate()) * 13 / 364) - 1) * 4);
            return $"W{Semana.ToString()}";
        }
        public static string PxWx(DateTime fechainicio, DateTime fecha)
        {
            return $"{Periodos(fechainicio, fecha)}{Semanas(fechainicio, fecha)}";
        }
        public static string WeekOfYear(DateTime fechainicio,DateTime fecha)
        {
            double Semana = Math.Ceiling((fecha.Date.ToOADate() - fechainicio.Date.ToOADate()) / 7);
            return $"{Semana.ToString().PadLeft(2, '0')}";
        }
        public static void MarsCalendar(DateTime fechainicio)
        {
            List<DateTime> Mars = new List<DateTime>();
            Mars.Add(fechainicio);
            List<DateTime> Periodos = new List<DateTime>();
            for (int x = 1; x < 364; x++)
            {
                Mars.Add(fechainicio.AddDays(x));
            }
            Periodos.Add(fechainicio.AddDays(1));
            for (int x = 1; x < 13; x++)
            {
                Periodos.Add(fechainicio.AddDays(Math.Ceiling(Convert.ToDouble(x * 364 / 13))+1));
            }
        }
    }
}
