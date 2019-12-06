namespace Domain
{
    public class User
    {
        public readonly string Name;
        public int ProjectCount { get; private set; }

        public User(string name)
        {
            Name = name;
        }

        public void AddProject()
        {
            ProjectCount = ProjectCount + 1;
        }
    }
}