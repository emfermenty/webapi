using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    private int _id;
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    private string _category_Name;
    public string Category_Name
    {
        get
        {
            return _category_Name;
        }
        set
        {
            _category_Name = value;
        }
    }
    public List<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    public Category()
    {

    }
    public Category(int id, string name)
    {
        this._id = id;
        this._category_Name = name;
    }
}