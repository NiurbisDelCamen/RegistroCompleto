using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Registro.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public int PersonaId { get; set; }
        public decimal Deposito { get; set; }
        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            Comentarios = string.Empty;
            Monto = 0;
            Balance = 0;
            PersonaId = 0;
            Deposito = 0;
        }
    } 
}

