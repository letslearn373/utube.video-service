namespace VideoService.Infrastructure.Settings;

public class MongoDbSetting
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string VideoDbName { get; set; } = string.Empty;
}
