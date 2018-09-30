namespace LearningMVC.Models.Web_APIs
{
    public class Food: BaseModel
    {
        public string Description { get; set; }
        public Measure Measure { get; set; }
    }
}