namespace CslyViz;

public interface ICslyContext 
{
    
    string SampleName { get; set; }
    
    string Grammar { get; set; }
    
    string Source { get; set; }
    
    string DotGraph { get; set; }

    void SetSample(string sampleName);

    List<string> GetSamples();

}