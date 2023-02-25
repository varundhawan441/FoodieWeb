﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Models
{
	public class MenuItem
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		[Range(1,1000, ErrorMessage ="Price should between be $1 to $1000")]
		public double Price { get; set; }
		[DisplayName("Food Type")]
		public int FoodTypeId { get; set; }
		[ForeignKey("FoodTypeId")]
		public FoodType FoodType { get; set;}
		[DisplayName("Category")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
