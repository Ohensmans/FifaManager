//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifaDAL.BackEnd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quarter
    {
        public System.Guid quartersId { get; set; }
        public System.DateTime dateDebut { get; set; }
        public System.DateTime dateFin { get; set; }
        public System.DateTime lastUpdate { get; set; }
        public System.Guid championnatId { get; set; }
    
        public virtual Championnat Championnat { get; set; }
    }
}
