using ObjRenderer.Tuples;

namespace ObjRenderer.Light
{
    public class PointLight
    {
        public Point Position { get; }
        public PointLight(Point position)
        {
            Position = position;
        }
    }
}