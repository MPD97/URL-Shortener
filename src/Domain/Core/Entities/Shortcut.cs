﻿namespace Core.Entities
{
    public class Shortcut
    {
        public long ShortcutId { get; set; }
        public string Alias { get; set; }
        
        public long RedirectId { get; set; }
        public long RedirectExtendedId { get; set; }

    }
}