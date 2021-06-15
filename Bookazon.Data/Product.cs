﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Data
{
    public enum FormatType { Hardcover, Paperback, Audiobook, Ebook }
    public enum Condition { New, Used }
    public enum Genre { Mystery, Thriller, Horror, Fantasy, Childrens, Romance, Nonfiction, History, SciFi }
    public enum Audience { Child, Teen, Adult}
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public double StarRating { get; set; }

        [Required]
        public FormatType TypeOfFormat { get; set; }

        public Genre TypeofGenre { get; set; }

        public Audience TypeofAudience { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public int PublishYear { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Condition TypeOfCondition { get; set; }

        public virtual List<Authorship> Authors { get; set; }

        public virtual List<Publisher> Publishers { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
