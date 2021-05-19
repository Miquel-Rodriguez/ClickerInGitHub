using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateMissions : MonoBehaviour
{
    public GameObject missionPrefab;
    public List<string> descsTier1,descTier2,descTier3;
    // Start is called before the first frame update
    void Start()
    {
        readFile("Tier1.txt");

        for (int i = 0; i < 5; i++)
        {
            
            GameObject mission = Instantiate(missionPrefab, this.gameObject.transform) as GameObject;
            mission.GetComponent<Mission>().missionID = i+1;
            mission.GetComponent<Mission>().missionName = "Mission "+(i+1);
            mission.GetComponent<Mission>().missionDescription = descsTier1[Random.Range(0, descsTier1.Count-1)];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readFile(string file)
    {
        FileInfo theSourceFile = null;
        StreamReader reader = null;
        string text = " ";
        theSourceFile = new FileInfo(file);
        reader = theSourceFile.OpenText();
        while (text != null)
        {
            text = reader.ReadLine();
            descsTier1.Add(text);
        }
        for (var i = descsTier1.Count - 1; i > -1; i--)
        {
            if (descsTier1[i] == "")
                descsTier1.RemoveAt(i);
        }
    }
}
