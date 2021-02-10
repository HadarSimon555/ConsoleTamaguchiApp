using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך משחק עם החיה
    class GamesScreen : Screen
    {
        // פעולה בונה
        public GamesScreen() : base("Game Screen") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            try
            {
                base.Show(); // ניקיון המסך והצגת הכותרת
                Task<ActionTypeDTO> actionTypeTask = UIMain.api.GetActionTypeAsync("Playing"); // בניית אוביקט הפעולה
                Console.WriteLine("May take a few seconds...");
                actionTypeTask.Wait();
                ActionTypeDTO actionType = actionTypeTask.Result;

                Task<List<ActionDTO>> actionListTask = UIMain.api.GetActionsListAsync(actionType);
                Console.WriteLine("May take a few seconds...");
                actionTypeTask.Wait();
                List<ActionDTO> actionList = actionListTask.Result;

                List<object> listActions = actionList.ToList<object>(); // קבלת הפעולות שניתן לבצע על החיה לתוך רשימה
                ObjectsList objList = new ObjectsList("Actions", listActions); // בניית טבלת פעולות שניתן לבצע על החיה
                objList.Show(); // הצגת הפעולות שניתן לבצע לחיה למשתמש
                Console.WriteLine();

                // קליטה מהמשתמש את הפעולה אותה הוא רוצה לבצע לחיה
                Console.WriteLine("Choose what do you want to play with your tamagotchi: ");
                int id = int.Parse(Console.ReadLine());
                ActionDTO action = actionList.Where(p => p.ActionId == id).FirstOrDefault();

                // מסננת קלט לבדוק שבאמת חזרה פעולה
                while (action == null)
                {
                    Console.WriteLine("The id is invalid! Please type again: ");
                    id = int.Parse(Console.ReadLine());
                    action = actionList.Where(p => p.ActionId == id).FirstOrDefault();
                }

                Task<bool> playTask = UIMain.api.PlayWithAnimalAsync(action);
                Console.WriteLine("Your animal is playing, please wait a few seconds...");
                playTask.Wait();
                bool play = playTask.Result;

                if (play)
                    Console.WriteLine("Action managed successfully!");
                else
                    Console.WriteLine("OOps, something went wrong...");
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine($"Fail with error: {e.Message}!");
            }
        }
    }

}
