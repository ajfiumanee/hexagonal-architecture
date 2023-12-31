using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings;

public class StateMachineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldAlwaysStartWithCreatedStatus()
    {
        var booking = new Booking();
        Assert.AreEqual(booking.Status, Status.Created);
    }

    [Test]
    public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);

        Assert.AreEqual(booking.Status, Status.Paid);
    }

    [Test]
    public void ShouldSetStatusToCancelWhenCancelingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);

        Assert.AreEqual(booking.Status, Status.Canceled);
    }

    [Test]
    public void ShouldSetStatusToFinishedWhenFinishingABookingWithPaidStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);

        Assert.AreEqual(booking.Status, Status.Finished);
    }

    [Test]
    public void ShouldSetStatusToRefundedWhenRefundingAPaidBooking()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refund);

        Assert.AreEqual(booking.Status, Status.Refunded);
    }

    [Test]
    public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Reopen);

        Assert.AreEqual(booking.Status, Status.Created);
    }

    [Test]
    public void ShouldNotChangeStatusWhenRefundingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Refund);

        Assert.AreEqual(booking.Status, Status.Created);
    }

    [Test]
    public void ShouldNotChangeStatusWhenRefundingAFinishedBooking()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        booking.ChangeState(Action.Refund);

        Assert.AreEqual(booking.Status, Status.Finished);
    }
}