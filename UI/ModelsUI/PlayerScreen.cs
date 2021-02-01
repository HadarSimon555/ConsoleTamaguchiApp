using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך הצגת פרטי השחקן
    class PlayerScreen : Screen
    {
        // פעולה בונה
        public PlayerScreen() : base("Show Player") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            try
            {
                base.Show(); // ניקיון המסך והצגת הכותרת
                ObjectView showPlayer = new ObjectView("", UIMain.CurrentPlayer); // אובייקט פרט המשתמש
                showPlayer.Show(); // הצגת פרטי השחקן
                Console.WriteLine("Press A to see Player Animals or other key to go back!");
                char c = Console.ReadKey().KeyChar;
                if (c == 'a' || c == 'A')
                {
                    Console.WriteLine();
                    //Create list to be displayed on screen
                    //Format the desired fields to be shown! (screen is not wide enough to show all)
                    List<Object> animals = (from animalList in UIMain.CurrentPlayer.Animals
                                            select new
                                            {
                                                ID = animalList.AnimalId,
                                                Name = animalList.AnimalName,
                                                BirthDate = animalList.AnimalCreateDay.ToString(),
                                                Weight = $"{animalList.AnimalWeight:F2}",
                                                Age = animalList.AnimalAge,
                                            }).ToList<Object>();
                    ObjectsList list = new ObjectsList("Animals", animals);
                    list.Show();
                    Console.WriteLine();
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ooops something was wrong " + e.Message);
            }
        }
    }
}
