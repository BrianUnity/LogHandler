using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Logic : MonoBehaviour
{
    void Start()
    {
        Debug.unityLogger.logHandler = new MyLogger();
    }

    void Update()
    {
        logStrings.Clear();
        
        c.CrashFuntion();
    }

    private MyClass c = new MyClass();
    
    public static List<string> logStrings = new List<string>();

    void OnGUI()
    {
        int y = 0;
        foreach (var s in logStrings)
        {
            GUI.Label(new Rect(0f, y * 200f, 2000f, 200f), s);

            y++;
        }
    }
}

public class MyClass
{
    public void CrashFuntion()
    {
        throw new Exception("ThownException");
    }
}

public class MyLogger : ILogger
{
    public MyLogger()
    {
        logHandler = this;
    }
    
    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
        Logic.logStrings.Add(string.Format(format, args));
    }

public void LogException(Exception exception, Object context)
{
    Logic.logStrings.Add($"MyLoggerException: {exception.Message} --- {exception.StackTrace}");
}

    public bool IsLogTypeAllowed(LogType logType)
    {
        return true;
    }

    public void Log(LogType logType, object message)
    {
        Logic.logStrings.Add($"MyLogger: {(string)message}");
    }

    public void Log(LogType logType, object message, Object context)
    {
        Logic.logStrings.Add($"MyLogger: {(string)message}");
    }

    public void Log(LogType logType, string tag, object message)
    {
        Logic.logStrings.Add($"MyLogger: {(string)message}");
    }

    public void Log(LogType logType, string tag, object message, Object context)
    {
        Logic.logStrings.Add($"MyLogger: {(string)message}");
    }

    public void Log(object message)
    {
        Logic.logStrings.Add($"MyLogger: {(string)message}");
    }

    public void Log(string tag, object message)
    {
    }

    public void Log(string tag, object message, Object context)
    {
        Logic.logStrings.Add($"MyLogger: {(string)message}");
    }

    public void LogWarning(string tag, object message)
    {
        Logic.logStrings.Add($"MyLoggerWarning: {(string)message}");
    }

    public void LogWarning(string tag, object message, Object context)
    {
        Logic.logStrings.Add($"MyLoggerWarning: {(string)message}");
    }

    public void LogError(string tag, object message)
    {
        Logic.logStrings.Add($"MyLoggerError: {(string)message}");
    }

    public void LogError(string tag, object message, Object context)
    {
        Logic.logStrings.Add($"MyLoggerError: {(string)message}");
    }

    public void LogFormat(LogType logType, string format, params object[] args)
    {
        Logic.logStrings.Add(string.Format(format, args));
    }

    public void LogException(Exception exception)
    {
        Logic.logStrings.Add($"MyLoggerException2: {exception.Message} --- {exception.StackTrace}");
    }

    public ILogHandler logHandler { get; set; }
    public bool logEnabled { get; set; } = true;
    public LogType filterLogType { get; set; } = LogType.Log;
}
