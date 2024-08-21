using Microsoft.ML;
using NetworkTrafficAnomalyDetector.ML.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.TimeSeries;
using NetworkTrafficAnomalyDetector.ML.Objects;
using Microsoft.ML.Transforms.TimeSeries;
namespace NetworkTrafficAnomalyDetector.ML
{
    public class Predictor : BaseML
    {

    


        public void Predict(string inputDataFile)
        {
            if (!File.Exists(ModelPath))
            {
                ////Verifying if the model exists prior to reading it
                Console.WriteLine($"Failed to find model at {ModelPath}");
                return;

            }
            if (!File.Exists(inputDataFile))
            {
                //Verifying if the input file exists before making predictions on it 
                Console.WriteLine($"Failed to find input data at {inputDataFile}");
                return;
            }

            /*Loading the model  */
            //Then we define the ITransformer Object
            ITransformer mlModel = MlContext.Model.Load(ModelPath, out var modelInputSchema);


            if (mlModel == null)
            {
                Console.WriteLine("Failed to load the model");
                return;
            }
            // Create a prediction engine with the NetworkTrafficHistory and NetworkHistoryPrediction types


            // Create and add the forecast estimator to the pipeline.
         


            var predictionEngine = mlModel.CreateTimeSeriesEngine<NetworkTrafficHistory, NetworkTrafficPrediction>(MlContext);

            //Next we read the input into an IDataView variable
            var inputData = MlContext.Data.LoadFromTextFile<NetworkTrafficHistory>(inputDataFile, separatorChar: ',');

            //Next we take the newly created IDataView variable and get an enumerable based off of that data view
            var rows = MlContext.Data.CreateEnumerable<NetworkTrafficHistory>(inputData, false);

            //Lastly we run the prediction and then output the results of the model run
            //With Transform only returning the three-element vector, the original row data is output to give context
            Console.WriteLine($"Based on input file({inputDataFile}):");

#pragma warning disable 8602
            foreach (var row in rows)
            {
                var prediction = predictionEngine.Predict(row);
                Console.Write($"HOST: {row.HostMachine} TIMESTAMP: {row.TimeStamp} TRANSFER: {row.BytesTransferred} ");
                Console.Write($"ALERT: {prediction.Prediction[0]} SCORE: {prediction.Prediction[1]:f2} P-VALUE: {prediction.Prediction[2]:F2}{Environment.NewLine}");
            }
            










        }

    }
}


