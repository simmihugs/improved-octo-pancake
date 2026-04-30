namespace WanderBar.Dtos;

public record UpdateHikeDto(
    string? Name,
    string? Description,
    double? Distance,
    double? Duration,
    string[]? Participants
);