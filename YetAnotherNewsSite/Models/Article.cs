﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace YetAnotherNewsSite.Models
{
    public class Article
    {
        public string Headline { get; set; }
        public string TextField { get; set; }
        public string  Picture { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public Comment Comment { get; set; }



    }
}