[System.Serializable]
public class Reward
{
    public string name;
    public string description;
    public Sprite icon;

    public Reward(string name, string description, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
    }

    public void ClaimReward()
    {
        Debug.Log("Reward claimed: " + name);
    }
}
