using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private SOExtens soExtens;

    [SerializeField] [Range(0, 100)] private int lowerPriceRange = 20; public int LowerPriceRange { get { return lowerPriceRange; } }
    [SerializeField] [Range(0, 100)] private int higerPriceRange = 100; public int HigherPriceRange { get { return higerPriceRange; } }

    //[SerializeField] private List<Task> tasksList = new List<Task>();
    public List<Task> tasksList = new List<Task>();
    [SerializeField] private List<Client> clientsList = new List<Client>();
    [SerializeField] private List<Dog> dogsList = new List<Dog>();

    public GameObject texts;
    public TMP_Text textPrefab;

    private static TaskManager instance;

    public static TaskManager Instance
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
                var task = new Task(client, client.Dog, (Random.Range(lowerPriceRange, higerPriceRange) * client.PriceFactor));
                client.IsTaskAssigned = true;

                tasksList.Add(task);

                Debug.Log($"Task created for: {client.ID} {client.FirstName} {client.Surname}");

                DrawTaskOnUI();

                StartCoroutine(StartClientCooldown(client));
            }
        }
    }

    IEnumerator StartClientCooldown(Client client)
    {
        //yield return new WaitForSecondsRealtime(Random.Range(600f, 1200f));

        yield return new WaitForSecondsRealtime(25f);
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

    void DrawTaskOnUI()
    {
        var text = Instantiate(textPrefab);
        text.transform.SetParent(texts.transform);
        text.text = $"Task: Client: {tasksList[tasksList.Count - 1].TaskClient.FirstName} {tasksList[tasksList.Count - 1].TaskClient.Surname}, dog: {tasksList[tasksList.Count - 1].TaskDog.DogName} ";
        text.enabled = true;
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
