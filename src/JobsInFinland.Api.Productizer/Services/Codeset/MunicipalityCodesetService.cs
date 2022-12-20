using System.Text.Json;
using JobsInFinland.Api.Productizer.Models.Data;

namespace JobsInFinland.Api.Productizer.Services.Codeset;

public class MunicipalityCodesetService : IMunicipalityCodesetService
{
    private readonly Dictionary<string, string> _codes;

    public MunicipalityCodesetService()
    {
        _codes = new Dictionary<string, string>();
        try
        {
            using var reader = new StreamReader("Data/municipalities.json");
            var stream = reader.ReadToEnd();

            var codeJsonObject = JsonSerializer.Deserialize<List<MunicipalityCodeset>>(stream);
            if (codeJsonObject != null)
            {
                foreach (var o in codeJsonObject)
                {
                    foreach (var name in o.Names.Where(name => name.LanguageCode == "fi"))
                    {
                        _codes.Add(o.Code, name.Text);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IDictionary<string, string> GetCodeset()
    {
        return _codes;
    }
}
