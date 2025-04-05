using System.ComponentModel.DataAnnotations;
using System.Numerics;
public class Post
{
    [Key]
    private int _Id;
    public int Id
    {
        get
        {
            return _Id;
        }
        set
        {
            _Id = value;
        }
    }
    private string _name;
    public string Name
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
    private string _description;
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    private int _authorid;
    public int Authorid
    {
        get
        {
            return _authorid;
        }
        set
        {
            _authorid = value;
        }
    }
    private Author? _author;
    public Author? Author
    {
        get { return _author; }
        set { _author = value; }
    }
    private int _categoryid;
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }

    private int _post_rating;
    public int post_rating
    {
        get
        {
            return _post_rating;
        }
        set
        {
            _post_rating = value;
        }
    }
    public virtual List<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    public Post()
    {
    }
    public Post(int id, string name, string description, int authorid, int rating, int categoryid)
    {
        this._Id = id;
        this._name = name;
        this._description = description;
        this._post_rating = rating;
        this._authorid = authorid;
        this._categoryid = categoryid;
    }

}
