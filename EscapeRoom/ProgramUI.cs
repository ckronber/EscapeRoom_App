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
        private bool _foundExit = false;
        //string _ExitCode = "";
        Dictionary<string, int> solutionToSafe = new Dictionary<string, int> { };
        LockBoxStuff NewLockBox = new LockBoxStuff();

     

    public void Run()
        {
            //Setup - can add to class later
            NewLockBox.CodeMaster = new Dictionary<int, string>
            {
                {0,"H"},{1,"E"},{2,"L"},{3,"L"},{ 4,"O"}
            };

            NewLockBox.GetCode();

            Room1 officeRoom = new Room1();
            RoomObject desk = new RoomObject(ObjectType.Desk,NewLockBox.CodeMaster[2]+ "-2");
            Room2 diningRoom = new Room2();

            officeRoom.RoomObjects.Add(desk);
            NewLockBox.CodeMaster.Remove(2);
            officeRoom.RoomObjects.Add(new RoomObject(ObjectType.Dresser, NewLockBox.CodeMaster[4] + "- 4"));
            NewLockBox.CodeMaster.Remove(4);
            officeRoom.RoomObjects.Add(new RoomObject(ObjectType.Window, NewLockBox.CodeMaster[3] + "- 3"));
            NewLockBox.CodeMaster.Remove(3);

            diningRoom.RoomObjects.Add(new RoomObject(ObjectType.Dinette, NewLockBox.CodeMaster[1] + "- 1"));
            NewLockBox.CodeMaster.Remove(1);
            diningRoom.RoomObjects.Add(new RoomObject(ObjectType.Trashcan, NewLockBox.CodeMaster[0] + "- 0"));
            NewLockBox.CodeMaster.Remove(0);

            diningRoom.LockBox = NewLockBox;

            //Display
            Console.WriteLine("Welcome to the Escape Room.\n" +
                "Hope you make it out! ahaha.\n" +
                "If you don't have a good memory, you should probably get a pen and paper... I won't be remembering for you.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            bool inRoomOne = true;
            int val = 1;
            bool goToLockBox = true;

            while (!_foundExit)
            {
                
                Console.Clear();

                if (inRoomOne)
                { Console.WriteLine($"You have now entered Room 1. Choose an object: desk, dresser, or window.");
                    string objects = Console.ReadLine().ToLower();
                    if (objects == "desk")
                    {
                        Console.WriteLine("You just selected desk.");
                        officeRoom.RoomObjects[0].Open();
                    }
                    else if (objects == "dresser")
                    {
                        Console.WriteLine("You just selected dresser.");
                        officeRoom.RoomObjects[1].Open();
                    }
                    else if (objects == "window")
                    {
                        Console.WriteLine("You just selected window.");
                        officeRoom.RoomObjects[2].Open();
                    }
                    foreach(RoomObject room in officeRoom.RoomObjects)
                    {
                        if (room.hasOpened == false)
                            val *= 0;
                        else
                            val += 1;
                    }
                    if (val > 0)
                    {
                        Console.WriteLine("You have successfully made it out of Room 1.\n" +
                            "Good job! On to room 2.");
                      inRoomOne = false;
                    }
                }
                else
                {
                    Console.WriteLine("You have now entered Room 2. Choose an object: trashcan or dinette.");
                    string input = Console.ReadLine().ToLower();
                    if (input == "trashcan")
                    {
                        Console.WriteLine("You have just selected trashcan.");
                        diningRoom.RoomObjects[0].Open();
                    }
                    else if (input == "dinette")
                    {
                        Console.WriteLine("You have just selected dinette.");
                        diningRoom.RoomObjects[0].Open();
                    }
                    foreach(RoomObject room in diningRoom.RoomObjects)
                    {
                        if  (room.hasOpened == false)
                        {
                            val *= 0;
                        }
                        else
                            val += 1;
                    }
                    if (val > 0)
                        goToLockBox = false;
                }

                if (!goToLockBox)
                {
                    Console.WriteLine("You are at the Lockbox \n" +
                        "==================================================");

                    //saved for the end
                    bool _foundExit = diningRoom.LockBox.Open();
                    if (_foundExit)
                        Console.WriteLine("\n\nCongrats! You got out");
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
