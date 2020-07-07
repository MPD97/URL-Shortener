using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Requests
{
    public class ShortcutCreateRequest
    {
        [MaxLength(30)]
        public string Alias { get; set; }
        
        [Required]
        [MaxLength(1000)]
        [DataType(DataType.Url)]
        public string Url { get; set; }
    }
}