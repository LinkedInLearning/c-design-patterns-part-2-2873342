using System.Threading.Tasks;

namespace HPlusSports.Core.Commands{
    public interface IEntityUpdateCommand
    {
        Task Invoke();
        Task<bool> CanInvoke();
    }
}