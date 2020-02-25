using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

// Reference 1: https://github.com/Hanslen/Unity-with-MYSQL/blob/master/Assets/Scripts/DatabaseHandler.cs
// Reference 2: http://zetcode.com/csharp/mysql/

public class DatabaseHandler : MonoBehaviour
{
    public enum DATABASESTATE { DEVELOPMENT, PRODUCTION}
    public DATABASESTATE databaseState = DATABASESTATE.DEVELOPMENT;

    // fill these in for production build
    public string host, database, user, password;
    public bool pooling = true;

    private string connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;

    private MD5 _md5Hash;

    private FileHandler fileHandler = new FileHandler();

    public void SetupDatabaseHandler()
    {
        DontDestroyOnLoad(gameObject);

        switch (databaseState)
        {
            case DATABASESTATE.PRODUCTION:
                connectionString = String.Format("Server={0}; Database={1}; User={2}; Password={3}; Pooling={4};", host, database, user, password, pooling ? "True" : "False");
                break;
            case DATABASESTATE.DEVELOPMENT:
                List<string> DBData = LoadDotEnvProperties();
                connectionString = String.Format("Server={0}; Database={1}; User={2}; Password={3}; Pooling={4};", DBData[0], DBData[1], DBData[2], DBData[3], pooling ? "True" : "False");
                break;
            default:
                Logger.WriteToLog("DatabaseHandler: SetupDatabaseHandler(): ERROR: DATABASESTATE has defaulted for some reason!");
                break;
        }

        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.LogFormat("Mysql state: {0}");


        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private List<string> LoadDotEnvProperties()
    {
        List<string> output = new List<string>();

        try
        {
            // have to create a .env file in Assets and then fill in database values
            output = fileHandler.ReadTextFile(".env");
        }catch(Exception e)
        {
            Debug.Log(e);
        }


        return output;
    }

    private void OnApplicationQuit()
    {
        if(con != null)
        {
            if(con.State.ToString() != "Closed")
            {
                con.Close();
                Debug.Log("MySQL Connection Closed!");
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
