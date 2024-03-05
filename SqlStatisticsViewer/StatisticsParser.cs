using System.Text;

namespace SqlStatisticsViewer
{
    internal class StatisticsParser
    {
        public List<StatisticItem> ParseInput(string input, decimal threshold = 120)
        {
            List<StatisticItem> statistics = new List<StatisticItem>();
            StatisticItem item = new StatisticItem();
            int index = 0;
            foreach (var row in ParseData(input, ','))
            {
                if (row.StartsWith("Table"))
                {
                    if (index > 0)
                    {
                        statistics.Add(item);
                        item = new StatisticItem();
                    }
                    item.Line = index++;
                    item.Table = NormiliseName(row);
                    continue;
                }
                if (GetFieldByName(row, "scan count")) item.ScanCount = GetFieldValue(row, 2);
                if (GetFieldByName(row, "logical reads")) item.LogicialReads = GetFieldValue(row, 2);
                if (GetFieldByName(row, "physical reads")) item.PhysicalReads = GetFieldValue(row, 2);
                if (GetFieldByName(row, "page server reads")) item.PageServerReads = GetFieldValue(row, 3);
                if (GetFieldByName(row, "read-ahead reads")) item.ReadAheadReads = GetFieldValue(row, 2);
                if (GetFieldByName(row, "page server read-ahead reads")) item.PageServerReadAheadReads = GetFieldValue(row, 4);
                if (GetFieldByName(row, "lob logical reads")) item.LobLogicalReads = GetFieldValue(row, 3);
                if (GetFieldByName(row, "lob physical reads")) item.LobPhysicalReads = GetFieldValue(row, 3);
                if (GetFieldByName(row, "lob page server reads")) item.LobPageServerReads = GetFieldValue(row, 4);
                if (GetFieldByName(row, "lob read-ahead reads")) item.LobReadAheadReads = GetFieldValue(row, 3);
                if (GetFieldByName(row, "lob page server read-ahead reads")) item.PageServerReadAheadReads = GetFieldValue(row, 5);
            }
            statistics.Add(item);
            return FindHighestValues(statistics, (int)threshold);
        }
        private List<StatisticItem> FindValue(List<StatisticItem> statistics, string table)
        {
            List<StatisticItem> items = new List<StatisticItem>();
            foreach (var item in statistics)
            {
                if (item.Table.ToLower().Contains(table.ToLower())) items.Add(item);
            }
            return items;
        }
        private List<StatisticItem> FindHighestValues(List<StatisticItem> statistics, int threshold = 120)
        {
            List<StatisticItem> items = new List<StatisticItem>();
            int itemCount = 0;
            foreach (var item in statistics)
            {
                itemCount = items.Count;
                if (item is null) continue;
                foreach (var prop in item.GetType().GetProperties())
                {
                    if (prop is null) continue;
                    string name = prop.Name;
                    if (name == "Line") continue;
                    int? value = 0;
                    if (prop.GetValue(item, null)?.GetType() == typeof(int))
                    {
                        value = (int?)prop.GetValue(item, null);
                        if (value > 0)
                        {
                            if (value >= threshold)
                            {
                                items.Add(item);
                                break;
                            }
                        }
                    }
                }
                if (items.Count > itemCount) continue;
            }
            return items;
        }
        private bool GetFieldByName(string row, string name)
            => row.ToLower().StartsWith(name);
        private int GetFieldValue(string row, int position)
            => Convert.ToInt32(row.Split(' ')[position]);
        private string NormiliseName(string name)
        {
            string normilisedName = string.Empty;
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (c == '_' && count < 3) count++;
                if (c != '_' || c == '_' && count < 3) normilisedName += c.ToString();
            }
            return normilisedName;
        }
        private IEnumerable<string> ParseData(string data, char delimiter)
        {
            int doubleQuoteStart = 0;
            int doubleQuoteEnd = 0;
            int periodStart = 0;
            int periodEnd = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                char c = data[i];
                if (c == delimiter && doubleQuoteStart > 0 && doubleQuoteEnd == 0)
                {
                    yield return RemoveQuotes(sb.ToString().Trim());
                    sb.Clear();
                }
                else if (c == delimiter && doubleQuoteStart == 0 && doubleQuoteEnd == 0)
                {
                    yield return sb.ToString().Trim();
                    sb.Clear();
                }
                else if (isPeriod(c) && periodStart == 0)
                {
                    periodStart = i;
                    yield return sb.ToString().Trim();
                    sb.Clear();
                }
                else if (isPeriod(c) && periodStart > 0 && periodEnd == 0)
                {
                    periodEnd = i;
                    yield return sb.ToString().Trim();
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }

                if (doubleQuoteEnd > doubleQuoteStart)
                {
                    doubleQuoteStart = 0;
                    doubleQuoteEnd = 0;
                }
                if (periodEnd > periodStart)
                {
                    periodStart = 0;
                    periodEnd = 0;
                }

                if (isDoubleQuote(c))
                {
                    if (doubleQuoteStart == 0) { doubleQuoteStart = i; };
                    if (doubleQuoteStart > doubleQuoteEnd && doubleQuoteStart != i) { doubleQuoteEnd = i; };
                }
            }
            if (sb.Length > 0) yield return RemoveQuotes(sb.ToString().Trim());
        }
        static bool isSpace(char c) => c == ' ';
        static bool isPeriod(char c) => c == '.';
        static bool isDoubleQuote(char c) => c == '\"';
        static bool isNewLine(char c) => c == '\n';
        static string RemoveQuotes(string s) => s.Replace("\"", "");
    }
    public class StatisticItem
    {
        public int Line { get; set; }
        public string Table { get; set; }
        public int ScanCount { get; set; }
        public int LogicialReads { get; set; }
        public int PhysicalReads { get; set; }
        public int PageServerReads { get; set; }
        public int ReadAheadReads { get; set; }
        public int PageServerReadAheadReads { get; set; }
        public int LobLogicalReads { get; set; }
        public int LobPhysicalReads { get; set; }
        public int LobPageServerReads { get; set; }
        public int LobReadAheadReads { get; set; }
        public int LobPageServerReadAheadReads { get; set; }
    }
}
