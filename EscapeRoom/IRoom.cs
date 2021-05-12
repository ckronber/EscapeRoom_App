using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public interface IRoom
    {
        string RoomName { get; }
        //RoomObject Object();
        List<RoomObject> RoomObjects {get;}
    }

    public class Room1 : IRoom
    {
        public Room1() { }
        public Room1(List<RoomObject> objects)
        {
            this.RoomObjects = objects;
        }

        public string RoomName => "Office";
        public List<RoomObject> RoomObjects { get; set; }
    }

    public class Room2 : IRoom
    {
        public Room2() { }
        public Room2(List<RoomObject> objects, LockBoxStuff lockBox)
        {
            this.RoomObjects = objects;
            this.LockBox = lockBox;
        }
        public string RoomName => "Dining Room";
        public List<RoomObject> RoomObjects { get; set; }

        public LockBoxStuff LockBox { get; set; }
    }
}
