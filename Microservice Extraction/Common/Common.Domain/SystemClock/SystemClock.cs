
namespace Common.Domain.SystemClock
{
    public sealed class SystemClock : ISystemClock
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
