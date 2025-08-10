namespace WebApplication1
{
    public class Meeting
    {
        private Int32 _id;
        private List<User> _participants;
        private DateTime _startTime;
        private DateTime _endTime;

        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<User> Participants
        {
            get { return _participants; }
            set { _participants = value; }
        }
        [BusinessTime]
        public DateTime StartTime { get { return _startTime; } set { _startTime = value; } }
        [BusinessTime]
        public DateTime EndTime { get { return _endTime; } set { _endTime = value; } }
    }
}
