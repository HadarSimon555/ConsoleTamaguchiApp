using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך ההתחלה
    class StartScreen : Screen
    {
        // פעולה בונה
        public StartScreen() : base($"Start Screen") { }

        // פעולה המציגה את המסך למשתמש 
        public override void Show()
        {
            base.Show(); // ניקיון המסך והצגת הכותרת
            StartMenu startMenu = new StartMenu(); // בניית אובייקט תפריט התחלתי
            startMenu.Show(); // העברת המשתמש לתפריט ההתחלתי
        }
    }
}
