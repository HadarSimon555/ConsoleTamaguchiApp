using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleTamaguchiApp.WebServices;
using ConsoleTamaguchiApp.ModelsUI;

namespace ConsoleTamaguchiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UIMain ui = new UIMain(new StartScreen());
            ui.ApplicationStart();
        }
    }
}
