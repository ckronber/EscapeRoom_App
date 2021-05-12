using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public enum ObjectType { Desk, Dresser, Dinette, Lockbox, Window,Trashcan}

    public class RoomObject
    {
        public RoomObject() { }

        public RoomObject(ObjectType type,string ObjCode)
        {
            this.TypeofObject = type;
            this.objCode = ObjCode;
        }

        public ObjectType TypeofObject { get; set; }

        public bool hasOpened { get; private set; }

        public string objCode { get; private set; }

        public void Open()
        {
            if (hasOpened == true)
                Console.WriteLine("You have already been here. Look Somewhere else =)");
            else
            {
                hasOpened = true;
                Console.WriteLine($"You opened {TypeofObject} and has a Code {objCode}");
            }
        }
    }

    public class LockBoxStuff
    {
        //public LockBoxStuff() { }

        public Dictionary<int, string> CodeMaster { get; set; }
      
        public string userEnteredText { get; set; }
        public string entryText { get; private set; }

        public bool hasOpened { get; private set; } = false;

        public bool Open()
        {
            Console.WriteLine("Enter the secret code: ");
            userEnteredText = Console.ReadLine().ToUpper();

            if (userEnteredText == entryText)
            {
                Console.WriteLine("Congratulations! You got the key to the Exit");
                hasOpened = true;
                return hasOpened;
            }
            else
            {
                Console.WriteLine("You Failed! Try again");
                return hasOpened;
            }
        }

        public void GetCode()
        { 
            for (int i=0; i < CodeMaster.Count; i++)
                entryText += CodeMaster[i];
        }
        
    }

}
