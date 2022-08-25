namespace BookShop.Data
{
    internal class Configuration
    {
        internal static string ConnectionString 
            => "Server = (local)\\SQLEXPRESS; Database = BookShop; Integrated Security = True; Encrypt = False";
    }
}
