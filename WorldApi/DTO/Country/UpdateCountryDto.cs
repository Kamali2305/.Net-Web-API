﻿using System.ComponentModel.DataAnnotations;

namespace WorldApi.DTO.Country
{
    public class UpdateCountryDto
    {

        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }


        [Required]
        [MaxLength(5)]
        public string CountryCode { get; set; }

    }
}
