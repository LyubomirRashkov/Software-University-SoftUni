namespace Exam.DeliveriesManager
{
    public class Package
    {
        public Package(string id, string receiver, string address, string phone, double weight)
        {
            this.Id = id;
            this.Receiver = receiver;
            this.Address = address;
            this.Phone = phone;
            this.Weight = weight;
        }

        public string Id { get; set; }

        public string Receiver { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public double Weight { get; set; }

        public Deliverer Deliverer { get; set; }
    }
}
