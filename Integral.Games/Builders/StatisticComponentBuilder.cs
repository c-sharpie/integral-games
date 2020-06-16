using System;
using Integral.Assemblers;
using Integral.Components;

namespace Integral.Builders
{
    public sealed class StatisticComponentBuilder<Key> : ComponentBuilder<StatisticComponent<Key>, StatisticComponentAssembler<Key>>
        where Key : notnull
    {
        public override StatisticComponent<Key> Build(Action<StatisticComponentAssembler<Key>> action)
        {
            StatisticCollectionComponent<Key> statisticCollectionComponent = new StatisticCollectionComponent<Key>(Composition!);
            StatisticCollectionAssembler<Key> statisticCollectionAssembler = new StatisticCollectionAssembler<Key>(statisticCollectionComponent);
            action(statisticCollectionAssembler);
            return statisticCollectionComponent;
        }
    }
}