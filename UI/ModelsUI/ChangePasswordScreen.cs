using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך שינוי סיסמה
    class ChangePasswordScreen : Screen
    {
        // פעולה בונה
        public ChangePasswordScreen() : base("Change Password") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            base.Show(); // ניקיון המסך והצגת הכותרת
            // קליטת הסיסמה החדשה מהמשתמש
            Console.WriteLine("Please Type new password: ");
            string newPswd = Console.ReadLine();
            UIMain.CurrentPlayer.PlayerPassword = newPswd; // עדכון הסיסמה שנקלטה לשחקן הנוכחי
            // בדיקה האם הסיסמה תקינה והודעה בהתאם
            try
            {

                Console.WriteLine("Password changed successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Password change fail with error: {e.Message}!");
            }
            Console.ReadKey();
        }
    }
}
