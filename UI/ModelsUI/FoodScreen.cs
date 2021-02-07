using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך האכלת החיה
    class FoodScreen : Screen
    {
        // פעולה בונה
        public FoodScreen() : base($"Food Screen") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            try
            {
                base.Show(); // ניקיון המסך והצגת הכותרת
                Task<ActionTypeDTO> actionTypeTask = UIMain.api.GetActionTypeAsync("Feeding"); // בניית אוביקט הפעולה
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
                Console.WriteLine("Choose what do you want to feed your tamagotchi: ");
                int id = int.Parse(Console.ReadLine());
                ActionDTO action = actionType.GetAction(id); // קבלת הפעולה לתוך משתנה לפי המספר שנקלט
                                                          // מסננת קלט לבדוק שבאמת חזרה פעולה
                while (action == null)
                {
                    Console.WriteLine("The id is invalid! Please type again: ");
                    id = int.Parse(Console.ReadLine());
                    action = actionType.GetAction(id);
                }
                AnimalDTO animal = UIMain.CurrentPlayer.GetActiveAnimal(); // קבלת החיה הפעילה של השחקן הנוכחי
                animal.FeedAnimal(action); // האכלת החיה
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
