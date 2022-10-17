namespace HomeWork.Share.Dtos
{
    public class PostDto
    {
        public PostDto() { }
        public PostDto(int id, string name, float standSalary)
        {
            Id = id;
            Name = name;
            StandSalary = standSalary;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StandSalaryId { get; set; }
        public float StandSalary { get; set; }
    }
}
