using ClashRoyaleClanWarsAPI.Application.Responses;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces;

public interface IPredefinedQueries
{
    Task<IEnumerable<FirstQueryResponse>> FirstQuery();
    Task<IEnumerable<SecondQueryResponse>> SecondQuery();
    Task<IEnumerable<ThirdQueryResponse>> ThirdQuery();
    Task<IEnumerable<FourthQueryResponse>> FourthQuery();
    Task<IEnumerable<FifthQueryResponse>> FifthQuery(int trophies);
    Task<IEnumerable<SixthQueryResponse>> SixthQuery();
    Task<IEnumerable<SeventhQueryResponse>> SeventhQuery(int year);
}
