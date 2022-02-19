﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MySecondBrain.Infrastructure.DB
{
    public partial class NoteTagRel
    {
        public int NoteId { get; set; }
        public int TagId { get; set; }

        public virtual Note Note { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
