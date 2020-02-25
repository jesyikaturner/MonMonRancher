using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Logger
{
    public static List<string> log = new List<string>();
    private static FileHandler fileHandler = new FileHandler();

    public static void SetUpLogger()
    {
        // TODO read from file if it exists
        try
        {
            log = fileHandler.ReadTextFile("logfile");
        }
        catch(Exception e)
        {
            string line = string.Format("Logger: SetUpLogger(): ERROR: {0} \n Creating new logfile!", e);
            fileHandler.WriteTextFile("logfile", line);
            AssetDatabase.ImportAsset("Assets/logfile");
        }
    }

    public static void WriteToLog(string data)
    {
        fileHandler.WriteTextFile("logfile", data);
    }
}
