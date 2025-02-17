﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser() : base() { }

    }
}
