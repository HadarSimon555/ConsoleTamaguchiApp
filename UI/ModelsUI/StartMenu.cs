using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // תפריט התחלתי
    class StartMenu : Menu
    {
        // פעולה בונה
        public StartMenu() : base($"Start Screen - Do you want to log in or register?")
        {
            AddItem("Log in", new LoginScreen()); //בניית מסך ההתחברות
            AddItem("Register", new RegisterScreen()); // בניית מסך ההרשמה
        }
    }
}
