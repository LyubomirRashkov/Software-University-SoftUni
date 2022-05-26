using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private const int MinLength = 3;
        private const int MinHorsepower = 900;
        private const int MaxHorsepower = 1050;
        private const double MinEngineDisplacement = 1.6;
        private const double MaxEngineDisplacement = 2.00;

        private string model;
        private int horsepower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                Validator.ThrowExceptionWhenParameterIsNullWhiteSpaceOrHasLengthLessThanMinLength(value, MinLength, string.Format(ExceptionMessages.InvalidF1CarModel, value));

                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horsepower;
            private set
            {
                Validator.ThrowExceptionWhenParameterIsLessThanMinValueOrIsGreaterThahMaxValue(value, MinHorsepower, MaxHorsepower, string.Format(ExceptionMessages.InvalidF1HorsePower, value));

                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDisplacement;
            private set
            {
                Validator.ThrowExceptionWhenParameterIsLessThanMinValueOrIsGreaterThahMaxValue(value, MinEngineDisplacement, MaxEngineDisplacement, string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));

                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return (this.EngineDisplacement / this.Horsepower * laps);
        }
    }
}
