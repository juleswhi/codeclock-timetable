namespace CCTT;

class Team {
    public string? Name { get; set; }
    public TimeSpan? Length { get; set; } = TimeSpan.Zero;
    public bool Completed { get; set; } = false;

    public Team(string name) {
        Name = name;
    }
}
