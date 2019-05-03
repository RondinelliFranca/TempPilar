using System;

namespace Pilar_Facilitis.Domain.ViewModel
{
    public class EquipamentoViewModel
    {
        public Guid Id { get; set; }

        public string Desc_Equip { get; set; }

        public float Capacidade { get; set; }

        public string Fabricante { get; set; }

        public string NumDeSerie { get; set; }
    }
}