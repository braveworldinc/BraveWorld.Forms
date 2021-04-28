using System;
namespace BWFSamples.Models
{
    public struct ChangeLogEntry
    {
        public ChangeLogEntryType EntryType { get; }
        public string Message { get; }


        public ChangeLogEntry(ChangeLogEntryType entryType, string message)
        {
            EntryType = entryType;
            Message = message;
        }


        public override string ToString() => $"{EntryType.ToString().ToUpper()}: {Message}";
    }

    public enum ChangeLogEntryType
    {
        New,
        Added,
        Updated,
        Fixed,
        Removed
    }
}
