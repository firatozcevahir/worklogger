using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkLogger.Models
{
    public partial class WorkingLog: IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Giriş Saati")]
        public string EntranceTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Çıkış Saati")]
        public string ExitTime { get; set; }

        [Required]
        [DataType(DataType.Date)]

        [Display(Name = "Tarih")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Parse(ExitTime) < DateTime.Parse(EntranceTime))
            {
                yield return
                  new ValidationResult(errorMessage: "Çıkış saati giriş saatinden daha büyük olmalıdır",
                                       memberNames: new[] { "ExitTime" });
            }
        }
    }
}
