namespace _02.FacadePattern
{
    public class CarBuilderFacade
    {
        public CarBuilderFacade()
        {
            this.Car = new Car();
        }

        protected Car Car { get; set; }

        public Car Build() => this.Car;

        public CarInfoBuilder CarInfo => new CarInfoBuilder(this.Car);

        public CarAddressBuilder CarAddressBuilder => new CarAddressBuilder(this.Car);
    }
}
