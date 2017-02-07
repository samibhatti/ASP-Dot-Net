﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconMDB.Models
{
    public class Movie
    {
        private bool flag;
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public int AgeLimit { get; set; }
        public int MetaScore { get; set; }
       // public bool IsSorted { get; set; }
        //public bool Flag { get { return false; } set {flag = value; } }
    }
}