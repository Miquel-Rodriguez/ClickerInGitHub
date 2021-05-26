using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthParticlesManager : MonoBehaviour
{
    [SerializeField] GameObject clickEffect;
    private Vector2 mousePos;

    private void Start()
    {
        clickEffect.SetActive(false);
    }
    void Update()
    {
        StartCoroutine(hearts());
    }

    private IEnumerator hearts()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickEffect.SetActive(true);
            clickEffect.transform.position = new Vector2(mousePos.x, mousePos.y);
            yield return new WaitForSeconds(1f);
            clickEffect.SetActive(false);
            
           
        }
    }
}
