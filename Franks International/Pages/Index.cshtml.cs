using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Franks_InternationalML.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ML;


namespace Franks_International.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public IndexModel(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [BindProperty]
        public float userYear { get; set; }
        [BindProperty]
        public DateTime userMonth { get; set; }
        [BindProperty]
        public int UserDuration { get; set; }

        //scratch code below

        //int[] arrayYear = new int[] { 2019, 2020, 2021 }; //array for input years
        //int[] arrayMonth = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; //array for input months
        List<float> lPredictionScore = new List<float>(); // initialization of list for predictions
        List<int> lPredictionMonth = new List<int>(); //initialization of list of months

        //int[] arrayDuration = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        //end scratch code

        public void OnPost(int userYear, int userMonth, int userDuration, float userDayRevenue = 0)
        {
            for (int i = 0; i < userDuration; i++)
            {
                float userDay = DateTime.DaysInMonth(userYear, userMonth);
                var input = new ModelInput { Year = userYear, Month = userMonth, Day = userDay, Day_Revenue = userDayRevenue };
                var prediction = _predictionEnginePool.Predict(input);
                ViewData["confirmation"] += $"{userMonth}, {userDay}, {userYear}, forecast is: ${prediction.Score}<br />"; //testing output
                lPredictionMonth.Add(userMonth); //add predicted month to list
                lPredictionScore.Add(prediction.Score); //add prediction score to list
                userMonth++;
                if (userMonth > 12)
                {
                    userMonth = 1;
                    userYear++;
                }
            }
        }
    }
}
