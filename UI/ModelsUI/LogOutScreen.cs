using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך התנתקות
    class LogOutScreen : Screen
    {
        // פעולה בונה
        public LogOutScreen() : base($"Log out screen") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            try
            {
                base.Show(); // ניקיון המסך והצגת הכותרת
                             // רק במידה ויש משתמש מחובר- ניתוקו מהמערכת
                if (UIMain.CurrentPlayer != null)
                {
                    UIMain.CurrentPlayer = null;
                    Console.WriteLine("You are successfully logged out");
                }
                else // אחרת- הדפסת הודעה מתאימה
                    Console.WriteLine("You are not logged in");
                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                Console.WriteLine("ooops something was wrong " + e.Message);
            }

            StartMenu startMenu = new StartMenu();
            startMenu.Show();
        }
    }
}
