using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Hey, you fool! You need to enter a last name!")]
        public string LastName { get; set; }
        public byte Age { get; set; }
        [Phone]
        [Required(ErrorMessage ="Phone numbers need to be in (###) ### - #### form.")]
        public string Phone { get; set; }
        public bool CreeperStalker { get; set; }
        //Build foreign key relationship
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}
