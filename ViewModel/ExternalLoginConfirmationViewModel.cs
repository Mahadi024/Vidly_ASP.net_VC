﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.ViewModel
{
    public class ExternalLoginConfirmationViewModel
    {
        
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [Display(Name = "Driving License")]
            public string DrivingLicense { get; set; }

            [Required]
            [Display(Name = "Phone Number")]
            public string Phone { get; set; }
        
    }
}