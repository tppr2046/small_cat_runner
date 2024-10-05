using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CountingData", menuName = "Access Counting Data", order = 0)]
public class DataScriptableObject : ScriptableObject
{
    [SerializeField]
    public List<CountingData> countingdata;


    [System.Serializable]
    public class CountingData
    {
        [SerializeField]
        public string timeStamp;

        [SerializeField]
        public bool win;
        [SerializeField]
        public int score;
    }

}
