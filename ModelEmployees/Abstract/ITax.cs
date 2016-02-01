namespace ModelEmployees.Abstract
{
    public interface ITax
    {
        decimal ApplyTax(decimal salary);
        decimal GetTax(decimal salary);
    }
}
