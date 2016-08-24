using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Pair Find(SearchType searchType)
        {
            List<Pair> pairs = GetAllPairs(_people);

            if (pairs.Count < 1)
            {
                return new Pair();
            }

            return GetMatchingPair(searchType, pairs);
        }

        private Pair GetMatchingPair(SearchType searchType, List<Pair> pairs)
        {
            Pair matchingPair = pairs[0];
            foreach (var pair in pairs)
            {
                if (IsBetterMatch(searchType, matchingPair, pair))
                {
                    matchingPair = pair;
                }
            }

            return matchingPair;
        }

        private bool IsBetterMatch(SearchType searchType, Pair matchingPair, Pair pair)
        {
            if (searchType == SearchType.Closest &&
                 pair.Difference < matchingPair.Difference)
            {
                return true;
            }
            if (searchType == SearchType.Furthest &&
                pair.Difference > matchingPair.Difference)
            {
                return true;
            }

            return false;
        }

        private List<Pair> GetAllPairs(List<Person> people)
        {
            var pairs = new List<Pair>();

            for (var current = 0; current < people.Count - 1; current++)
            {
                for (var next = current + 1; next < people.Count; next++)
                {
                    pairs.Add(ComputeBirthDateDifference(people[current], people[next]));
                }
            }

            return pairs;
        }

        private Pair ComputeBirthDateDifference(Person person1, Person person2)
        {
            var result = new Pair();

            result.Oldest = IsOlder(person1, person2) ? person1 : person2;
            result.Younger = IsOlder(person1, person2) ? person2 : person1;
            result.Difference = result.Younger.BirthDate - result.Oldest.BirthDate;

            return result;
        }

        private bool IsOlder(Person person1, Person person2)
        {
            return person1.BirthDate < person2.BirthDate;
        }
    }
}