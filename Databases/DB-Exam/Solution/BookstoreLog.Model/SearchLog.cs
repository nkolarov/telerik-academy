namespace BookstoreLog.Model
{
    using System;

    /// <summary>
    /// Defines Search Log table.
    /// </summary>
    public class SearchLog
    {
        public int SearchLogId { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}
