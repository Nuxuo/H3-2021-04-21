﻿using SQLite;
using System;

namespace H3_App.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
        public DateTime Date { get; set; }
    }
}
