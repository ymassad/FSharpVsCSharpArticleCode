using System;
using System.Collections.Immutable;
using System.Linq;
using MoreLinq;

namespace LookAndSayFunctionalCSharp
{
    public static class Module1
    {
        record Group (char Digit, int Count)
        {
            public string Encode() => Count.ToString() +  Digit;
        }

        public static string LookAndSay(string str)
        {
            var stringDigits = str.ToImmutableArray();

            Group IncrementCount(Group group) => group with { Count = group.Count + 1 };

            Group GetOneGroup (ImmutableArray<char> nonEmptyDigits) =>
                nonEmptyDigits switch
                {
                    { Length: >= 2} when nonEmptyDigits[0] == nonEmptyDigits[1] =>
                        IncrementCount(
                            GetOneGroup(nonEmptyDigits.Skip(1).ToImmutableArray())),
                    _ => new Group(nonEmptyDigits[0], 1)
                };
            
            (Group group, ImmutableArray<char> remainingDigits)? GetOneGroupAndRemainingDigits(ImmutableArray<char> digits)
            {
                if (digits.IsEmpty)
                    return null;

                var group = GetOneGroup(digits);

                return (group, digits.Skip(group.Count).ToImmutableArray());
            }

            var groups = MoreEnumerable.Unfold(
                state: stringDigits,
                generator: GetOneGroupAndRemainingDigits,
                predicate: x => x.HasValue,
                stateSelector: x => x.Value.remainingDigits,
                resultSelector: x => x.Value.group);

            return string.Concat(groups.Select(x => x.Encode()));
        }
    }
}
