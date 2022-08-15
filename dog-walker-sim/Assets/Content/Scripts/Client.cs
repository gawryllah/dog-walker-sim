using UnityEngine;

public class Client
{
    [SerializeField] private int id;
    public int ID { get { return id; } } //set { id = value; } }

    [SerializeField] private string firstName, surname;
    public string FirstName { get { return firstName; } } //set { firstName = value; } }
    public string Surname { get { return surname; } } //set { surname = value; } }

    [SerializeField] private GameObject address;
    public GameObject Address { get { return address; } }//set { address = value; } }

    [SerializeField] private bool taskAssigned;
    public bool IsTaskAssigned { get { return taskAssigned; } set { taskAssigned = value; } }

    [SerializeField] private Dog dog;
    public Dog Dog { get { return dog; } set { dog = value; } }


    [SerializeField] private float priceFactor;
    public float PriceFactor { get { return priceFactor; } }

    public Client(int id, string firstName, string surname, GameObject address, Dog dog)
    {
        this.id = id;
        this.firstName = firstName;
        this.surname = surname;
        this.address = address;
        this.dog = dog;
        IsTaskAssigned = false;
        priceFactor = Random.Range(0.25f, 1f);
    }

    public Client(ClientSO clientSO)
    {
        this.id = clientSO.ID;
        this.firstName = clientSO.FirstName;
        this.surname = clientSO.Surname;
        this.address = clientSO.Address;
        this.dog = CreateDog(clientSO.DogSO);
        IsTaskAssigned = false;
        priceFactor = clientSO.PriceFactor;
    }

    private Dog CreateDog(DogSO dogSO)
    {
        var dog = new Dog(dogSO.ID, dogSO.DogName, dogSO.DogAgressivness, dogSO.DogListeningToLeader, dogSO.DogSympathyForPlayer, dogSO.DogTriggeringRange);

        return dog;
    }
}
