using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Model representing a book
/// </summary>

namespace DamianMuchaDom2.Models
{
    public class Book
    {
        public Book(int id, string title, string description, string author, string genre, double price, string image)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Genre = genre;
            Price = price;
            Image = image;
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required!")]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Description is required!")]
        [MaxLength(3000)]
        public string Description { get; set; }
        [Required(ErrorMessage ="Author is required!")]
        [MaxLength(255)]
        public string Author { get; set; }
        [Required(ErrorMessage ="Genre is required!")]
        public string Genre { get; set; }
        [Required(ErrorMessage ="Price is required!")]
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
