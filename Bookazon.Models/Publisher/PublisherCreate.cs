﻿using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Publisher
{
    public class PublisherCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

    }
}
