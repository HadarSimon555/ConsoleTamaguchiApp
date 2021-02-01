using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // תפריט כאשר יש חיה פעילה
    class HasAnimalMenu : Menu
    {
        // פעולה בונה
        public HasAnimalMenu() : base("Menu")
        {
            AddItem("Player details", new PlayerScreen()); // בניית מסך הצגת פרטי השחקן
            AddItem("Animal care", new ChooseActionsMenu()); // בניית תסך תפריט הפעולות
            AddItem("Change password", new ChangePasswordScreen()); // בניית מסך שינוי סיסמה
            AddItem("Log out", new LogOutScreen()); // בניית מסך התנקות השחקן
        }
    }
}
