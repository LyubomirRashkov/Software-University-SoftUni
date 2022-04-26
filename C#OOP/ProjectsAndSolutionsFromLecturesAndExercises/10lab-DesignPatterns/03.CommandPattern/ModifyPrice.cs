namespace _03.CommandPattern
{
    public class ModifyPrice
    {
        private ICommand command;

        public ModifyPrice()
        {
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke() 
        {
            this.command.ExecuteAction();
        }
    }
}
