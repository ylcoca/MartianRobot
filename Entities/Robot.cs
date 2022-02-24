
using System.ComponentModel;
using System.Drawing;

namespace MartianRobot.Entities
{
    public class Robot
    {
        private readonly Planet _planet;
        private Point _location;
        private Orientation _orientation;
        private bool isLost = false;
        private Scent _scent = new Scent();


        public Robot()
        {

        }

        public Robot(Planet planet, Point startingLocation, Orientation startingOrientation)
        {
            _planet = planet;
            _location = startingLocation;
            _orientation = startingOrientation;

            planet.AddRobot(this);
        }

        public void InstructionString(string instructions)
        {
            Command command = new(this);
            for (int i = 0; i < instructions.Length; i++)
            {

                if (isLost)
                {
                    break;
                }

                switch (instructions.ElementAt(i))
                {
                    case 'R':
                        command.TurnRight();
                        break;
                    case 'L':
                        command.TurnLeft();
                        break;
                    case 'F':
                        command.MoveForward();
                        break;
                    default:
                        throw new InvalidEnumArgumentException("Value did not match approved movements");
                }
            }
        }


        private void AddScent(Scent scent)
        {
            _planet.AddScent(scent);
        }

        public bool IsLost()
        {
            if (_location.X > _planet.GetUpperRightPoint().X || _location.Y > _planet.GetUpperRightPoint().Y ||
                    _location.X < 0 || _location.Y < 0)
            {
                isLost = true;
            }
            return isLost;
        }

        public Planet GetPlanet()
        {
            return _planet;
        }

        public Point GetLocation()
        {
            return _location;
        }

        public void SetLocation(Point location)
        {
            _location = location;
        }

        public Orientation GetOrientation()
        {
            return _orientation;
        }

        public void SetOrientation(Orientation orientation)
        {
            _orientation = orientation;
        }

        public void SetScent(Scent scent)
        {
            _scent = scent;
            AddScent(scent);
        }

        public string ShowPosition()
        {
            if (isLost)
            {
                return _scent._point.X + " " + _scent._point.Y + " " + _scent._orientation.ToString() + " LOST";
            }
            else return _location.X + " " + _location.Y + " " + _orientation.ToString();
        }
    }
}
