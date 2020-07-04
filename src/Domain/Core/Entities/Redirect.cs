namespace Core.Entities
{
    public class Redirect
    {
        public long RedirectId { get; set; }
        public string Url { get; set; }
        
        public long ShortcutId { get; set; }
        public Shortcut Shortcut { get; set; }    
    }
}