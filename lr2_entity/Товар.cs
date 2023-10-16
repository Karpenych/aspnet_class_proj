using System;
using System.Collections.Generic;

namespace lr2_entity;

public partial class Товар
{
    public int КодТовара { get; set; }

    public string Название { get; set; } = null!;

    public decimal ЦенаЗаЕд { get; set; }

    public string Тип { get; set; } = null!;

    public string Сорт { get; set; } = null!;

    public string ГородПроизв { get; set; } = null!;

    public string РасСчет { get; set; } = null!;

    public virtual ICollection<Сделка> Сделкаs { get; set; } = new List<Сделка>();
}
