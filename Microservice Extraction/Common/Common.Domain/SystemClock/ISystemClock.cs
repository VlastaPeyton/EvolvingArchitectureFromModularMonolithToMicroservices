
namespace Common.Domain.SystemClock
{
    public interface ISystemClock
    {
        DateTimeOffset Now { get; }
    }
}
