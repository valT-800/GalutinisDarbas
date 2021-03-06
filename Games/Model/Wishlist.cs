using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Model
{
    /// <summary>
    /// Defines Database table Wishlist
    /// </summary>
    /// <param name="Id"> Holds id number </param>>
    /// <param name="GameId"> Links this table with one of chosen games by id</param>>
    /// <param name="Date"> When the game was added to watchlist </param>>
    public partial class Wishlist
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("GameId")]
        public int? GameId { get; set; }
        [Column("date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty("Wishlist")]
        public virtual Game Game { get; set; }
    }
}
