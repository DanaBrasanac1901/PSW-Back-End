using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibery.News
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

       
        public DateTime Timestamp { get; set; }


        public Message(string text, DateTime timestamp)
        {
            this.Id = Guid.NewGuid();
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.Timestamp.ToString();
        }
    }
}
