namespace CslyViz;

public interface ICslyContext 
{
    
    string SampleName { get; }
    
    string Grammar { get; set; }
    
    string Source { get; set; }

    void SetSample(string sampleName);



    List<string> GetSamples();

}