using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Elvis.Models
{
    /// <summary>
    /// Created by: Elvis
    /// Date Created: 05/12/2019
    /// Album contains artist and genre class in addition to other information
    /// Modified 05/13 added data validation
    /// </summary>
    public class Album
    {
        //private readonly MusicStoreContext _context;
        //private Genre _Genre;

        //public Album(MusicStoreContext context)
        //{
        //    _context = context;
        //}

        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        public virtual Genre Genre {
            get; set; 
        }
        public virtual Artist Artist { get; set; }
    }
}
