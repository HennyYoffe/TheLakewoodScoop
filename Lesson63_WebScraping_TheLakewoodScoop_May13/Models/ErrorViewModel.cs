using System;

namespace Lesson63_WebScraping_TheLakewoodScoop_May13.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}