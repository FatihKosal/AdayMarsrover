using MarsRover.Models.MarsPlateau;

namespace MarsRover.Commands
{
    public    class CreatePlateauCommand : ICreatePlataeuCommand
    {
        public Size Size { get;private set; }
        private IPlateau Plateau { get; set; }

        public CreatePlateauCommand(Size size)
        {
            Size = size;
        }
        public void Execute()
        {
            Plateau.SetSize(Size);
        }

        public void Inject(IPlateau plataeu)
        {
            Plateau = plataeu;
        }

        CommandType ICommand.GetType()
        {
            return CommandType.CreatePlateau;
        }
    }
}
