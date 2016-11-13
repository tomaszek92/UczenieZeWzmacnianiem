namespace UczenieZeWzmacnianiem.WinForms
{
    public class SimulatorSettings
    {
        public int WorldSize { get; private set; }
        public int NumberOfExits { get; private set; }
        public int MaxOfAgentSteps { get; private set; }
        public int NumberOfTests { get; private set; }
        public int NumberOfWalls { get; private set; }

        public SimulatorSettings(int worldSize, int numberOfExits, int maxOfAgentSteps, int numberOfTests,
            int numberOfWalls)
        {
            WorldSize = worldSize;
            NumberOfExits = numberOfExits;
            MaxOfAgentSteps = maxOfAgentSteps*worldSize;
            NumberOfTests = numberOfTests;
            NumberOfWalls = numberOfWalls;
        }
    }
}