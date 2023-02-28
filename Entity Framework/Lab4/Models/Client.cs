using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(50)]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }


        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }

        }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}