using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApiParserWorker.Infrastructure.Hosts.ResponseModels
{
    public interface IResponseModel
    {
        public List<Iitem> items { get; set; }
    }
}
