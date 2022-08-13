using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DogSO", menuName = "ScriptableObjects/DogSO")]
public class DogSO : ScriptableObject
{
    [SerializeField] private string dogName;
    [SerializeField] [Range(0f, 100f)] private float agressivness; //to other dogs
    [SerializeField] [Range(0f, 100f)] private float listningToLeader; //responsiveness for leader commands (mostly for player)
    [SerializeField] [Range(0f, 100f)] private float sympathyForPlayer; // higher score means more likly dog will follow player's commands
    [SerializeField] [Range(0f, 50f)] private float triggeringRange;


    public void initDog(string dogName, float agressivness, float listningToLeader, float sympathyForPlayer, float triggeringRange)
    {
        this.dogName = dogName;
        this.agressivness = agressivness;
        this.listningToLeader = listningToLeader;
        this.sympathyForPlayer = sympathyForPlayer;
        this.triggeringRange = triggeringRange;

        EditorUtility.SetDirty(this);
    }

    public string getDogName()
    {
        return dogName;
    }

    public float getAgressivness()
    {
        return agressivness;
    }

    public float getListningToLeader()
    {
        return listningToLeader;
    }

    public float getSympathyForPlayer()
    {
        return sympathyForPlayer;
    }
}
