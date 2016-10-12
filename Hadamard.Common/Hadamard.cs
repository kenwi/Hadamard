using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common
{
    public class Hadamard
    {
        private bool _isRunning;

        private IInputOutput _ioHandler;
        private ICommandHandler _commandHandler;

        public Hadamard(IInputOutput ioHandler)
        {
            _ioHandler = ioHandler;
            _commandHandler = new ChatCommandHandler(ioHandler);
        }

        public void Run()
        {
            _isRunning = true;
            while(_isRunning)
            {
                if (!_ioHandler.IsRegistered)
                    continue;

                _ioHandler.Send("> ");
                var line = _ioHandler.GetInput();
                if (line == null)
                    break;
                if (line.Length == 0)
                    continue;

                var command = _commandHandler.GetCommandKeyword(line);
                var parameters = _commandHandler.GetCommandParameters(line);

                _commandHandler.ReadCommand(command, parameters);
            }
        }
    }
}
