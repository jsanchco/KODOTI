namespace Service.Common.Mapping
{
    #region Using

    using System.Text.Json;

    #endregion

    public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
        }
    }
}
