namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        private const string DefaultTrainingHall = "BoxingGym";
        private const int AdditionalStamina = 15;

        private string trainingHall;

        public Boxer(string fullName, string motivation, int numberOfMedals) 
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
