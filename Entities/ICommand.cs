using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot.Entities
{
    interface ICommand
    {
        public void TurnRight();
        public void TurnLeft();
        public void MoveForward();
    }
}
