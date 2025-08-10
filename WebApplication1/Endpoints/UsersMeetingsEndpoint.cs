using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Endpoints
{
    public static class UsersMeetingsEndpoint 
    {
        private static List<User> _users = new List<User>();
        private static List<Meeting> _meetings = new List<Meeting>();

        public static IResult GetMeetings(Int32 userId)
        {
            return UsersEndpoint.GetMeetings(userId, _meetings);
        }

        public static IResult AddUser(String name)
        {
            return UsersEndpoint.AddUser(name, _users);
        }

        public static IResult OfferMeeting(MeetingInput input)
        {
            return MeetingEndpoint.OfferMeeting(input, _users, _meetings);
        }

    }
}
