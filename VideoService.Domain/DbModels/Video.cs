using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoService.Domain.DbModels;

public class Video
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ObjectRootId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new List<string>();
    public List<string> Thumbnails { get; set; } = new List<string>();
    public string DefaultThumbnail { get; set; } = null!;
    public DateTime UploadDate { get; set; }
    public string OrigialVideo { get; set; }
}
