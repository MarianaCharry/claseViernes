namespace Entity.Model.Security
{
    public class Role
    {
     public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public DateTime DeleteAt { get; set; }

    public bool State {  get; set; }

    }
}
