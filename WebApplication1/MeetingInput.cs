namespace WebApplication1
{
    public record class MeetingInput(List<Int32> paticipantIds, Int32 durationMinutes, [BusinessTime] DateTime earliestStart, [BusinessTime] DateTime latestEnd);
}
