using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JavascriptHook : MonoBehaviour
{

    [SerializeField] private Text stringText;

    public void SetString(string str)
    {
        stringText.text = str.ToString();
    }

    public void TestJson(string json)
    {
        JsonObject jsonObject = JsonUtility.FromJson<JsonObject>(json);
        stringText.text = string.Format("Name: {0}; Age: {1}", jsonObject.name, jsonObject.age);
    }


    public class JsonObject
    {
        public string name;
        public int age;
    }
}
