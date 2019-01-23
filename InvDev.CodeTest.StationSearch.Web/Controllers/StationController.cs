using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using InvDev.CodeTest.StationSearch.Service;

namespace InvDev.CodeTest.StationSearch.Controllers
{
    //[Authorize]
    public class StationsController : ApiController
    {
        private LookupService s = new LookupService();

        // GET api/values
        public async Task<StationSearchResult> Get(string filter)
        {
            if (filter=="" || filter==null)
            {
                filter=" ";
            }
            filter = filter.Trim('"');
            var stations = await s.GetAllStartingWithAsync(filter);

            var nextPossibleChars = stations.Where(station => station.Length > filter.Length).Select(station => station[filter.Length]).OrderBy(x=>x).Distinct();

            return new StationSearchResult(nextPossibleChars, stations.OrderBy(x=>x));
        }

    }

    public class StationSearchResult
    {
        public StationSearchResult() { }

        public StationSearchResult(IEnumerable<char> nextPossibleCharacters, IEnumerable<string> stations)
        {
            NextPossibleCharacters = nextPossibleCharacters ?? new char[0];
            Stations = stations ?? new string[0];
        }

        public IEnumerable<char> NextPossibleCharacters { get; private set; }

        public IEnumerable<string> Stations { get; private set; }
    }

}
