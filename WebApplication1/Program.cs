using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using WebApplication1;
using WebApplication1.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/users/{userId}/meetings", UsersMeetingsEndpoint.GetMeetings).WithName("GetMeetingsByUserId");
app.MapPost("/users", UsersMeetingsEndpoint.AddUser).WithName("Users");
app.MapPost("/meetings", UsersMeetingsEndpoint.OfferMeeting).WithName("Meetings");


app.Run();