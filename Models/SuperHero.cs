﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeros.Models
{
    public class SuperHero
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }
        public string CatchPhrase { get; set; }
        public string AlterEgo { get; set; }
    }

}   
   

