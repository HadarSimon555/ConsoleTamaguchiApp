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

                Task<bool> feedTask = UIMain.api.FeedAnimalAsync(action);
                Console.WriteLine("Your animal is eating, please wait a few seconds...");
                feedTask.Wait();
                bool feed = feedTask.Result;

                if(feed)
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
