namespace HW13
{
    class Program
    {
        static void Main()
        {
            PoemCollection collection = new PoemCollection();

            collection.AddPoem(new Poem("Poem 1", "Author 1", 2000, "Text of poem 1", "Topic 1"));
            collection.AddPoem(new Poem("Poem 2", "Author 2", 2010, "Text of poem 2", "Topic 2"));

            Console.WriteLine("All Poems:");
            collection.PrintAllPoems();

            string filePath = "poems.txt";
            collection.SaveToFile(filePath);

            PoemCollection loadedCollection = new PoemCollection();
            loadedCollection.LoadFromFile(filePath);

            Console.WriteLine("\nDownloaded poems:");
            loadedCollection.PrintAllPoems();

            var searchResults = collection.SearchPoems("Topic 1", p => p.Theme == "Topic 1");
            Console.WriteLine("\nSearch poems by topic 'Topic 1':");
            foreach (var poem in searchResults)
            {
                Console.WriteLine(poem);
            }

            collection.RemovePoem("Poem 1");
            Console.WriteLine("\nPoem 'Poem 1' has been deleted. Current collection:");
            collection.PrintAllPoems();

            collection.UpdatePoem("Poem 2", new Poem("Poem 2", "Author 2", 2015, "New text of poem 2", "New theme 2"));
            Console.WriteLine("\nInformation about 'Poem 2' changed:");
            collection.PrintAllPoems();

            //task2
            Console.WriteLine("Report under the title 'Poem 1':");
            collection.ReportTitle("Poem 1");

            Console.WriteLine("\nReport by author 'Author 1':");
            collection.ReportAuthor("Author 1");

            Console.WriteLine("\nReport by topic 'Topic 1':");
            collection.ReportTheme("Topic 1");

            // Збереження звіту у файл
            string reportFilePath = "report_by_author.txt";
            collection.ReportAuthor("Автор 1", saveToFile: true, filePath: reportFilePath);
        }
    }
}
