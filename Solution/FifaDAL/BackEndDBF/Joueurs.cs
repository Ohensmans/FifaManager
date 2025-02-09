//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifaDAL.BackEndDBF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Joueurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Joueurs()
        {
            this.CartonsJaunesHistory = new HashSet<CartonsJaunesHistory>();
            this.CartonsRougesHistory = new HashSet<CartonsRougesHistory>();
            this.GoalsHistory = new HashSet<GoalsHistory>();
            this.JoueursParticipationHistory = new HashSet<JoueursParticipationHistory>();
            this.TransfertsHistory = new HashSet<TransfertsHistory>();
        }
    
        public System.Guid joueurId { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public System.DateTime lastUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsJaunesHistory> CartonsJaunesHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsRougesHistory> CartonsRougesHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsHistory> GoalsHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoueursParticipationHistory> JoueursParticipationHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransfertsHistory> TransfertsHistory { get; set; }
    }
}
