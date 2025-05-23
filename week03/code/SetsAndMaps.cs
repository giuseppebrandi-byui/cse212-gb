using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var noDuplicateWords = new HashSet<string>(words);
        var results = new List<string>();
        // To avoid duplication when the symmetric word has been checked against the original word.
        var found = new HashSet<string>();

        foreach (string word in words)
        {
            // Reverse the string
            char[] wordToChars = word.ToCharArray();
            // If the letters are the same (e.g. "aa"), continue.
            if (wordToChars[0] == wordToChars[1])
            {
                continue;
            }
            Array.Reverse(wordToChars);
            string symmetric = new string(wordToChars);

            // Check if there is a symmetric in the array
            if (noDuplicateWords.Contains(symmetric))
            {
                // Check if the pair has already been included
                if (!found.Contains(word))
                {
                    found.Add(word);
                    found.Add(symmetric);
                    results.Add(word + " & " + symmetric); // am & ma
                }
            }
        }
        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            string degreeName = fields[3];

            if (!degrees.ContainsKey(degreeName))
            {
                degrees[degreeName] = 1;
            }
            else
            {
                degrees[degreeName] += 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        var anagramLetters1 = new Dictionary<char, int>();
        string wordLc1 = word1.ToLower();
        string wordLc2 = word2.ToLower();
        foreach (char letter in wordLc1)
        {
            if (letter == ' ')
            {
                continue;
            }
            if (!anagramLetters1.ContainsKey(letter))
            {
                anagramLetters1[letter] = 1;
            }
            else
            {
                anagramLetters1[letter] += 1;
            }
        }

        var anagramLetters2 = new Dictionary<char, int>();
        foreach (char letter in wordLc2)
        {
            if (letter == ' ')
            {
                continue;
            }

            if (!anagramLetters2.ContainsKey(letter))
            {
                anagramLetters2[letter] = 1;
            }
            else
            {
                anagramLetters2[letter] += 1;
            }
        }

        if (!(anagramLetters1.Keys.Count == anagramLetters2.Keys.Count))
        {
            return false;
        }

        foreach (char letter in wordLc1)
        {
            if (letter == ' ')
            {
                continue;
            }

            if (!anagramLetters2.ContainsKey(letter))
            {
                return false;
            }

            if (anagramLetters1[letter] != anagramLetters2[letter])
            {
                return false;
            }
        }


        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}