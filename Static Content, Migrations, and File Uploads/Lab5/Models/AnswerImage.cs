using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public enum Question
    {
        Earth,
        Computer
    }
    public class AnswerImage
    {

        public int AnswerImageId { get; set; }

        [Display(Name = "Question")]
        [Required()]
        public Question question { get; set; }
        [Display(Name = "File Name")]
        [Required()]
        public string FileName { get; set; }
        [Required()]
        public string Url { get; set; }

       
    }
}
