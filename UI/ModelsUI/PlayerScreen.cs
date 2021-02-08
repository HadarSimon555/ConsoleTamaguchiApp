using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTamaguchiApp.WebServices;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Threading.Tasks;

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
            base.Show();
            ObjectView showPlayer = new ObjectView("", UIMain.CurrentPlayer);
            showPlayer.Show();
            Console.WriteLine("Press A to see Player Animals or other key to go back!");
            char c = Console.ReadKey().KeyChar;
            if (c == 'a' || c == 'A')
            {
                //Read first the animals of the player
                Task<List<AnimalDTO>> t = UIMain.api.GetPlayerAnimalsAsync();
                Console.WriteLine("Reading player anuimals...");
                t.Wait();
                List<AnimalDTO> list = t.Result;
                if (list != null)
                {
                    //Create list to be displayed on screen
                    //Format the desired fields to be shown! (screen is not wide enough to show all)

                    List<Object> animals = list.ToList<Object>();
                    ObjectsList oList = new ObjectsList("Animals", animals);
                    oList.Show();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Animals could not be read!");
                }
                Console.WriteLine();


                Console.ReadKey();
            }
        }
    }
}
