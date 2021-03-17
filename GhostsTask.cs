using System;
using System.Text;

namespace hashes
{
	public class GhostsTask : 
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
		IMagic
	{
        byte[] content = new byte[] { 1, 2, 3 };
        private Cat cat = new Cat("Tom", "Britan", DateTime.Today);
        private Vector vector = new Vector(1.0, 2.0);
        private Robot robot;
        private Document doc;
        private Segment segment;

        public Cat Cat1 { get => cat; set => cat = value; }
        public Vector Vector { get => vector; set => vector = value; }
        public Robot Robot1 { get => robot; set => robot = value; }
        public Document Doc { get => doc; set => doc = value; }
        public Segment Segment1 { get => segment; set => segment = value; }

        public void DoMagic()
		{
            if (this.Cat1 != null) Cat1.Rename("Tim");
            if (this.Vector != null) Vector.Add(new Vector(3.0, 4));
            if (this.Robot1 != null) Robot.BatteryCapacity = 70;
            if (this.Doc != null) content[0] = 3;
            if (this.Segment1 != null) Cat1.Rename("Tim");
        }

		Vector IFactory<Vector>.Create() { return Vector; }

		Segment IFactory<Segment>.Create()
		{
            Segment1 = new Segment(Vector, Vector);
            return Segment1;
        }

        Document IFactory<Document>.Create()
        {
            Doc = new Document("test", Encoding.ASCII, content);
            return Doc;
        }

        Cat IFactory<Cat>.Create() { return Cat1; }

        Robot IFactory<Robot>.Create()
        {
            Robot1 = new Robot("robot1");
            return Robot1;
        }
    }
}