using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // תפריט פעולות
    class ChooseActionsMenu : Menu
    {
        // פעולה בונה
        public ChooseActionsMenu() : base("Choose Action")
        {
            AddItem("Feed animal", new FoodScreen()); // בניית מסך האכלת החיה
            AddItem("Clean animal", new HygeneScreen()); // בניית מסך ניקיון החיה
            AddItem("Play with animal", new GamesScreen()); // בניית מסך משחק עם החיה
        }
    }
}
