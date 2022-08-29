using HomeWork.api.Dtos.Datadictionary;

namespace HomeWork.api.Dtos
{
    public class StaffDto : IdentityDto
    {
        private DateTime brith;

        public DateTime Brith
        {
            get { return brith; }
            set { brith = value; }
        }
        private int polical;
        public Polical PolicalType
        {
            get
            {
                if (Enum.IsDefined(typeof(Polical), (Polical)polical))
                    return (Polical)polical;
                else return Polical.Unknown;
            }
            set { polical = (int)value; }
        }

        private string? healthStatus;

        public string HealthStatus
        {
            get { return healthStatus; }
            set { healthStatus = value; }
        }

        private PostDto postStatus;

        public PostDto PostStatus
        {
            get { return postStatus; }
            set { postStatus = value; }
        }

        private DepartmentDto departmentStatus;

        public DepartmentDto DepartmentStatus
        {
            get { return departmentStatus; }
            set { departmentStatus = value; }
        }

    }
}
