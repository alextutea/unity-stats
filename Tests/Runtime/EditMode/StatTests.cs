using NUnit.Framework;

namespace Stats
{
    public class StatTests
    {
        private static Stat NewTestStat(int min, int max)
        {
            var s = new Stat
            {
                MaxLimit = max,
                MinLimit = min
            };
            s.SetToMax();
            return s;
        }
        
        [Test]
        public void TestNewStat()
        {
            var health = NewTestStat(0, 100);
            Assert.AreEqual(100, health.Value);
        }
        
        [Test]
        public void TestDecreaseStat()
        {
            var health = NewTestStat(0, 100);
            
            health.Value -= 10;
            Assert.AreEqual(90, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.Value -= -20;
            Assert.AreEqual(100, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.Value -= 90;
            Assert.AreEqual(10, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.Value -= 30;
            Assert.AreEqual(0, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
        }
        
        [Test]
        public void TestIncreaseStat()
        {
            var health = NewTestStat(0, 100);
            health.SetToMin();
            
            health.Value += 10;
            Assert.AreEqual(10, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.Value += -20;
            Assert.AreEqual(0, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.Value += 90;
            Assert.AreEqual(90, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.Value += 30;
            Assert.AreEqual(100, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
        }
        
        [Test]
        public void TestRemoveMaxLimit()
        {
            var health = NewTestStat(0, 100);
            
            health.Value += 10;
            Assert.AreEqual(100, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.RemoveMinLimit();

            health.Value += 10;
            Assert.AreEqual(100, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.RemoveMaxLimit();
            
            health.Value += 10;
            Assert.AreEqual(110, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(0, health.MaxLimit);
        }
        
        [Test]
        public void TestRemoveMinLimit()
        {
            var health = NewTestStat(0, 100);
            health.SetToMin();

            health.Value -= 10;
            Assert.AreEqual(0, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.RemoveMaxLimit();

            health.Value -= 10;
            Assert.AreEqual(0, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(0, health.MaxLimit);
            
            health.RemoveMinLimit();
            
            health.Value -= 10;
            Assert.AreEqual(-10, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(0, health.MaxLimit);
        }
        
        [Test]
        public void TestChangeLimit()
        {
            var health = NewTestStat(0, 100);
            
            health.Value += 10;
            Assert.AreEqual(100, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);

            health.MaxLimit = 75;
            Assert.AreEqual(75, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(75, health.MaxLimit);

            health.MaxLimit = 100;
            Assert.AreEqual(75, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);

            health.MinLimit = 85;
            Assert.AreEqual(85, health.Value);
            Assert.AreEqual(85, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
            
            health.MinLimit = 0;
            Assert.AreEqual(85, health.Value);
            Assert.AreEqual(0, health.MinLimit);
            Assert.AreEqual(100, health.MaxLimit);
        }
    }
}

