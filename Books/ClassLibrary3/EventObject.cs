using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class EventObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is Required")]
        [Display(Name = "Date")]
        public System.DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is Required")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Start Time is Required")]
        [Display(Name = "Start Time")]
        public System.TimeSpan StartTime { get; set; }

        [Display(Name = "Type")]
        public bool Type { get; set; }

        [Range(minimum: 0, maximum: 4, ErrorMessage = "Duration should be between 0-4 hrs")]
        public int? Duration { get; set; }

        public string Desciption { get; set; }
        public string Others { get; set; }
        public string Emails { get; set; }
        public string OwnerEmail { get; set; }
    }
}
