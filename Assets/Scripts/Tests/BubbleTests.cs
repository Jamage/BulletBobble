using NUnit.Framework;

[TestFixture]
    public class BubbleTests
    {
        [Test]
        public void GetRandomEnum_returns_a_random_enum_value()
        {
            Bubble bubble = new Bubble();
            Bubble.BubbleColor color = bubble.GetRandomEnum<Bubble.BubbleColor>();
            bool returnedColor = false;

            switch(color)
            {
                case Bubble.BubbleColor.Black:
                case Bubble.BubbleColor.Blue:
                case Bubble.BubbleColor.Green:
                case Bubble.BubbleColor.Red:
                case Bubble.BubbleColor.White:
                    returnedColor = true;
                    break;
                default:
                    returnedColor = false;
                    break;
            }

            Assert.That(returnedColor == true);
        }
    }

