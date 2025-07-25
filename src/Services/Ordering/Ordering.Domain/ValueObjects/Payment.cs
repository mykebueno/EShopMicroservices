namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardNumber { get; init; } = default!;
    public string? CardName { get; init; } = default!;
    public string Expiration { get; init; } = default!;
    public string CVV { get; init; } = default!;
    public int PaymentMethod { get; } = default!;
    protected Payment()
    {
        // Required for EF Core
    }

    private Payment(string cardNumber, string? cardName, string expiration, string cvv, int paymentMethod)
    {
        CardNumber = cardNumber;
        CardName = cardName;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardNumber, string cardName, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));
        ArgumentException.ThrowIfNullOrWhiteSpace(expiration, nameof(expiration));
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3, nameof(cvv));

        return new Payment(cardNumber, cardName, expiration, cvv, paymentMethod);
    }
}
