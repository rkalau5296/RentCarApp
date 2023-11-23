using System.Text.Json;

namespace RentCarApp.Data.Entities.Extension
{
    public static class EntityExtension
    {
        public static T? Copy<T>(this T itemToCopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}