namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;
        private const string DefaultTrainingHall = "WeightliftingGym";
        private const int AdditionalStamina = 10;

        private string trainingHall;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
            this.TrainingHall = DefaultTrainingHall;
        }

        public string TrainingHall 
        {
            get => this.trainingHall;
            private set
            {
                this.trainingHall = value;
            }
        }

        public override void Exercise()
        {
            this.Stamina += AdditionalStamina;
        }
    }
}
