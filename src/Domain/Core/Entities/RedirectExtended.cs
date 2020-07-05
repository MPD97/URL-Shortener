namespace Core.Entities
{
    public class RedirectExtended
    {
        public long RedirectExtendedId { get; set; }
        public string Url { get; set; }

        public long ShortcutId { get; set; }
        public Shortcut Shortcut { get; set; }        
    }
}