using ContactDetails.Actions;
using ContactManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManagerApp
{
    internal class Repl
    {
        private TextReader _input;
        private TextWriter _output;
        private Commands.Commands _commands;
        public Repl(TextReader input, TextWriter output, ContactStore contactStore, Actions actions) 
        {
            _input = input;
            _output = output;
            _commands = CommandFactory(contactStore, actions);
        }

        public void run() 
        {
            bool isQuit = false;
            while (!isQuit)
            {
                isQuit =TryMapToCommand();
            }
        }
        private bool TryMapToCommand() 
        {
            _output.WriteLine($"Enter Command: List, Add, Delete, Find, Load, Save, Quit");
            var cmd = Console.ReadLine().ToLower();
            bool isQuit = false;
            bool isSucessful = false;
            switch (cmd)
            {
                case "quit":
                    isQuit = true;
                    break;
                case "add":
                    _output.WriteLine($"Enter contact detail:");
                    isSucessful =_commands.Add(Console.ReadLine());
                    break;
                case "remove":
                    _output.WriteLine($"Enter firatname:");
                    isSucessful =_commands.Remove(Console.ReadLine());
                    break;
                case "load":
                    isSucessful =_commands.Load();
                    break;
                case "list":
                    foreach (var contact in _commands.List())
                    {
                        _output.WriteLine(contact);
                    }
                    isSucessful = true;
                    break;
                case "save":
                    isSucessful =_commands.Save();
                    break;
                default:
                    cmd = $"Inavlid Command {cmd}";
                    isSucessful = false;
                    break;
            }
            _output.WriteLine($"Is Operation sucessful: {cmd}");
            return isQuit;
        }
        
        public static void Command() { }
        public static Commands.Commands CommandFactory(ContactStore contactStore, Actions actions)
        {
            Commands.Commands commandOverrived = null;
            if (contactStore != null)
            {
                commandOverrived = new Commands.Commands(contactStore, actions);
            }
            return commandOverrived;
        }
    }
}
