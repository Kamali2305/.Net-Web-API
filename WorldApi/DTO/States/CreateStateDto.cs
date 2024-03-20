using System.ComponentModel.DataAnnotations;

namespace WorldApi.DTO.States
{
    public class CreateStateDto
    {
        public string Name { get; set; }

        public double Population { get; set; }

        public int CountryId { get; set; }




    }
}
