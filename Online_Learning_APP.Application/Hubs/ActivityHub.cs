using Microsoft.AspNetCore.SignalR;
using MediatR;
using Online_Learning_APP.Application.Handler;

public class ActivityHub : Hub
{
    private readonly IMediator _mediator;

    public ActivityHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    //Send full list when a user connects
    public override async Task OnConnectedAsync()
    {
        var activities = await _mediator.Send(new GetAllActivitiesQuery());
        await Clients.Caller.SendAsync("ReceiveActivitiesList", activities);

        await base.OnConnectedAsync();
    }

    // Or: On client-side request
    public async Task RequestActivities()
    {
        var activities = await _mediator.Send(new GetAllActivitiesQuery());
        await Clients.Caller.SendAsync("ReceiveActivitiesList", activities);
    }

}





