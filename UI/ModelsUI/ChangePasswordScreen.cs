using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            // בדיקה האם הסיסמה תקינה והודעה בהתאם
            try
            {
                Task<bool> changeTask = UIMain.api.ChangePasswordAsync(newPswd); // עדכון הסיסמה שנקלטה לשחקן הנוכחי
                Console.WriteLine("Password changing is in progress...");
                Console.WriteLine("May take a few seconds...");
                changeTask.Wait();
                bool change = changeTask.Result;
                if (change)
                    Console.WriteLine("Password changed successfully!");
                else
                    Console.WriteLine("Password changed failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Password change failed with error: {e.Message}!");
            }
            Console.ReadKey();
        }
    }
}
