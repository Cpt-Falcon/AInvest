using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using Microsoft.ML.Transforms.Categorical;
using Microsoft.ML.Transforms.Normalizers;
using Microsoft.ML.Transforms.Text;

namespace AInvest
{
    public class RegressionEngine
    {
        public RegressionEngine()
        {
            MLContext mlContext = new MLContext(seed: 0);
        }

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            Evaluate(mlContext, model);
            var predictions = model.Transform(null);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
        }
    }
}
