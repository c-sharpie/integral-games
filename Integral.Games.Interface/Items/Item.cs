using Integral.Actors;

namespace Integral.Items
{
    public interface Item
    {
        void Bind(Actor actor);

        void Unbind(Actor actor);
    }
}
