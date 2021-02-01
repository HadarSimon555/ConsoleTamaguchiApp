using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // תפריט כאשר אין חיה פעילה
    class NoAnimalMenu : Menu
    {

        public NoAnimalMenu() : base("Menu")
        {
            AddItem("Player details", new PlayerScreen()); // בניית מסך הצגת פרטי השחקן
            AddItem("Create animal", new CreateAnimalScreen()); // בניית מסך של בניית חיה
            AddItem("Change password", new ChangePasswordScreen()); // בניית מסך שינוי סיסמה
            AddItem("Log out", new LogOutScreen()); // בניית מסך התנקות השחקן
        }
    }
}
