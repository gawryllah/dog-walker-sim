using UnityEngine;

public class Task
{
    private static int Ids = 0;
    private int id;
    public int ID { get { return id; } }


    [SerializeField] private Client client; public Client TaskClient { get { return client; } }
    [SerializeField] private Dog dog; public Dog TaskDog { get { return dog; } }
    [SerializeField] private GameObject address; public GameObject TaskAddress { get { return address; } }
    [SerializeField] private float price; public float TaskPrice { get { return (int)price; } }

    [SerializeField] private bool isTaskStarted; public bool IsTaskStarted { get { return isTaskStarted; } set { isTaskStarted = value; } }

    public Task(Client client, Dog dog, float price)
    {
        this.client = client;
        this.dog = dog;
        address = client.Address;
        this.price = price;
        id = Ids;
        Ids++;
        isTaskStarted = false;
    }
}
