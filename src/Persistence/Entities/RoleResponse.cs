using PunchClock.Service.Domain.Entities;

namespace PunchClock.Service.Persistence.Entities
{
    public class RoleResponse
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public static implicit operator RoleResponse(Role prop)
        {
            return prop is null ? null : new RoleResponse()
            {
                Id = prop.Id,
                Description = prop.Description,
                Active = (bool)prop.Active
            };
        }
    }
}
