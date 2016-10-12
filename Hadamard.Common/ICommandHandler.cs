namespace Hadamard.Common
{
    internal interface ICommandHandler
    {
        string[] GetCommandParameters(string line);
        string GetCommandKeyword(string line);
        void ReadCommand(string command, string[] parameters);
        bool IsOfflineOnly();
    }
}