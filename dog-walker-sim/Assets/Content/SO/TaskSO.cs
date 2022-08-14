using UnityEditor;
using UnityEngine;

public class TaskSO : ScriptableObject
{
    [SerializeField] private ClientSO client;
    [SerializeField] private DogSO dog;
    //[SerializeField] private GameObject address;
    [SerializeField] private string address;
    [SerializeField] [Range(20, 150)] private int price;

    private static int id = 0;

    public void initTask(ClientSO client, DogSO dog, int money)
    {
        this.client = client;
        this.dog = dog;
        address = client.getAddress();
        this.price = money;

        AssetDatabase.CreateAsset(this, $"Assets/Content/SO/Tasks/Task{id}.asset");
        id++;

        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

    public string getTaskInfo()
    {
        return $"At {this}, Client: {client.getClientInfo()}, Dog: {dog.getDogName()}, ad: {address}, price: {price}";
    }
}

