namespace HW13
{
    internal class PoemCollection
    {
        public List<Poem> poems = new List<Poem>();

        //task1
        public void AddPoem(Poem poem)
        {
            poems.Add(poem);
        }

        public void RemovePoem(string title)
        {
            var poem = poems.FirstOrDefault(p => p.Title == title);
            if (poem != null)
            {
                poems.Remove(poem);
            }
        }

        public void UpdatePoem(string title, Poem updatedPoem)
        {
            var poem = poems.FirstOrDefault(p => p.Title == title);
            if (poem != null)
            {
                poem.Title = updatedPoem.Title;
                poem.Author = updatedPoem.Author;
                poem.Year = updatedPoem.Year;
                poem.Text = updatedPoem.Text;
                poem.Theme = updatedPoem.Theme;
            }
        }

        public List<Poem> SearchPoems(string searchTerm, Func<Poem, bool> predicate)
        {
            return poems.Where(predicate).ToList();
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var poem in poems)
                {
                    writer.WriteLine(poem.Title);
                    writer.WriteLine(poem.Author);
                    writer.WriteLine(poem.Year);
                    writer.WriteLine(poem.Theme);
                    writer.WriteLine(poem.Text);
                    writer.WriteLine("----");
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            poems.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string title;
                while ((title = reader.ReadLine()) != null)
                {
                    string author = reader.ReadLine();
                    int year = int.Parse(reader.ReadLine());
                    string theme = reader.ReadLine();
                    string text = reader.ReadLine();
                    string separator = reader.ReadLine(); // "----"
                    poems.Add(new Poem(title, author, year, text, theme));
                }
            }
        }

        public void PrintAllPoems()
        {
            foreach (var poem in poems)
            {
                Console.WriteLine(poem);
            }
        }

        //task2
        public void ReportTitle(string title, bool saveToFile = false, string filePath = "")
        {
            var results = poems.Where(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
            GenerateReport(results, saveToFile, filePath);
        }

        public void ReportAuthor(string author, bool saveToFile = false, string filePath = "")
        {
            var results = poems.Where(p => p.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
            GenerateReport(results, saveToFile, filePath);
        }

        public void ReportTheme(string theme, bool saveToFile = false, string filePath = "")
        {
            var results = poems.Where(p => p.Theme.Equals(theme, StringComparison.OrdinalIgnoreCase)).ToList();
            GenerateReport(results, saveToFile, filePath);
        }

        //task3
        public void ReportWord(string word, bool saveToFile = false, string filePath = "")
        {
            var results = poems.Where(p => p.Text.Contains(word, StringComparison.OrdinalIgnoreCase)).ToList();
            GenerateReport(results, saveToFile, filePath);
        }

        public void ReportYear(int year, bool saveToFile = false, string filePath = "")
        {
            var results = poems.Where(p => p.Year == year).ToList();
            GenerateReport(results, saveToFile, filePath);
        }

        public void ReportLength(int minLength, int maxLength, bool saveToFile = false, string filePath = "")
        {
            var results = poems.Where(p => p.Text.Length >= minLength && p.Text.Length <= maxLength).ToList();
            GenerateReport(results, saveToFile, filePath);
        }

        private void GenerateReport(List<Poem> poems, bool saveToFile, string filePath)
        {
            if (saveToFile)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var poem in poems)
                    {
                        writer.WriteLine(poem.ToString());
                    }
                }
                Console.WriteLine($"The report is saved to a file: {filePath}");
            }
            else
            {
                foreach (var poem in poems)
                {
                    Console.WriteLine(poem);
                }
            }
        }

    }
}
