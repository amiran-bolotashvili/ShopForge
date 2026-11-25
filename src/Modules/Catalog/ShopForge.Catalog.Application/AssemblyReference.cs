using System.Reflection;

namespace ShopForge.Catalog.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
