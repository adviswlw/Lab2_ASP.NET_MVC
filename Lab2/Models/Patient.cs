using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Patient
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// номер медицинской карты
        /// </summary>
        [Required(ErrorMessage = "Поле 'Номер медицинской карты' обязательно для заполнения.")]
        [StringLength(9999, ErrorMessage = "Номер медицинской карты не должен превышать 9999 символов.")]
        public string MedicalCardNumber { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Фамилия не должна превышать 100 символов.")]
        public string Surname { get; set; }

        /// <summary>
        /// диагноз
        /// </summary>
        [Required(ErrorMessage = "Поле 'Диагноз' обязательно для заполнения.")]
        [StringLength(200, ErrorMessage = "Диагноз не должен превышать 200 символов.")]
        public string Diagnosis { get; set; }

        /// <summary>
        /// статус
        /// </summary>
        [Required(ErrorMessage = "Поле 'Статус' обязательно для заполнения.")]
        public string Status { get; set; }

       

        /// <summary>
        /// внешний ключ
        /// </summary>
        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }
    }
}
