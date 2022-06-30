using CatalogueGQL.Server.Models;

namespace CatalogueGQL.Server.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Courses OnCoursesAdded([EventMessage] Courses courses) => courses;
    }
}
