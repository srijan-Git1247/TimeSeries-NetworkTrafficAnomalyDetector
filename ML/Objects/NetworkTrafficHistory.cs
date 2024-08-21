using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTrafficAnomalyDetector.ML.Objects
{

    //This class is the container class that contains the data to both predict and train our model
    public class NetworkTrafficHistory
    {

        [LoadColumn(0)] //The number in the LoadColumn decorator maps to the index in the CSV file.
        public string? HostMachine
        { get; set; }

        [LoadColumn(1)]
        public DateTime TimeStamp
        {
            get;
            set;
        }
        [LoadColumn(2)]

        public float BytesTransferred
        {
            get;
            set;
        }
    }
}
