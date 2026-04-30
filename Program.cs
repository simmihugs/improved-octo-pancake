using WanderBar.Dtos;

var builder = WebApplication.CreateBuilder(args);
const string endPointName = "GetHike";
var app = builder.Build();

List<HikeDto> hikes =
[
    new(1, "Wendelstein", "Schoene lange Wanderung zum Wendelsteinhaus", 11.2, 6.0, ["Laura", "Simon"]),
    new(2, "Sigl Alm", "Kurze Wanderung mit Lamas", 3, 2.0, ["Laura", "Raul", "Simon"]),
    new(3, "Burgruine", "Kurzer Trip zur Burgruine ueber dem Schliersee", 4.2, 3.0, ["Laura", "Nina", "Simon"]),
];


// Get /hikes
app.MapGet("/hikes", () => hikes);

// Get /hikes/<ID>
app.MapGet("/hikes/{id:int}", (int id) => hikes.Find(hike => hike.Id == id))
    .WithName(endPointName);

// Post /hikes
app.MapPost("/hikes", (CreateHikeDto dto) =>
{
    var hike = new HikeDto(
        hikes.Count + 1,
        dto.Name,
        dto.Description,
        dto.Distance,
        dto.Duration,
        dto.Participants
    );
    hikes.Add(hike);

    return Results.CreatedAtRoute(endPointName, new { id = hike.Id }, hike);
});

// PUT /hikes/1
app.MapPut("/hikes/{id:int}", (int id, UpdateHikeDto dto) =>
{
    var hike = hikes.Find(hike => hike.Id == id);
    if (hike == null)
    {
        return Results.NotFound();
    }
    else
    {
        var newHike = new HikeDto(hike.Id, 
            dto.Name ?? hike.Name,
            dto.Description ?? hike.Description,
            (double)(dto.Distance ?? hike.Distance),
            (double)(dto.Duration ?? hike.Duration),
            dto.Participants ?? hike.Participants);
        hikes[hike.Id - 1] = newHike;
        return Results.Ok(newHike);
    }
});

app.Run();