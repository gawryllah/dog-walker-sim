using UnityEngine;
using Random = UnityEngine.Random;

public class Dog
{
    [SerializeField] private int id;
    public int ID { get { return id; } } //set { id = value; } }

    [SerializeField] private string dogName; 
    [SerializeField] [Range(0f, 100f)] private float agressivness; //to other dogs
    [SerializeField] [Range(0f, 100f)] private float listeningToLeader; //responsiveness for leader commands (mostly for player)
    [SerializeField] [Range(0f, 100f)] private float sympathyForPlayer; // higher score means more likly dog will follow player's commands
    [SerializeField] [Range(0f, 50f)] private float triggeringRange;
    [SerializeField] private GameObject dogGO;



    public string DogName { get { return dogName; } }
    public float DogAgressivness { get { return agressivness; } }
    public float DogListeningToLeader { get { return listeningToLeader; } }
    public float DogSympathyForPlayer { get { return sympathyForPlayer; } }
    public float DogTriggeringRange { get { return triggeringRange; } }
    public GameObject DogGO { get { return dogGO; } }

    public Dog(int id, string dogName, float agressivness, float listeningToLeader, float sympathyForPlayer, float triggeringRange, GameObject dogGO)
    {
        this.id = id;
        this.dogName = dogName;
        this.agressivness = agressivness;
        this.listeningToLeader = listeningToLeader;
        this.sympathyForPlayer = sympathyForPlayer;
        this.triggeringRange = triggeringRange;
        this.dogGO = dogGO;
    }

    public Dog(DogSO dogSO)
    {
        this.id = dogSO.ID;
        this.dogName = dogSO.DogName;
        this.agressivness = dogSO.DogAgressivness;
        this.listeningToLeader = dogSO.DogListeningToLeader;
        this.sympathyForPlayer = dogSO.DogSympathyForPlayer;
        this.triggeringRange = dogSO.DogSympathyForPlayer;
        this.dogGO = dogSO.DogGO;
        //this.dogGO.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);


    }
}
