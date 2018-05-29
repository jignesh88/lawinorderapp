using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LawInOrderApp.Application.ViewModels
{
    public class TimeSheetViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The hour worked is Required")]
        [MinLength(1)]
        [MaxLength(2)]
        [DisplayName("Hour Worked")]
        public int HourWorked { get; set; }


        [Required(ErrorMessage = "The Dateworked required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Date format is invalid")]
        [DisplayName("Date Worked")]
        public DateTime DateWorked { get; set; }
    }
}
