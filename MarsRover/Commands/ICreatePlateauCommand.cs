using MarsRover.Models.MarsPlateau;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
   public interface ICreatePlataeuCommand:ICommand
    {
        void Inject(IPlateau plataeu);
    }
}
    