using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using ConsoleTamaguchiApp.WebServices;

namespace ConsoleTamaguchiApp.ModelsUI
{
    class UIMain
    {
        //UI Main object is perfect for storing all UI state as it is initialized first and detroyed last.
        public static PlayerDTO CurrentPlayer { get; set; }
        public static TamaguchiWebAPI api { get; private set; }

        private Screen initialScreen;
        public UIMain(Screen initial)
        {
            this.initialScreen = initial;
        }
        public void ApplicationStart()
        {
            //Initialize web api
            api = new TamaguchiWebAPI(@"https://localhost:44311/api");
            CurrentPlayer = null;
            //Show Screen and start app!
            initialScreen.Show();

        }
    }
}
