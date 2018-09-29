using System;

namespace crystalCLAIMSAPI.Models.Interfaces
{
    public interface IServiceBase
    {
        // int? MakerId { get; set; }
        string ShortName { get; set; }
        string LongName { get; set; }
        string Description { get; set; }
        string Code { get; set; }
    }
}
