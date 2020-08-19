namespace Api.Hubs
{
    using System.Collections.Generic;
    using System.Linq;
    using Api.DataAccess.Repository;
    using Argument.Check;
    using Microsoft.AspNetCore.SignalR;
    using Models.Car;
    using Newtonsoft.Json;

    public class CarHub : Hub
    {
        private readonly Repository<CarModel> _repo;
        private readonly IHubContext<CarHub> _hubContext;

        public CarHub(Repository<CarModel> repo, IHubContext<CarHub> hubContext)
        {
            Throw.IfNull(() => repo);

            _repo = repo;
            _hubContext = hubContext;

            Init();
        }

        private void Init()
        {
            _repo.AddedEvent += items => _hubContext.Clients.All.SendAsync("CarAdded", ConvertToJson(items));
            _repo.UpdatedEvent += items => _hubContext.Clients.All.SendAsync("CarUpdated", ConvertToJson(items));
            _repo.DeletedEvent += items => _hubContext.Clients.All.SendAsync("CarDeleted", ConvertToJson(items));
        }

        private string ConvertToJson(IEnumerable<CarModel> items)
        {
            var keys = items.Select(x => x.Key.ToString());
            var json = JsonSerialize(keys);
            return json;
        }

        private string JsonSerialize<T>(T source)
        {
            return JsonConvert.SerializeObject(source, new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
        }
    }
}