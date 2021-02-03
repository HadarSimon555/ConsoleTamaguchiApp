using System;
using Microsoft.EntityFrameworkCore;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Threading.Tasks;

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
                Task<AnimalDTO> animal = UIMain.api.CreateAnimalAsync(animalName);
                Console.WriteLine("The creation of the animal is carried out...");
                Console.WriteLine("May take a few seconds...");
                animal.Wait();
                AnimalDTO a = animal.Result;
                if (a != null)
                    Console.WriteLine("Added animal successfully!");
                else
                    Console.WriteLine("Added animal faild!");
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
