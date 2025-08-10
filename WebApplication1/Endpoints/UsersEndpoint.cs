namespace WebApplication1.Endpoints
{
    public class UsersEndpoint
    {
        public static IResult GetMeetings(Int32 userId, List<Meeting> meetings)
        {
            List<Meeting> userMeetings = meetings.FindAll(x => x.Participants.Any(user => user.Id == userId)).ToList();
            return Results.Ok(userMeetings);
        }

        public static IResult AddUser(String name, List<User> users)
        {
            User user = new User
            {
                Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
                Name = name
            };
            users.Add(user);
            return Results.Created("/users", user);
        }

    }
}
