namespace ForcesOfCorruptionModdingTool.Configuration
{
    public class UsedSoftwareInformation
    {
        public string Name { get; }
        public string Creator { get; }

        public UsedSoftwareInformation(string name, string creator)
        {
            Name = name;
            Creator = creator;
        }
    }
}
