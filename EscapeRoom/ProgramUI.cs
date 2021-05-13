using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class ProgramUI
    {
        public bool _foundExit = false;
        Dictionary<string, int> solutionToSafe = new Dictionary<string, int> { };
        LockBoxStuff NewLockBox = new LockBoxStuff();

        string title = @"
             _____                          ______                      
            |  ___|                         | ___ \                     
            | |__ ___  ___ __ _ _ __   ___  | |_/ /___   ___  _ __ ___  
            |  __/ __|/ __/ _` | '_ \ / _ \ |    // _ \ / _ \| '_ ` _ \ 
            | |__\__ \ (_| (_| | |_) |  __/ | |\ \ (_) | (_) | | | | | |
            \____/___/\___\__,_| .__/ \___| \_| \_\___/ \___/|_| |_| |_|
                               | |                                      
                               |_|                                      ";

        string enterCode = @"
         _____      _              _   _            _____           _      
        |  ___|    | |            | | | |          /  __ \         | |     
        | |__ _ __ | |_ ___ _ __  | |_| |__   ___  | /  \/ ___   __| | ___ 
        |  __| '_ \| __/ _ \ '__| | __| '_ \ / _ \ | |    / _ \ / _` |/ _ \
        | |__| | | | ||  __/ |    | |_| | | |  __/ | \__/\ (_) | (_| |  __/
        \____/_| |_|\__\___|_|     \__|_| |_|\___|  \____/\___/ \__,_|\___|
";

        string gameOver = @"
        
          ______    ______   __       __  ________         ______   __     __  ________  _______  
         /      \  /      \ /  \     /  |/        |       /      \ /  |   /  |/        |/       \ 
        /$$$$$$  |/$$$$$$  |$$  \   /$$ |$$$$$$$$/       /$$$$$$  |$$ |   $$ |$$$$$$$$/ $$$$$$$  |
        $$ | _$$/ $$ |__$$ |$$$  \ /$$$ |$$ |__          $$ |  $$ |$$ |   $$ |$$ |__    $$ |__$$ |
        $$ |/    |$$    $$ |$$$$  /$$$$ |$$    |         $$ |  $$ |$$  \ /$$/ $$    |   $$    $$< 
        $$ |$$$$ |$$$$$$$$ |$$ $$ $$/$$ |$$$$$/          $$ |  $$ | $$  /$$/  $$$$$/    $$$$$$$  |
        $$ \__$$ |$$ |  $$ |$$ |$$$/ $$ |$$ |_____       $$ \__$$ |  $$ $$/   $$ |_____ $$ |  $$ |
        $$    $$/ $$ |  $$ |$$ | $/  $$ |$$       |      $$    $$/    $$$/    $$       |$$ |  $$ |
         $$$$$$/  $$/   $$/ $$/      $$/ $$$$$$$$/        $$$$$$/      $/     $$$$$$$$/ $$/   $$/ 
                                                                                          
";

        string youEscaped = @"
        
          ______    ______   __    __   ______   _______    ______   ________  ______   __                         
         /      \  /      \ /  \  /  | /      \ /       \  /      \ /        |/      \ /  |                        
        /$$$$$$  |/$$$$$$  |$$  \ $$ |/$$$$$$  |$$$$$$$  |/$$$$$$  |$$$$$$$$//$$$$$$  |$$ |                        
        $$ |  $$/ $$ |  $$ |$$$  \$$ |$$ | _$$/ $$ |__$$ |$$ |__$$ |   $$ |  $$ \__$$/ $$ |                        
        $$ |      $$ |  $$ |$$$$  $$ |$$ |/    |$$    $$< $$    $$ |   $$ |  $$      \ $$ |                        
        $$ |   __ $$ |  $$ |$$ $$ $$ |$$ |$$$$ |$$$$$$$  |$$$$$$$$ |   $$ |   $$$$$$  |$$/                         
        $$ \__/  |$$ \__$$ |$$ |$$$$ |$$ \__$$ |$$ |  $$ |$$ |  $$ |   $$ |  /  \__$$ | __                         
        $$    $$/ $$    $$/ $$ | $$$ |$$    $$/ $$ |  $$ |$$ |  $$ |   $$ |  $$    $$/ /  |                        
         $$$$$$/   $$$$$$/  $$/   $$/  $$$$$$/  $$/   $$/ $$/   $$/    $$/    $$$$$$/  $$/                         
                                                                                                           
                                                                                                           
                                                                                                           
         __      __  ______   __    __        ________   ______    ______    ______   _______   ________  _______  
        /  \    /  |/      \ /  |  /  |      /        | /      \  /      \  /      \ /       \ /        |/       \ 
        $$  \  /$$//$$$$$$  |$$ |  $$ |      $$$$$$$$/ /$$$$$$  |/$$$$$$  |/$$$$$$  |$$$$$$$  |$$$$$$$$/ $$$$$$$  |
         $$  \/$$/ $$ |  $$ |$$ |  $$ |      $$ |__    $$ \__$$/ $$ |  $$/ $$ |__$$ |$$ |__$$ |$$ |__    $$ |  $$ |
          $$  $$/  $$ |  $$ |$$ |  $$ |      $$    |   $$      \ $$ |      $$    $$ |$$    $$/ $$    |   $$ |  $$ |
           $$$$/   $$ |  $$ |$$ |  $$ |      $$$$$/     $$$$$$  |$$ |   __ $$$$$$$$ |$$$$$$$/  $$$$$/    $$ |  $$ |
            $$ |   $$ \__$$ |$$ \__$$ |      $$ |_____ /  \__$$ |$$ \__/  |$$ |  $$ |$$ |      $$ |_____ $$ |__$$ |
            $$ |   $$    $$/ $$    $$/       $$       |$$    $$/ $$    $$/ $$ |  $$ |$$ |      $$       |$$    $$/ 
            $$/     $$$$$$/   $$$$$$/        $$$$$$$$/  $$$$$$/   $$$$$$/  $$/   $$/ $$/       $$$$$$$$/ $$$$$$$/  
                                                                                                           
                                                                                                           
                                                                                                           

";

        public void Run()
        {
            //Setup - can add to class later
            NewLockBox.CodeMaster = new Dictionary<int, string>
            {
                {0,"H"},{1,"E"},{2,"L"},{3,"L"},{ 4,"O"}  // code for getting out of the lockbox
            };

            NewLockBox.GetCode();

            Room1 officeRoom = new Room1();
            Room2 diningRoom = new Room2();

            officeRoom.RoomObjects.Add(new RoomObject(ObjectType.Desk, NewLockBox.CodeMaster[2] + " - 2"));
            NewLockBox.CodeMaster.Remove(2);
            officeRoom.RoomObjects.Add(new RoomObject(ObjectType.Dresser, NewLockBox.CodeMaster[4] + " - 4"));
            NewLockBox.CodeMaster.Remove(4);
            officeRoom.RoomObjects.Add(new RoomObject(ObjectType.Window, NewLockBox.CodeMaster[3] + " - 3"));
            NewLockBox.CodeMaster.Remove(3);

            diningRoom.RoomObjects.Add(new RoomObject(ObjectType.Dinette, NewLockBox.CodeMaster[1] + " - 1"));
            NewLockBox.CodeMaster.Remove(1);
            diningRoom.RoomObjects.Add(new RoomObject(ObjectType.Trashcan, NewLockBox.CodeMaster[0] + " - 0"));
            NewLockBox.CodeMaster.Remove(0);

            diningRoom.LockBox = NewLockBox;

            //Display                                                                                   
            

            Console.WriteLine(title);

            Console.WriteLine("\n\nWelcome to the Escape Room.\n" +
                "Hope you make it out! ahaha.\n" +
                "If you don't have a good memory, you should probably get a pen and paper... I won't be remembering for you.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            bool inRoomOne = true;
            bool goToLockBox = false;
            int counter = 0;

            while (!_foundExit)
            {
                
                Console.Clear();

                if (inRoomOne)
                { Console.WriteLine("You have now entered Room 1. Choose an object: desk, dresser, or window:");
                    string objects = Console.ReadLine().ToLower();
                    if (objects.Contains("desk"))
                    {
                        officeRoom.RoomObjects[0].Open();
                        readKey();
                    }
                    else if (objects.Contains("dresser"))
                    {
                        officeRoom.RoomObjects[1].Open();
                        readKey();
                    }
                    else if (objects.Contains("window"))
                    {
                        officeRoom.RoomObjects[2].Open();
                        readKey();
                    }
                    else
                    {
                        if (counter >= 5 && counter <10)
                        {
                            Console.Clear();
                            Console.WriteLine("You must type either: desk, dresser, or window");
                            readKey();
                        }
                        else if (counter >= 10 && counter < 18)
                        {
                            Console.Clear();
                            Console.WriteLine("You really dont get the concept of this game. Are you using your brain?");
                            readKey();
                        }
                        else if(counter >= 18)
                        {
                            Console.Clear();
                            Console.WriteLine("You have brain damage. GO TO A DOCTOR! \n" +
                                "GAME WILL END NOW!!!!!!");
                            Thread.Sleep(2000);

                            Console.Clear();
                            Console.WriteLine(gameOver);
                            readKey();
                            _foundExit = true;
                        }
                       counter++;
                    }
                    inRoomOne = false;
                    foreach(RoomObject room in officeRoom.RoomObjects)
                    {
                        if (room.hasOpened == false)
                        {
                            inRoomOne = true;
                            break;
                        }
                    }
                    
                    if (!inRoomOne)
                    {
                        Console.Clear();
                        Console.WriteLine("You have successfully made it out of Room 1.\n" +
                            "Good job! On to room 2.");
                        readKey();
                      inRoomOne = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have now entered Room 2. Choose an object: trashcan or dinette.");
                    string input = Console.ReadLine().ToLower();
                    if (input.Contains("dinette"))
                    {
                        diningRoom.RoomObjects[0].Open();
                        readKey();
                    }
                    else if (input.Contains("trashcan"))
                    {
                        diningRoom.RoomObjects[1].Open();
                        readKey();
                    }
                    goToLockBox = true;
                    foreach(RoomObject rooms in diningRoom.RoomObjects)
                    {
                        if(rooms.hasOpened == false)
                        {
                            goToLockBox = false;
                            break;
                        }                     
                    }
                }

                if (goToLockBox == true)
                    counter = 0;

                while(goToLockBox) //stays in a while loop until the correct code is entered
                {
                    Console.Clear();
                    Console.WriteLine(enterCode);
                    Console.WriteLine("\n====================================================================================================\n");
                         _foundExit = diningRoom.LockBox.Open();
                    if (_foundExit)
                    {
                        Console.Clear();
                        Console.WriteLine(youEscaped);
                        Thread.Sleep(3000);
                        goToLockBox = false;
                    }
                    else if (counter == 10)
                    {
                        Console.WriteLine("You should just give up. You really are bad at remembering or just suck at this game\n" +
                            "Maybe you should go back to kindergarten.\n\n");
                        Thread.Sleep(2000);
                        readKey();
                    }
                    else if(counter == 25)
                    {
                        Console.WriteLine("Just give up! you SUUUUUUCK! The GAME will exit now.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Console.WriteLine(gameOver);
                        _foundExit = true;
                        goToLockBox = false;
                    }
                    counter++;
                }
            }
        }

        //Method for pausing and reading key
        public void readKey()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}
