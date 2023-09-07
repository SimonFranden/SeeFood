using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace SeeFood
{
    public class ImageAnalyzer
    {
        private static string cognitiveEndpoint = "https://compvisionseefood.cognitiveservices.azure.com/";
        private static string cognitiveKey = "16fea0ae9134441baf586041c8125192";

        private readonly ComputerVisionClient computerVision;

        public ImageAnalyzer()
        {
            ApiKeyServiceClientCredentials visionCredentials = new(cognitiveKey);
            computerVision = new ComputerVisionClient(visionCredentials);
            computerVision.Endpoint = cognitiveEndpoint;
        }

        
        public async void DectectItemsAsync(string url)
        {
            Console.Clear();
            //Select what to look for in the image
            List<VisualFeatureTypes?> featureTypes = new()
            {
                VisualFeatureTypes.Objects
            };

            Console.WriteLine("Analyzing...");
            ImageAnalysis analysis = await computerVision.AnalyzeImageAsync(url, featureTypes);
            Console.Clear();

           
            if (analysis.Objects.Count > 0) //check if any objects is returned
            {
                string result = analysis.Objects[0].ObjectProperty; //Result is equal to the top object
                
                //Check if the object is a hot dog or not
                if(result == "Hot dog")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("'||'  '||'           .      '||''|.                   \r\n ||    ||    ...   .||.      ||   ||    ...     ... . \r\n ||''''||  .|  '|.  ||       ||    || .|  '|.  || ||  \r\n ||    ||  ||   ||  ||       ||    || ||   ||   |''   \r\n.||.  .||.  '|..|'  '|.'    .||...|'   '|..|'  '||||. \r\n                                              .|....'");
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'|.   '|'           .      '||'  '||'           .      '||''|.                   \r\n |'|   |    ...   .||.      ||    ||    ...   .||.      ||   ||    ...     ... . \r\n | '|. |  .|  '|.  ||       ||''''||  .|  '|.  ||       ||    || .|  '|.  || ||  \r\n |   |||  ||   ||  ||       ||    ||  ||   ||  ||       ||    || ||   ||   |''   \r\n.|.   '|   '|..|'  '|.'    .||.  .||.  '|..|'  '|.'    .||...|'   '|..|'  '||||. \r\n                                                                         .|....' ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Found object: " + result);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Bad image, try again");
            }

            Console.WriteLine("Press any key to continue");            
            
        }

        
    }
}
