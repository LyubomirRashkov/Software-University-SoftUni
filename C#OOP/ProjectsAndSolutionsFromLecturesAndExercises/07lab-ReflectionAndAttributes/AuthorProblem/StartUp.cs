namespace AuthorProblem
{
    [Author("SoftUni")]
    [Author("Lyubomir")]
    public class StartUp
    {
        [Author("Lyubomir Rashkov")]
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
