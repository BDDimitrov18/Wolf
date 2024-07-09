using DTOS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateDocumentOfOwnershipDTO
    {
        [Required]
        public string TypeOfDocument { get; set; }
        [Required]
        [Number(ErrorMessage = "Number is invalid")]
        public string NumberOfDocument { get; set; }
        [Required]
        public string Issuer { get; set; }
        [Required]
        public int TOM { get; set; }
        [Required]
        [Number(ErrorMessage = "Number is invalid")]
        public string register { get; set; }
        [Required]
        [Number(ErrorMessage = "Number is invalid")]
        public string DocCase { get; set; }

        public string TypeOfOwnership { get; set; }

        [Required(ErrorMessage = "Required Date of Issuing")]
        public DateTime DateOfIssuing { get; set; }
        [Required(ErrorMessage = "Required Date of registering")]
        public DateTime DateOfRegistering { get; set; }
    }
}
