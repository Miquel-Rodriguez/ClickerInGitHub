using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateMissions : MonoBehaviour
{
    public GameObject missionPrefab, gameController;
    public List<string> descsTier1,descTier2,descTier3;
    public List<GameObject> currentMissions;
    // Start is called before the first frame update
    void Start()
    {
        readFile("Tier1.txt");

        generate5Missions();
        
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

    public void generate5Missions() {
        for (int i = 0; i < 5; i++)
        {

            GameObject mission = Instantiate(missionPrefab, this.gameObject.transform) as GameObject;
            mission.GetComponent<Mission>().missionID = i;
            mission.GetComponent<Mission>().missionName = "Mission " + (i + 1);
            mission.GetComponent<Mission>().missionDescription = descsTier1[Random.Range(0, descsTier1.Count - 1)];
            mission.GetComponent<Mission>().numberController = gameController;
            mission.GetComponent<Mission>().generator = this.gameObject;
            currentMissions.Add(mission);
        }
        
    }

    public void deleteAllMissions() {
        for (int i = 0; i < currentMissions.Count; i++)
        {
            Destroy(currentMissions[i].gameObject);
        }
        currentMissions.Clear();
    }

    public void deleteMission(int id) {
        for (int i = 0; i < currentMissions.Count-1; i++)
        {
            if (currentMissions[i].GetComponent<Mission>().missionID == id) 
            {
                currentMissions.RemoveAt(i);
            }
        }
    }
}
