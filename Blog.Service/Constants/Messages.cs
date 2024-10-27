
namespace Blog.Service.Constants;

public static class Messages
{
    public const string PostAddedMessage = "Post Eklendi";
    public const string PostUpdatedMessage = "Post Güncellendi";
    public const string PostDeleteMessage = "Post Silindi";

    public static string PostIsNotPresentMessage(Guid id)
    {
        return $"ilgili id ye göre post bulunamadı : {id}";


    }
}
