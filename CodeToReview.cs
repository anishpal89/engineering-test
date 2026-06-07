using System;

// REVIEW: Typo in namespace.
// Should be System.Collections.Generic.
using System.Collegctions.Generic;

using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    // REVIEW: Class name should likely be singular ("Person")
    // since this represents a single entity.
    public class People
    {
        // REVIEW: Variable name suggests "Under16"
        // but logic subtracts only 15 years.
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);

        public string Name { get; private set; }

        public DateTimeOffset DOB { get; private set; }

        public People(string name) : this(name, Under16.Date) { }

        // REVIEW: Constructor accepts DateTime while property uses DateTimeOffset.
        // Consider using a consistent date type throughout the model.
        public People(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// REVIEW: XML comment does not describe the field meaningfully.
        /// "MaxItemsToRetrieve" appears unrelated to the actual field.
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// REVIEW: Method summary should describe actual behavior.
        /// "GetPeoples" is grammatically incorrect and unclear.
        /// </summary>

        /// <param name="j">
        /// REVIEW: Parameter documentation does not match actual parameter name.
        /// </param>

        /// <returns>
        /// REVIEW: Return type documentation is incorrect.
        /// Method returns List<People>, not List<object>.
        /// </returns>
        public List<People> GetPeople(int i)
        {
            // REVIEW: Variable name "i" is unclear.
            // Consider using a more descriptive name like "count".
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // REVIEW: Typo in comment ("dandon").
                    // Also comment may be unnecessary because code is self-explanatory.
                    // Creates a dandon Name

                    string name = string.Empty;

                    // REVIEW: Random should not be instantiated inside the loop.
                    // This can generate duplicate values due to identical seeds.
                    var random = new Random();

                    // REVIEW: random.Next(0,1) always returns 0.
                    // "Betty" branch will never execute.
                    if (random.Next(0, 1) == 0)
                    {
                        name = "Bob";
                    }
                    else
                    {
                        name = "Betty";
                    }

                    // REVIEW:
                    // 1. 356 appears incorrect for days in a year (likely should be 365).
                    // 2. Contains multiple magic numbers (18, 85, 356).
                    // 3. TimeSpan-based age calculation may not handle leap years accurately.
                    _people.Add(
                        new People(
                            name,
                            DateTime.UtcNow.Subtract(
                                new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0)
                            )
                        )
                    );
                }
                catch (Exception e)
                {
                    // REVIEW:
                    // 1. Catching Exception is too broad.
                    // 2. Original exception details are lost.
                    // 3. Exception variable "e" is never used.
                    // 4. Comment is informal/unprofessional.

                    // Dont think this should ever happen

                    throw new Exception("Something failed in user creation");
                }
            }

            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            // REVIEW:
            // Logic appears reversed.
            // DOB >= current date minus 30 years returns younger people,
            // not people older than 30.

            // REVIEW:
            // DateTime.Now and DateTime.UtcNow are mixed throughout the codebase.
            // Consider using a consistent approach.

            return olderThan30
                ? _people.Where(
                    x => x.Name == "Bob"
                    && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))
                )
                : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            // REVIEW:
            // Potential NullReferenceException if lastName is null.
            if (lastName.Contains("test"))
                return p.Name;

            // REVIEW:
            // Expression is difficult to read and understand.
            if ((p.Name.Length + lastName).Length > 255)
            {
                // REVIEW:
                // Result of Substring is ignored, so truncation has no effect.
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}