namespace SW.Framework.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Random"/>.
    /// </summary>
    public static class RandomExtensions
    {
        #region CONSTANTS
        public const string ALPHABET = "AÄBCDEFGHIJKLMNOÖPQRSTUÜVWXYZaäbcdefghijklmnoöpqrstuüvwxyz";
        public const string ALPHANUMERIC = ALPHABET + "0123456789 _!?,.:;'\"*#@()[]{}";

        public static readonly List<string> FIRSTNAMES = new()
        {
            "Albert",
            "Alfred",
            "Anna",
            "Beat",
            "Bettina",
            "Carina",
            "Christian",
            "Christine",
            "Daniel",
            "Daniela",
            "Edith",
            "Ernst",
            "Ferdinand",
            "Franziska",
            "Freddy",
            "Gertrud",
            "Gustav",
            "Heidi",
            "Herbert",
            "Hildegard",
            "Iris",
            "Immanuel",
            "Jana",
            "Johann",
            "John",
            "Karl",
            "Kassandra",
            "Katja",
            "Konrad",
            "Leonie",
            "Lukas",
            "Manuel",
            "Manuela",
            "Michael",
            "Michaela",
            "Nadine",
            "Nadja",
            "Norbert",
            "Olga",
            "Otto",
            "Patricia",
            "Patrick",
            "Patrizia",
            "Renate",
            "Roland",
            "Sandro",
            "Sarah",
            "Sascha",
            "Tanja",
            "Timo",
            "Uwe",
            "Veronika",
            "Viktor",
            "Werner",
            "Xenia",
            "Xeno",
            "Yanna",
            "Zacharias",
        };

        public static readonly List<string> LASTNAMES = new()
        {
            "Abbold",
            "Abderhalden",
            "Abegg",
            "Abels",
            "Ablinger",
            "Abt",
            "Ackermann",
            "Adank",
            "Aeberhard",
            "Aebersold",
            "Aepli",
            "Aerni",
            "Aeschbacher",
            "Affentranger",
            "Affolter",
            "Ahrens",
            "Albrecht",
            "Alge",
            "Ammann",
            "Amrein",
            "Amstutz",
            "Anliker",
            "Bach",
            "Bachfischer",
            "Bächler",
            "Bachmann",
            "Bader",
            "Baiker",
            "Ballmer",
            "Balz",
            "Bänziger",
            "Bardelli",
            "Barmettler",
            "Barnieck",
            "Bartels",
            "Barth",
            "Bärtsch",
            "Bauer",
            "Baumann",
            "Baumgartner",
            "Benz",
            "Berger",
            "Bieri",
            "Bischof",
            "Bischofberger",
            "Brändle",
            "Buschor",
            "Camenisch",
            "Carnier",
            "Caduff",
            "Christen",
            "Corsini",
            "Cristuzzi",
            "Czech",
            "Dahinden",
            "Dähler",
            "Dallmann",
            "Debrunner",
            "Decker",
            "Degasper",
            "Degasperi",
            "Degen",
            "Di Maria",
            "Dittmann",
            "Dodic",
            "Dolder",
            "Döriger",
            "Duff",
            "Ehrlich",
            "Färber",
            "Frank",
            "Frei",
            "Gabathuler",
            "Göthe",
            "Hofer",
            "Hongler",
            "Illedits",
            "Indermaur",
            "Jud",
            "Krüsi",
            "Künzler",
            "Kurz",
            "Lanz",
            "Mannhart",
            "Niederer",
            "Nolte",
            "Odermatt",
            "Pfenniger",
            "Pizio",
            "Quadry",
            "Quintero",
            "Räss",
            "Rebholz",
            "Riedi",
            "Riedener",
            "Roth",
            "Schär",
            "Schläpfer",
            "Seitz",
            "Sonderegger",
            "Strack",
            "Strauss",
            "Thür",
            "Tischhauser",
            "Tüxsen",
            "Uecker",
            "Ullmann",
            "Vetsch",
            "Vögele",
            "Vogt",
            "Vorburger",
            "Voropova",
            "Wachter",
            "Waibel",
            "Williams",
            "Xander",
            "Yachter",
            "Zäch",
            "Zimmermann"
        };
        #endregion CONSTANTS

        #region BOOLEANS
        /// <summary>
        /// Generates a random boolean.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <returns>The generated boolean.</returns>
        public static bool NextBoolean(this Random random)
        {
            return random.Next(2) == 0;
        }
        #endregion BOOLEANS

        #region DATETIMES
        /// <summary>
        /// Generates a random date.
        /// </summary>
        /// <remarks>
        /// The date is between <see cref="DateTime.MinValue"/> and <see cref="DateTime.MaxValue"/>.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <returns>The random date.</returns>
        public static DateTime NextDateTime(this Random random)
        {
            return NextDateTime(random, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// Generates a random date in the past.
        /// </summary>
        /// <remarks>
        /// The date is between <see cref="DateTime.MinValue"/> and the present date.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <returns>The random date.</returns>
        public static DateTime NextDateTimePast(this Random random)
        {
            return NextDateTime(random, DateTime.MinValue, DateTime.Now);
        }

        /// <summary>
        /// Generates a random date in the past.
        /// </summary>
        /// <remarks>
        /// Generates a random date between the specified <paramref name="from"/> date and the present date.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <param name="from">
        /// The inclusive lower bound of the random date to be generated.
        /// <paramref name="from"/> must be a past date.
        /// </param>
        /// <returns>The random date.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <see cref="from"/> is invalid.</exception>
        public static DateTime NextDateTimePast(this Random random, DateTime from)
        {
            if (from > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(from), $"{nameof(from)} ({from}) must not be in future!");
            }

            return NextDateTime(random, from, DateTime.Now);
        }

        /// <summary>
        /// Generates a random date in the future.
        /// </summary>
        /// <remarks>
        /// The generated date is between the present date and <see cref="DateTime.MaxValue"/>.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <returns>The random date.</returns>
        public static DateTime NextDateTimeFuture(this Random random)
        {
            return NextDateTime(random, DateTime.Now, DateTime.MaxValue);
        }

        /// <summary>
        /// Generates a random date in the future.
        /// </summary>
        /// <remarks>
        /// The generated date is between the present date and the specified <paramref name="until"/> date.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <param name="until">
        /// The exclusive upper bound of the random date to be generated.
        /// <paramref name="until"/> must be a future date.
        /// </param>
        /// <returns>The random date.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <see cref="until"/> is invalid.</exception>
        public static DateTime NextDateTimeFuture(this Random random, DateTime until)
        {
            if (until < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(until), $"{nameof(until)} ({until}) must not be in past!");
            }

            return NextDateTime(random, DateTime.Now, until);
        }

        /// <summary>
        /// Generates a random date int the specified range.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <param name="from">
        /// The inclusive lower bound of the random date to be generated.
        /// <paramref name="from"/> must be smaller or equal than <paramref name="until"/>.
        /// </param>
        /// <param name="until">
        /// The exclusive upper bound of the random date to be generated.
        /// <paramref name="until"/> must be greater or equal than <paramref name="from"/>.
        /// </param>
        /// <returns>The random date.</returns>
        public static DateTime NextDateTime(this Random random, DateTime from, DateTime until)
        {
            if (until < from)
            {
                DateTime temp = until;
                until = from;
                from = temp;
            }

            if (until == from)
            {
                return from;
            }
            else
            {
                return from.AddTicks(random.NextInt64(0, until.Ticks - from.Ticks));
            }
        }
        #endregion DATETIMES

        #region STRINGS
        /// <summary>
        /// Generates a random string.
        /// </summary>
        /// <remarks>
        /// The generated string is between 1 and 50 characters long.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <returns>The random string.</returns>
        public static string NextString(this Random random)
        {
            return NextString(random, random.Next(1, 50));
        }

        /// <summary>
        /// Generates a random string with length in specified range.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <param name="minLength">
        /// The inclusive lower bound of the length of the random string to be generated.
        /// <paramref name="minLength"/> must be smaller or equal than <paramref name="maxLength"/>.
        /// </param>
        /// <param name="maxLength">
        /// The exclusive upper bound of the length of the random string to be generated.
        /// <paramref name="maxLength"/> must be greater than or equal to 0.</param>
        /// <returns>The random string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the range is invalid!</exception>
        public static string NextString(this Random random, int minLength, int maxLength)
        {
            if (maxLength < minLength)
            {
                (minLength, maxLength) = (maxLength, minLength);
            }

            if (maxLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLength), $"Parameter {nameof(maxLength)} ({maxLength}) must be greater or equal to zero!");
            }
            else if (minLength < 0)
            {
                minLength = 0;
            }

            return NextString(random, random.Next(minLength, maxLength));
        }

        /// <summary>
        /// Generates a random string with specified length.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <param name="length">The length of the random string to be generated.</param>
        /// <returns>The random string.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string NextString(this Random random, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "String length must not be lower than zero!");
            }
            string temp = string.Empty;

            for (int i = 0; i < length; i++)
            {
                temp += ALPHABET[random.Next(ALPHABET.Length)];
            }

            return temp;
        }
        #endregion STRINGS

        #region PERSONS
        /// <summary>
        /// Returns a random firstname.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <returns>The firstname.</returns>
        public static string NextFirstname(this Random random)
        {
            return FIRSTNAMES[random.Next(FIRSTNAMES.Count)];
        }

        /// <summary>
        /// Returns a random lastname.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <returns>The lastname.</returns>
        public static string NextLastname(this Random random)
        {
            return LASTNAMES[random.Next(LASTNAMES.Count)];
        }

        /// <summary>
        /// Returns a random firstname and lastname combination.
        /// </summary>
        /// <param name="random">The calling object.</param>
        /// <returns>The firstname and lastname combination.</returns>
        public static (string Firstname, string Lastname) NextName(this Random random)
        {
            return (FIRSTNAMES[random.Next(FIRSTNAMES.Count)], LASTNAMES[random.Next(LASTNAMES.Count)]);
        }

        /// <summary>
        /// Generates a random person.
        /// </summary>
        /// <remarks>
        /// A person consists of a firstname, a lastname and a birthdate in the past.
        /// </remarks>
        /// <param name="random">The calling object.</param>
        /// <returns>The random person.</returns>
        public static (string Firstname, string Lastname, DateOnly Birthdate) NextPerson(this Random random)
        {
            (string Firstname, string Lastname) name = NextName(random);

            int year = random.Next(DateTime.Now.Year - 100, DateTime.Now.Year - 1);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return (name.Firstname, name.Lastname, new DateOnly(year, month, day));
        }
        #endregion PERSONS
    }
}
