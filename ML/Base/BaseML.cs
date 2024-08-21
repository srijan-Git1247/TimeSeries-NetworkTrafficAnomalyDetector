using Microsoft.ML;
using NetworkTrafficAnomalyDetector.ML.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetworkTrafficAnomalyDetector.Common;


namespace NetworkTrafficAnomalyDetector.ML.Base
{
    public class BaseML
    {
        protected const string FEATURES = "Features";

        protected static string ModelPath => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_FILENAME);

        protected readonly MLContext MlContext;

        protected IDataView GetDataView(string fileName, bool training = true) =>
            MlContext.Data.LoadFromTextFile<NetworkTrafficHistory>(fileName, separatorChar: ',', hasHeader: false);

        protected BaseML()
        {
            MlContext = new MLContext(2020);
        }
    }
}
