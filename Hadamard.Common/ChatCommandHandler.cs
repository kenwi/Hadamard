using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common
{
    public class ChatCommandHandler : ICommandHandler
    {
        protected delegate void CommandProcessor(string command, IList<string> parameters);
        protected IDictionary<string, CommandProcessor> _commandProcessors;

        private IInputOutput _ioHandler;

        public ChatCommandHandler(IInputOutput ioHandler)
        {
            _ioHandler = ioHandler;

            _commandProcessors = new Dictionary<string, CommandProcessor>()
            {
                {
                    "hello", (command, parameters) =>
                    {
                        _ioHandler.Send("Hello there!");
                    }
                }
            };
        }

        public string[] GetCommandParameters(string line)
        {
            return line.Split(' ').Skip(1).ToArray();
        }

        public string GetCommandKeyword(string line)
        {
            return line.Split(' ')[0].ToLower();
        }

        public void ReadCommand(string command, string[] parameters)
        {
            CommandProcessor processor;
            if (_commandProcessors.TryGetValue(command, out processor))
            {
                try
                {
                    processor(command, parameters);
                }
                catch (Exception ex)
                {
                    _ioHandler.Send("Error: " + ex.Message);
                }
            }
            else
                _ioHandler.Send($"+ Command '{command}' not recognized", command);
        }

        public bool IsOfflineOnly()
        {
            return true;
        }
    }
}
