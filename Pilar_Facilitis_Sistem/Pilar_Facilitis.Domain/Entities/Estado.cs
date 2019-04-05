﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Estado
    {
        public int EstadoId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public int PaisId { get; set; }

        public Pais Pais { get; set; }
    }
}
