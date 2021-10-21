using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distance;

    private bool nearBool = false;

    private GameObject p1 = null;
    private GameObject p1VFX = null;
    private GameObject k1 = null;
    private GameObject k1VFX = null;
    private GameObject pk1 = null;
    private GameObject pk1VFX1 = null;
    private GameObject pk1VFX2 = null;
    private bool p1Hint = false;
    private bool k1Hint = false;
    
    private GameObject p2 = null;
    private GameObject p2VFX = null;
    private GameObject k2 = null;
    private GameObject k2VFX = null;
    private GameObject pk2 = null;
    private GameObject pk2VFX1 = null;
    private GameObject pk2VFX2 = null;
    private bool p2Hint = false;
    private bool k2Hint = false;
    
    private GameObject p3 = null;
    private GameObject p3VFX = null;
    private GameObject k3 = null;
    private GameObject k3VFX = null;
    private GameObject pk3 = null;
    private GameObject pk3VFX1 = null;
    private GameObject pk3VFX2 = null;
    private bool p3Hint = false;
    private bool k3Hint = false;

    public static int hintCollect = 0;
    public static int hintTotal = 6;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //p1
        //assign object and vfx
        if (p1 == null)
        {
            p1 = GameObject.Find("P1 OBJ(Clone)");

            if (p1VFX == null)
            {
                p1VFX = GameObject.Find("P1 VFX");
            }
        }
        //if near object can trigger interact
        if (p1 != null && Nearby(p1) == true)
        {
            Debug.Log("Near P1");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("P1 Interact");
                //hint+1
                if (p1VFX.activeSelf)
                {
                    hintCollect += 1;
                    p1Hint = true;
                }
                //disable VFX
                p1VFX.SetActive(false);
               
            }
        }

        
        //k1
        //assign object and vfx
        if (k1 == null)
        {
            k1 = GameObject.Find("K1 OBJ");

            if (k1VFX == null)
            {
                k1VFX = GameObject.Find("K1 VFX");
            }
        }
        //if near object can trigger interact
        if (k1 != null && Nearby(k1) == true)
        {
            Debug.Log("Near K1");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("K1 Interact");
                //hint+1
                if (k1VFX.activeSelf)
                {
                    hintCollect += 1;
                    k1Hint = true;
                }
                //disable VFX
                k1VFX.SetActive(false);
               
            }
        }

        
        //pK1
        //assign object and vfx
        if (pk1 == null)
        {
            pk1 = GameObject.Find("PK1 OBJ(Clone)");
            
            if (pk1VFX1 == null)
            {
                pk1VFX1 = GameObject.Find("PK1 VFX1");
                if (pk1VFX1!= null && p1Hint == true)
                {
                    pk1VFX1.SetActive(false);
                }
            }
            if (pk1VFX2 == null)
            {
                pk1VFX2 = GameObject.Find("PK1 VFX2");
                if (pk1VFX2!= null && k1Hint == true)
                {
                    pk1VFX2.SetActive(false);
                }
            }
        }
        //if near object can trigger interact
        if (pk1 != null && Nearby(pk1) == true)
        {
            Debug.Log("Near PK1");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("PK1 Interact");
                //hint+1/2
                if (p1Hint == false)
                {
                    hintCollect += 1;
                    pk1VFX1.SetActive(false);
                    p1Hint = true;
                }
                if (k1Hint == false)
                {
                    hintCollect += 1;
                    pk1VFX2.SetActive(false);
                    k1Hint = true;
                }
            }
        }
        
        
        //p2
        //assign object and vfx
        if (p2 == null)
        {
            p2 = GameObject.Find("P2 OBJ(Clone)");

            if (p2VFX == null)
            {
                p2VFX = GameObject.Find("P2 VFX");
            }
        }
        //if near object can trigger interact
        if (p2 != null && Nearby(p2) == true)
        {
            Debug.Log("Near P2");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("P2 Interact");
                //hint+1
                if (p2VFX.activeSelf)
                {
                    hintCollect += 1;
                    p2Hint = true;
                }
                //disable VFX
                p2VFX.SetActive(false);
               
            }
        }
        
        //k2
        //assign object and vfx
        if (k2 == null)
        {
            k2 = GameObject.Find("K2 OBJ");

            if (k2VFX == null)
            {
                k2VFX = GameObject.Find("K2 VFX");
            }
        }
        //if near object can trigger interact
        if (k2 != null && Nearby(k2) == true)
        {
            Debug.Log("Near K2");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("K2 Interact");
                //hint+1
                if (k2VFX.activeSelf)
                {
                    hintCollect += 1;
                    k2Hint = true;
                }
                //disable VFX
                k2VFX.SetActive(false);
               
            }
        }
        
        //pK2
        //assign object and vfx
        if (pk2 == null)
        {
            pk2 = GameObject.Find("PK2 OBJ(Clone)");
            
            if (pk2VFX1 == null)
            {
                pk2VFX1 = GameObject.Find("PK2 VFX1");
                if (pk2VFX1!= null && p2Hint == true)
                {
                    pk2VFX1.SetActive(false);
                }
            }
            if (pk2VFX2 == null)
            {
                pk2VFX2 = GameObject.Find("PK2 VFX2");
                if (pk2VFX2!= null && k2Hint == true)
                {
                    pk2VFX2.SetActive(false);
                }
            }
        }
        //if near object can trigger interact
        if (pk2 != null && Nearby(pk2) == true)
        {
            Debug.Log("Near PK2");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("PK2 Interact");
                //hint+1/2
                if (p2Hint == false)
                {
                    hintCollect += 1;
                    pk2VFX1.SetActive(false);
                    p2Hint = true;
                }
                if (k2Hint == false)
                {
                    hintCollect += 1;
                    pk2VFX2.SetActive(false);
                    k2Hint = true;
                }
            }
        }
        
        
        //p3
        //assign object and vfx
        if (p3 == null)
        {
            p3 = GameObject.Find("P3 OBJ (Clone)");

            if (p3VFX == null)
            {
                p3VFX = GameObject.Find("P3 VFX");
            }
        }
        //if near object can trigger interact
        if (p3 != null && Nearby(p3) == true)
        {
            Debug.Log("Near P3");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("P3 Interact");
                //hint+1
                if (p3VFX.activeSelf)
                {
                    hintCollect += 1;
                    p3Hint = true;
                }
                //disable VFX
                p3VFX.SetActive(false);
               
            }
        }

        //k3
        //assign object and vfx
        if (k3 == null)
        {
            k3 = GameObject.Find("K3 OBJ");

            if (k3VFX == null)
            {
                k3VFX = GameObject.Find("K3 VFX");
            }
        }
        //if near can trigger interact
        if (k3 != null && Nearby(k3) == true)
        {
            Debug.Log("Near K3");
            //if trigger interact, disable VFX and hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("K3 Interact");
                if (k3VFX.activeSelf)
                {
                    hintCollect += 1;
                    k3Hint = true;
                }
                k3VFX.SetActive(false);
                
            }
        }
        
        
        //pK3
        //assign object and vfx
        if (pk3 == null)
        {
            pk3 = GameObject.Find("PK3 OBJ(Clone)");
            
            if (pk3VFX1 == null)
            {
                pk3VFX1 = GameObject.Find("PK3 VFX1");
                if (pk3VFX1!= null && p3Hint == true)
                {
                    pk3VFX1.SetActive(false);
                }
            }
            if (pk3VFX2 == null)
            {
                pk3VFX2 = GameObject.Find("PK3 VFX2");
                if (pk3VFX2!= null && k3Hint == true)
                {
                    pk3VFX2.SetActive(false);
                }
            }
        }
        //if near object can trigger interact
        if (pk3 != null && Nearby(pk3) == true)
        {
            Debug.Log("Near PK3");
            //if trigger interact, disable VFX, hint+1
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("PK3 Interact");
                //hint+1/2
                if (p3Hint == false)
                {
                    hintCollect += 1;
                    pk3VFX1.SetActive(false);
                    p3Hint = true;
                }
                if (k3Hint == false)
                {
                    hintCollect += 1;
                    pk3VFX2.SetActive(false);
                    k3Hint = true;
                }
            }
        }
        
        
    }
    

    bool Nearby(GameObject npc)
    {
        float npcDistance = Vector3.Distance(npc.transform.position, transform.position);
        if (npcDistance <= distance)
        {
            nearBool = true;
        }

        if (npcDistance > distance)
        {
            nearBool = false;
        }

        return nearBool;
    }
}
