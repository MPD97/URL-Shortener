using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Requests
{
    public class ShortcutCreateRequest
    {
        [Required]
        [MaxLength(1000)]
        [DataType(DataType.Url)]
        public string Url { get; set; }
    }
}