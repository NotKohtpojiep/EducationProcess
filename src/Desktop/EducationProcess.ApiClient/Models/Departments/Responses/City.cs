﻿namespace EducationProcess.ApiClient.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int? RegionId { get; set; }

        public Region Region { get; set; }
    }
}