// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.ML;
using DrCaptcha_irML.Model;
using System.Configuration;

namespace DrCaptcha_irML.Model
{
    public class ConsumeModel
    {
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);

        public static string MLNetModelPath = ConfigurationManager.AppSettings["MLModel"];
        public static ModelOutput Predict(ModelInput input)
        {
            try
            {
                ModelOutput result = PredictionEngine.Value.Predict(input);
                return result;
            }
            catch (Exception ex)
            {
                return new ModelOutput();
            }
        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            return predEngine;
        }
    }
}