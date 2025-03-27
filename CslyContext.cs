using Microsoft.AspNetCore.Components;
using SharpFileSystem.FileSystems;

namespace CslyViz;

public class CslyContext : ICslyContext
{
    private string _sampleName;
    
    public string SampleName
    {
        get => _sampleName;
        set
        {
            _sampleName = value;
        }
    }
    
    private string _description;
    public string SampleDescription
    {
        get => _description;
        set
        {
            _description = value;
        }
    }
    

    private string _grammar = "";

    public string Grammar
    {
        get => _grammar;
        set
        {
            _sampleName = "";
            _description = "";
            _dotGraph = "";
            _grammar = value;
        }
    }

    public string DotGraph
    {
        get => _dotGraph;
        set => _dotGraph = value;
    }

    public string Source
    {
        get => _source;
        set
        {
            _dotGraph = "";
            _source = value;
        }
    }

    public CslyContext()
    {
    }
    
    public void SetSample(string sampleName)
    {
        if (string.IsNullOrEmpty(sampleName))
        {
            Grammar = "";
            Source = "";
            _description = "";
            _dotGraph = "";
        }
        else
        {
            var sample = Samples[sampleName];
            
            Grammar = GetSampleGrammar(sampleName);
            Source = getSampleSource(sampleName);
            _description = sample.description;
            _sampleName = sampleName;
            
            _dotGraph = "";
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

    private Dictionary<string, (string file, string description)> Samples = new Dictionary<string, (string file, string description)>()
    {
        { "", ("","") },
        { "Expressions", ("expression.txt","demonstrates expression parsing") },
        { "XML", ("xml.txt", "") },
        { "JSON", ("json.txt","") },
        { "simple template", ("template.txt","demonstrates lexer modes") },
        { "While language", ("while.txt","") },
        { "indented While language", ("indented-while.txt","demonstrates indentation awareness") },
        { "repeat", ("repeat.txt","demonstrates EBNF repetitions {x} and {x-y}") },
        { "lexer modes", ("lexerModes.txt","demonstrates lexer modes") },
        { "csly-cli parse itself", ("meta.txt", "meta demonstration : csly-cli grammar parses itself") },
    };

    private string _dotGraph;
    private string _source;

    public List<(string name, string description)> GetSamples()
    {
        return Samples.Select(x =>(x.Key, x.Value.description)).ToList();
    }

    public string GetSampleGrammar(string sampleName)
    {
        string sampleGrammar = "";
        if (!SamplesGrammars.TryGetValue(sampleName, out sampleGrammar))
        {
            if (Samples.TryGetValue(sampleName, out var d ))
            {
                var fs = new EmbeddedResourceFileSystem(GetType().Assembly);
                sampleGrammar = fs.ReadAllText($"/samples/grammar/{d.file}");
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
            
            if (Samples.TryGetValue(sampleName, out var d ))
            {
                var fs = new EmbeddedResourceFileSystem(GetType().Assembly);
                sampleSource = fs.ReadAllText($"/samples/source/{d.file}");
                SamplesSources[sampleName] = sampleSource;
            }
        }

        return sampleSource;
    }

  
    
}