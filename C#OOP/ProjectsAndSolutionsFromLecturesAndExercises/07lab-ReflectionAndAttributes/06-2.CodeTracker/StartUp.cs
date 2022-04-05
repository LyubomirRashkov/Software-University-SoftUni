namespace AuthorProblem
{
    [Author("SoftUni")]
    [Author("Lyubomir")]
    public class StartUp
    {
        [Author("Lyubomir")]
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
