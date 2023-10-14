using System.ComponentModel.DataAnnotations;

namespace Web_API._Web_приложение__Музыкальный_портал_.Models
{
    public class Singer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле имя исполнителя должно быть установлено.")]
        [Display(Name = "Имя исполнителя")]
        public string? SingerName { get; set; }

        ICollection<Music> Musics { get; set; }
    }
}
