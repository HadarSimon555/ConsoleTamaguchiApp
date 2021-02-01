using System;
using Microsoft.EntityFrameworkCore;
using ConsoleTamaguchiApp.DataTransferObjects;

namespace ConsoleTamaguchiApp.ModelsUI
{
    // מסך יצירת החיה
    class CreateAnimalScreen : Screen
    {
        // פעולה בונה
        public CreateAnimalScreen() : base("Create animal") { }

        // פעולה המציגה את המסך למשתמש
        public override void Show()
        {
            base.Show(); // ניקיון המסך והצגת הכותרת
            // קליטת שם השחקן- את כל שאר הנתונים לא צריך לקלוט כי אנחנו מאתחלים אותם
            Console.WriteLine($"Please enter the name of your tamagotchi: ");
            string animalName = Console.ReadLine();
            try
            {
                AnimalDTO animal = UIMain.api.Animals.CreateProxy(animalName);
                UIMain.CurrentPlayer.Animals.Add(animal);
                UIMain.api.SaveChanges();
                Console.WriteLine("Added animal successfully!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("ooops create animal wrong " + e.Message);
                Console.ReadKey();
                return;
            }
            new HasAnimalMenu().Show(); // מעבר למסך הבא- כאשר בטוח יש חיה פעילה לשחקן
        }
    }
}
