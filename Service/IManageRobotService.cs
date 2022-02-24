
using MartianRobot.Entities;
using System.Drawing;

namespace MartianRobot.Service
{
    public interface IManageRobotService
    {
        public void ReadSetUpFile();
        public List<Robot> GetRobotsMovement();
    }
}
