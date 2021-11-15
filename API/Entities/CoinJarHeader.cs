using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class CoinJarHeader
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Volume { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? TrackAmount { get; set; }
    }
}
