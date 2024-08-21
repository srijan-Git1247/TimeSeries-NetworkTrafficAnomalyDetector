using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTrafficAnomalyDetector.ML.Objects
{
    public class NetworkTrafficPrediction //This class contains the properties mapped to to our prediction
    {
        [VectorType(3)] //VectorType(3) function holds the alert, score and p-value.
        public double[]? Prediction
        { get; set; } 
    }
}
