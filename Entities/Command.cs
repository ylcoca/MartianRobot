
namespace MartianRobot.Entities
{
    class Command : ICommand
    {
        private readonly Robot _robot;

        public Command(Robot robot)
        {
            _robot = robot;
        }

        public void MoveForward()
        {

            Scent tempScent = new(_robot.GetLocation(), _robot.GetOrientation());

            if (_robot.GetPlanet().HasMatchingScent(tempScent))
            {
                return;
            }
            else
            {
                var newPosition = _robot.GetLocation();

                switch (_robot.GetOrientation())
                {
                    case Orientation.N:
                        newPosition.Y++;
                        break;
                    case Orientation.E:
                        newPosition.X++;
                        break;
                    case Orientation.S:
                        newPosition.Y--;
                        break;
                    case Orientation.W:
                        newPosition.X--;
                        break;

                }

                _robot.SetLocation(newPosition);

                if (_robot.IsLost())
                {
                    _robot.SetScent(tempScent);
                }
            }

        }

        public void TurnLeft()
        {

            switch (_robot.GetOrientation())
            {
                case Orientation.N:
                    _robot.SetOrientation(Orientation.W);
                    break;
                case Orientation.E:
                    _robot.SetOrientation(Orientation.N);
                    break;
                case Orientation.S:
                    _robot.SetOrientation(Orientation.E);
                    break;
                case Orientation.W:
                    _robot.SetOrientation(Orientation.S);
                    break;
            }
        }

        public void TurnRight()
        {
            switch (_robot.GetOrientation())
            {
                case Orientation.N:
                    _robot.SetOrientation(Orientation.E);
                    break;
                case Orientation.E:
                    _robot.SetOrientation(Orientation.S);
                    break;
                case Orientation.S:
                    _robot.SetOrientation(Orientation.W);
                    break;
                case Orientation.W:
                    _robot.SetOrientation(Orientation.N);
                    break;
            }
        }
    }
}
