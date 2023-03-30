using System;

[Serializable]
public class InvalidSettingsFormatException : Exception
{
    public InvalidSettingsFormatException() { }

    public InvalidSettingsFormatException(string message)
        : base(message) { }
}
