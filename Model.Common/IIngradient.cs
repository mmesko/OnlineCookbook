using System;


namespace OnlineCookbook.Model.Common
{
    public interface IIngradient
    {
        int Id { get; set; }
        string IngradientName { get; set; }
    }
}