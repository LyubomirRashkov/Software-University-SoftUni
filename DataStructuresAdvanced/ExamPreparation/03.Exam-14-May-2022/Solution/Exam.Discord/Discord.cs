using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        private readonly Dictionary<string, Message> messagesById;
        private readonly Dictionary<string, List<Message>> messagesByChannel;

        public Discord()
        {
            this.messagesById = new Dictionary<string, Message>();
            this.messagesByChannel = new Dictionary<string, List<Message>>();
        }

        public int Count => this.messagesById.Count;

        public void SendMessage(Message message)
        {
            if (!this.messagesById.ContainsKey(message.Id))
            {
                this.messagesById.Add(message.Id, message);

                string channel = message.Channel;

                if (!this.messagesByChannel.ContainsKey(channel))
                {
                    this.messagesByChannel.Add(channel, new List<Message>());
                }

                this.messagesByChannel[channel].Add(message);
            }
        }

        public bool Contains(Message message) => this.messagesById.ContainsKey(message.Id);

        public Message GetMessage(string messageId)
        {
            this.ValidateMessageExists(messageId);

            return this.messagesById[messageId];
        }

		public void DeleteMessage(string messageId)
        {
            this.ValidateMessageExists(messageId);

            Message message = this.messagesById[messageId];

            this.messagesById.Remove(messageId);

            this.messagesByChannel[message.Channel].Remove(message);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            this.ValidateMessageExists(messageId);

            this.messagesById[messageId].Reactions.Add(reaction);
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (!this.messagesByChannel.ContainsKey(channel))
            {
                throw new ArgumentException();
            }

			List<Message> filteredMessages = this.messagesByChannel[channel];

            if (filteredMessages.Count == 0)
            {
                throw new ArgumentException();
            }

            return filteredMessages;
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
            => this.messagesById.Values
                .Where(m => reactions.All(r => m.Reactions.Contains(r)))
                .OrderByDescending(m => m.Reactions.Count)
                .ThenBy(m => m.Timestamp);

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
            => this.messagesById.Values
                .Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound)
                .OrderByDescending(m => this.messagesByChannel[m.Channel].Count);

        public IEnumerable<Message> GetTop3MostReactedMessages()
            => this.messagesById.Values
                .OrderByDescending(m => m.Reactions.Count)
                .Take(3);

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
            => this.messagesById.Values
                .OrderByDescending(m => m.Reactions.Count)
                .ThenBy(m => m.Timestamp)
                .ThenBy(m => m.Content.Length);

		private void ValidateMessageExists(string messageId)
		{
            if (!this.messagesById.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
		}
    }
}
