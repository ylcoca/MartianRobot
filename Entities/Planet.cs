using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot.Entities
{
    public class Planet
    {
        private Point UpperRightPoint { get; set; }
        private readonly List<Scent> scents = new();
        private readonly List<Robot> robots = new();

        public Planet(Point upperRightPoint)
        {
            UpperRightPoint = upperRightPoint;
        }
        public void AddRobot(Robot robot)
        {
            robots.Add(robot);
        }

        public List<Robot> GetRobots()
        {
            return robots;
        }

        public void AddScent(Scent scent)
        {
            scents.Add(scent);
        }

        private List<Scent> GetScents()
        {
            return scents;
        }

        public Point GetUpperRightPoint()
        {
            return UpperRightPoint;
        }

        public bool HasMatchingScent(Scent scent)
        {            
            if(GetScents().Any(x => x.PointExist(scent)))
            {
                return true;
            }
            return false;
        }

    }
}
