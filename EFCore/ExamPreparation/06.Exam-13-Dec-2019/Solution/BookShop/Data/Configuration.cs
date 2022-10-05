namespace BookShop.Data
{
    public static class Configuration
    {
        //public static string ConnectionString = @"Server=.;Database=BookShop;Trusted_Connection=True";
        
        public static string ConnectionString = "Server = (local)\\SQLEXPRESS; Database = BookShop; Integrated Security = True; Encrypt = False";
    }
}