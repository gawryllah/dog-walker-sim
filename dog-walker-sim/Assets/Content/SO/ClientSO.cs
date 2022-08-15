using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "ClientSO", menuName = "ScriptableObjects/ClientSO")]
public class ClientSO : ScriptableObject
{


    private static int Ids = 0;

    private int id;

    public int ID
    {
        get
        {
            return id;
        }
    }

    [SerializeField] private string firstName, surname;
    public string FirstName { get { return firstName; } }
    public string Surname { get { return surname; } }

    [SerializeField] GameObject addressGO;
    public GameObject Address { get { return addressGO; } }

    [SerializeField] private DogSO dogSO;
    public DogSO DogSO { get { return dogSO; } set { dogSO = value; } }

    [SerializeField] private float priceFactor;
    public float PriceFactor { get { return priceFactor; } }



    public void initClient(string firstName, string surname, GameObject address)
    {
        this.firstName = firstName;
        this.surname = surname;
        this.addressGO = address;
        id = Ids;

        priceFactor = Random.Range(0.25f, 1f);

        EditorUtility.SetDirty(this);

        Debug.Log($"At {this}, {name} {Ids}");

        Ids++;
    }

}
