using Mmu.LolTimer.Areas.Domain.Models;
using StructureMap;

namespace Mmu.LolTimer.Infrastructure.DependencyInjection
{
    public class LolTimerRegistry : Registry
    {
        public LolTimerRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<LolTimerRegistry>();

                scanner.AddAllTypesOf<JungleCamp>();
                scanner.WithDefaultConventions();
            });

            For<JungleCamp>().Singleton();
        }
    }
}