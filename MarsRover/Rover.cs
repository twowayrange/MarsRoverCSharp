using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }
        public int RoverType { get; set; }


        //public Rover(string commandType)
        //{
        //    CommandType = commandType;
        //    if (String.IsNullOrEmpty(commandType))
        //    {
        //        throw new ArgumentNullException(commandType, "Command type required.");
        //    }
        //}


        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public void ReceiveMessage(Message message)
        {
            for (int i = 0; i < message.Commands.Length; i++)
            {
                if (message.Commands[i].CommandType == "MODE_CHANGE")
                {
                    Mode = message.Commands[i].NewMode;
                }

                else if (message.Commands[i].CommandType == "MOVE")
                {
                    if (Mode != "LOW_POWER")

                        Position = message.Commands[i].NewPostion;
                }
            }
        }

        //Set command, message, and rover to receive commands

         //Command[] commands = {new Command("MOVE", 5000)};
         // Message newMessage = new Message("Test message with one command", commands);
         // Rover newRover = new Rover(98382);

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
