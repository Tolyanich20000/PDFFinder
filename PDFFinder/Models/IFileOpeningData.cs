using System;

namespace PDFFinder.Models
{
    public interface IFileOpeningData
    {
        Guid Id { get; set; }
        DateTime Opening { get; set; }
        string FileName { get; set; }
    }
}