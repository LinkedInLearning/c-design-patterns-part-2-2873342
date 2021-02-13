using System.Threading.Tasks;

namespace HPlusSports.Core.Commands
{
    public interface IUpdateCommand
    {
        Task Update();
        Task<bool> CanUpdate();
    }
}