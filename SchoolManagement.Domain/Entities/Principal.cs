using SchoolManagement.Domain.Entities.Base;

namespace SchoolManagement.Domain.Entities
{
    public class Principal : PeopleEntity
    {
        public PrincipalAccount? Account { get; set; }
        public List<Teacher>? Teachers { get; set; }
    }
}
