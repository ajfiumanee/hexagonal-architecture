namespace Domain.Enums;

public enum Action
{
    Pay = 0, // Paid
    Finish = 1, // After paid and used;
    Cancel = 2, // Can never be paid;
    Refund = 3, // Paid then refund;
    Reopen = 4 // Canceled;
}