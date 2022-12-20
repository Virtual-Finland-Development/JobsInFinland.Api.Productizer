using System.Text.Json;
using System.Text.RegularExpressions;
using JobsInFinland.Api.Productizer.Models.Data;

namespace JobsInFinland.Api.Productizer.Services.Codeset;

public class OccupationCodesetService : IOccupationCodesetService
{
    private readonly Dictionary<string, string> _codes;

    public OccupationCodesetService()
    {
        _codes = new Dictionary<string, string>();

        try
        {
            using var reader = new StreamReader("Data/esco-1.1.0-occupations.json");
            var stream = reader.ReadToEnd();

            var codeJsonObject = JsonSerializer.Deserialize<List<OccupationCodeset>>(stream);

            if (codeJsonObject == null) return;

            foreach (var o in codeJsonObject)
            {
                if (string.IsNullOrEmpty(o.Uri) || string.IsNullOrEmpty(o.PrefLabel.En)) continue;
                _codes.TryAdd(o.Uri, o.PrefLabel.En);
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


