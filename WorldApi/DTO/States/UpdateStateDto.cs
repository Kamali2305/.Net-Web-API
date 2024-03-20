
using System.ComponentModel.DataAnnotations;

namespace WorldApi.DTO.States
{
    public class UpdateStateDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public double Population { get; set; }

        public int CountryId { get; set; }



    }
}
