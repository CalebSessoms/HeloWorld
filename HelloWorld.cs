using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public GameObject message;
    public float distance = 5;
    bool once;

    void Update()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            if(once == false)
            {

                StartCoroutine(change());
                once = true;
            }
        }
           
    }
    private IEnumerator change()
    {
        Destroy(message);
        yield return new WaitForSeconds(1.5f);
        transform.Translate(-distance, 0, 0);
        Debug.Log("moves");
        once = true;
        yield return new WaitForSeconds(4.5f);
        Application.Quit();
    }
}
