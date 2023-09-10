﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Statement
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }

    }
}
