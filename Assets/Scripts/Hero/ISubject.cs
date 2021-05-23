public interface ISubject
{
    void Atach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
