using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DogSO", menuName = "ScriptableObjects/DogSO")]
public class DogSO : ScriptableObject
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

    [SerializeField] private string dogName;
    [SerializeField] [Range(0f, 100f)] private float agressivness; //to other dogs
    [SerializeField] [Range(0f, 100f)] private float listeningToLeader; //responsiveness for leader commands (mostly for player)
    [SerializeField] [Range(0f, 100f)] private float sympathyForPlayer; // higher score means more likly dog will follow player's commands
    [SerializeField] [Range(0f, 50f)] private float triggeringRange;

    public string DogName { get { return dogName; } }
    public float DogAgressivness { get { return agressivness; } }
    public float DogListeningToLeader { get { return listeningToLeader; } }
    public float DogSympathyForPlayer { get { return sympathyForPlayer; } }
    public float DogTriggeringRange { get { return triggeringRange; } }


    public void initDog(string dogName, float agressivness, float listningToLeader, float sympathyForPlayer, float triggeringRange)
    {
        this.dogName = dogName;
        this.agressivness = agressivness;
        this.listeningToLeader = listningToLeader;
        this.sympathyForPlayer = sympathyForPlayer;
        this.triggeringRange = triggeringRange;
        id = Ids;

        EditorUtility.SetDirty(this);
    }


}
