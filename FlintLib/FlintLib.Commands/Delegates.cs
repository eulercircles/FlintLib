namespace FlintLib.Commands
{
    public delegate void Action();

    public delegate void Action<P>(P parameter);

    public delegate R Function<R>();

    public delegate R Function<R, P>(P parameter);
}
