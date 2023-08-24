namespace TodoWithEFCore.Models;

public class Todo
{
    public int Id { get; set; }
    public string Title{ get; set; }

    public bool Completed { get; set; }
    public DateTime Created_on { get; set; }
    public DateTime Updated_on { get; set; }
    public List<Subtask> Subtasks { get; set; }
}
public class Subtask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public DateTime Created_on { get; set; }
    public DateTime Updated_on { get; set; }

    public int TodoId { get; set; }
    public Todo Todo { get; set; }
}