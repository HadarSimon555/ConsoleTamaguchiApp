using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }
        public string PlayerUserName { get; set; }
        public string AnimalName { get; set; }
        public DateTime AnimalCreateDay { get; set; }
        public double AnimalWeight { get; set; }
        public int AnimalAge { get; set; }
        public int AnimalHungerLevel { get; set; }
        public int AnimalHygieneLevel { get; set; }
        public int AnimalHappinessLevel { get; set; }
        public AnimalDTO() { }
    }
}
