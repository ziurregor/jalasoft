using System;
namespace Jalasoft.Pattern.Composite
{
    public interface IProductOperations
    {
        void Add(ProductBase gift);
        void Remove(ProductBase gift);
    }
}
