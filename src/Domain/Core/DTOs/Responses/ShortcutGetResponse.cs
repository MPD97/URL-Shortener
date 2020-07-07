namespace Core.DTOs.Responses
{
    public class ShortcutGetResponse
    {
        public long ShortcutId { get; set; }

        public string Alias { get; set; }
        
        public long TimesRedirect { get; set; }
        
        public string Url { get; set; }
    }
}