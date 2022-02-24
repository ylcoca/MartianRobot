
using MartianRobot.Service;

namespace MartianRobot
{
    public class RobotMovement
    {
        public IManageRobotService _manageRobotService { get; }

        public RobotMovement(IManageRobotService manageRobotService)
        {
            _manageRobotService = manageRobotService;
        }

        public void ReadFile()
        {
            try
            {
                Console.WriteLine("Reading Instructions:");
                Console.WriteLine(" ");
                _manageRobotService.ReadSetUpFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void GetRobotsMovement()
        {
            try
            {
                Console.WriteLine("Robot's Movements");
                foreach (var robot in _manageRobotService.GetRobotsMovement())
                {
                    Console.WriteLine(robot.ShowPosition());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
