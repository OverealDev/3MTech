
public class Item
{
    public int Id { get; set; }
    
    public string name;

    public float price;

    public TagType tag;


}

public enum TagType
{
    Food,
    Cleaning_Stuff,
    Entertainment
}