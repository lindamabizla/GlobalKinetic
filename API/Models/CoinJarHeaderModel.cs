using API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CoinJarHeaderModel : ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
