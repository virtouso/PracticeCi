using Newtonsoft.Json;

namespace Help.Script.Help.Utility
{
     public interface IUtilitySerializer
     {
          T Deserialize<T>(string serializedText);
          string Serialize<T>(T dataModel);
     }
     
     public class UtilityNewtonSoftJson : IUtilitySerializer
     {
          public T Deserialize<T>(string serializedText)
          {

               return JsonConvert.DeserializeObject<T>(serializedText);
          }

          public string Serialize<T>(T dataModel)
          {
               return JsonConvert.SerializeObject(dataModel);
          }
     }
     
}