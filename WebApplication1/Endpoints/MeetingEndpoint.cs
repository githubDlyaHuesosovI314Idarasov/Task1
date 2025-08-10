namespace WebApplication1.Endpoints
{
    public class MeetingEndpoint
    {
        public static IResult OfferMeeting(MeetingInput input, List<User> users, List<Meeting> meetings)
        {
            DateTime potentialStart = input.earliestStart;
            DateTime potentialEnd = potentialStart.AddMinutes(input.durationMinutes);
            List<User> foundUsers = users.Where(user => input.paticipantIds.Contains(user.Id)).ToList();

            while (potentialStart.Date == input.earliestStart.Date && potentialEnd <= input.latestEnd && potentialEnd.Date == input.earliestStart.Date)
            {
                bool slotAvailable = input.paticipantIds.All(participantId =>
                    !meetings.Any(meeting =>
                        meeting.Participants.Any(user => user.Id == participantId) &&
                        meeting.StartTime < potentialEnd && meeting.EndTime > potentialStart
                    )
                );

                if (slotAvailable)
                {
                    Meeting newMeeting = new Meeting
                    {
                        Id = meetings.Count > 0 ? meetings.Max(u => u.Id) + 1 : 1,
                        Participants = foundUsers,
                        StartTime = potentialStart,
                        EndTime = potentialEnd
                    };
                    meetings.Add(newMeeting);
                    return Results.Ok(newMeeting);
                }

                potentialStart = potentialStart.AddMinutes(1);
                potentialEnd = potentialStart.AddMinutes(input.durationMinutes);
                
            }

            return Results.NotFound("No available time slot found.");
        }

    }
}
