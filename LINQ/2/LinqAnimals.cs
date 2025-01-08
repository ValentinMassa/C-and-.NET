using System;
using System.Linq;
using System.Threading.Tasks;

namespace _2
{
    public class LinqAnimals
    {
        public List<Animal> Animals{private get; set;}
        public List<Animal> QueryGreenColorAndStartsWithVowel()
        {
            char[] vowels = {'A', 'E', 'I', 'O', 'U'};
            
            return (from p in Animals
                where !string.IsNullOrEmpty(p.Name) &&
                    vowels.Contains(p.Name.ToUpperInvariant()[0]) && p.Color == "Verde" 
                select p).ToList();
            
        }

        public List<Animal> AnimalsOrderByName()
        {
            return Animals.OrderBy(p=> p.Name).ToList();
        }

        public IEnumerable<IGrouping<string?, Animal>> AnimalsGroupByColor()
        {
            return Animals.GroupBy(p=> p.Color).OrderBy(p=> p.Key);
        }
    }
}