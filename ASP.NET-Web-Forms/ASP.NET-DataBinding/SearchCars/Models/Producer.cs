namespace SearchCars.Models
{
    using System;
    using System.Collections.Generic;

    public class Producer
    {
        public string Name { get; set; }

        public List<Model> Models { get; set; }
    }
}