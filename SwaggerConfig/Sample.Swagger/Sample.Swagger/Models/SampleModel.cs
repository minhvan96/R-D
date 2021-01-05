namespace Sample.Swagger.Models
{
    public class SampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateSampleModel
    {
        /// <summary>
        /// Sample Name
        /// </summary>
        /// <example>Sample 1</example>
        public string Name { get; set; }

        /// <summary>
        /// Sample Description
        /// </summary>
        /// <example>This is Sample 1</example>
        public string Description { get; set; }
    }

    public class SampleViewModel
    {
        /// <summary>
        /// Sample Id
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Sample Name
        /// </summary>
        /// <example>Sample 1</example>
        public string Name { get; set; }

        /// <summary>
        /// Sample Description
        /// </summary>
        /// <example>This is Sample 1 with Id = 1</example>
        public string Description { get; set; }
    }
}