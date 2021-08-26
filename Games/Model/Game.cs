using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Model
{
    /// <summary>
    /// Defines Database table Movie
    /// </summary>
    /// <param name="Id"> Holds id number </param>>
    /// <param name="Name"> Name of a Movie </param>>
    /// <param name="Genre"> Genre of a movie </param>>
    /// <param name="Levels"> TOtal runtime of movie in minutes </param>>
    /// <param name="Date"> Date of creation of a movie </param>>
    public partial class Game
    {
        public Game()     
        {
            PlayedGames = new HashSet<PlayedGames>();
            Wishlist = new HashSet<Wishlist>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string Genre { get; set; }
        [Column(TypeName = "levels")]
        public int? Levels { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [InverseProperty("Game")]
        public virtual ICollection<Played> Played { get; set; }
        [InverseProperty("Game")]
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}