using System;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
	public class GhostsTask : 
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
		IMagic
	{
        //List<Cat> list = new List<Cat>();
        int hash = 0;
        byte[] content = new byte[] { 1, 2, 3 };
        private Cat cat;
        private Vector vector;
        private Robot robot;
        private Document doc;
        private Segment segment;

        public Cat Cat1 { get => cat; set => cat = value; }
        public Vector Vector { get => vector; set => vector = value; }
        public Robot Robot { get => robot; set => robot = value; }
        public Document Doc { get => doc; set => doc = value; }
        public Segment Segment1 { get => segment; set => segment = value; }

        public void DoMagic()
		{
            if (this.Cat1 != null) Cat1.Rename("Tim");
            if (this.Vector != null) Vector.Add(new Vector(3.0, 4));
            if (this.Robot != null) Robot.Move(4, 5.5);
            if (this.Doc != null) content[0] = 3;
            if (this.Segment1 != null) Cat1.Rename("Tim");
            GetHashCode();
        }

		// Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
		// придется воспользоваться так называемой явной реализацией интерфейса.
		// Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
		// На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

		Vector IFactory<Vector>.Create()
		{
			return new Vector(1.0, 2.0);
		}

		Segment IFactory<Segment>.Create()
		{
            Segment1 = new Segment(new Vector(1.0, 1.0), new Vector(2.0, 2.0));
            return Segment1;
        }

        Document IFactory<Document>.Create()
        {
            Doc = new Document("test", Encoding.ASCII, content);
            hash = Doc.GetHashCode();
            return Doc;
        }

        Cat IFactory<Cat>.Create()
        {            
            Cat1 = new Cat("Tom", "Britan", DateTime.Today);
            hash = Cat1.GetHashCode();
            return Cat1;
        }

        Robot IFactory<Robot>.Create()
        {
            Robot = new Robot("robot1");
            return Robot;
        }
    }
}