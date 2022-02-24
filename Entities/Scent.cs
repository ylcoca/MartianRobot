
using System.Drawing;

namespace MartianRobot.Entities
{
    public  class Scent
    {
        public Point _point { get; set; }
        public Orientation _orientation { get; set; }

        public Scent()
        {

        }

        public Scent(Point point, Orientation orientation)
        {
           _point = point;
           _orientation = orientation; 
        }

        public bool PointExist(Scent scent)
        {
            return _point.Equals(scent._point) && _orientation.Equals(scent._orientation);
        }


    }
}
