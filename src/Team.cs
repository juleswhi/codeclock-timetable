namespace CCTT;

class Team {
    public string? Name { get; set; }
    public TimeSpan? Length { get; set; } // Will be null by default

    public Team(string name) {
        Name = name;
    }
}
