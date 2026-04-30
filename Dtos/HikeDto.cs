namespace WanderBar.Dtos;

public record HikeDto(
    int Id,
    string Name,
    string Description,
    double Distance,
    double Duration,
    string[] Participants
);
