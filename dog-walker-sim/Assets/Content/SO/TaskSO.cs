/*
using UnityEditor;
using UnityEngine;

public class TaskSO : ScriptableObject
{
    [SerializeField] private ClientSO client;
    [SerializeField] private DogSO dog;
    //[SerializeField] private GameObject address;
    [SerializeField] private GameObject address;
    [SerializeField] private int price;

    private static int id = 0;

    public void initTask(ClientSO client, DogSO dog, int money)
    {
        this.client = client;
        this.dog = dog;
        address = client.Address;
        this.price = money;

        AssetDatabase.CreateAsset(this, $"Assets/Content/SO/Tasks/Task{id}.asset");
        id++;

        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }


}
*/

