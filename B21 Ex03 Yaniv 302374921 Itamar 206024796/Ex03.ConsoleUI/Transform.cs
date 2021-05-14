namespace Ex03.ConsoleUI
{
    public class Transform
    {
        public Point Position { get; set; }
        public int Height { get; set; }

        public Transform()
        {
            Position = new Point(0, 0);
        }

        public Transform(int i_Height) : this()
        {
            Height = i_Height;
        }
    }
}
