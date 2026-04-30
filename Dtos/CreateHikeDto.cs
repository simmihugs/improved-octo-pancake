namespace WanderBar.Dtos;

public record CreateHikeDto(
    string Name,
    string Description,
    double Distance,
    double Duration,
    string[] Participants
);