﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCRS.Domain
{

    public abstract class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
