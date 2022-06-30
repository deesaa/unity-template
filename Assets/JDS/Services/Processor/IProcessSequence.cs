namespace JDS.Services.Processor
{
    public interface IProcessSequence : IProcess, IProgressable
    {
        IProcessSequence Append(IProcess process);
    }
}