 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkTrafficAnomalyDetector.ML.Base;
using NetworkTrafficAnomalyDetector.ML.Objects;
using Microsoft.ML;
namespace NetworkTrafficAnomalyDetector.ML
{
    public class Trainer : BaseML
    {
        //The four variables to send to the transform

        private const int PvalueHistoryLength = 3;
        private const int SeasonalWindowSize = 3;
        private const int TrainingWindowSize = 7;
        private const int Confidence = 98;
        public void Train(string trainingFileName)
        {
            // Check if training data exists
            if (!File.Exists(trainingFileName))
            {
                Console.WriteLine($"Failed to find the training data file {trainingFileName}");
                return;
            }

            //Loads Text file into an IDataViewObject from CSV Training file
            var trainingDataView = GetDataView(trainingFileName);

            //We can the create SSA spike detection
#pragma warning disable 0618
            var trainingPipeLine = MlContext.Transforms.DetectSpikeBySsa(
                                  nameof(NetworkTrafficPrediction.Prediction),
                                  nameof(NetworkTrafficHistory.BytesTransferred),
                                  confidence: Confidence,
                                  pvalueHistoryLength: PvalueHistoryLength,
                                  trainingWindowSize: TrainingWindowSize,
                                  seasonalityWindowSize: SeasonalWindowSize);


            //We fit the model on the training data and save the model
            ITransformer trainedModel= trainingPipeLine.Fit(trainingDataView);

            //Save created model to the filename specified matching training set's schema
            MlContext.Model.Save(trainedModel, trainingDataView.Schema, ModelPath);


            Console.WriteLine("Model Trained");





        }
    }
}
