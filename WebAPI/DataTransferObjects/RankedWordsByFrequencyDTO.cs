using System;
namespace WebAPI.DataTransferObjects
{
    public class RankedWordsByFrequencyDTO
    {
        public string Word
        {
            get;
            set;
        }
        public int Frequency
        {
            get;
            set;
        }
    }
}
