using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    public class ActionDTO
    {
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public int ActionTypeId { get; set; }
        public ActionDTO() { }
    }
}
