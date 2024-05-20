using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Hospital
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// название
        /// </summary>
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов.")]
        public string Name { get; set; }

        /// <summary>
        /// адрес
        /// </summary>
        [Required(ErrorMessage = "Поле 'Адрес' обязательно для заполнения.")]
        [StringLength(200, ErrorMessage = "Адрес не должен превышать 200 символов.")]
        public string Address { get; set; }

        /// <summary>
        /// специализации
        /// </summary>
        [Required(ErrorMessage = "Поле 'Специализации' обязательно для заполнения.")]
        public string Specializations { get; set; }

        /// <summary>
        /// главный врач
        /// </summary>
        [Required(ErrorMessage = "Поле 'Главный врач' обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Имя главного врача не должно превышать 100 символов.")]
        public string ChiefDoctor { get; set; }

        /// <summary>
        /// год основания
        /// </summary>
        [Required(ErrorMessage = "Поле 'Год основания' обязательно для заполнения.")]
        [Range(1800, int.MaxValue, ErrorMessage = "Год основания должен быть в диапазоне от 1800 до текущего года.")] 
        public int FoundationYear { get; set; }

        /// <summary>
        /// связь один ко многим
        /// </summary>
        public List<Patient> Patients { get; set; }
    }
}
