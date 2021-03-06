using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Model
{
    /// <summary>
    /// Defines Database table Played
    /// </summary>
    /// <param name="Id"> Holds id number </param>>
    /// <param name="GameId"> Links this table with one of chosen games by id</param>>
    /// <param name="Date"> When the game was last time played </param>>
    /// <param name="Rating"> User rating of a game </param>>
    /// <param name="Comment"> Comment about game </param>>
    public partial class Played
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("GameId")]
        public int? GameId { get; set; }
        [Column("date")]
        public DateTime? Date { get; set; }
        
        public int? Rating { get; set; }
        [StringLength(128)]
        public string Comment { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty("Played")]
        public virtual Game Game { get; set; }
    }
}
