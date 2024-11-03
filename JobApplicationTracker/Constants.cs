namespace JobApplicationTracker
{
    public static class Constants
    {
        public const string DatabaseFilename = "JobApplicationTracking.db3";

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
