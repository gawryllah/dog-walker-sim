using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

[Obsolete("Not used any more", true)]
public class TaskManagerSO : MonoBehaviour
{
    public SOExtens sOExtens;
    public PlayerStatsSO playerStats;

    private static TaskManagerSO instance;

    [SerializeField] private List<TaskSO> tasksList = new List<TaskSO>();

    public static TaskManagerSO Instance
    {
        get
        {
            return instance;
        }
    }

    public static int lowerPriceRange = 25;
    public static int higherPriceRange = 150;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        StartCoroutine(taskAssigner());
    }


    IEnumerator taskAssigner()
    {
        Debug.Log($"Started task assigner, {GameManager.Instance.GameOn}");

        while (GameManager.Instance.GameOn)
        {
            //yield return new WaitForSeconds(Random.Range(15f, 30f));
            yield return new WaitForSeconds(5f);
            Debug.Log($"Started at {this}");
            var task = ScriptableObject.CreateInstance<TaskSO>();
            var client = sOExtens.getClientExtens()[Random.Range(0, sOExtens.getClientExtens().Count-1)];

            if (client.getCanAssignTask()) {
                client.TaskAssigned();
            
                task.initTask(client, sOExtens.getDogOfOwner(client), Random.Range(lowerPriceRange, higherPriceRange) + playerStats.reputation);
                Debug.Log(task.getTaskInfo());

                tasksList.Add(task);

                StartCoroutine(startClientCooldown(client));
            }
        }
    }

    IEnumerator startClientCooldown(ClientSO client)
    {
        //yield return new WaitForSecondsRealtime(Random.Range(600f, 1200f));

        yield return new WaitForSecondsRealtime(25f);
        client.setAssignTask(true);
        Debug.Log($"At {this}, cooldown status {client.getCanAssignTask()}, for client: {client.getClientInfo()}");

    }
}
