using AppSpace.API.Contracts.Enums;

namespace AppSpace.API.Contracts.Responses
{
    public interface ITvShow : IRecommendation
    {
        int SeasonCount { get; set; }

        TvShowStatusEnum Status { get; set; }

        int EpisodesCount { get; set; }
    }
}
