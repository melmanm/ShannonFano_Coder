using System;
using System.Collections.Generic;
using System.Linq;

namespace Shano_Fano
{
    public class Coder
    {

        private  List<Element> _Elements = new List<Element>();
        public IEnumerable<Element> Elements 
        
        {
            get {return _Elements;} 
            set{_Elements = new List<Element>(value).OrderByDescending(o => o.Probability).ToList();}
        }
        

        public Coder(List<Element> element)
        {
            Elements = element;
        }

        public Coder()
        {

        }

        public Dictionary<Element, string> GetCodes()
        {
            if(_Elements.Sum(x=>x.Probability)!=1.0)
            {
                throw new Exception("Sum of elements probabilities must be equal 1.");
            }
            var result = new Dictionary<Element, string>();
            InitDictionary(result);
            Recurse(_Elements, result);
            return result;

        }

        public void Recurse(List<Element> elements, Dictionary<Element, string> result )
        {
            var index = DivideArray(elements);
            int i=0;
           
            foreach (var element in elements)
            {
               
                if(index >= i)
                    result[element] += "0";
                else
                    result[element] += "1";
                i++;
            }
            var arr1 = elements.GetRange(0,index+1);
            var arr2 = elements.GetRange(index+1,elements.Count-index-1);
            if(arr1.Count>1)
            {
               Recurse(arr1, result);
            }
            if(arr2.Count>1)
            {
               Recurse(arr2, result);
            }
            
        } 

        public int DivideArray(List<Element> elements)
        {
            if(elements.Count == 2)
            {
                return 0;
            }
            var sum=0.0;
            foreach(var element in elements)
            {
                sum+=element.Probability;
            }
            var result =0;
            var currsum =0.0;
            foreach(var element in elements)
            {
            
                if(currsum + element.Probability > sum/2) 
                {
                    if(Math.Abs(sum/2 - currsum) < Math.Abs(sum/2 - (currsum + element.Probability)))
                    {
                        result--;
                        break;
                    }
                    break;
                }
                currsum += element.Probability;
                result ++; 
            }  
            return result;

        }
        private void InitDictionary(Dictionary<Element, string> dictionary)
        {
            foreach(var element in _Elements)
            {
                dictionary.Add(element, String.Empty);
            }
        }
    }
}