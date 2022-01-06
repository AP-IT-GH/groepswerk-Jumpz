using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentProjectileHit : MonoBehaviour
{

    //public GameObject Target1;
    //public GameObject Target2;
    //public GameObject Target3;
    //public GameObject Target4;
    //public GameObject Target5;
    //public GameObject Target6;
    //public GameObject Target7;
    //public GameObject Target8;
    //public GameObject Target9;
    //public GameObject Target10;
    //public GameObject Target11;
    //public GameObject Target12;
    List<GameObject> targets = new List<GameObject>();
    public Material Green;
    public Material Default;


    private void Start()
    {

        for (int i = 1; i < 13; i++)
        {
            targets.Add(GameObject.Find("Target" + i));
            //Debug.Log(GameObject.Find("Target" + i));
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("HIT");

            GetNewTarget(other.gameObject);
            AgentBehaviour.agentInstance.AddReward(1f);
            AgentBehaviour.agentInstance.hitTarget = true;
            AgentBehaviour.agentInstance.EndEpisode();
            Debug.Log("New episode");
        }
        else if (other.gameObject.CompareTag("Dht"))
        {
            Debug.Log("HIT WRONG ONE");
        }
        else
        {
            Debug.Log("MISSED");
        }
        Destroy(gameObject);
    }

    public void GetNewTarget(GameObject currentTarget)
    {
        var parent = currentTarget.transform.parent;
        var colorObject = parent.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        colorObject.GetComponent<Renderer>().material = Default;
        int random;

        List<GameObject> targetToChoose = targets;
        targetToChoose.Remove(parent.gameObject);

        GameObject chosenTarget;

        random = Random.Range(0, 11);


        chosenTarget = targetToChoose[random];

        var chosenColor = chosenTarget.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        chosenColor.GetComponent<Renderer>().material = Green;
        chosenTarget.transform.GetChild(1).tag = "Target";

        currentTarget.gameObject.tag = "Dht";
        ScoreManager.instance.AddAgentPoint();

    }
}

