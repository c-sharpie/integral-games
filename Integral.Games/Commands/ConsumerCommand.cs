using Integral.Abstractions;
using Integral.Consumers;

namespace Integral.Commands
{
    public class ConsumerCommand<Consumable> : Executable
        where Consumable : notnull
    {
        private readonly Consumable consumable;

        private readonly Consumer<Consumable> consumer;

        public ConsumerCommand(Consumable consumable, Consumer<Consumable> consumer)
        {
            this.consumable = consumable;
            this.consumer = consumer;
        }

        public void Execute() => consumer.Consume(consumable);
    }
}