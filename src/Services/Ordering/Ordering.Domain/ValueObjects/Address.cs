﻿namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string? EmailAddress { get; init; } = default!;
    public string AddressLine { get; init; } = default!;
    public string Country { get; init; } = default!;
    public string State { get; init; } = default!;
    public string ZipCode { get; init; } = default!;
    protected Address()
    {
        // Required for EF Core
    }

    private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine, nameof(addressLine));

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}
