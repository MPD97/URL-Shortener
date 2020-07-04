namespace Core.Entities
{
    public class Shortcut
    {
        public long ShortcutId { get; set; }
        public string Alias { get; set; }
        public string Redirect { get; set; }
    }
}