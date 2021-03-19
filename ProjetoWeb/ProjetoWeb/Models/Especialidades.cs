﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class Especialidades : BaseModel
    {
        //Informações Basicas -------------------------
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string NomeDaEspecialidade { get; set; }
        //Informações Basicas -------------------------
    }
}
