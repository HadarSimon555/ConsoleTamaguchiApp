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
                Task<ActionDTO> actionTask = UIMain.api.GetActionAsync(id); // קבלת הפעולה לתוך משתנה לפי המספר שנקלט
                Console.WriteLine("May take a few seconds...");
                actionTask.Wait();
                ActionDTO action = actionTask.Result;

                // מסננת קלט לבדוק שבאמת חזרה פעולה
                while (action == null)
                {
                    Console.WriteLine("The id is invalid! Please type again: ");
                    id = int.Parse(Console.ReadLine());
                    actionTask = UIMain.api.GetActionAsync(id); // קבלת הפעולה לתוך משתנה לפי המספר שנקלט
                    Console.WriteLine("May take a few seconds...");
                    actionTask.Wait();
                    action = actionTask.Result;
                }

                Task<AnimalDTO> aDTO = UIMain.api.GetPlayerActiveAnimalAsync(); // קבלת החיה הפעילה של השחקן הנוכחי
                Console.WriteLine("May take a few seconds...");
                aDTO.Wait();
                AnimalDTO currentAnimal = aDTO.Result;

                currentAnimal.PlayWithAnimal(action); // משחק עם החיה
                Console.WriteLine("Action managed successfully!");
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine($"Fail with error: {e.Message}!");
            }
        }
    }

}
