﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTamaguchiApp.DataTransferObjects;

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
                ActionType actionType = UIMain.api.GetActionType("Playing"); // בניית אוביקט הפעולה
                List<object> listActions = actionType.GetActions().ToList<object>(); // קבלת הפעולות שניתן לבצע על החיה לתוך רשימה
                ObjectsList objList = new ObjectsList("Actions", listActions); // בניית טבלת פעולות שניתן לבצע על החיה
                objList.Show(); // הצגת הפעולות שניתן לבצע לחיה למשתמש
                Console.WriteLine();
                // קליטה מהמשתמש את הפעולה אותה הוא רוצה לבצע לחיה
                Console.WriteLine("Choose what do you want to play with your tamagotchi: ");
                int id = int.Parse(Console.ReadLine());
                Action action = actionType.GetAction(id); // קבלת הפעולה לתוך משתנה לפי המספר שנקלט
                                                          // מסננת קלט לבדוק שבאמת חזרה פעולה
                while (action == null)
                {
                    Console.WriteLine("The id is invalid! Please type again: ");
                    id = int.Parse(Console.ReadLine());
                    action = actionType.GetAction(id);
                }
                AnimalDTO animal = UIMain.CurrentPlayer.GetActiveAnimal(); // קבלת החיה הפעילה של השחקן הנוכחי
                animal.PlayWithAnimal(action); // משחק עם החיה
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
