using Ardalis.SmartEnum;

namespace BuberDinner.Domain.DinnerAggregate.Enums;

public class ReservationStatus(string name, int value) : SmartEnum<ReservationStatus>(name, value)
{
    public static readonly ReservationStatus PendingGuestApproval = new(nameof(PendingGuestApproval), 1);
    public static readonly ReservationStatus Reserved = new(nameof(Reserved), 2);
    public static readonly ReservationStatus Cancelled = new(nameof(Cancelled), 3);
}