namespace CslyViz;

public interface ICslyContext 
{
    
    string SampleName { get;  }
    
    string SampleDescription { get;  }
    
    string Grammar { get; set; }
    
    string Source { get; set; }
    
    string DotGraph { get; set; }

    void SetSample(string sampleName);

    List<(string name, string description)> GetSamples();

}