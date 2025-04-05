using System.ComponentModel.DataAnnotations;

public class Author
{
    [Key]
    private int _id;
    public int id
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
    private string _name;
    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    private string _biography;
    public string biography
    {
        get
        {
            return _biography;
        }
        set
        {
            _biography = value;
        }
    }
    private List<Post>? _posts;
    public List<Post>? Posts
    {
        get { return _posts; }
        set { _posts = value; }
    }
    public Author()
    {
    }
    public Author(int id, string name, string biography)
    {
        this._id = id;
        this._name = name;
        this._biography = biography;
    }
}