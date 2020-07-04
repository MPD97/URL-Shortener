using System.Collections.Generic;

namespace Core.Entities
{
    public class Shortcut
    {
        public long ShortcutId { get; set; }
        public string Alias { get; set; }
        public long TimesRedirect { get; set; }
        
        public long? RedirectId { get; set; }
        public long? RedirectExtendedId { get; set; }

        public virtual Redirect Redirect { get; set; }
        public virtual RedirectExtended RedirectExtended { get; set; }
    }
}