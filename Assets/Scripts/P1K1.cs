using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1K1 : MonoBehaviour
{
    public GameObject p1;
    public GameObject k1;
    public GameObject p1k1;

    private GameObject p1Spawn;
    public GameObject p1k1Spawn;

    public Transform[] p1Targets;
    public Transform[] k1Targets;
    public Transform[] p1k1Targets;

    public float speed;

    private int p1Current;
    private int k1Current;
    private int p1k1Current;

    public Vector3 d2StartPos;
    public Vector3 d2PickupPos;

    private bool p1k1Bool = false;
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate p1
        p1Spawn = Instantiate(p1,d2StartPos,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (p1k1Spawn != null)
        {
            //p1 move start
            if (p1Spawn != null && p1Spawn.transform.position != p1Targets[p1Current].position)
            {
                Vector3 p1Pos = Vector3.MoveTowards(p1Spawn.transform.position, p1Targets[p1Current].position, speed);
                p1Spawn.GetComponent<Rigidbody>().MovePosition(p1Pos);
            }
            else if (p1Spawn != null && p1Current != p1Targets.Length - 1)
            {
                p1Current = (p1Current + 1) % p1Targets.Length;
                Debug.Log("D2 Pickup POS: " + p1Spawn.transform.position);
            }
            //p1 move ends
            else if (p1Current == p1Targets.Length - 1)
            {
                Debug.Log("p1Current: " + p1Current);
                //k1 move start when p1 move ends
                if (k1 != null && k1.transform.position != k1Targets[k1Current].position)
                {
                    Vector3 k1Pos = Vector3.MoveTowards(k1.transform.position, k1Targets[k1Current].position, speed);
                    k1.GetComponent<Rigidbody>().MovePosition(k1Pos);
                    //TODO: 替换移动方式为，直接设置P和K的坐标为目标坐标（优化）
                    //TODO: 加一个Timer，让P和K在目标坐标停留一定时间，留给玩家触发对话（新需求）
                }
                else if (k1 != null && k1Current != k1Targets.Length - 1)
                {
                    k1Current = (k1Current + 1) % k1Targets.Length;
                }
                //k1 move ends
                else if (k1Current == k1Targets.Length - 1)
                {
                    //Destroy p1 and k1
                    Destroy(k1);
                    Destroy(p1Spawn);

                    //At the same pos spawn p1k1
                    if (p1k1Bool == false)
                    {
                        p1k1Spawn = Instantiate(p1k1, d2PickupPos, Quaternion.identity);
                        p1k1Bool = true;
                    }

                    //p1k1 move starts
                    if (p1k1Spawn.transform.position != p1k1Targets[p1k1Current].position)
                    {
                        Vector3 p1k1Pos = Vector3.MoveTowards(p1k1Spawn.transform.position,
                            p1k1Targets[p1k1Current].position, speed);
                        p1k1Spawn.GetComponent<Rigidbody>().MovePosition(p1k1Pos);
                    }
                    else if (p1k1Current != p1k1Targets.Length - 1)
                    {
                        p1k1Current = (p1k1Current + 1) % p1k1Targets.Length;
                    }
                    else if (p1k1Current == p1k1Targets.Length - 1)
                    {
                        Destroy(p1k1Spawn);
                    }
                }
            }
        }


    }
}
