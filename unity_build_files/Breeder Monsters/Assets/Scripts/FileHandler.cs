using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteTextFile(string filename, string line)
    {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/" + filename, true);
        writer.WriteLine(line);
        writer.Close();
    }

    public List<string> ReadTextFile(string filename)
    {
        List<string> output = new List<string>();
        StreamReader reader = new StreamReader(Application.dataPath+"/"+filename);
        while(!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine();
            output.Add(inputLine);
        }
        reader.Close();
        Logger.WriteToLog("FileHandler: ReadTextFile(): SUCCESS: file read, returning output list.");
        return output;
    }
}
