using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    public class PlayerDTO
    {
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerEmail { get; set; }
        public DateTime? PlayerBirthDate { get; set; }
        public string PlayerUserName { get; set; }
        public string PlayerPassword { get; set; }
        public PlayerDTO() { }
    }
}
