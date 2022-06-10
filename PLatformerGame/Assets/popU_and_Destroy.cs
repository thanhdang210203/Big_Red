using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popU_and_Destroy : MonoBehaviour
{
    public float timeToDestroy;
    public float WaitForPopUp;
    public GameObject PopUp;
    // Start is called before the first frame update

    private void Start()
    {
        PopUp.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.tag == "Player")
        {
            StartCoroutine(PopUP());
            Destroy(this.gameObject, timeToDestroy);
        }
    }
    IEnumerator PopUP()
    {
        yield return new WaitForSeconds(WaitForPopUp);
        PopUp.SetActive(true);
    }

   
}
