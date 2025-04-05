public class PostCategory
{
    private int _postId;
    public int PostId { get { return _postId; } set { _postId = value; } }

    private Post? _post;
    public Post? Post { get { return _post; } set { _post = value; } }
    private int _categoryId;
    public int CategoryId { get { return _categoryId; } set { _categoryId = value; } }
    private Category? _category;
    public Category? Category { get { return _category; } set { _category = value; } }
}

