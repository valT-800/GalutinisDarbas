using System.Runtime.Serialization;

namespace RAWG.Libs.Models
{
    /// <summary>
    /// Defines data for external API results
    /// </summary>
    /// <param name="id"> id of game </param>>
    /// <param name="chartRating"> Rating of game </param>>
    [DataContract]
    public class Data
    {
        /*fixdis*/
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "chartRating")]
        public string chartRating { get; set; }
    }
}
