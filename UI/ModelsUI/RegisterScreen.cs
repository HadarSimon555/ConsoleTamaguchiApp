using System;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using ConsoleTamaguchiApp.DataTransferObjects;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך התחברות
    class RegisterScreen : Screen
    {
        // פעולה בונה
        public RegisterScreen() : base("Register") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            base.Show(); // ניקיון המסך והצגת הכותרת

            // בדיקה אם יש כבר משתמש שמחובר למערכת, במידה ויש מוציאים אותו מהמערכת או מחזירים אותו לתפריט
            if (UIMain.CurrentPlayer != null)
            {
                Console.WriteLine($"Currently, {0} is logged in. Press Y to log out or other key to go back to menu!");
                char c = Console.ReadKey().KeyChar;
                if (c == 'Y' || c == 'y')
                {
                    // שמירת השינויים- הוצאת המשתמש מהמערכת
                    UIMain.api.SaveChanges();
                    UIMain.CurrentPlayer = null;
                }
            }

            // כאשר אין שחקן מחובר למערכת- ביצוע הרשמה
            while (UIMain.CurrentPlayer == null)
            {
                base.Show(); // ניקיון המסך והצגת הכותרת
                // קליטת נתונים מהמשתמש לצורך בנייתו
                Console.WriteLine($"Please enter your first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine($"Please enter your last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine($"Please enter your email: ");
                string email = Console.ReadLine();
                // בדיקת תקינות אימייל
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                while (!regex.Match(email).Success)
                {
                    Console.WriteLine("invalid email!! type again:");
                    email = Console.ReadLine();
                }
                while (UIMain.api.PlayerExistByEmail(email))
                {
                    Console.WriteLine("This email already exist! Type again: ");
                    email = Console.ReadLine();
                    while (!regex.Match(email).Success)
                    {
                        Console.WriteLine("invalid email!! type again:");
                        email = Console.ReadLine();
                    }
                }
                Console.WriteLine($"Please enter your gender: (male/female) ");
                string gender = Console.ReadLine();
                while (gender != "female" && gender != "male")
                {
                    Console.WriteLine("invaild gender! Please type again: ");
                    gender = Console.ReadLine();
                }
                Console.WriteLine($"Please enter your birth year: ");
                int year = int.Parse(Console.ReadLine());
                while (year > 2020 || year < 1900)
                {
                    Console.WriteLine("Birth year must be between 1900 to 2020! Pleae type again: ");
                    year = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Please enter your birth month: ");
                int month = int.Parse(Console.ReadLine());
                while (month > 12 || month < 1)
                {
                    Console.WriteLine("Birth month must be between 1 to 12! Pleae type again: ");
                    month = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Please enter your birth day: ");
                int day = int.Parse(Console.ReadLine());
                while (day > 31 || day < 1)
                {
                    Console.WriteLine("Birth day must be between 1 to 31! Pleae type again: ");
                    day = int.Parse(Console.ReadLine());
                }
                DateTime birthDate = new DateTime(year, month, day);
                Console.WriteLine($"Please enter your user name: ");
                string userName = Console.ReadLine();
                while (UIMain.api.PlayerExistByUserName(userName))
                {
                    Console.WriteLine("This user name already exist! Type again: ");
                    userName = Console.ReadLine();
                }
                Console.WriteLine($"Please enter password: ");
                string password = Console.ReadLine();
                PlayerDTO player = UIMain.api.Players.CreateProxy(firstName, lastName, email, gender, birthDate, userName, password);
                UIMain.api.Players.Add(player);
                UIMain.api.SaveChanges();

                UIMain.CurrentPlayer = player; // עדכון השחקן הנוכחי
            }
            new NoAnimalMenu().Show(); // העברת השחקן למסך כאשר בטוח אין לו חיה
        }
    }
}
