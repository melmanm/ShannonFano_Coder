namespace Shano_Fano
{
    public class Element
    {
        public Element(string name, double probability)
        {
            Name = name;
            Probability = probability;
        }
        public string Name {get; set;}
        public double Probability {get; set;}
    }
}