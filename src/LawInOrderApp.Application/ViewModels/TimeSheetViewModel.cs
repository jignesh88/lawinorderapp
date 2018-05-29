using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LawInOrderApp.Application.ViewModels
{
    public class TimeSheetViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public int HourWorked { get; set; }


        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime DateWorked { get; set; }
    }
}
