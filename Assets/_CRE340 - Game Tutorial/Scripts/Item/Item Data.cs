[System.Serializable]

public class ItemData
{
    public string itemName;
    public string description;

    public ItemData()
    {
        itemName = "Generic Item";
        description = "A generic item that does things.";
    }

    public ItemData(string newItemName, string newDescription)
    {
        itemName = newItemName;
        description = newDescription;
    }
}
