using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour
{
    public float delay = 0.0f;
    private string currentText = "";
    private int random;
    private string code = "";
    private string ex1 = "from twisted.internet import reactor\nfrom twisted.internet.protocol import Protocol, ClientFactory\nclass SimpleClient(Protocol):\ndef connectionMade(self):\ndef dataReceived(self, data):\nprint 'Server Said: ', data\nself.transport.loseConnection()\ndef connectionLost(self, reason):\nprint 'Connection Lost %s ' %(reason)\nclass SimpleClientFactory(ClientFactory):\n protocol = SimpleClient\ndef clientConnectionFailed(self, connector, reason) :\nprint 'Connection Failed!!'\n reactor.stop()\nreactor.stop()\nreactor.connectTCP('localhost', 8000, SimpleClientFactory())\nreactor.run()";
    private string ex2 = "hola";
    private string ex3 = "hola222";
    private string ex4 = "a\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na";
    bool qadaws = false;
    int aux1 = 0;

    private void Start()
    {
        randomString();
    }
    IEnumerator showText()
    {
        int i;
        for ( i = aux1 +1; i<code.Length +1; i++)
        {
                currentText = code.Substring(0, i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
                aux1++;
            break;
        }
        Debug.Log(i);
        Debug.Log(code.Length);
        if (i == code.Length + 1)
        {
            randomString();
            currentText = "";
            aux1 = 0;
            print("se ejecuta");
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            StartCoroutine(showText()); 
        }

     
    }

    private void randomString()
    {
        random = Random.Range(1, 5);

        switch (random)
        {
            case 1:
                code = ex1;
                break;
            case 2:
                code = ex2;
                break;
            case 3:
                code = ex3;
                break;
            case 4:
                code = ex4;
                break;
        }
    }
}
