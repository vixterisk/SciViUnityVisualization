using System;

[Serializable]
public class InvalidSettingsFormatException : Exception
{
    public InvalidSettingsFormatException() { }

    public InvalidSettingsFormatException(string message)
        : base(message) { }
}

public class NotConfiguredSettingsException : Exception
{
    public NotConfiguredSettingsException() { }

    public NotConfiguredSettingsException(string message)
        : base(message) { }
}
