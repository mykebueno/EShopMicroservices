﻿namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardNumber { get; init; } = default!;
    public string? CardName { get; init; } = default!;
    public string Expiration { get; init; } = default!;
    public string CVV { get; init; } = default!;
    public int PaymentMethod { get; } = default!;
}
