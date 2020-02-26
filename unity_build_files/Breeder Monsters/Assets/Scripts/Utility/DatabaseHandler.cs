using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using MySql.Data.MySqlClient;

// TODO I need the javascript functions to access the unity scripts not the other way around. 
// I need to pass in the logged in user's token

// Reference 1: https://github.com/Hanslen/Unity-with-MYSQL/blob/master/Assets/Scripts/DatabaseHandler.cs
// Reference 2: http://zetcode.com/csharp/mysql/
// Reference 3: https://stackoverflow.com/questions/44377680/unity-webgl-and-browser-javascript-communication

public class DatabaseHandler : MonoBehaviour
{
    // fill these in for production build
    public string host, database, user, password;
    public bool pooling = true;

    private string connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;

    private MD5 _md5Hash;

    public void SetupDatabaseHandler()
    {
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
        List<string> DBData = new List<string>();
        DBData = FileHandler.ReadTextFile(".env");
        connectionString = String.Format("Server={0}; Database={1}; User={2}; Password={3}; Pooling={4};", DBData[0], DBData[1], DBData[2], DBData[3], pooling ? "True" : "False");
#endif

#if !UNITY_EDITOR && UNITY_WEBGL
        connectionString = String.Format("Server={0}; Database={1}; User={2}; Password={3}; Pooling={4};", host, database, user, password, pooling ? "True" : "False");
#endif

        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Logger.WriteToLog("DatabaseHandler: SetupDatabaseHandler(): ERROR: keys length doesn't equal values length");
            Debug.LogFormat("Mysql state: {0}");


        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void OnApplicationQuit()
    {
        if(con != null)
        {
            if(con.State.ToString() != "Closed")
            {
                con.Close();
                Logger.WriteToLog("DatabaseHandler: OnApplicationQuit(): MySQL Connection Closed!");
            }
            con.Dispose();
        }
    }

    public string GetFromDatabase(string query)
    {
        cmd = new MySqlCommand(query, con);
        using (rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                return string.Format("Data: {0} {1}", rdr[0], rdr[1]);
            }
        }
        return null;
    }

    public void SendToDatabase(string query, string[] keys, string[] values)
    {
        // TODO Finish this. I don't know if this even works.
        if (keys.Length != values.Length) {
            Logger.WriteToLog("DatabaseHandler: SendToDatabase(): ERROR: keys length doesn't equal values length");
            return;
        }

        cmd = new MySqlCommand(query, con);
        for (int i = 0; i < keys.Length; i++)
        {
            cmd.Parameters.AddWithValue("@"+keys[i], values[i]);
        }
        cmd.Prepare();

    }
}
