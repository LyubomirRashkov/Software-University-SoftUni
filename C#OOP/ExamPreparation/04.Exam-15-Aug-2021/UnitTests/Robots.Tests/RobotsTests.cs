namespace Robots.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private const int Capacity = 2;

        [Test]
        public void RobotConstructor_SetsProperties()
        {
            string robotName = "Robot";
            int maximumBattery = 100;

            Robot robot = new Robot(robotName, maximumBattery);

            Assert.That(robot.Name, Is.EqualTo(robotName));
            Assert.That(robot.MaximumBattery, Is.EqualTo(maximumBattery));
            Assert.That(robot.Battery, Is.EqualTo(maximumBattery));
        }

        [Test]
        public void RobotManagerConstructor_ThrowsException_WhenParameterCapacityIsLessThanZero()
        {
            int invalidCapacity = -10;

            Assert.That(() => new RobotManager(invalidCapacity), Throws.ArgumentException);
        }

        [Test]
        public void RobotManagerConstructor_SetsCapacityToTheGivenValue()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Assert.That(robotManager.Capacity, Is.EqualTo(Capacity));
        }

        [Test]
        public void RobotManagerConstructor_CreatesEmptyCollection()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_ThrowsException_WhenAddingARobotWithExistingName()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            string robotName = "Robot";

            Robot robot1 = new Robot(robotName, 100);

            robotManager.Add(robot1);

            Robot robot2 = new Robot(robotName, 150);

            Assert.That(() => robotManager.Add(robot2), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsReached()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot1 = new Robot("Robot1", 100);
            robotManager.Add(robot1);

            Robot robot2 = new Robot("Robot2", 120);
            robotManager.Add(robot2);

            Assert.That(() => robotManager.Add(new Robot("Robot3", 150)), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_WorksCorrectly_WhenParametersAreValid()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot1 = new Robot("Robot1", 100);
            robotManager.Add(robot1);
            
            Assert.That(robotManager.Count, Is.EqualTo(1));

            Robot robot2 = new Robot("Robot2", 120);
            robotManager.Add(robot2);

            Assert.That(robotManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_ThrowsException_WhenTryingToRemoveANonexistingRobot()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot = new Robot("Robot", 100);
            robotManager.Add(robot);

            Assert.That(() => robotManager.Remove("FakeRobot"), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_WorksCorrectly_WhenParameterIsValid()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot = new Robot("Robot", 100);
            robotManager.Add(robot);

            Assert.That(robotManager.Count, Is.EqualTo(1));

            robotManager.Remove("Robot");

            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Work_ThrowsException_WhenInvokingANonexistingRobot()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot = new Robot("Robot", 100);
            robotManager.Add(robot);

            Assert.That(() => robotManager.Work("FakeRobot", "somejob", 10), Throws.InvalidOperationException);
        }

        [Test]
        public void Work_ThrowsException_WhenInvokingARobotWithExhaustedBattery()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot = new Robot("Robot", 10);
            robotManager.Add(robot);

            Assert.That(() => robotManager.Work("Robot", "somejob", 100), Throws.InvalidOperationException);
        }

        [Test]
        public void Work_DecreasesRobotBattery_WhenRobotWorked()
        {
            int requiredBattery = 2;
            string robotName = "Robot";

            Robot robot = new Robot(robotName, 10);

            int expected = robot.Battery - requiredBattery;

            RobotManager robotManager = new RobotManager(Capacity);
            robotManager.Add(robot);

            robotManager.Work(robotName, "somejob", requiredBattery);

            int actual = robot.Battery;

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Charge_ThrowsException_WhenInvokingANonexistingRobot()
        {
            RobotManager robotManager = new RobotManager(Capacity);

            Robot robot = new Robot("Robot", 100);
            robotManager.Add(robot);

            Assert.That(() => robotManager.Charge("FakeRobot"), Throws.InvalidOperationException);
        }

        [Test]
        public void Charge_WorksCorrectly_WhenParametersAreValid()
        {
            string robotName = "Robot";
            int maximumBattery = 100;

            int requiredBattery = 25;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager robotManager = new RobotManager(Capacity);
            robotManager.Add(robot);

            robotManager.Work(robotName, "somejob", requiredBattery);

            robotManager.Charge(robotName);

            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }
    }
}
