using _07.MilitaryElite.Enums;

namespace _07.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        MissionState State { get; }

        void CompleteMission();
    }
}
