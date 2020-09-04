using CsvHelper.Configuration.Attributes;

namespace ReadFiles
{
    public class LineFile
    {
        [Name("Team")]
        public string Team { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Race Number")]
        public string RaceNumber { get; set; }
        [Name("Order")]
        public int Order { get; set; }
    }
}
