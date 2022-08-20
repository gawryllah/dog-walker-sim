using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskGenerator : MonoBehaviour
{
    [SerializeField] private GameObject playersDogPlace;
    [SerializeField] private SOExtens soExtens;

    [SerializeField] [Range(0, 100)] private int lowerPriceRange = 20; public int LowerPriceRange { get { return lowerPriceRange; } }
    [SerializeField] [Range(0, 100)] private int higerPriceRange = 100; public int HigherPriceRange { get { return higerPriceRange; } }

    [SerializeField] private GameObject block; //for now probably it will be common address for dynamically generated clients

    //[SerializeField] private List<Task> tasksList = new List<Task>();
    [SerializeField] private List<Task> tasksList = new List<Task>(); public List<Task> TasksList { get { return tasksList; } }
    [SerializeField] private List<Client> clientsList = new List<Client>();
    [SerializeField] private List<Dog> dogsList = new List<Dog>();

    [SerializeField] private List<GameObject> instansiatedDogs = new List<GameObject>();

    private static TaskGenerator instance;

    public static TaskGenerator Instance
    {
        get
        {
            return instance;
        }
    }

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
        InitClientsList();
        //InitDogsList();

        StartCoroutine(TaskAssigner());
    }


    IEnumerator TaskAssigner()
    {
        Debug.Log($"Started task assigner, {GameManager.Instance.GameOn}");

        while (GameManager.Instance.GameOn)
        {
            //yield return new WaitForSeconds(Random.Range(15f, 30f));
            yield return new WaitForSeconds(5f);

            var client = clientsList[Random.Range(0, clientsList.Count - 1)];

            if (!client.IsTaskAssigned)
            {

                if (tasksList.Count != 0)
                {
                    //tasksList.Clear();
                    foreach (GameObject go in instansiatedDogs)
                    {
                        Destroy(go);
                    }
                }

                var task = new Task(client, client.Dog, (Random.Range(lowerPriceRange, higerPriceRange) * client.PriceFactor));
                client.IsTaskAssigned = true;

                tasksList.Add(task);

                GameObject dogInstance = Instantiate(task.TaskDog.DogGO, playersDogPlace.transform.position, Quaternion.identity);
                dogInstance.GetComponent<DogUIRenderer>().setName($"{task.TaskDog.DogName}");
                dogInstance.transform.SetParent(playersDogPlace.transform);

                instansiatedDogs.Add(dogInstance);

                Debug.Log($"Task {task.ID} created for: {client.ID} {client.FirstName} {client.Surname}");

                GameManager.Instance.CreateUITask();

                StartCoroutine(StartClientCooldown(client));
            }
        }
    }

    IEnumerator StartClientCooldown(Client client)
    {


        //yield return new WaitForSecondsRealtime(Random.Range(600f, 1200f));

        yield return new WaitForSeconds(25f); //still thinking if i want to co
        if (client.IsTaskAssigned)
            client.IsTaskAssigned = false;

        Debug.Log($"At {this}, task assigned: {client.IsTaskAssigned}, for client: {client.ID} {client.FirstName} {client.Surname}");

    }


    void InitClientsList()
    {
        foreach (ClientSO clientSO in soExtens.ClientsSO)
        {
            var client = new Client(clientSO);
            clientsList.Add(client);
        }
    }

    public void printTask(Task task)
    {
        Debug.Log($"Task {task.ID}: {task.TaskClient.FirstName} {task.TaskClient.Surname}, {task.TaskDog.DogName}, {task.TaskPrice}");
    }

    /*
    void InitDogsList()
    {
        foreach (DogSO dogSO in soExtens.DogsSO)
        {
            var dog = new Dog(dogSO.ID, dogSO.DogName, dogSO.DogAgressivness, dogSO.DogListeningToLeader, dogSO.DogSympathyForPlayer, dogSO.DogTriggeringRange);
            dogsList.Add(dog);
        }
    }
    */



}
