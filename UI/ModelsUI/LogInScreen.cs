using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך התחברות
    class LoginScreen : Screen
    {
        // פעולה בונה
        public LoginScreen() : base("Login screen") { }

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
                    UIMain.CurrentPlayer = null;
                }
            }

            // כאשר אין שחקן מחובר למערכת- ביצוע התחברות
            while (UIMain.CurrentPlayer == null)
            {
                base.Show(); // ניקיון המסך והצגת הכותרת
                // קליטת פרטי המשתמש לצורך התחברות
                Console.WriteLine($"Please enter your email: ");
                string email = Console.ReadLine();
                // בדיקת תקינות אימייל
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                while (!regex.Match(email).Success)
                {
                    Console.WriteLine("invalid email!! type again:");
                    email = Console.ReadLine();
                }
                Console.WriteLine("Please enter your user name: ");
                string userName = Console.ReadLine();
                Console.WriteLine($"Please enter your password: ");
                string password = Console.ReadLine();
                try
                {
                    PlayerDTO pDTO = new PlayerDTO()
                    {
                        PlayerEmail = email,
                        PlayerUserName = userName,
                        PlayerPassword = password
                    };
                    // חיבור המשתמש למערכת
                    Task<PlayerDTO> p = UIMain.api.LoginAsync(pDTO);
                    p.Wait();
                    pDTO = p.Result;
                    UIMain.CurrentPlayer = pDTO;
                    // במידה וההתחברות נכשלה
                    if (UIMain.CurrentPlayer == null)
                    {
                        Console.WriteLine("Login fail!! Press any key to try again!");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ooops something was wrong " + e.Message);
                    Console.ReadKey();
                    return;
                }
            }
            // בדיקה אם לשחקן יש חיות פעילות והעברתו למסך מתאים

            Task<AnimalDTO> aDTO = UIMain.api.GetPlayerActiveAnimalAsync();
            aDTO.Wait();
            AnimalDTO currentAnimal = aDTO.Result;
            if (currentAnimal != null)
                new HasAnimalMenu().Show();
            else
                new NoAnimalMenu().Show();
            Console.ReadKey();
            return;
        }
    }
}
