using Microsoft.AspNetCore.Components;
using SharpFileSystem.FileSystems;

namespace CslyViz;

public class CslyContext : ICslyContext
{
    private string _sampleName;
    
    public string SampleName => _sampleName;
    public string Grammar { get; set; }
    public string Source { get; set; }

    public CslyContext()
    {
    }
    
    public void SetSample(string sampleName)
    {
        if (string.IsNullOrEmpty(sampleName))
        {
            Grammar = "";
            Source = "";
        }
        else
        {
            Grammar = GetSampleGrammar(sampleName);
            Source = getSampleSource(sampleName);
        }
    }

    

    public void SetSource(string source)
    {
        Source = source;
    }

    public void SetGrammar(string grammar)
    {
        Grammar = grammar;
    }
    
    
    
    private Dictionary<string, string> SamplesGrammars = new Dictionary<string, string>();
    
    private Dictionary<string, string> SamplesSources = new Dictionary<string, string>();

    private Dictionary<string, string> Samples = new Dictionary<string, string>()
    {
        { "", null },
        { "Expressions", "expression.txt" },
        { "XML", "xml.txt" },
        { "JSON", "json.txt" },
        { "simple template", "template.txt" },
        { "While language", "while.txt" },
        { "indented While language", "indented-while.txt" },
    };
    public List<string> GetSamples()
    {
        return Samples.Keys.ToList();
    }

    public string GetSampleGrammar(string sampleName)
    {
        string sampleGrammar = "";
        if (!SamplesGrammars.TryGetValue(sampleName, out sampleGrammar))
        {
            if (Samples.TryGetValue(sampleName, out string path ))
            {
                var fs = new EmbeddedResourceFileSystem(GetType().Assembly);
                sampleGrammar = fs.ReadAllText($"/samples/grammar/{path}");
                SamplesGrammars[sampleName] = sampleGrammar;
            }
        }

        return sampleGrammar;
    }
    
    public string getSampleSource(string sampleName)
    {
        string sampleSource = "";
        if (!SamplesSources.TryGetValue(sampleName, out sampleSource))
        {
            
            if (Samples.TryGetValue(sampleName, out string path ))
            {
                var fs = new EmbeddedResourceFileSystem(GetType().Assembly);
                sampleSource = fs.ReadAllText($"/samples/source/{path}");
                SamplesSources[sampleName] = sampleSource;
            }
        }

        return sampleSource;
    }

  
    
}