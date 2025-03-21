namespace CheckListBuild_BE.Configs
{
    public class CheckListConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string UsersCollection { get; set; } = string.Empty;
        public string CheckListCollection { get; set; } = string.Empty;
        public string CheckListItemCollection { get; set; } = string.Empty;
        public string DepartmentsCollection { get; set; } = string.Empty;
        public string JobTitlesCollection { get; set; } = string.Empty;
        public string PermissionsCollection { get; set; } = string.Empty;
        public string PermissionDetailsCollection { get; set; } = string.Empty;
        public string CountriesCollection { get; set; } = string.Empty;
    }

}
