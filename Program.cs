using WanderBar.Dtos;

var builder = WebApplication.CreateBuilder(args);
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
app.MapGet("/hikes/{id}", (int id) =>  hikes.Find(hike => hike.Id == id));

app.Run();