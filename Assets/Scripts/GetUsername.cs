using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GetUsername : MonoBehaviour
{
    [SerializeField] TextMesh usernameText;
    void Start()
    {
       usernameText.text = Social.localUser.userName.ToString();       
    }

    
}
