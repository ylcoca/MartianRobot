

using Entities;
using MartianRobot.Entities;
using System.Drawing;

namespace MartianRobot.Service
{
    public class ManageRobotService : IManageRobotService
    {
        Planet _mars;
        private readonly IFile _fileMgmt;

        public ManageRobotService(IFile file)
        {
            _mars = new Planet(new Point(50, 50));
            _fileMgmt = file;
        }

        private void CreatePlanet(Point planetEdge)
        {
            _mars = new Planet(planetEdge);
        }

        private Planet GetPlanet()
        {
            return _mars;
        }


        public void ReadSetUpFile()
        {
            int counter = 0;
            Dictionary<Robot, string> robotDict = new();
            Robot robot = new();
            int x = 0, y = 0;

            foreach (string line in GetFile())
            {
                Console.WriteLine(line);
                string[] letters = line.Split(' ');
                counter++;
                if (counter == 1)
                {
                    CreatePlanet(new Point(int.Parse(letters[0]), int.Parse(letters[1])));
                }
                else if (counter % 2 == 0 && counter > 1)
                {
                    x = int.Parse(letters[0]);
                    y = int.Parse(letters[1]);

                    robot = new Robot(GetPlanet(), new Point(x, y), SetOrientation(letters[2]));

                }
                else
                {
                    if (ValidCoordinates(x, y) && ValidateInstructions(line))
                        robotDict.Add(robot, line);
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            StartRobots(robotDict);
        }

        private IEnumerable<string> GetFile()
        {
            return _fileMgmt.GetFile();
        }

        private bool ValidateInstructions(string instructions)
        {
            if (instructions.Length <= 100)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Instruction greater than 100 steps");
            }

        }

        private bool ValidCoordinates(int x, int y)
        {
            if (x <= 50 && y <= 50 && x>= 0 && y >= 0)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Out of bounds coordinates");
            }
        }

        private void StartRobots(Dictionary<Robot, string> robotDict)
        {
            foreach (var robot in robotDict)
            {
                PassInstructions(robot.Key, robot.Value);
            }

            GetRobotsMovement();
        }

        private void PassInstructions(Robot robot, string instructions)
        {
            robot.InstructionString(instructions);
        }

        public List<Robot> GetRobotsMovement()
        {
            return GetPlanet().GetRobots();
        }

        private Orientation SetOrientation(string stringOrientation)
        {
            return (Orientation)Enum.Parse(typeof(Orientation), stringOrientation);
        }
    }
}
