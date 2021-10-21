using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PK3 : MonoBehaviour
{
     public GameObject p;
    public GameObject k;
    public GameObject pk;

    private GameObject pSpawn;
    public GameObject pkSpawn;

    public Transform[] pTargets;
    public Transform[] kTargets;
    public Transform[] pkTargets;

    public float speed;

    private int pCurrent;
    private int kCurrent;
    private int pkCurrent;

    public Vector3 startPos;
    public Vector3 pickupPos;

    private bool pkBool = false;
    


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate p
        pSpawn = Instantiate(p,startPos,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (pkSpawn != null)
        {
            //p move start
            if (pSpawn != null && pSpawn.transform.position != pTargets[pCurrent].position)
            {
                Vector3 pPos = Vector3.MoveTowards(pSpawn.transform.position, pTargets[pCurrent].position, speed);
                pSpawn.GetComponent<Rigidbody>().MovePosition(pPos);
            }
            else if (pSpawn != null && pCurrent != pTargets.Length - 1)
            {
                pCurrent = (pCurrent + 1) % pTargets.Length;
                Debug.Log("D2 Pickup POS: " + pSpawn.transform.position);
            }
            //p move ends
            else if (pCurrent == pTargets.Length - 1)
            {
                //Debug.Log("p1Current: " + pCurrent);
                //k move start when p1 move ends
                if (k != null && k.transform.position != kTargets[kCurrent].position)
                {
                    Vector3 kPos = Vector3.MoveTowards(k.transform.position, kTargets[kCurrent].position, speed);
                    k.GetComponent<Rigidbody>().MovePosition(kPos);
                }
                else if (k != null && kCurrent != kTargets.Length - 1)
                {
                    kCurrent = (kCurrent + 1) % kTargets.Length;
                }
                //k move ends
                else if (kCurrent == kTargets.Length - 1)
                {
                    //Destroy p and k
                    Destroy(k);
                    Destroy(pSpawn);

                    //At the same pos spawn pk
                    if (pkBool == false)
                    {
                        pkSpawn = Instantiate(pk, pickupPos, Quaternion.identity);
                        pkBool = true;
                    }

                    //pk move starts
                    if (pkSpawn.transform.position != pkTargets[pkCurrent].position)
                    {
                        Vector3 pkPos = Vector3.MoveTowards(pkSpawn.transform.position,
                            pkTargets[pkCurrent].position, speed);
                        pkSpawn.GetComponent<Rigidbody>().MovePosition(pkPos);
                    }
                    else if (pkCurrent != pkTargets.Length - 1)
                    {
                        pkCurrent = (pkCurrent + 1) % pkTargets.Length;
                    }
                    else if (pkCurrent == pkTargets.Length - 1)
                    {
                        Destroy(pkSpawn);
                    }
                }
            }
        }


    }
}
